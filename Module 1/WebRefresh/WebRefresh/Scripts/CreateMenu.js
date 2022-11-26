function Start() {
    $("#header").load("Layout/Header.html");
    $("#footer").load("../../Webpages/Layout/Footer.html");

    var CurrentPage;

    try { CurrentPage = document.location.href.match(/[^\/]+$/)[0]; }
    catch { CurrentPage = "index.html"; }
    finally {
        setTimeout(function () {
            PageLoadTimeOut(CurrentPage);
        }, 200);
    }
}

function PageLoadTimeOut(CurrentPageInfo) {
    $("header a").each($(this).removeClass("VisitPage"));

    $("header").find('a').each(function () {
        if ($(this).attr('href') == CurrentPageInfo)
            $(this).addClass("VisitPage");
    });
}