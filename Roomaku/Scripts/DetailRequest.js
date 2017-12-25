function submitForm() {
    var data = {
        Nama: $('#txtNama').val(),
        Lokasi: $('#txtLokasi').val(),
        Telp: $('#txtTelp').val(),
        Email: $('#txtEmail').val(),
        Material: $('#txtMaterial').val()
    }

    if ($('txtTelp').val() != '') {
        $.ajax({
            type: "POST",
            url: base_url + "odata/tblT_RoomakuOData",
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (response) {
                alert("Your request has been Submitted");
            },
            error: function (event, textStatus, errorThrown) {
                debugger;
                alert("Message : Javasript or your connection is disabled or not connected ");
            }
        })
    }
}