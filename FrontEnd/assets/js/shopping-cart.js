$(document).ready(function() {

    var ids = getArrayCookies("FoodId");
    var names = getArrayCookies("FoodName");
    var prices = getArrayCookies("FoodPrice");
    var quantitys = getArrayCookies("FoodQuantity");
    if (ids) {
        var text = "";
        for (var i = 0; i < ids.length; i++) {
            text = text.concat(makeRow(i + 1, ids[i], names[i], quantitys[i], prices[i]));
        }
        $("tbody").html(text);
    } else {
        emptyCart();
        // var text = "";
        // for (var i = 0; i < 10; i++) {
        //     text = text.concat(makeRow(i + 1, "f00".concat(i.toString()), "Cơm".concat(i.toString()), 11, "19.000VNĐ"));
        // }
        // $("tbody").html(text);
    }
    $("[id=delete]").click(function() {
        deleteRow($(this).parents("tr"));
    })
    $('[data-toggle="tooltip"]').tooltip();
})

function emptyCart() {
    var obj = $(".section").find(".container");
    obj.addClass("text-center");
    obj.html("<p>Ooppss... Chưa có gì trong giỏ hàng.</p>" +
        "<p>Nhấn vào <a class='alert-link' href='#'>đây</a> để quay lại menu</p>");
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

function makeRow(no, id, name, quantity, price) {
    var res = "<tr>" +
        "<td>" + no + "</td>" +
        "<td id='" + id + "'>" + name + "</td>" +
        "<td>" + quantity + "</td>" +
        "<td>" + price + " x " + quantity + " = " + intToMoney(quantity * moneyToInt(price)) + "</td>" +
        "<td><a class='alert-link' id='delete' data-toggle='tooltip' data-placement='top' title='Hủy'><i class='now-ui-icons ui-1_simple-remove'></i></a></td>" +
        "</tr>";
    return res;
}

function moneyToInt(money) {
    money = money.trim();
    var res = 0;
    for (var i = 0; i < money.length; i++) {
        var c = money.charAt(i);
        if (c >= '0' && c <= 9) {
            res = res * 10 + parseInt(c);
        }
    }
    return res;
}

function intToMoney(int) {
    var money = "VNĐ";
    var c = 0;
    int = int.toString();
    for (var i = int.length - 1; i >= 0; i--) {
        if (c % 3 == 0 && c != 0) {
            money = ".".concat(money);
        }
        c++;
        money = int.charAt(i).concat(money);
    }
    return money;
}

function deleteRow(parent) {
    var id = parent.children("td:nth-child(2)").attr("id");
    var ids = getArrayCookies("FoodId");
    var names = getArrayCookies("FoodName");
    var prices = getArrayCookies("FoodPrice");
    var quantitys = getArrayCookies("FoodQuantity");
    var pos = getIdPos(id, ids);
    ids.splice(pos, 1);
    names.splice(pos, 1);
    quantitys.splice(pos, 1);
    prices.splice(pos, 1);
    if (ids.length > 0) {
        addArrayCookies("FoodId", ids, 1);
        addArrayCookies("FoodName", names, 1);
        addArrayCookies("FoodPrice", prices, 1);
        addArrayCookies("FoodQuantity", quantitys, 1);
        $("#badge-count").text(ids.length);
        $("#badge-count").removeClass("invisible");
    } else {
        addArrayCookies("FoodId", "", -1);
        addArrayCookies("FoodName", "", -1);
        addArrayCookies("FoodPrice", "", -1);
        addArrayCookies("FoodQuantity", "", -1);
        $("#badge-count").addClass("invisible");
        emptyCart();
    }
    parent.find("a").tooltip('dispose');
    parent.remove();
    updateNo();
}

function updateNo() {
    var i = 1;
    $("tbody").children("tr").children("td:first-child").each(function() {
        $(this).text(i);
        i++;
    })
}