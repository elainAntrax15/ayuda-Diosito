var Usuario = {
    Objects: {
        IDUsuario: 0
    },
    init: function () {
        $("#formulario").on("submit", function (e) {
            e.preventDefault()

            var Nombre = $("#nombre").val();
            var Apellido = $("#apellido").val();
            var Genero = $("#genero").val();
            var Correo = $("#correo").val();
            var Contraseña = $("#contraseña").val();

            if (Usuario.Objects.IDUsuario == 0) {
                var Rol = $("#rol").val();

                if (Nombre.trim() == "") {
                    Dialog.show("El campo 'Nombre' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Apellido.trim() == "") {
                    Dialog.show("El campo 'Apellido' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Genero.trim() == "") {
                    Dialog.show("El campo 'Genero' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Correo.trim() == "") {
                    Dialog.show("El campo 'Correo' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Contraseña.trim() == "") {
                    Dialog.show("El campo 'Contraseña' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Rol.trim() == "") {
                    Dialog.show("El campo 'Rol' es obligatorio", Dialog.type.error);
                    return;
                }

                $.ajax({
                    url: Root + "Usuarios/New",
                    type: "POST",
                    data: { nombre: Nombre, apellido: Apellido, genero: Genero, correo: Correo, contraseña: Contraseña, rol: Rol },
                    beforeSend: function () {
                        Dialog.show("Enviando Datos...", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Nuevo Usuario Creado Con Exito", Dialog.type.success);
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