$(document).ready(function () {

    //datetimepicker
    $('.mydatepicker').datepicker(
        { format: 'dd/mm/yyyy', autoclose: true });

    //Get Customer
    $.ajax({
        type: "GET", url: "/Admin/GetCustomer",
        datatype: "Json",
        success: function (data) {
            $.each(data, function (index, value) {
                $('#Customer1').append('<option value="' + value.Id + '">' + value.Name + '</option>')
            })
        }
    });

    // Get Project by Customer
    $('#Customer1').change(function () {
        $.ajax({
            type: "GET", url: "/Admin/GetProjectByCustomer",
            datatype: "Json",
            data: { customerId: $('#Customer1').val() },
            success: function (data) {
                $.each(data, function (index, value) {
                    $('#Project').append('<option value="' + value.Id + '">' + value.ProjectName + '</option>')
                });
                //Check if required
                //LoadProjectDetails($("#Project option:selected").val())
            }
        })
    });

    // Save the Form with details
    $("#BtnSave").click(function (e) {
        e.preventDefault();
         {
            var data = JSON.stringify({
                ReceiptNumber: $("#ReceiptNumber").val(),
                ReceiptDate: $("#ReceiptDate").val(),
                CustomerId: $("#Customer1").val(),
                ProjectId: $("#Project").val(),
                Amount: $("#Amount").val(),
                Status: $("#Status").val(),
                ReceivedBy: $("#ReceivedBy").val(),
            });
            alert("Save");

            console.log(data);
            $.when(saveOrder(data)).then(function (response) {
                console.log(response);
                alert("Save1");
                toastr.success(response.message); location.href = "/Admin/ReceiptList"
            }).fail(function (err) { toastr.error(response.message) })
        }
    });
    function saveOrder(data) {
        return $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: "/Admin/AddReceipt",
            data: data
        })
    }
    
    // Submit Validation
    function submitValidation() {
        var rReceiptNumber = document.getElementById("#ReceiptNumber").value;
        var rReceiptDate = document.getElementById("#ReceiptDate").value;
        var rCustomer = document.getElementById("#Customer1").value;
        var rProject = document.getElementById("#Project").value;
        var rAmount = document.getElementById("#Amount").value;
        var rStatus = document.getElementById("#Status").value;
        var rReceivedBy = parseFloat($("#ReceivedBy").value());

        if (rReceiptNumber == "" || rReceiptDate == "" || rCustomer == "" || rProject == "" ||
            rAmount == "" || rStatus == "" || rReceivedBy == "") {
            if (rReceiptNumber == "") { document.getElementById("error_InvoiceStatus").style.display = "block" }
            else { document.getElementById("error_InvoiceStatus").style.display = "none" }

            if (rReceiptDate == "") { document.getElementById("error_Payment").style.display = "block" }
            else { document.getElementById("error_Payment").style.display = "none" }

            if (rCustomer == "") { document.getElementById("error_Code").style.display = "block" }
            else { document.getElementById("error_Code").style.display = "none" }

            if (rProject == "") { document.getElementById("error_Project").style.display = "block" }
            else { document.getElementById("error_Project").style.display = "none" }

            if (rAmount == "") { document.getElementById("error_Customer").style.display = "block" }
            else { document.getElementById("error_Customer").style.display = "none" }

            if (rStatus == "") { document.getElementById("error_Status").style.display = "block" }
            else { document.getElementById("error_Status").style.display = "none" }

            if (rReceivedBy == "") { document.getElementById("error_SubTotal").style.display = "block" }
            else { document.getElementById("error_SubTotal").style.display = "none" }
           
            return !1
        }
        else { return !0 }
    }





});