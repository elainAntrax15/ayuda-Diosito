var Recetas = {
    Objects: {
        ID_Recetas: 0
    },
    init: function () {
        $("#formulario").on("submit", function (e) {
            e.preventDefault()

            var RECETA = $("#nombre").val();
            var TIEMPO = $("#tiempo").val();
            var INGREDIENTES = $("#ingredientes").val();
            var PREPARACION = $("#preparacion").val();
          

            if (Recetas.Objects.ID_Recetas == 0) {
               

                if (RECETA.trim() == "") {
                    Dialog.show("El campo 'Nombre de la receta' es obligatorio", Dialog.type.error);
                    return;
                }
                if (TIEMPO.trim() == "") {
                    Dialog.show("El campo 'Tiempo' es obligatorio", Dialog.type.error);
                    return;
                }
                if (INGREDIENTES.trim() == "") {
                    Dialog.show("El campo 'Ingredientes' es obligatorio", Dialog.type.error);
                    return;
                }
                if (PREPARACION.trim() == "") {
                    Dialog.show("El campo 'Preparacion' es obligatorio", Dialog.type.error);
                    return;
                }
                $.ajax({
                    url: Root + "Receta/AgregarReceta",
                    type: "POST",
                    data: { receta: RECETA, tiempo: TIEMPO, ingredientes: INGREDIENTES, preparacion: PREPARACION},
                    beforeSend: function () {
                        Dialog.show("Enviando Datos...", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Nueva Receta Creada Con Exito", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al guardar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            }
        });

    },
}