$(".owl-right-top").owlCarousel({
    loop: true,
    autoplay: true,
    autoplayHoverPause: true,
    autoplayTimeout: 6000,
    items: 1,
    dots: false,
    nav: false,
    autoplaySpeed: 2000

});

$(".owl-right-bottom").owlCarousel({
    loop: true,
    autoplay: true,
    autoplayHoverPause: true,
    autoplayTimeout: 7000,
    items: 1,
    dots: false,
    autoplaySpeed: 2000,
});

$(".publications").owlCarousel({
    loop: true,
    autoplay: true,
    autoplayHoverPause: true,
    autoplayTimeout: 6000,
    items: 4,
    margin: 10,
    dots: false,
    nav: false,
    autoplaySpeed: 2000

});

$(".owl-elections").owlCarousel({
    loop: true,
    autoplay: true,
    autoplayHoverPause: true,
    autoplayTimeout: 4500,
    items: 1,
    margin: 5,
    dots: true,
    nav: false,
    autoplaySpeed: 2000

});

$(".owl-video").owlCarousel({
    loop: true,
    autoplay: true,
    autoplayHoverPause: true,
    autoplayTimeout: 4500,
    responsive: {
        0: {
            items: 1,
        },
        768: {
            items: 4,
          
        }
      },
    margin: 5,
    dots: false,
    nav: false,
    autoplaySpeed: 2000

});

$(".owl-partners").owlCarousel({
    loop: true,
    autoplay: true,
    autoplayHoverPause: true,
    autoplayTimeout: 4500,
    responsive: {
        0: {
            items: 1,
        },
        768: {
            items: 5,
          
        }
    },
    margin: 5,
    dots: false,
    nav: false,
    autoplaySpeed: 2000

});



$(document).ready(function () {

      $("#latestpostlist").niceScroll({
            cursorcolor: "#dc3545",
            cursorwidth: "10px",
            cursoropacitymax: 0.7
      });

   

});


function addHeadLinksToNav() {
    let bodyWidth = width = document.body.offsetWidth;
    if (bodyWidth > 1000) {

        let headerLinks = document.getElementById("header-links");
        document.getElementById("header-top-row").appendChild();
      
    }
    if (bodyWidth <= 768) {
        document.getElementById("nav-list").appendChild(document.getElementById("header-links"));
      
    }
   
}


addHeadLinksToNav();
window.onresize = addHeadLinksToNav;