(function ($) {
   
    $(document).ready(function () {
        $(".proc").inputmask({regex: "^[0-1]{1,1}(\\,\\d{1,2})?$"});
    });

}(jQuery));