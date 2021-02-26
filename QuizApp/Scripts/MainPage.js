function ShowAlert() {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Yükleniyor',
        showConfirmButton: false,
    })
}
function ErrorAlert(error) {
    Swal.fire({
        position: 'top-end',
        icon: 'error',
        title: 'Hata',
        showConfirmButton: true,
    })
}
function CloseAlert() {
    Swal.close();
}
function UserShow() {
    $.ajax({
        url: '/Users/UserProfile',
        type: 'GET',
        cache: false,
        beforeSend: function () {
            ShowAlert();
        },
        success: function (result) {
            CloseAlert();
            $('#editloadin').html(result);
            $('#editcon').modal('show');
        },
        error: function (error) {
            ErrorAlert(error);
        }
    });
}
function UserEdit() {
    $.ajax({
        type: "GET",
        url: '/Users/UserSettings',
        beforeSend: function () {
            ShowAlert();
        },
        success: function (result) {
            CloseAlert();
            $('#userloadin').html(result);
            $('#usercon').modal('show');
        },
        error: function (error) {
            ErrorAlert(error);
        }
    });
}
function PageTo(Url,Title,) {
    $.ajax({
        type: "GET",
        url: Url,
        beforeSend: function () {
            ShowAlert();
        },
        success: function (result) {
            window.history.pushState("AA",Title,Url);
            CloseAlert();
            $('#Main').html(result);
        },
        error: function (error) {
            ErrorAlert(error);
        }
    });
}
