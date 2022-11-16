

(function ($) {

    function getCurrentNpl() {
        let selectedNpl = $('#npl').find(":selected").text();
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

    function updateKpis() {
        let nplFilter = getCurrentNpl();
        let monthFilter = getCurrentMonth();
        let procFilter = getCurrentProcess();
        $.ajax({
            url: "/Wallet/GetKpis",
            data: {
                npl: nplFilter,
                month: monthFilter,
                process: procFilter
            },
            method: "POST",
            async: true,
            success: function (data) {
                let dispTot = document.getElementById("dispTot");
                let dispSE = document.getElementById("dispSE");
                let dispLT = document.getElementById("dispLT");
                let dispAUT = document.getElementById("dispAUT");
                let dispTLE = document.getElementById("dispTLE");

                dispTot.innerHTML = (data["dispTot"].toFixed(2));
                dispSE.innerHTML = (data["dispSE"].toFixed(2));
                dispLT.innerHTML = (data["dispLT"].toFixed(2));
                dispAUT.innerHTML = (data["dispAUT"].toFixed(2));
                dispTLE.innerHTML = (data["dispTLE"].toFixed(2));

                let necTot = document.getElementById("necTot");
                let necSE = document.getElementById("necSE");
                let necLT = document.getElementById("necLT");
                let necAUT = document.getElementById("necAUT");
                let necTLE = document.getElementById("necTLE");

                necTot.innerHTML = (data["necTot"].toFixed(2));
                necSE.innerHTML = (data["necSE"].toFixed(2));
                necLT.innerHTML = (data["necLT"].toFixed(2));
                necAUT.innerHTML = (data["necAUT"].toFixed(2));
                necTLE.innerHTML = (data["necTLE"].toFixed(2));


                let satTot = document.getElementById("satTot");
                let satSE = document.getElementById("satSE");
                let satLT = document.getElementById("satLT");
                let satAUT = document.getElementById("satAUT");
                let satTLE = document.getElementById("satTLE");

                let aux = (data["necTot"].toFixed(2) * 100 / data["dispTot"].toFixed(2));
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = aux + " %";
                satTot.innerHTML = aux;

                aux = (data["necSE"].toFixed(2) * 100 / data["dispSE"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = aux + " %";
                satTot.innerHTML = aux;

                satSE.innerHTML = aux;

                aux = (data["necLT"].toFixed(2) * 100 / data["dispLT"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = aux + " %";

                satLT.innerHTML = aux;

                aux = (data["necAUT"].toFixed(2) * 100 / data["dispAUT"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = aux + " %";

                satAUT.innerHTML = aux;

                aux = (data["necTLE"].toFixed(2) * 100 / data["dispTLE"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = aux + " %";
                satTLE.innerHTML = aux;

            }
        });
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
            updateKpis();
        });
        $("#month").on("change", function () {
            calendar.refetchEvents();
            let m = this.value;
            let currentTime = new Date();
            year = currentTime.getFullYear();

            if (m == "")
                m = currentTime.getMonth() + 1;
            calendar.gotoDate(year + "-" + m + "-13");
            updateKpis();
        });
        $("#processo").on("change", function () {
            calendar.refetchEvents();
            updateKpis();
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