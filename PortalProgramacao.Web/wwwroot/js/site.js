// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function ($) {

    function loginCallback()
    {
        let formData = {
            UserName: $("#UserName").val(),
            Password: $("#Password").val(),
          };
        
        $.ajax({
            url: "/Home/Login",
            data: JSON.stringify(formData),
            method: "POST",
            async: true,
            contentType: 'application/json; charset=utf-8',
            // headers: {
            //     'RequestVerificationToken': gettoken(),
            // },
            success: function (data) {
                if(data.length > 0){
                    $("#loginValidations").text(data);
                    $("#loginValidations").show();
                }
                else
                {
                    $("#loginValidations").hide();
                    $("#loginValidations").text("");
                    location.reload();
                }
            }
        });
    }

    $(document).ready(function () {
        
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        });

        $("#loginLink").on("click", function () {
            $("#loginValidations").hide();
            $("#loginValidations").text("");
        });

        $("#confirmLogin").on("click", loginCallback);
            
    });



}(jQuery));