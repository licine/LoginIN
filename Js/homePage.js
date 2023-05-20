$(".first_nav > li").mouseenter(function () {
    $(this).children("ul").fadeIn(100);
    //$(this).addClass("navShow");
});

$(".first_nav > li").mouseleave(function () {
    $(this).children("ul").fadeOut(100);
    //$(this).removeClass("navShow");
});

