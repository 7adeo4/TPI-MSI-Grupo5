$(document).ready(function () {
    $.ajax({
      url: "https://localhost:5001/Deportes/ObtenerDeportes",
      type: "GET",
      dataType: "json",
      success: (result) => {
        if (result.ok) {
          var html = "<option value=''>Seleccione un rol</option>";
          $("#rolUser").append(html);
          select = document.getElementById("rolUser");
          for (let i = 0; i < result.return.length; i++) {
            var option = document.createElement("option");
            option.value = result.return[i].idRol;
            option.text = result.return[i].rol;
            select.add(option);
          }
        } else {
          swal(result.error);
        }
      },
      error: function (error) {
        swal("Problemas al conseguir los roles");
      },
    });
  });

  