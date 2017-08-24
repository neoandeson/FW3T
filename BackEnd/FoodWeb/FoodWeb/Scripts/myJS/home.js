/*jslint browser: true*/
/*global $, jQuery, alert, consolse*/
/*jslint devel: true */

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
var loadedProduct = [];
var imgarr = [];
var commentarr = [];

function updatePopUp(idMonAn, tenMonAn, artical, rating, discount, price) {
//    $.ajax({
//        
    //    });
    $('#myModalLabel').empty();
    $('#myModalLabel').append(tenMonAn);
    var div;
    $('#DetailsPane').empty();
    div = $('<div class="control-group DetailsPane"/>');
    div.append('<label class="control-label"><h3>' + tenMonAn + '</h3></label >');
    div.append('<h4>' + artical + '</h4>');

    for (var i = 0; i < imgarr.length; i++) {
        if (imgarr[i].Id == idMonAn) {
            for (var j = 0; j < imgarr[i].img.length; j++) {
                div.append('<img src="' + imgarr[i].img[j] + '"/>');
            }
        }
    }
    $('#DetailsPane').append(div);

    div = $('<div class="tPopUp_Rating"/>');
    $('#CommentPane').empty();
    $('#CommentPane').append('Bình chọn: ');
    for (var i = 0; i < rating; i++) {
        div.append('<b class="glyphicon glyphicon-star"></b>');
    }
    $('#CommentPane').append(div);
    $('#CommentPane').append('<br/>Bình luận: <br />');
    for (var i = 0; i < commentarr.length; i++) {
        if (commentarr[i].Id == idMonAn) {
            for (var j = 0; j < commentarr[i].cmt.length; j++) {
                $('#CommentPane').append('<h5>' + commentarr[i].cmt[j] + '</h5>');
            }
        }
    }
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

$(document).ready(getFoods('/api/Product/GetProducts', '#rows'));
var tmp;

function getFoods(url, resultTagId) {
    $.ajax({
        async: false,
        url: url,
        method: "GET",
        success: function (data) {
            tmp = data;
            var number;
            //$(resultTagId).empty();
            var div1, div2, div3, div4, div5, div6, div7;
            

            for (var i = 0; i < data.length; i = i + 3) {
                div1 = $('<div class="row"/>');//row
                for (var j = i; j < i + 3; j++) {
                    if (data[j] == null) {
                        break;
                    }
                    number = data[j].Id;
                    //alert(data[j].Id + ' ' + data[j].Name);
                    if (loadedProduct.indexOf(number) < 0) {
                        imgarr.push({ Id: data[j].Id, img: data[j].imgs});
                        commentarr.push({ Id: data[j].Id, cmt: data[j].Comment});
                        loadedProduct.push(number);
                    }
                    div2 = $('<div class="col-lg-3 col-md-3 col-sm-3 tBlock" data-toggle="modal" data-target="#myModal" onclick="updatePopUp('
                        + data[j].Id + ',\'' + data[j].Name + '\',\'' + data[j].Artical + '\',' + data[j].Rating + ','
                        + data[j].Discount + ',' + data[j].Price +')"/>');//tBlock
                    div3 = $('<div class="tBlockImg"/>');//tBlock Img
                    div3.append('<img src="' + data[j].imgs[0] +'">');
                    div4 = $('<div class="tBlockDescription"/>');//tBlock Description
                    div4.append('<b>' + data[j].Name + '</b>');
                    div4.append('<p class="tBlockDescriptionp">' + data[j].Description + '</p>');
                    div5 = $('<div class="tBlockFunction"/>');//tBlock Function
                    div6 = $('<div class="tBlockFunction_Rating"/>');//tBlock F_Rating
                    for (var k = 0; k < data[j].Rating; k++) {
                        div6.append('<b class="glyphicon glyphicon-star"></b>');
                    }
                    div7 = $('<div class="tBlockFunction_Function"/>');//tBlock F_Function
                    div7.append('<h4>Giảm ' + data[j].Discount + '%</h4>');
                    div5.append(div6);
                    div5.append(div7);

                    div2.append(div3);
                    div2.append(div4);
                    div2.append(div5);
                    div1.append(div2);
                    $(resultTagId).append(div1);
                }
            }

            //for (var i = 0; i < data.length; i++) {
                
            //    tr = $('<tr/>');
            //    tr.append('<td>' + data[i].mssv + '</td>');
            //    tr.append("<td><input id='tenSVTag" + data[i].id + "' type='text' value='" + data[i].hoTen + "'> </td>");
            //    tr.append('<td>' + convertDatetoString(data[i].dob) + '</td>');
            //    tr.append("<td><input type=\"button\" value='XemKhoa' onclick=\"getDataSinhVienAjax('#result'," + data[i].id + ")\"></td>");
            //    tr.append("<td><input type=\"button\" value='XemNganh' onclick=\"getDataSinhVienAjax('#result'," + data[i].id + ")\"></td>");
            //    tr.append("<td><input type=\"button\" value='Update' onclick=\"updateData('#tenSVTag" + data[i].id + "'," + data[i].id + ")\"></td>");
            //    tr.append("<td><input type=\"button\" value='Xoa' onclick=\"deleteSinhVien(" + data[i].id + ")\"></td>");
            //    tbody.append(tr);
            //}
            //$(resultTagId).append(div1);
        }
    });
}