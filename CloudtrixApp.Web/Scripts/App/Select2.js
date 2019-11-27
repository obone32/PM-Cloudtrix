$("#Architect").select2({ width: "100%" });
$("#Customer1").select2({ width: "100%" });
$("#Project").select2({ width: "100%" });




$(function () { // will trigger when the document is ready
    $('.datepicker').datepicker({
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,
        selectWeek: true,
        inline: true,
        format: 'dd/MM/yyyy',
        pickTime: false,
        closeOnDateSelect: true,
        startDate: '01/01/2019',
        firstDay: 1

    }); //Initialise any date pickers
   
    $('.timepicker').timepicker({
        'timeFormat': 'H:i',
        'minTime': '10:00',
        'maxTime': '20:30',
        autoclose: true
    });
});

// TimeSpan

