function validarFormulario() {
    const nombre = document.getElementById("Nombre");
    if (!nombre || nombre.value.trim() === "") {
        Swal.fire("Atención", "El campo Nombre es obligatorio", "warning");
        return false;
    }
    return true;
}

// Inicializa Select2
$(document).ready(function () {
    $('.select2').select2();
});

// Inicializa DataTables
$(document).ready(function () {
    $('#miTabla').DataTable({
        language: {
            url: "//cdn.datatables.net/plug-ins/1.13.4/i18n/es-ES.json"
        }
    });
});





