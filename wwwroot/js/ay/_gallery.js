AY.Gallery = {
    Init: function () {    

        $(".slider-image").on("click", function () {
            AY.Gallery.changeImage($(this))
        });

        $(".slider").slick({
            dots: false,
            infinite: false,
            speed: 200,
            slidesToShow: 6,
            slidesToScroll: 1,
            responsive: [
                {
                    breakpoint: 992,
                    settings: {
                        slidesToShow: 5,
                        slidesToScroll: 1                                         
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 4,
                        slidesToScroll: 1
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 1,
                        arrows: false
                    }
                }             
            ]
        });
    },

    changeImage: function (element) {
        $(".image-wrapper").removeClass("selected");
        $(".slider-image").removeClass("selected");
        var imgNum = element.attr("data-imgNum");
        $(".image-wrapper[data-imgNum='" + imgNum + "']").addClass("selected");
        element.addClass("selected");

        $(".beforeAndAfter").twentytwenty();
    }
}
