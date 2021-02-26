using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace AgileEngineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private string _token;
        private readonly IMemoryCache _cache;
        public PhotoController(IMemoryCache memoryCache)
        {
            _token = getToken();
            _cache = memoryCache;

        }
        public static class RequestConstants
        {
            public const string BaseUrl = "http://interview.agileengine.com";
            public const string Auth = "/auth";
            public const string UserAgent = "User-Agent";
            public const string UserAgentValue = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
        }

        private string handlerHttpClientGetRequest(string endpoint, string token)
        {

            var url = RequestConstants.BaseUrl + "/" + endpoint;
            using (var httpClient = new HttpClient())
            {
                //var token = getToken();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              
                var response = "";
                
                var result = httpClient.GetAsync(new Uri(url), HttpCompletionOption.ResponseContentRead).Result;
                if(result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _token = getToken();
                     
                    handlerHttpClientGetRequest(endpoint, _token);
                }
                response = result.Content.ReadAsStringAsync().Result;
                
                

                //var response = result.Content.ReadAsStringAsync().Result;
                return response;
            }
        }

        [HttpGet]
        [Route("token")]
        public string authenticate()
        {
           

           
            var url = RequestConstants.BaseUrl + RequestConstants.Auth;
            using (var httpClient = new HttpClient())
            {
               
                var stringContent = new StringContent("{ \"apiKey\": \"23567b218376f79d9415\"}", UnicodeEncoding.UTF8, "application/json");
                var result = httpClient.PostAsync(new Uri(url), stringContent).Result;
                
                var response = result.Content.ReadAsStringAsync().Result;
                return response;
            }

            
        }

        [HttpGet]
        [Route("photos")]
        public string getPhotos(int page = 0)
        {
            return JsonConvert.SerializeObject(GetPhotos(page));
        }

        public Photo GetPhoto(string id)
        {
            //var token = getToken();
            var result = handlerHttpClientGetRequest("images/" + id, _token);
           

            Photo photo = JsonConvert.DeserializeObject<Photo>(result);

            return photo;



        }


        public PhotoList GetPhotos(int page = 0)
        {
            var endpoint = (page > 0 ? "images?page=" + page : "images");
            
            var result = handlerHttpClientGetRequest(endpoint, _token);

            PhotoList photoList = JsonConvert.DeserializeObject<PhotoList>(result);

            return photoList;
        }

        public List<Photo> GetAllPhotos()
        {
            
            List<Photo> cacheEntry;
            if (!_cache.TryGetValue("ALL-CACHED-PHOTOS", out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = getAllPhotFromServiceApi();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60*10));

                // Save data in cache.
                _cache.Set("ALL-CACHED-PHOTOS", cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public bool IsAuthenticate()
        {
            var token = authenticate();
            Session session = JsonConvert.DeserializeObject<Session>(token);

            return session.auth;
        }

        private List<Photo> getAllPhotFromServiceApi()
        {
            var allPhotos = new List<Photo>();
            //get firt Image list
            var imageQuantity = 0;
            var imageList = GetPhotos();
            imageQuantity = imageList.pictures.Count;
            //get total page
            var totalPages = imageList.pageCount;
            var hasMore = imageList.hasMore;
            //loop all pages
            var nextPage = 1;
            do
            {


                Parallel.ForEach(imageList.pictures, img =>
                {
                    //get the information details by photo
                    var photoInfo = GetPhoto(img.id);
                    //add to a collection
                    allPhotos.Add(photoInfo);
                });

                //store the complete collection in cache 


                nextPage++;
                imageList = GetPhotos(nextPage);
                hasMore = imageList.hasMore;

            } while (hasMore);

            return allPhotos;
        }
        [HttpGet]
        [Route("search/{term}")]
        public IActionResult searchPhotos(string term)
        {
            var photoListResult = GetAllPhotos();

            var findWord = term.ToLower();
            var foundPhotosList = photoListResult.FindAll(img => img.author.ToLower().Contains(findWord) ||
                                                                (img.camera != null ? img.camera.ToLower().Contains(findWord) : false) ||
                                                                img.tags.ToLower().Contains(findWord));


            //store the complete collection in cache 

            return Ok(foundPhotosList);
        }

        public string getToken()
        {

            var token = authenticate();
            Session session = JsonConvert.DeserializeObject<Session>(token);

            return session.token;
        }


    }

    public class Session
    {
        public bool auth { get; set; }
        public string token { get; set; }
    }

    public class PhotoItem
    {
        public string id { get; set; }
        public string cropped_picture { get; set; }
    }
    public class Photo
    {
        /*
            "id": "a24b5a478fefc4817bb4",
            "author": "Tempting Mention",
            "camera": "Polaroid 600",
            "tags": "#photography #whataview #wonderfullife #view ",
            "cropped_picture": "http://interview.agileengine.com/pictures/cropped/03 - WPIX_86.jpg",
            "full_picture": "http://interview.agileengine.com/pictures/full_size/03 - WPIX_86.jpg"
         */

        public string id { get; set; }
        public string author { get; set; }
        public string camera { get; set; }
        public string tags { get; set; }
        public string cropped_picture { get; set; }
        public string full_picture { get; set; }

    }



    public class PhotoList
    {
        public List<PhotoItem> pictures { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
        public bool hasMore { get; set; }

    }
}
