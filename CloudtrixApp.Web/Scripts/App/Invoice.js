﻿
var currentItemPrice;
$(document).ready(function () {
    $('.mydatepicker').datepicker({ format: 'dd/mm/yyyy' });
    $.ajax({
        type: "GET", url: "/Admin/GetSupplier",
        datatype: "Json",
        success: function (data) {
            $.each(data, function (index, value) {
                $('#Supplier').append('<option value="' + value.Id + '">' + value.Name + '</option>')
            })
        }
    });
    $.ajax({
        type: "GET", url: "/Admin/GetCustomer",
        datatype: "Json",
        success: function (data) {
            $.each(data, function (index, value) {
                $('#Customer').append('<option value="' + value.Id + '">' + value.Name + '</option>')
            })
        }
    });
    $.ajax({
        type: "GET", url: "/Admin/GetCategories", datatype: "Json", success: function (data) {
            $.each(data, function (index, value) {
                $('#SCategory').append('<option value="' + value.Id + '">' + value.Name + '</option>')
            })
        }
    });
    $('#Customer').change(function () {
        $('#Project').empty();
        $.ajax({
            type: "GET", url: "/Admin/GetProjectByCustomer",
            datatype: "Json",
            data: { customerId: $('#Customer').val() },
            success: function (data) {
                $.each(data, function (index, value) {
                    $('#Project').append('<option value="' + value.Id + '">' + value.ProjectName + '</option>')
                });
                LoadProjectDetails($("#Project option:selected").val())
            }
        })
    });
    $('#SCategory').change(function () {
        $('#SMedicine').empty();
        $.ajax({
            type: "GET", url: "/Admin/GetStockMedicinesByCategory",
            datatype: "Json",
            data: { categoryId: $('#SCategory').val() },
            success: function (data) {
                $.each(data, function (index, value) {
                    $('#SMedicine').append('<option value="' + value.MedicineId + '">' + value.MedicineModel.Name +
                      '(' + value.MedicineModel.BatchNo + ')' + '</option>')
                }); LoadStockMedicineDetails($("#SMedicine option:selected").val())
            }
        })
    });
    $.ajax({
        type: "GET", url: "/Admin/GetProjectByCustomer",
        datatype: "Json",
        success: function (data) {
            $.each(data, function (index, value) {
                $('#Project').append('<option value="' + value.Id + '">' + value.Name + '</option>')
            })
        }
    });
    $('#Project').change(function ()
    { LoadProjectDetails($("#Project option:selected").val()); blankme("Project") });
    $("#Quantity").change(function () { blankme("Quantity") });

    $("#addToList").click(function (e) {
        e.preventDefault(); if (add_validation()) {
            var productId = $("#Description").val(),
                productName = $("#Description").text(),
                rate = $("#Rate").val(),
                quantity = $("#Quantity").val(),
                detailsTableBody = $("#detailsTable tbody");
            var productItem = '<tr> <td> ' + productId + ' </td> + <td>' +
                productName + '</td><td>' + rate.toFixed(2) + '</td><td>' +
                quantity + '</td><td class="amount">' + (parseFloat(rate) * parseInt(quantity)).toFixed(2)
                + '</td><td><a data-itemId="0" href="#" class="deleteItem"><i class="fa fa-trash"></i></a></td></tr>';
            detailsTableBody.append(productItem); calculateSum(); $("#Quantity").val(''); blankme("SubTotal"); blankme("GrandTotal")
        }
    });
    $("#BtnSave").click(function (e) {
        e.preventDefault();
        if (submitValidation()) {
            var orderArr = [];
            orderArr.length = 0; $.each($("#detailsTable tbody tr"),
                function () {
                    orderArr.push({
                        MedicineId: parseInt($(this).find('td:eq(0)').html()),
                        MedicineName: $(this).find('td:eq(1)').html(), Price: parseFloat($(this).find('td:eq(2)').html()),
                        Quantity: parseInt($(this).find('td:eq(3)').html()),
                        Amount: parseFloat($(this).find('td:eq(4)').html()),
                    })
                });
            var data = JSON.stringify({
                SupplierId: $("#Supplier").val(),
                PurchaseCode: $("#Code").val(),
                PurchaseDate: $("#Date").val(), PaymentMethod: $("#Payment").val(),
                Total: parseFloat($("#SubTotal").text()), Notes: $("#Notes").val(),
                Status: $("#PurchaseStatus").val(), Discount: parseFloat($('#Discount').val()).toFixed(2),
                GrandTotal: parseFloat($('#GrandTotal').text()).toFixed(2), Items: orderArr
            });
            console.log(data); $.when(saveOrder(data)).then(function (response) {
                console.log(response);
                toastr.success(response.message); location.href = "/Admin/PurchaseList"
            }).fail(function (err) { toastr.error(response.message) })
        }
    });
    $("#BtnUpdate").click(function (e) {
        e.preventDefault(); if (submitValidation()) {
            var orderArr = [];
            orderArr.length = 0; $.each($("#detailsTable tbody tr"),
                function () {
                    orderArr.push({
                        MedicineId: parseInt($(this).find('td:eq(0)').html()),
                        MedicineName: $(this).find('td:eq(1)').html(), Price: parseFloat($(this).find('td:eq(2)').html()),
                        Quantity: parseInt($(this).find('td:eq(3)').html()), Amount: parseFloat($(this).find('td:eq(4)').html()),
                    })
                });
            var data = JSON.stringify({
                Id: $("#BtnUpdate").attr("data-purchase-id"),
                SupplierId: $("#Supplier").val(), PurchaseCode: $("#Code").val(),
                PurchaseDate: $("#Date").val(), PaymentMethod: $("#Payment").val(),
                Total: parseFloat($("#SubTotal").text()), Notes: $("#Notes").val(),
                Status: $("#PurchaseStatus").val(), Discount: parseFloat($('#Discount').val()).toFixed(2),
                GrandTotal: parseFloat($('#GrandTotal').text()).toFixed(2), Items: orderArr
            });
            console.log(data);
            $.when(UpdateOrder(data)).then(function (response) {
                console.log(response); toastr.success(response.message);
                location.href = "/Admin/PurchaseList"
            }).fail(function (err) { toastr.error(response.message) })
        }
    });
    function saveOrder(data) {
        return $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: "/Admin/Purchase",
            data: data
        })
    }
    function UpdateOrder(data) {
        return $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: "/Admin/UpdatePurchase",
            data: data
        })
    }
    $(document).on('click', 'a.deleteItem', function (e) {
        e.preventDefault();
        var $self = $(this); $(this).parents('tr').css("background-color", "#1f306f").fadeOut(800, function () {
            $(this).remove();
            calculateSum(); blankme("SubTotal")
        })
    })
});
function LoadMedicineDetails(id) {
    if (id == "") {
        var details = $('#medicineDetails').html(``); return
    }
    $.ajax({
        type: "GET",
        url: "/Admin/GetMedicinesById",
        datatype: "Json",
        data: { id: id },
        success: function (data) {
            $.each(data, function (index, value) {
                var details = $('#medicineDetails').html(`<p style="font-size:11px">buying price : <strong>
                    ${value.BuyingPrice}</strong>,
                    Batch No: <strong>${value.BatchNo}</strong> </p>`);
                currentItemPrice = value.BuyingPrice; console.log(value.BuyingPrice, value.BatchNo)
            })
        }
    })
}

function calculateSum() {
    var sum = 0; $(".amount").each(function () {
        var value = $(this).text();
        if (!isNaN(value) && value.length !== 0) { sum += parseFloat(value) }
    });
    if (sum == 0.0) { $('#Discount').text("0"); $('#GrandTotal').text("0") }
    $('#SubTotal').text(sum.toFixed(2)); $('#GrandTotal').text(sum.toFixed(2));

    var b = parseFloat($('#Discount').val()).toFixed(2); if (isNaN(b)) return;
    var a = parseFloat($('#SubTotal').text()).toFixed(2); $('#GrandTotal').text(a - b)
};
$('.amount').each(function () { calculateSum() }); function DiscountAmount() {
    blankme("Discount"); blankme("GrandTotal");
    var b = parseFloat($('#Discount').val()).toFixed(2); if (isNaN(b)) return; var a = parseFloat($('#SubTotal').text()).toFixed(2);
    $('#GrandTotal').text(a - b)
}
function add_validation() {
    var medicine = document.getElementById("Medicine").value; var quantity = document.getElementById("Quantity").value;
    if (quantity == "" || medicine == "") {
        if (quantity == "") { document.getElementById("error_Quantity").style.display = "block" }
        else { document.getElementById("error_Quantity").style.display = "none" }
        if (medicine == "") { document.getElementById("error_Medicine").style.display = "block" }
        else { document.getElementById("error_Medicine").style.display = "none" }
        return !1
    }
    else { return !0 }
}
function blankme(id) {
    var val = document.getElementById(id).value; var error_id = "error_" + id;
    if (val == "" || val === 0.00) { document.getElementById(error_id).style.display = "block" }
    else { document.getElementById(error_id).style.display = "none" }
}

function submitValidation() {
    var supplier = document.getElementById("Supplier").value; var purcahseCode = document.getElementById("Code").value;
    var purcahseDate = document.getElementById("Date").value; var paymentmethod = document.getElementById("Payment").value;
    var pStaus = document.getElementById("PurchaseStatus").value; var total = parseFloat($("#SubTotal").text());
    var gtotal = parseFloat($("#GrandTotal").text());
    if (supplier == "" || pStaus == "" || purcahseCode == "" || purcahseDate == "" || paymentmethod == "" || (total == "" || total == 0.00 || isNaN(total)) || (gtotal == "" || gtotal == 0.00 || isNaN(gtotal))) {
        if (pStaus == "") { document.getElementById("error_PurchaseStatus").style.display = "block" }
        else { document.getElementById("error_PurchaseStatus").style.display = "none" }
        if (supplier == "") { document.getElementById("error_Supplier").style.display = "block" }
        else { document.getElementById("error_Supplier").style.display = "none" }
        if (purcahseCode == "") { document.getElementById("error_Code").style.display = "block" }
        else { document.getElementById("error_Code").style.display = "none" }
        if (purcahseDate == "") { document.getElementById("error_Date").style.display = "block" }
        else { document.getElementById("error_Date").style.display = "none" }
        if (paymentmethod == "") { document.getElementById("error_Payment").style.display = "block" }
        else { document.getElementById("error_Payment").style.display = "none" }
        if (total == "" || total === 0.00 || isNaN(total)) { document.getElementById("error_SubTotal").style.display = "block" }
        else { document.getElementById("error_SubTotal").style.display = "none" }
        if (gtotal == "" || gtotal === 0.00 || isNaN(gtotal)) { document.getElementById("error_GrandTotal").style.display = "block" }
        else { document.getElementById("error_GrandTotal").style.display = "none" }
        return !1
    }
    else { return !0 }
}