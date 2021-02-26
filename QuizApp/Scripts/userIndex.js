            function Delete(ID) {
                window.location.href = "../Users/Delete/" + ID;
        }
        function Show(ID) {
                $.ajax({
                    url: '/Users/Details/' + ID,
                    type: 'POST',
                    dataType: 'json',
                    success: function (data) {
                        $("#Email").html(data.Email);
                        $("#LastName").html(data.LastName);
                        $("#Name").html(data.Name);
                        $("#NickName").html(data.NickName);
                        $("#PhoneNumber").html(data.PhoneNumber);
                        document.getElementById("ID").val = data.ID;
                    }
                });
        }
        function Edit() {
            var ID = document.getElementById("ID").val;
            $.ajax({
                url: '/Users/Edit/'+ID,
                type: 'GET',
                cache: false,
            }).done(function(result) {
                $('#editloadin').html(result);
                $('#editcon').modal('show');
            });
        }
            $('#datatable').DataTable({
                'destroy': true,
            dom: '<"row"<"col-md-12"<"row"<"col-md-6"B><"col-md-6"f> > ><"col-md-12"rt> <"col-md-12"<"row"<"col-md-5"i><"col-md-7"p>>> >',
            buttons: {
                buttons: [
                    {
                extend: 'excelHtml5',
                        text: '<i class="fa fa-file-pdf-o"></i>',
                        titleAttr: 'Excel',
                        className: 'btn btn-outline-secondary'
                    },
                    {
                text: '<b>Oluştur</b>',
                        action: function(e, dt, button, config) {
                $('#loadin').load('/Users/Create');
                            $('#CreateUsers').modal('show')
                        },
                        className: 'btn btn-outline-info'
                    }
                ]
            },
            "oLanguage": {
                "oPaginate": {"sPrevious": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-left"><line x1="19" y1="12" x2="5" y2="12"></line><polyline points="12 19 5 12 12 5"></polyline></svg>', "sNext": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-right"><line x1="5" y1="12" x2="19" y2="12"></line><polyline points="12 5 19 12 12 19"></polyline></svg>' },
                "sInfo": "Showing page _PAGE_ of _PAGES_",
                "sSearch": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>',
                "sSearchPlaceholder": "Ara...",
                "sLengthMenu": "Results :  _MENU_",
            },
            "stripeClasses": [],
            "lengthMenu": [7, 10, 20, 50],
            "pageLength": 7
        });
            function DeleteWarning(ID) {
                Swal.fire({
                    title: 'Silmek İstediğinize Emin Misiniz ?',
                    text: "Bu işlemi geri alamazsınız!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Evet, Sil'
                }).then((result) => {
                    if (result.value) {
                        Swal.fire(
                            'Silindi!',
                            'Kullanıcı Silindi',
                            'success',
                            Delete(ID)
                        );
                    }
                });
        }
