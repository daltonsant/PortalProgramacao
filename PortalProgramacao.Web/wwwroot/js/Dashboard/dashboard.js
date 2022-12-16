(function($) {

    function fnInitTracker(url,method, charts) {
        fnGetCards(url, method, charts);

         setInterval(function () {
             fnGetCards(url, method, charts);
         }, 360000);
    }

    function fnGetCards(url, method, charts) {
        $.ajax({
            url: url,
            method: method,
            async : true,
            data: { month: document.getElementById("month").value },
            success: function (data) {
                fnUpdateCards(data, charts);
            }
        });
    }

    function fnUpdateCards(data, charts) {

        for(let index = 0; index < charts.length; index++) {
            let dataset = data.charts[index];
            if(dataset)
                charts[index].config.dataset.source = dataset;
            else
                charts[index].config.dataset.source = [];

            charts[index].chart.setOption(charts[index].config)
        }
    }

    function fnGetPendenciesPerStepsChart(){
        let chartDom = document.getElementById('pendeciasPerEtapas');
        let myChart = echarts.init(chartDom);

        let configuredChart = {};
        configuredChart.chart = myChart;
        configuredChart.config = {
            color: ['#848f98', '#0063be', '#151515', '#61a60e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'value',
                boundaryGap: [0, 0.02],
                axisLabel : { show: false }, splitLine: { show: false }
            },
            yAxis: {
                type: 'category'
            },
            dataset: {
                // Provide a set of data.
                source: [
                    // ['Step', 'Não iniciada', 'Em andamento', 'Em revisão', 'Concluída'],
                    // ['Planejamento', 1, 2, 3, 4],
                    // ['TAC Equip. Interlig.', 2, 3, 4, 5],
                    // ['TAF SPCS', 3, 4, 5, 6],
                    // ['TAC SPCS', 4, 5, 6, 7],
                    // ['Energização', 8, 7, 6, 5],
                    // ['SAP', 6, 5, 4, 3]
                ]
            },
            series: [
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff"
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff"
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff"
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff"
                    }
                }
            ]
        };

        return configuredChart;
    }

    function fnGetPendenciesPerCategoryChart(){
        let chartDom = document.getElementById('pendeciasPerCategorias');
        let myChart = echarts.init(chartDom);

        let configuredChart = {};
        configuredChart.chart = myChart;
        configuredChart.config = {
            color: ['#848f98', '#0063be', '#151515', '#61a60e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'value',
                boundaryGap: [0, 0.02],
                axisLabel : { show: false }, splitLine: { show: false }
            },
            yAxis: {
                type: 'category'
            },
            dataset: {
                // Provide a set of data.
                source: [
                    // ['Category', 'Não iniciada', 'Em andamento', 'Em revisão', 'Concluída'],
                    // ['Civil', 43.3, 85.8, 93.7, 20.0],
                    // ['Eletromecânico', 83.1, 73.4, 55.1, 40.0],
                    // ['Aterramento', 86.4, 65.2, 82.5, 200.0],
                    // ['Projeto', 72.4, 53.9, 39.1, 100.0],
                    // ['Painéis', 72.4, 53.9, 39.1, 100.0],
                    // ['Equipamentos', 72.4, 53.9, 39.1, 100.0],
                    // ['Interligações', 72.4, 53.9, 39.1, 100.0],
                    // ['SPCS', 72.4, 53.9, 39.1, 100.0]
                ]
            },
            series: [
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff"
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff"
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff"
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff"
                    }
                }
            ]
        };

        return configuredChart;
    }

    function fnGetProgressChart() {
        let chartDom = document.getElementById('progressPerEtapas');
        let myChart = echarts.init(chartDom);

        let configuredChart = {};
        configuredChart.chart = myChart;
        configuredChart.config = {
            color: ['#848f98', '#0063be', '#151515', '#61a60e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'value',
                boundaryGap: [0, 0.02],
                axisLabel : { show: false }, splitLine: { show: false }
            },
            yAxis: {
                type: 'category'
            },
            dataset: {
                source: [
                    // ['Status', 'Não iniciada', 'Em andamento', 'Em revisão', 'Concluída'],
                    // ['Informativo', 43.3, 85.8, 93.7,55],
                    // ['Acompanhamento', 83.1, 73.4, 55.1,55],
                    // ['Pendência não impeditiva', 86.4, 65.2, 82.5,55],
                    // ['Pendência impeditiva', 72.4, 53.9, 39.1,55],
                    // ['Não conformidade', 72.4, 53.9, 39.1,55]
                ]
            },
            series: [
                {type: 'bar', stack: 'total', label: { show: true, color: "#fff" } },
                { type: 'bar', stack: 'total', label: { show: true, color: "#fff" } },
                { type: 'bar', stack: 'total', label: { show: true, color: "#fff" } },
                { type: 'bar', stack: 'total', label: { show: true, color: "#fff" }}
            ]
        };

        return configuredChart;
    }

    function fnGetProgressPerProject(){
        let chartDom = document.getElementById('progressPerProjects');
        let myChart = echarts.init(chartDom);

        let configuredChart = {};
        configuredChart.chart = myChart;
        configuredChart.config = {
            color: ['#9d9d9d','#0063be', '#ff5a00', '#61a60e'],
            tooltip: {
                trigger: 'item'
            },
            legend: {
                orient: 'vertical',
                left: 'left'
            },
            dataset: {
                source : [
                    // ['Projetos concluídos',100],
                    // ['Projetos em andamento',200],
                    // ['Projetos não iniciados',120],
                ]
            },
            series: [
                {
                    type: 'pie',
                    top: '10%',
                    bottom : '0%',
                    radius: '80%',
                    center: ['60%', '50%'],
                    label: {
                        position: 'inner',
                        fontSize: 12,
                        color: "#fff",
                        formatter: function(value) {
                            let percent = Number.parseFloat(value.percent);

                            if(percent === 0.0) return "";

                            return percent.toFixed(1) + " %";
                        }
                    },
                    labelLine: {
                        show: false
                    },
                    emphasis: {
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                },
            ]
        };

        return configuredChart;
    }
    
    function nplPerProcessChart(){
        let chartDom = document.getElementById('nplPerProc');
        let myChart = echarts.init(chartDom);

        let configuredChart = {};
        configuredChart.chart = myChart;
        configuredChart.config = {
            color: ['#53672A', '#5c881A', '#61A60E', '#FF5A00'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            yAxis: {
                type: 'value',
                boundaryGap: [0, 0.02],
                axisLabel : { show: false }, splitLine: { show: false }
            },
            xAxis: {
                type: 'category'
            },
            dataset: {
                // Provide a set of data.
                source: [
                    // ['Npl', 'SE', 'LT', 'AUT', 'TLE'],
                    // ['CAA', 43.3, 85.8, 93.7, 20.0],
                    // ['CPN', 83.1, 73.4, 55.1, 40.0],
                    // ['GAN', 86.4, 65.2, 82.5, 200.0],
                    // ['MTN', 72.4, 53.9, 31.1, 101.0],
                    // ['MTS', 72.4, 58.9, 33.1, 130.0],
                    // ['PMR', 72.4, 54.9, 36.1, 110.0],
                    // ['PTU', 72.4, 56.9, 35.1, 120.0],
                    // ['SRT', 72.4, 59.9, 39.1, 102.0]
                ]
            },
            series: [
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff",
                        formatter:  function(params) {
                            let percent = Number.parseFloat(params.value[params.encode.y[0]]);

                            if(percent === 0.0) return "";

                            return percent.toFixed(2) + " %";
                        }
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff",
                        formatter: function(params) {
                            let percent = Number.parseFloat(params.value[params.encode.y[0]]);

                            if(percent === 0.0) return "";

                            return percent.toFixed(2) + " %";
                        }
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff",
                        formatter: function(params) {
                            let percent = Number.parseFloat(params.value[params.encode.y[0]]);

                            if(percent === 0.0) return "";

                            return percent.toFixed(2) + " %";
                        }
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff",
                        formatter: function(params) {
                            let percent = Number.parseFloat(params.value[params.encode.y[0]]);

                            if(percent === 0.0) return "";

                            return percent.toFixed(2) + " %";
                        }
                    }
                }
            ]
        };

        return configuredChart;
    }

    function regionPerProcessChart(){
        let chartDom = document.getElementById('regionPerProc');
        let myChart = echarts.init(chartDom);

        let configuredChart = {};
        configuredChart.chart = myChart;
        configuredChart.config = {
            color: ['#53672A', '#5c881A', '#61A60E', '#FF5A00'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            yAxis: {
                type: 'value',
                boundaryGap: [0, 0.02],
                axisLabel : { show: false }, splitLine: { show: false }
            },
            xAxis: {
                type: 'category'
            },
            dataset: {
                // Provide a set of data.
                source: [
                    ['Region', 'SE', 'LT', 'AUT', 'TLE'],
                    ['Interior', 43.3, 85.8, 93.7, 20.0],
                    ['Litoral', 83.1, 73.4, 55.1, 40.0],
                    ['Metropolitano', 86.4, 65.2, 82.5, 200.0],
                    ['NSPS',10.0, 22.0, 35.0, 44.0]
                ]
            },
            series: [
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff",
                        formatter:  function(params) {
                            let percent = Number.parseFloat(params.value[params.encode.y[0]]);

                            if(percent === 0.0) return "";

                            return percent.toFixed(2) + " %";
                        }
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff",
                        formatter: function(params) {
                            let percent = Number.parseFloat(params.value[params.encode.y[0]]);

                            if(percent === 0.0) return "";

                            return percent.toFixed(2) + " %";
                        }
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff",
                        formatter: function(params) {
                            let percent = Number.parseFloat(params.value[params.encode.y[0]]);

                            if(percent === 0.0) return "";

                            return percent.toFixed(2) + " %";
                        }
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true,
                        color: "#fff",
                        formatter: function(params) {
                            let percent = Number.parseFloat(params.value[params.encode.y[0]]);

                            if(percent === 0.0) return "";

                            return percent.toFixed(2) + " %";
                        }
                    }
                }
            ]
        };

        return configuredChart;
    }
    
    $(document).ready(function () {
        const charts = [];

        charts.push(
            regionPerProcessChart(), 
            nplPerProcessChart());
        
        let url = "/Dashboard/Dash/";
        let method = "POST";
        
        fnInitTracker(url, method, charts);

        $("#month").on("change", function () {
            fnGetCards(url, method, charts);
        });
        
        $(window).resize(function() {
            for(let index = 0; index < charts.length;index++){
                charts[index].chart.resize();
            }
        });
    });
})(jQuery)