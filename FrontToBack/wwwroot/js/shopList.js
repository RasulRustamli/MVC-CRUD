const previcon='<i class="fas fa-caret-right"></i>'
const nexticon='<i class="fas fa-caret-left"></i>'


$('.home-slider').owlCarousel({
    loop:true,
    margin:20,
    nav:true,
    dots:false,
    hover:false,
    navText:[nexticon,previcon],
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:4
        }
    }
})