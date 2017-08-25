var text;
var total = 0;

$(document).ready(function () {
    
    var ids = getArrayCookies("FoodId");
    var names = getArrayCookies("FoodName");
    var prices = getArrayCookies("FoodPrice");
    var quantitys = getArrayCookies("FoodQuantity");
    if (ids) {
        var tbody, tr, td;
        text = "";
        total = 0;
        $("#tTable").empty();
        $('#tTable').append('<thead><th>ID</th><th class="thName">Ten Mon</th><th class="thPrice">Giá</th><th>Số lượng</th><th></th></thead>');
        tbody = $('<tbody/>');
        for (var i = 0; i < ids.length; i++) {
            text = text.concat(makeRow(i + 1, ids[i], names[i], quantitys[i], prices[i]));
            total = total + (parseInt(quantitys[i]) * parseInt(moneyToInt(prices[i])));
        }
        tbody.append(text);

        tr = $('<tr class="sumtr"/>');
        td = $('<td colspan="2">Tổng cộng</td>');
        tr.append(td);
        td = $('<td colspan="3">'+ total +'<span>&nbsp;&nbsp;VNĐ</span></td>');
        tr.append(td);
        $(tbody).append(tr);
        tr = $('<tr/>');
        tr.append('<td colspan="5"><button class="btn btn-success">Đặt giao hàng</button></td>');
        $(tbody).append(tr);

        $("#tTable").append(tbody);
    } else {
        $("#tTable").empty();
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
    $('.tbody').append("<p class='cartEmpty'>Ooppss... Chưa có gì trong giỏ hàng.</p>" +
        "<p class='cartEmpty'>Nhấn vào <a class='alert-link' href='MainPage'>đây</a> để quay lại đặt hàng</p>");
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
        "<td>" + price + "</td>" +
        //"<td>" + price + " x " + quantity + " = " + intToMoney(quantity * moneyToInt(price)) + "</td>" +
        "<td> <button class='btn-primary btn-minute' onclick='desc(\"#quan" + no + "\",\"" + id + "\")'>-</button>&nbsp;<b id='quan" + no + "'>"
        + quantity +
        "</b>&nbsp;<button class='btn-primary btn-plus' onclick='asc(\"#quan" + no + "\",\"" + id + "\")'>+</button></td>" +
        "<td><button class='btn btn- primary' onclick='deleteRow(" + no + ")'>X</button></td>" +
        "</tr>";
    return res;
}

//<td>
//    <button class="btn-primary btn-minute">-</button>
//    <b>10</b>
//    <button class="btn-primary btn-plus">+</button>
//</td>
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

function deleteRow(foodId) {
    //var id = parent.children("td:nth-child(2)").attr("id");
    var ids = getArrayCookies("FoodId");
    var names = getArrayCookies("FoodName");
    var prices = getArrayCookies("FoodPrice");
    var quantitys = getArrayCookies("FoodQuantity");
    var pos = getIdPos(foodId, ids);
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
    location.reload();
    //parent.find("a").tooltip('dispose');
    //parent.remove();
    //updateNo();
}

function updateNo() {
    var i = 1;
    $("tbody").children("tr").children("td:first-child").each(function() {
        $(this).text(i);
        i++;
    })
}

function desc(tagId, foodId) {
    var quan = parseInt($(tagId).text());
    if (quan > 1) {
        $(tagId).empty();
        $(tagId).append(quan - 1);

        var ids = getArrayCookies("FoodId");
        var quantitys = getArrayCookies("FoodQuantity");
        var pos = getIdPos(foodId, ids);
        quantitys[pos] = quan - 1;
        addArrayCookies("FoodQuantity", quantitys, 1);
    }
    if (quan == 1) {
        deleteRow(tagId.substring(4));
    }
}

function asc(tagId, foodId) {
    var quan = parseInt($(tagId).text());
    if (quan < 200) {
        $(tagId).empty();
        $(tagId).append(quan + 1);

        var ids = getArrayCookies("FoodId");
        var quantitys = getArrayCookies("FoodQuantity");
        var pos = getIdPos(foodId, ids);
        quantitys[pos] = quan + 1;
        addArrayCookies("FoodQuantity", quantitys, 1);
    }
}