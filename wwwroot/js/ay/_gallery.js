AY.Gallery = {
    Init: function () {
        $(".beforeAndAfter").twentytwenty();

        $(".slider-image").on("click", function () {
            AY.Gallery.changeImage($(this))
        });

        $(".slider").slick({
            dots: true,
            infinite: false,
            speed: 300,
            slidesToShow: 6,
            slidesToScroll: 6,
            responsive: [
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 4,
                        slidesToScroll: 4,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2
                    }
                }             
            ]
        });
    },

    changeImage: function (element) {
        $(".image-wrapper").removeClass("selected");
        var imgNum = element.attr("data-imgNum");
        $(".image-wrapper[data-imgNum='" + imgNum + "']").addClass("selected");
        console.log("Hello " + imgNum);
    }
}
