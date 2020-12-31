AY.SlideShow = {
    slideCount: 0,
    slidePosition: 0,
    sildeTimer: 8000,
    slideFadeTime: 1000,

    Init: function () {
        AY.SlideShow.slideCount = $(".home-slide-show").length;
        AY.SlideShow.slidePosition = AY.SlideShow.slideCount;
        setTimeout("AY.SlideShow.Step()", AY.SlideShow.sildeTimer);
    },
    Step: function () {
        var lastSlide = AY.SlideShow.slidePosition;
        if (lastSlide === 1) {
            AY.SlideShow.slidePosition = AY.SlideShow.slideCount;
        } else {           
            AY.SlideShow.slidePosition = lastSlide - 1;
        }
        $(".home-slide-show:nth-child(" + AY.SlideShow.slidePosition + ")").fadeIn(AY.SlideShow.slideFadeTime, function () {
            $(".home-slide-show:nth-child(" + lastSlide + ")").fadeOut(AY.SlideShow.slideFadeTime);
        });
        setTimeout("AY.SlideShow.Step()", AY.SlideShow.sildeTimer);
    }
}
