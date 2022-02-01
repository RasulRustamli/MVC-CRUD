


$(document).on("keyup", "#site-search", function () {
    let input = $("#site-search").val().trim();
    $("##site-search li").slice(1).remove();

    if (search.lenght>0) {
        $ajax({
            url: "/product/search?search=" + search,
            type: "get",
            success: function (res) {
               // $("#search-list").append(res);
            }
        })
    }

})
// Section 2 Start
  document.getElementById("defaultOpen").click();
// Section 2 End

// Section 1 Start

  $("#slideHow").vegas({
    slides: [
        { src: "~/img/h3-slider-background.jpg" },
        { src: "~/img/h3-slider-background-2.jpg" },
        { src: "~/img/h3-slider-background-3.jpg" }
    ]
});
// Section 1 End

// Section 7 Start


let rightiicon=document.getElementsByClassName("icon-S7-2");
let leftiicon=document.getElementsByClassName("icon-S7-1")
$('.owl-Slider7').owlCarousel({
  loop:true,
  margin:10,
  nav:true,
  navText:[leftiicon,rightiicon],
  dots:false,
  responsive:{
      0:{
          items:1
      },
      600:{
          items:1
      },
      1000:{
          items:1
      }
  }
})

// Section 7 End

$(document).ready(function () {
    let count = $("#count").val();
    let skip = 8;
    $(document).on("click", "#loadMore", function () {
        
        $ajax({

            url: "/product/LoadMore?skip=" + skip,
            method: "get",
            success: function (res) {
                //for (var item of res) {
                //    console.log(item)
                //    let diving = $("<div>").addClass("img");
                //    let link = $("<a>");
                //    let img = $("<img>").addClass("img-fluid").attr("scr", "/img/" + item.imageUrl)
                //    link.append(img);
                //    diving.append(link);


                //    let divtitle = $("<div>").addClass("title mt-3");
                //    let h6 = $("<h6>").text(item.title);
                //    divtitle.append(h6)
                //    let divprice = $("<div>").addClass("price");
                //    let spanaddcart = $("<span>").addClass("text-black-50").text("Add to cart")
                //    let spanspice = $("<span>").addClass("text-black-50").text(item.price)
                //    divprice.append(spanaddcart,spanprice);

                //    let divproduct = $("<div>").addClass("product.item text-center ").attr('data-id',"lorem");
                //    divproduct.append(divimg, divtitle, divprice);
                //    let divcol = $("<div>").addClass("col-sm-6 col-md-4 col-lg-3 mt-3")
                //    divcol.append(divproduct);
                 $("#productrow").append(divcol)

                   
                    
                //}
            }
        })
        skip += 8;
        if (skip >= count) {
            $("#loadMore").remove();
        }
    });
    
})
