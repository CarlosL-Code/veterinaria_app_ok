function mostrarConfirmacion() {
    let confirmacion = confirm("¿Estas seguro que desea salir?");

}

// funcion solicitar datos
function solicitarDatos() {
    let nombre = prompt("Por favor ingrese su nombre");
    if (nombre !== null && nombre !== "") {
        alert("Hola, Como estas " + nombre);
    } else if (nombre === "") {
        alert("No has ingresado tu nombre");
    } else {
        alert("Has Cancelado");
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const logoutForm = document.getElementById("logoutForm");

    if (logoutForm) {
        logoutForm.addEventListener("submit", function (e) {
            e.preventDefault(); // Evita el envío inmediato

            Swal.fire({
                title: '¿Cerrar sesión?',
                text: "¿Estás seguro de que deseas cerrar sesión?",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#3085d6',
                confirmButtonText: 'Sí, cerrar sesión',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    logoutForm.submit(); // Envía el formulario si el usuario confirma
                }
            });
        });
    }
});


