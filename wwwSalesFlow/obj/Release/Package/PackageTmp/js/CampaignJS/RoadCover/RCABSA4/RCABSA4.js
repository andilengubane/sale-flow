$(document).ready(function () {

    $('#sendOpBtn').click(function () {
        alert('Hello, my name is Boris!');

        var title = $('#cmbTitle').val();
        var surname = $('#txtSurname').val();
        var mailName = title + '. ' + surname;
        var email = $('#txtEmail').val();

        $.ajax({

            type: 'POST',
            url: '/campaignsForms/RCABSA4.aspx/SendOnePager',
            data: JSON.stringify({name:mailName, emailAddress:email}),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                alert('One-Pager Sent: ' + response.d);
            },
            failure: function (msg) {
                alert('Error: ' + msg.d);
            }
        });
        return false;
    });
});

$(document).on('show.bs.modal', function (e) {

    var title = $('#cmbTitle').val();
    var surname = $('#txtSurname').val();
    var email = $('#txtEmail').val();

    if (title === '') {
        $('#sendOpBtn').attr('disabled');
        $('#opModalInfo').val('Please select a title before sending a one-pager.');
    }
    else if (surname === '') {
        $('#sendOpBtn').attr('disabled');
        $('#opModalInfo').val('Please enter a surname before sending a one-pager.');
    }
    else if (email === "") {
        $('#sendOpBtn').attr('disabled');
        $('#opModalInfo').val('Please enter an email address before sending a one-pager.');
    }
    else {
        $('#sendOpBtn').removeAttr('disabled');
        $('#opModalInfo').html('Ready to send One-Pager email to <em>' + title + '. ' + surname + '</em> at <strong>' + email + '</strong>');
    }
});

function openModal() {
    $('#OnePagerModal').modal('show');
}

