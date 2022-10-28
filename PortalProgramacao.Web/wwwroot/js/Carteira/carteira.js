

(function ($) {
    

    $(document).ready(function (){

        /********************
         *     Calendar     *
         ********************/
         
         let calendarJQ = $("#calendar");
         let calendar = new FullCalendar.Calendar(calendarJQ[0], {
            themeSystem: 'bootstrap5',
            initialView: 'dayGridMonth',
            locale: 'pt-br'
           
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