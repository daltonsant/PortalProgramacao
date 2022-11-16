(function ($) {
   
    $(document).ready(function () {
        $(".num").inputmask({regex: "^([0-9]{1,4}?(\\,\\d{1,2})$"});
    });

}(jQuery));