/*jslint browser: true*/
/*global $, jQuery, alert, consolse*/
/*jslint devel: true */

//$(window).scroll(function () {
//    var scrollPos = $(document).scrollTop();
//    if ($(window).width() > 770) {
//        if (scrollPos > 30) {
//            $(".theader").switchClass("theader", "theader-collapse", 500);
//            $(".theadContain").switchClass("theadContain", "theadContain-collapse", 500);
//            $(".theadLine").switchClass("theadLine", "theadLine-collapse", 500);
//            $(".theadLogo").switchClass("theadLogo", "theadLogo-collapse", 500);
//            $(".tmainMenu").switchClass("tmainMenu", "tmainMenu-collapse", 500);
//            $(".tmainMenua").switchClass("tmainMenua", "tmainMenua-collapse", 500);
//            $(".li:hover").switchClass("li:hover", "li-collapse:hover", 500);
//            $(".theadLine").switchClass("theadLine", "theadLine-collapse", 500);
//        }
//        if (scrollPos <= 30) {
//            $(".theader-collapse").switchClass("theader-collapse", "theader", 500);
//            $(".theadContain-collapse").switchClass("theadContain-collapse", "theadContain", 500);
//            $(".theadLine-collapse").switchClass("theadLine-collapse", "theadLine", 500);
//            $(".theadLogo-collapse").switchClass("theadLogo-collapse", "theadLogo", 500);
//            $(".tmainMenu-collapse").switchClass("tmainMenu-collapse", "tmainMenu", 500);
//            $(".tmainMenua-collapse").switchClass("tmainMenua-collapse", "tmainMenua", 500);
//            $(".li-collapse:hover").switchClass("li-collapse:hover", "li:hover", 500);
//            $(".theadLine-collapse").switchClass("theadLine-collapse", "theadLine", 500);
//        }
//    }
//});

//function getEventTarget(e) {
//    e = e || window.event;
//    return e.target || e.srcElement; 
//}
//
//var tmp;
//var divSideNav = document.getElementById('divSideNav');
//divSideNav.onclick = function(event) {
//    var target = getEventTarget(event);
//    tmp = target;
////    alert(target);
//};

function updatePopUp(idMonAn) {
//    $.ajax({
//        
//    });
    $('#myModalLabel').empty();
    $('#myModalLabel').append('Mon an thu ' + idMonAn);
}

function addAFood()
{
    var foodId = $('#idMonAn').val();
    var foodName = $('#tenMonAn').val();
    var foodPrice = $('#giaMonAn').val();
    var quantitys = $('#idSoluong').val();
    
    console.log(foodId + foodName + foodPrice + quantitys);
    addFood(foodId, foodName, foodPrice, quantitys);
}