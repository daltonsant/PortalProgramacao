

(function ($) {
    
    function getOption(text,value) {
        let option = document.createElement('option')
        if(value !== undefined)
            option.value = value;
        option.text = text;
        return option;
    }
    
    function onSectorUpdate(selectedSector) {
        if(selectedSector === undefined || selectedSector === "")
            return;
        
        let nplFilter = document.getElementById("npl");
        
        let nplSelectedOld = nplFilter.value;
        
        for (a in nplFilter.options) { 
            nplFilter.options.remove(nplFilter.options.length-1); 
        }
        console.log(selectedSector);
        console.log(nplSelectedOld);
        
        let option = getOption("");
        nplFilter.add(option);
        nplFilter.value = "";
        
        if(parseInt(selectedSector) === 1) {
            option = getOption("PTU",4);
            nplFilter.add(option);
            option = getOption("SRT",5);
            nplFilter.add(option);
            if(nplSelectedOld == 4 || nplSelectedOld == 5){
                nplFilter.value = nplSelectedOld;
            }
        } else if (parseInt(selectedSector) === 2) {
            option = getOption("CAA",1);
            nplFilter.add(option);
            option = getOption("GAN",2);
            nplFilter.add(option);
            option = getOption("PMR",3);
            nplFilter.add(option);
            if(nplSelectedOld == 2 || nplSelectedOld == 3 || nplSelectedOld == 1){
                nplFilter.value=nplSelectedOld;
            }
        } else if(parseInt(selectedSector) ===3) {
            option = getOption("CPN",8);
            nplFilter.add(option);
            option = getOption("MTN",7);
            nplFilter.add(option);
            option = getOption("MTS",6);
            nplFilter.add(option);
            if(nplSelectedOld == 8 || nplSelectedOld == 7 || nplSelectedOld == 6){
                nplFilter.value = nplSelectedOld;
            }
        }
        else {
            option = getOption("CAA",1);
            nplFilter.add(option);
            option = getOption("CPN",8);
            nplFilter.add(option);
            option = getOption("GAN",2);
            nplFilter.add(option);
            option = getOption("MTN",7);
            nplFilter.add(option);
            option = getOption("MTS",6);
            nplFilter.add(option);
            option = getOption("PMR",3);
            nplFilter.add(option);
            option = getOption("PTU",4);
            nplFilter.add(option);
            option = getOption("SRT",5);
            nplFilter.add(option);
            nplFilter.value = nplSelectedOld;
        }
    }
    
    function getCurrentNpl() {
        let selectedNpl = $('#npl').find(":selected").text();
        return selectedNpl;
    }
    function getCurrentMonth() {6
        let selectedMonth = $('#month').find(":selected").val();
        return selectedMonth;
    }
    function getCurrentProcess() {
        let selectedProcess = $('#processo').find(":selected").val();
        return selectedProcess;
    }
    
    function getCurrentSector() {
        let selectedSector = $('#setor').find(":selected").val();
        return selectedSector;
    }

    function updateKpis() {
        let nplFilter = getCurrentNpl();
        let monthFilter = getCurrentMonth();
        let procFilter = getCurrentProcess();
        let sectorFilter = getCurrentSector();

        $.ajax({
            url: "/Wallet/GetKpis",
            data: {
                npl: nplFilter,
                month: monthFilter,
                process: procFilter,
                sector: sectorFilter
            },
            method: "POST",
            async: true,
            success: function (data) {
                let dispTot = document.getElementById("dispTot");
                let dispSE = document.getElementById("dispSE");
                let dispLT = document.getElementById("dispLT");
                let dispAUT = document.getElementById("dispAUT");
                let dispTLE = document.getElementById("dispTLE");

                dispTot.innerHTML = (data["dispTot"].toFixed(2)).replace(".",",");
                dispSE.innerHTML = (data["dispSE"].toFixed(2)).replace(".",",");
                dispLT.innerHTML = (data["dispLT"].toFixed(2)).replace(".",",");
                dispAUT.innerHTML = (data["dispAUT"].toFixed(2)).replace(".",",");
                dispTLE.innerHTML = (data["dispTLE"].toFixed(2).replace(".",","));

                let necTot = document.getElementById("necTot");
                let necSE = document.getElementById("necSE");
                let necLT = document.getElementById("necLT");
                let necAUT = document.getElementById("necAUT");
                let necTLE = document.getElementById("necTLE");

                necTot.innerHTML = (data["necTot"].toFixed(2)).replace(".",",");
                necSE.innerHTML = (data["necSE"].toFixed(2)).replace(".",",");
                necLT.innerHTML = (data["necLT"].toFixed(2)).replace(".",",");
                necAUT.innerHTML = (data["necAUT"].toFixed(2)).replace(".",",");
                necTLE.innerHTML = (data["necTLE"].toFixed(2)).replace(".",",");


                let satTot = document.getElementById("satTot");
                let satSE = document.getElementById("satSE");
                let satLT = document.getElementById("satLT");
                let satAUT = document.getElementById("satAUT");
                let satTLE = document.getElementById("satTLE");

                let aux = (data["necTot"].toFixed(2) * 100 / data["dispTot"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = (aux + "%").replace(".",",");
                satTot.innerHTML = aux;

                aux = (data["necSE"].toFixed(2) * 100 / data["dispSE"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = (aux + "%").replace(".",",");
                satSE.innerHTML = aux;

                aux = (data["necLT"].toFixed(2) * 100 / data["dispLT"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = (aux + "%").replace(".",",");

                satLT.innerHTML = aux;

                aux = (data["necAUT"].toFixed(2) * 100 / data["dispAUT"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = (aux + "%").replace(".",",");

                satAUT.innerHTML = aux;

                aux = (data["necTLE"].toFixed(2) * 100 / data["dispTLE"].toFixed(2)).toFixed(2);
                if (isNaN(aux) || !isFinite(aux))
                    aux = "-";
                else
                    aux = (aux + "%").replace(".",",");
                satTLE.innerHTML = aux;

            }
        });
    }

    $(document).ready(function (){
        /********************
         *     Calendar     *
         ********************/
         updateKpis();

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
                         process: getCurrentProcess(),
                         sector: getCurrentSector()
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

        $("#setor").on("change", function () {
            calendar.refetchEvents();
            onSectorUpdate(this.value);
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