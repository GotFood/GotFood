$(document).ready(function () {
    $("#update").click(function () {
        $('#counter').html(function (i, val) {
            $.ajax({
                url: '/path/to/script/',
                type: 'POST',
                data: { increment: true },
                success: function () { alert('Request has returned') }
            });
            return +val + 1;
        });
    });
});