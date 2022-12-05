function eliminar(id) {
    if (confirm("¿Estás seguro de que desea eliminar el registro?")) {
        var url = "/Doctor/Eliminar/" + id;
        window.location.href = url;

    }

}