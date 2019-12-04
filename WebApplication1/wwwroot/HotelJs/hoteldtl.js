$(document).ready(function () {
    $("#btnSearch").click(function () {
        if ($("#ddlDestinationName :selected").val() == 0) {
            alert("Please Select Destination");
            return false;
        }
        if ($("#txt_NoOfNights").val() == '') {
            alert("Please Enter No of nights");
            return false;
        }
        if ($("#txt_NoOfNights").val().length >8) {
            alert("Max Length should be less than 8");
            return false;
        }
        var objData = {
            destinationId: $("#ddlDestinationName :selected").val(),
            noofnights: $("#txt_NoOfNights").val()
        };
        var Htm = "<tr><th>Hotel Name</th><th>Board Type</th><th>Rate Type</th> <th> Rate </th></tr>";
        $.ajax({
            url: getHotelUrl,
            data: objData,
            method: "GET",
            success: function (response) {
                if (response.length > 0) {
                    for (var i = 0; i < response.length; i++) {

                        for (var j = 0; j < response[i].boardType.length; j++) {
                            Htm += "<tr>";
                            Htm += "<td>" + response[i].hotelName + "</td>";
                            Htm += "<td>" + response[i].boardType[j] + "</td>";
                            Htm += "<td>" + response[i].rateType[j] + "</td>";
                            Htm += "<td>" + response[i].rate[j] + "</td>";
                            
                            
                            Htm += "</tr>";

                        }
                    }
                    $("#tblHotelDtl").html(Htm);
                }
                else {
                    Htm += "<tr><td colspan=3 align='center'>No Record Found</td></tr>";
                    $("#tblHotelDtl").html(Htm);
                }
            }

        });
    });

    $(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^\d].+/, ""));
        if ((event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });
})
