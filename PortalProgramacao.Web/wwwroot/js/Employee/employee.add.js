(function ($) {
   
    $(document).ready(function () {
        $(".proc").inputmask({regex: "^([0-9](\\,\\d{1,2})?|[1-9][0-9](\\,\\d{1,2})?|100(\\,\\0{1,2})?)$"});
    });

    $(document).ready(function () {
        $(".month").inputmask({regex: "^([0-9](\\,\\d{1,2})?|[1-2][0-9](\\,\\d{1,2})?|30(\\,\\d{1,2})?|31,00)$"});
    });

}(jQuery));