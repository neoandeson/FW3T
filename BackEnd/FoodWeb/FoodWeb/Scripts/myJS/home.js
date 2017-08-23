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

function updatePopUp(idMonAn, tenMonAn) {
//    $.ajax({
//        
    //    });

    $('#idMonAn').empty();
    $('#idMonAn').append(idMonAn);
    $('#myModalLabel').empty();
    $('#myModalLabel').append(tenMonAn);
    $('#tenMonAnh3').empty();
    $('#tenMonAnh3').append(tenMonAn);
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
            //$(resultTagId).empty();
            var div1, div2, div3, div4, div5, div6, div7;    
            div1 = $('<div class="row"/>');//row

            for (var i = 0; i < data.length; i = i + 3) {
                for (var j = i; j < i + 3; j++) {
                    if (data[j] == null) {
                        break;
                    }
                    //alert(data[j].Id + ' ' + data[j].Name);
                    div2 = $('<div class="col-lg-3 col-md-3 col-sm-3 tBlock" data-toggle="modal" data-target="#myModal" onclick="updatePopUp(' + data[j].Id + ',\'' + data[j].Name + '\')"/>');//tBlock
                    div3 = $('<div class="tBlockImg"/>');//tBlock Img
                    div3.append('<img src="https://unsplash.it/300/200">');
                    div4 = $('<div class="tBlockDescription"/>');//tBlock Description
                    div4.append('<b>' + data[j].Name + '</b>');
                    div4.append('<p>-3 col-sm-3 tBlock" data-toggle="modal" data-target="#myModal" onclick= "updatePopUp ( asd asd qwe dsfs -3 col-sm-3 tBlock" data-toggle="modal" data-target="#myModal" onclick="updatePopUp(</p>');
                    div5 = $('<div class="tBlockFunction"/>');//tBlock Function
                    div6 = $('<div class="tBlockFunction_Rating"/>');//tBlock F_Rating
                    //for(data.rating)
                    div6.append('<b class="glyphicon glyphicon-star"></b>');
                    div7 = $('<div class="tBlockFunction_Function"/>');//tBlock F_Function
                    div7.append('<h4>Giam 30%</h4>');
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