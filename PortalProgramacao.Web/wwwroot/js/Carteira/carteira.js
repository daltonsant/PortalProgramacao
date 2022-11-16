

(function ($) {

    function getCurrentNpl() {
        let selectedNpl = $('#npl').find(":selected").text();
        console.log(selectedNpl)
        return selectedNpl;
    }
    function getCurrentMonth() {
        let selectedMonth = $('#month').find(":selected").val();
        return selectedMonth;
    }
    function getCurrentProcess() {
        let selectedProcess = $('#processo').find(":selected").val();
        return selectedProcess;
    }

    $(document).ready(function (){

        /********************
         *     Calendar     *
         ********************/
         
         let calendarJQ = $("#calendar");
         let calendar = new FullCalendar.Calendar(calendarJQ[0], {
            themeSystem: 'bootstrap5',
            initialView: 'dayGridMonth',
             locale: 'pt-br',
             events: {
                 url: '/Wallet/List',
                 method: 'POST',
                 extraParams: function () { // a function that returns an object
                     return {
                         npl: getCurrentNpl(),
                         month: getCurrentMonth(),
                         process: getCurrentProcess()
                     };
                 },
                 failure: function () {
                     alert('Houve um erro ao tentar carregar as atividades!');
                 },
             }
           
         });

        
        $("#npl").on("change", function () {
            calendar.refetchEvents();
        });
        $("#month").on("change", function () {
            calendar.refetchEvents();
            let m = this.value;
            let currentTime = new Date();
            year = currentTime.getFullYear();
            calendar.gotoDate(year+"-"+m+"-13");
        });
        $("#processo").on("change", function () {
            calendar.refetchEvents();
        });

          /**
           * 
           * 
           *  editable: false,
            eventLimit: true, // allow "more" link when too many events
            locale: "pt-br",
            events: "/Wallet/List",
            views: {
                agendaWeek: {
                    columnFormat: 'DD'
                }
            }
           * 
           */

          calendar.render();
    });

} ( jQuery ))