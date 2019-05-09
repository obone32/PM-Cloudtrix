
var currentItemPrice; var tempStock; $('.mydatepicker').datepicker({ format: 'mm/dd/yyyy' }); $.ajax({ type: "GET", url: "/Admin/GetCustomer", datatype: "Json", success: function (data) { $.each(data, function (index, value) { $('#Customer').append('<option value="' + value.Id + '">' + value.Name + '</option>') }) } }); $.ajax({ type: "GET", url: "/Admin/GetCategories", datatype: "Json", success: function (data) { $.each(data, function (index, value) { $('#SCategory').append('<option value="' + value.Id + '">' + value.Name + '</option>') }) } }); $('#SCategory').change(function () { $('#SMedicine').empty(); $.ajax({ type: "GET", url: "/Admin/GetStockMedicinesByCategory", datatype: "Json", data: { categoryId: $('#SCategory').val() }, success: function (data) { $.each(data, function (index, value) { $('#SMedicine').append('<option value="' + value.MedicineId + '">' + value.MedicineModel.Name + '(' + value.MedicineModel.BatchNo + ')' + '</option>') }); LoadStockMedicineDetails($("#SMedicine option:selected").val()) } }) }); $.ajax({ type: "GET", url: "/Admin/GetStockMedicinesByCategory", datatype: "Json", success: function (data) { $.each(data, function (index, value) { $('#SMedicine').append('<option value="' + value.MedicineModel.Id + '">' + value.MedicineModel.Name + '(' + value.MedicineModel.BatchNo + ')' + '</option>') }) } }); $('#SMedicine').change(function () { LoadStockMedicineDetails($("#SMedicine option:selected").val()); blankme("SMedicine") }); $("#SQuantity").change(function () { blankme("SQuantity"); stockQuantityCheckerVal() }); tempOrder = []; var a = 1; $("#SaleaddToList").click(function (e) { e.preventDefault(); if (Saleadd_validation() && stockQuantityCheckerVal()) { var productId = $("#SMedicine option:selected").val(), productName = $("#SMedicine option:selected").text(), price = currentItemPrice, quantity = $("#SQuantity").val(), detailsTableBody = $("#detailsTable tbody"); var data = { id: parseInt(productId), ref: a++, quantity: parseInt(quantity) }; tempOrder.push(data); console.log(tempOrder); var productItem = '<tr> <td> ' + productId + ' </td> + <td>' + productName + '</td><td>' + price.toFixed(2) + '</td><td>' + quantity + '</td><td class="amount">' + (parseFloat(price) * parseInt(quantity)).toFixed(2) + '</td><td><a data-itemId="' + (a - 1) + '" href="#" class="sdeleteItem"><i class="fa fa-trash"></i></a></td></tr>'; detailsTableBody.append(productItem); SalecalculateSum(); $("#SQuantity").val(''); LoadStockMedicineDetails($("#SMedicine option:selected").val()); blankme("SSubTotal"); blankme("SGrandTotal") } }); $("#SBtnSave").click(function (e) { e.preventDefault(); if (submitValidation()) { var orderArr = []; orderArr.length = 0; $.each($("#detailsTable tbody tr"), function () { orderArr.push({ MedicineId: parseInt($(this).find('td:eq(0)').html()), MedicineName: $(this).find('td:eq(1)').html(), Price: parseFloat($(this).find('td:eq(2)').html()), Quantity: parseInt($(this).find('td:eq(3)').html()), Amount: parseFloat($(this).find('td:eq(4)').html()), }) }); var data = JSON.stringify({ CustomerId: $("#Customer").val(), SaleCode: $("#SCode").val(), SalesDate: $("#SDate").val(), PaymentMethod: $("#SPayment").val(), Total: parseFloat($("#SSubTotal").text()), Notes: $("#Notes").val(), Status: $("#SaleStatus").val(), Discount: parseFloat($('#SDiscount').val()).toFixed(2), GrandTotal: parseFloat($('#SGrandTotal').text()).toFixed(2), Items: orderArr }); console.log(data); $.when(saveSale(data)).then(function (response) { console.log(response); toastr.success(response.message); location.href = "/Sales/Index" }).fail(function (err) { toastr.error(response.message) }) } }); $("#SBtnUpdate").click(function (e) { e.preventDefault(); if (submitValidation()) { var orderArr = []; orderArr.length = 0; $.each($("#detailsTable tbody tr"), function () { orderArr.push({ MedicineId: parseInt($(this).find('td:eq(0)').html()), MedicineName: $(this).find('td:eq(1)').html(), Price: parseFloat($(this).find('td:eq(2)').html()), Quantity: parseInt($(this).find('td:eq(3)').html()), Amount: parseFloat($(this).find('td:eq(4)').html()), }) }); var data = JSON.stringify({ Id: $("#SBtnUpdate").attr("data-sale-Id"), CustomerId: $("#Customer").val(), SaleCode: $("#SCode").val(), SalesDate: $("#SDate").val(), PaymentMethod: $("#SPayment").val(), Total: parseFloat($("#SSubTotal").text()), Notes: $("#Notes").val(), Status: $("#SaleStatus").val(), Discount: parseFloat($('#SDiscount').val()).toFixed(2), GrandTotal: parseFloat($('#SGrandTotal').text()).toFixed(2), Items: orderArr }); console.log(data); $.when(UpdateSale(data)).then(function (response) { console.log(response); toastr.success(response.message); location.href = "/Sales/Index" }).fail(function (err) { toastr.error(response.message) }) } }); $(document).on('click', 'a.sdeleteItem', function (e) {
    e.preventDefault(); var $self = $(this); var ref = $(this).attr('data-itemid'); var index = tempOrder.findIndex(function (a) { return a.ref == ref }); if (index > -1) { tempOrder.splice(index, 1) }
    $(this).parents('tr').css("background-color", "#1f306f").fadeOut(800, function () { $(this).remove(); SalecalculateSum(); blankme("SSubTotal"); LoadStockMedicineDetails($("#SMedicine option:selected").val()) })
}); function saveSale(data) { return $.ajax({ contentType: 'application/json; charset=utf-8', dataType: 'json', type: 'POST', url: "/Sales/AddSale", data: data }) }
function UpdateSale(data) { return $.ajax({ contentType: 'application/json; charset=utf-8', dataType: 'json', type: 'POST', url: "/Sales/EditSale", data: data }) }
function SalecalculateSum() {
    var sum = 0; $(".amount").each(function () { var value = $(this).text(); if (!isNaN(value) && value.length !== 0) { sum += parseFloat(value) } }); if (sum == 0.0) { $('#SDiscount').text("0"); $('#SGrandTotal').text("0") }
    $('#SSubTotal').text(sum.toFixed(2)); $('#SGrandTotal').text(sum.toFixed(2)); var b = parseFloat($('#SDiscount').val()).toFixed(2); if (isNaN(b)) return; var a = parseFloat($('#SSubTotal').text()).toFixed(2); $('#SGrandTotal').text(a - b)
}; function Saleadd_validation() {
    var medicine = document.getElementById("SMedicine").value; var quantity = document.getElementById("SQuantity").value; if (quantity == "" || medicine == "") {
        if (quantity == "") { document.getElementById("error_SQuantity").style.display = "block" }
        else { document.getElementById("error_SQuantity").style.display = "none" }
        if (medicine == "") { document.getElementById("error_SMedicine").style.display = "block" }
        else { document.getElementById("error_SMedicine").style.display = "none" }
        return !1
    }
    else { return !0 }
}
function SDiscountAmount() { blankme("SDiscount"); blankme("SGrandTotal"); var b = parseFloat($('#SDiscount').val()).toFixed(2); if (isNaN(b)) return; var a = parseFloat($('#SSubTotal').text()).toFixed(2); $('#SGrandTotal').text(a - b) }
function submitValidation() {
    var customer = document.getElementById("Customer").value; var saleCode = document.getElementById("SCode").value; var saleDate = document.getElementById("SDate").value; var paymentmethod = document.getElementById("SPayment").value; var sStaus = document.getElementById("SaleStatus").value; var total = parseFloat($("#SSubTotal").text()); var gtotal = parseFloat($("#SGrandTotal").text()); if (customer == "" || sStaus == "" || saleCode == "" || saleDate == "" || paymentmethod == "" || (total == "" || total == 0.00 || isNaN(total)) || (gtotal == "" || gtotal == 0.00 || isNaN(gtotal))) {
        if (sStaus == "") { document.getElementById("error_SaleStatus").style.display = "block" }
        else { document.getElementById("error_SaleStatus").style.display = "none" }
        if (customer == "") { document.getElementById("error_Customer").style.display = "block" }
        else { document.getElementById("error_Customer").style.display = "none" }
        if (saleCode == "") { document.getElementById("error_SCode").style.display = "block" }
        else { document.getElementById("error_SCode").style.display = "none" }
        if (saleDate == "") { document.getElementById("error_SDate").style.display = "block" }
        else { document.getElementById("error_SDate").style.display = "none" }
        if (paymentmethod == "") { document.getElementById("error_SPayment").style.display = "block" }
        else { document.getElementById("error_SPayment").style.display = "none" }
        if (total == "" || total === 0.00 || isNaN(total)) { document.getElementById("error_SSubTotal").style.display = "block" }
        else { document.getElementById("error_SSubTotal").style.display = "none" }
        if (gtotal == "" || gtotal === 0.00 || isNaN(gtotal)) { document.getElementById("error_SGrandTotal").style.display = "block" }
        else { document.getElementById("error_SGrandTotal").style.display = "none" }
        return !1
    }
    else { return !0 }
}
function blankme(id) {
    var val = document.getElementById(id).value; var error_id = "error_" + id; if (val == "" || val === 0.00) { document.getElementById(error_id).style.display = "block" }
    else { document.getElementById(error_id).style.display = "none" }
}
function stockQuantityCheckerVal() {
    var val = document.getElementById("SQuantity").value; if (tempStock == 0 || tempStock == "") return; if (val > tempStock) { document.getElementById("error_SQuantitycheck").style.display = "block"; return !1 }
    else { document.getElementById("error_SQuantitycheck").style.display = "none"; return !0 }
}
function tempStockCounter(id) { if (id == "" || id == 0) return 0; if (tempOrder.length == 0) return 0; var result = tempOrder.filter(function (a) { if (a.id == id) return a }).reduce(function (a, b) { return a + b.quantity }, 0); return result }
function LoadStockMedicineDetails(id) {
    if (id == "") { var details = $('#medicineDetails').html(``); return }
    $.ajax({ type: "GET", url: "/Admin/GetStockMedicineById", datatype: "Json", data: { id: id }, success: function (data) { $.each(data, function (index, value) { var tempstockCount = tempStockCounter(value.MedicineId); var details = $('#medicineDetails').html(`<p style="font-size:11px"> selling price : <strong>${value.MedicineModel.SellingPrice}</strong>, Stock: <strong>${value.TotalQuantity - tempstockCount}</strong> </p>`); currentItemPrice = value.MedicineModel.SellingPrice; origialStock = value.TotalQuantity; tempStock = value.TotalQuantity - tempstockCount; console.log(tempstockCount) }) } })
}

