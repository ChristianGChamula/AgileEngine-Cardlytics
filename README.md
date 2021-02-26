# AgileEngine-Cardlytics
technical interview evaluation: .Net C#

Imagine that you are involved in the development of a large file storage system. Special feature here is storing photos and images. We need to provide our users with the possibility to search stored images based on attribute fields.

http://localhost:57372/api/photo/search/${term}

Example
http://localhost:57372/api/photo/search/Tempting Mention

result
[
    {
        "id": "a24b5a478fefc4817bb4",
        "author": "Tempting Mention",
        "camera": "Polaroid 600",
        "tags": "#photography #whataview #wonderfullife #view ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/03 - WPIX_86.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/03 - WPIX_86.jpg"
    }
]

http://localhost:57372/api/photo/search/polaroid 600

[
    {
        "id": "d8b093f6ad76844e959d",
        "author": "Radiant Gold",
        "camera": "Polaroid 600",
        "tags": "#natureisbeautiful #photooftheday #whataview #today #photo ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/0015.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/0015.jpg"
    },
    {
        "id": "a24b5a478fefc4817bb4",
        "author": "Tempting Mention",
        "camera": "Polaroid 600",
        "tags": "#photography #whataview #wonderfullife #view ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/03 - WPIX_86.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/03 - WPIX_86.jpg"
    },
    {
        "id": "cd4bc65588b3e23bcd48",
        "author": "Ruddy Significance",
        "camera": "Polaroid 600",
        "tags": "#whataview #natureisbeautiful #wonderfulday ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/06 - WPIX_86.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/06 - WPIX_86.jpg"
    },
    {
        "id": "6ea013bc5f1d2b4dcc2a",
        "author": "Colorful Horse",
        "camera": "Polaroid 600",
        "tags": "#nature #beautifulday #whataview #photography #natureisbeautiful #photo ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/1206036519_72965090.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/1206036519_72965090.jpg"
    },
    {
        "id": "f1ef32bf4d067c6d4e66",
        "author": "Awesome Second",
        "camera": "Polaroid 600",
        "tags": "#wonderfullife #today #view #photooftheday #life #greatview #photo ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/1206036567_72965110.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/1206036567_72965110.jpg"
    },
    {
        "id": "810ffc2a2789272f27ca",
        "author": "Avaricious Door",
        "camera": "Polaroid 600",
        "tags": "#natureisbeautiful #today #view #wonderfullife #photography #photo #wonderfulday ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/35-1024.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/35-1024.jpg"
    },
    {
        "id": "957b5d94b7d5258dc026",
        "author": "Which Soft",
        "camera": "Polaroid 600",
        "tags": "#greatview #nature #today #wonderfullife #wonderfulday ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/5qpl91ethlrp654881z06uvo7zjx4i7k_6.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/5qpl91ethlrp654881z06uvo7zjx4i7k_6.jpg"
    },
    {
        "id": "d203d99033a15de3a77f",
        "author": "Muddy Weight",
        "camera": "Polaroid 600",
        "tags": "#nature #photo #life ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/7qti5y5etrl6anyg2tehym9fww4vfiov_2.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/7qti5y5etrl6anyg2tehym9fww4vfiov_2.jpg"
    },
    {
        "id": "9afb63a49bde68c93368",
        "author": "Ideal Green",
        "camera": "Polaroid 600",
        "tags": "#photography #photooftheday #greatview #life #wonderfulday #beauty #nature ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/837076.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/837076.jpg"
    },
    {
        "id": "6d9d14a48dcdfdcd9541",
        "author": "Cultivated Forever",
        "camera": "Polaroid 600",
        "tags": "#life ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/PEZAG58.JPG",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/PEZAG58.JPG"
    },
    {
        "id": "c6d52edc1c637402c7a4",
        "author": "Outlying Sing",
        "camera": "Polaroid 600",
        "tags": "#photo #beauty ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/PARK1.JPG",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/PARK1.JPG"
    },
    {
        "id": "f3995c28f84b7de44379",
        "author": "Chief Indication",
        "camera": "Polaroid 600",
        "tags": "#view #wonderfullife #photooftheday #nature #photo #life #beautifulday ",
        "cropped_picture": "http://interview.agileengine.com/pictures/cropped/ZWATER4.jpg",
        "full_picture": "http://interview.agileengine.com/pictures/full_size/ZWATER4.jpg"
    }
]
