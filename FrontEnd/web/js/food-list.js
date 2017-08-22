$(document).ready(function() {
    makeAnimation();
    enableButton();
})

// animation
function makeAnimation() {
    $(".food").children(".row").mouseenter(function() {
        var e = $(this);
        e.addClass("shadow-pulse");
        e.on('animationend', function() {
            e.removeClass("shadow-pulse");
            e.removeClass('img-raised-less');
            e.addClass('img-raised');
        })
    })
    $(".food").children(".row").mouseleave(function() {
        var e = $(this);
        e.addClass("invert-shadow-pulse");
        e.removeClass('img-raised');
        e.on('animationend', function() {
            e.removeClass("invert-shadow-pulse");
            e.removeClass('img-raised');
            e.addClass('img-raised-less');
        })
    })
}

// buying
function enableButton() {
    $('.food-delivery-time').each(function() {
        var e = $(this);
        var text = e.text().trim();
        var min = text.split(" ")[0];
        if (min < 15) {
            e.css("color", "green");
        } else if (min < 30) {
            e.css("color", "orange");
        } else {
            e.css("color", "red");
        }
    })

    $("[id=inc]").on('click', function() {
        var quantity = $(this).siblings('.option-quantity');
        var tmp = parseInt(quantity.text()) + 1;
        quantity.text(tmp);
    })

    $("[id=dec]").on('click', function() {
        var quantity = $(this).siblings('.option-quantity');
        var tmp = parseInt(quantity.text()) - 1;
        if (tmp <= 0) tmp = 1;
        quantity.text(tmp);
    })

    $("[id=add]").on('click', function() {
        var foodName = $(this).parents(".modal-body").find(".option-title").text().trim();
        var price = $(this).parents(".modal-body").find("option:selected").text().trim();
        var id = $(this).parents(".modal-body").find(".option-id").text().trim();
        var quantity = $(this).siblings('.option-quantity').text().trim();
        addFood(id, foodName, price, quantity);
    })
}

function inc() {
    var quantity = $('.option-quantity');
    var tmp = parseInt(quantity.text()) + 1;
    quantity.text(tmp);
}

function dec() {
    var quantity = $('.option-quantity');
    var tmp = parseInt(quantity.text()) - 1;
    if (tmp <= 0) tmp = 1;
    quantity.text(tmp);
}

function add() {
    var foodName = $(".option-title").text().trim();
    var price = $("[id=option-price]").find("option:selected").text().trim();
    var id = $(".option-id").text().trim();
    var quantity = $('.option-quantity').text().trim();
    addFood(id, foodName, price, quantity);
}

function getIdPos(id, idList) {
    if (idList == null) {
        return -1;
    }
    for (var i = 0; i < idList.length; i++) {
        if (idList[i] == id) return i;
    }
    return -1;
}

function addFood(id, name, price, quantity) {
    // FoodId, FoodName, FoodPrice, FoodQuantity
    var ids = getArrayCookies("FoodId");
    var names = getArrayCookies("FoodName");
    var prices = getArrayCookies("FoodPrice");
    var quantitys = getArrayCookies("FoodQuantity");
    var pos = getIdPos(id, ids);
    if (pos == -1) {
        if (ids != null) {
            ids[ids.length] = id;
            names[names.length] = name;
            prices[prices.length] = price;
            quantitys[quantitys.length] = quantity;
        } else {
            ids = [id];
            names = [name];
            prices = [price];
            quantitys = [quantity];
        }
    } else {
        quantitys[pos] = (parseInt(quantitys[pos]) + parseInt(quantity)).toString();
    }
    addArrayCookies("FoodId", ids, 1);
    addArrayCookies("FoodName", names, 1);
    addArrayCookies("FoodPrice", prices, 1);
    addArrayCookies("FoodQuantity", quantitys, 1);
    $("#badge-count").text(ids.length);
    $("#badge-count").removeClass("invisible");
}