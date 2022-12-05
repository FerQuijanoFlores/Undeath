function eliminar(id) {
    if (confirm("¿Estás seguro de que desea eliminar el registro?")) {
        var url = "/Consulta/Eliminar/" + id;
        window.location.href = url;

    }

}