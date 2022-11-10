﻿(function ($) {
   
    $(document).ready(function () {
        
        $('#staticBackdrop').on('hidden.bs.modal', function () {
            $(this).find('form').trigger('reset');
        });
 
        $(".delete-link").click(function() {
            $('#employeeId').val($(this).data('id'));
        });
 
        $('#importar').on('click', function () {
            //$('#import_form').submit();

            var formData = new FormData();
            formData.append('excel', $('#formFile')[0].files[0]);
            
            $("#importar").addClass("disabled");
            let span = $("<span>");
            span.addClass("spinner-border spinner-border-sm");
            span.attr("role","status");
            span.attr("aria-hidden","true");
            span.attr("id","spin_id");
            span.css("margin-right", "5px")

            $("#importar").prepend(span);

            $.ajax({
                url : '/Employee/Import/',
                type : 'POST',
                data : formData,
                processData: false,  // tell jQuery not to process the data
                contentType: false,  // tell jQuery not to set contentType
            })
            .done(function( msg ) {
                $("#importar").removeClass("disabled");
                $("#spin_id").remove();
                
                if (msg.length > 0) {
                    let error_container = $("#import_validations");
                    for (let i = 0; i < msg.length; i++) {
                        error_container.append($("<span>").text(msg[i]));
                    }
                }
                else {
                    location.reload();
                }
            });


            //$("#staticBackdrop").find('form').trigger('reset');
        });
 
        $( '#npls' ).select2({ theme: 'bootstrap-5' });
    
        let dTable= $('#example').DataTable({
            responsive: true,
            'language': {
                'searchPlaceholder': 'Pesquise aqui',
                url: '/js/datatable.pt_br.json'
            },
            columnDefs: [{
                orderable: false,
                className: 'select-checkbox',
                targets: 0
            },
            {
                targets: 1,
                searchable: false,
                orderable : false,
                className : 'taskids',
                visible  : false
            }],
            select: {
                style: 'os',
                selector: 'td:first-child'
            },
            order: [[1, 'asc']]

        });

        dTable.on('select', function(){
            let count = dTable.rows({selected: true}).count();
            
            if(count > 0 ){
                $("#exportSel").removeClass("disabled");
                $("#deleteSel").removeClass("disabled");
            }
        })
        .on('deselect', function(){
            let count = dTable.rows({selected: true}).count();
            
            if(count == 0 ){
                $("#exportSel").addClass("disabled");
                $("#deleteSel").addClass("disabled");

            }
        });

        $(".selectAll").on("click", function (e) {
            if ($(this).is(":checked")) {
                dTable.rows().select();
            } else {
                dTable.rows().deselect();
            }
        });

        $("#confirmar_delete").on("click", function() {
            let id = $("#employeeId").val();
            $.ajax({
                method: "Delete",
                url: "/Employee/Delete/",
                data: { ids: [id] }
              })
                .done(function( msg ) {
                    location.reload();
                });
        });

        $("#confirmar_deleteAll").on("click", function() {
            let data = dTable.rows({selected: true}).data();
            ids = []
            let length = data.length;
            
            for(let i = 0; i < length; i++) {
                ids.push(data[i][1]);
            }

            $.ajax({
                method: "Delete",
                url: "/Employee/Delete/",
                data: { ids: ids }
              })
                .done(function( msg ) {
                    location.reload();
                });
            
        });

        $("#exportSel").on("click", function() {
            let data = dTable.rows({ selected: true }).data();
            ids = []
            let length = data.length;

            for (let i = 0; i < length; i++) {
                ids.push(data[i][1]);
            }

            $.ajax({
                method: "POST",
                url: "/Employee/Export/",
                data: { ids: ids },
                xhrFields: {
                    responseType: 'blob'
                },
                success: function (result) {
                    
                    let a = document.createElement('a');
                    a.href = window.URL.createObjectURL(result);
                    a.download = "Colaboradores.xlsx";;
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                    window.URL.revokeObjectURL(a.href);
                }
            });
        });
    });

}(jQuery));