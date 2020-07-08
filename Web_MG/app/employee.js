function search() {
    /*Funcion que se encarga de llamar al servicio y realizar la busqueda de los empleados*/

    var code = $('.txt').val();
    if (code == null || code == "")
        code = 0;

    var url = "http://localhost:49994/api/employee/"+code+"/list"
    $.ajax({
        method: "GET",
        url: url,
    })
    .done(function (data) {
        ok(data);
    })
    .fail(function (data) {
        error(data);
    });
};

function ok(data) {
/*Funcion que se encarga completar el formulario con los datos recibidos del servicio*/
    if (data != null && data.length > 0) {
        var html = '';
        data.forEach(function (employee) {
            html += '<tr>'
                + '<th scope="row">' + employee.id + '</th>'
                + '<td>' + employee.name + '</td>'
                + '<td>' + employee.contractType + '</td>'
                + '<td>' + employee.roleName + '</td>'
                + '<td>' + employee.anualSalary + '</td>'
                + '</tr >'
        });

        $('.rowsemployee').empty().append(html);
    } else {
        $('.rowsemployee').empty();
    }
};

function error(msj) {
/*Funcion que se encarga de mostrar el error que llega desde el backend*/
    alert(msj.responseJSON);
};
