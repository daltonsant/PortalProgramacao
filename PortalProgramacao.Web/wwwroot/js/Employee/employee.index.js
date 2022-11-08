(function ($) {
   
    $(document).ready(function () {
        
        $('#staticBackdrop').on('hidden.bs.modal', function () {
            $(this).find('form').trigger('reset');
        });
 
        $(".delete-link").click(function() {
            $('#employeeId').val($(this).data('id'));
        });
 
        $('#importar').on('click', function () {
            $('#import_form').submit();
            $("#staticBackdrop").find('form').trigger('reset');
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

        $("#confirmar_deleteAll").on("click", function() {
            let data = dTable.rows({selected: true}).data();

            console.log(data);
            alert(data);
        });

    });

}(jQuery));