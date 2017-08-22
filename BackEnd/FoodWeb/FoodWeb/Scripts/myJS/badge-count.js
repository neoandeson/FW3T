$(document).ready(function() {
    var count = getArrayCookies("FoodId");
    if (count) {
        $("#badge-count").text(count.length);
        $("#badge-count").removeClass("invisible");
    } else {
        $("#badge-count").addClass("invisible");
    }
})