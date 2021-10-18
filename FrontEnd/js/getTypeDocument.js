$(document).ready(function () {
    $.ajax({
      url: "https://localhost:5001/Deportes/ObtenerDeportes",
      type: "GET",
      dataType: "json",
      success: (result) => {
        if (result.ok) {
          var html = "<option value=''>Seleccione un tipo de DNI</option>";
          $("#typeDni").append(html);
          select = document.getElementById("typeDni");
          for (let i = 0; i < result.return.length; i++) {
            var option = document.createElement("option");
            option.value = result.return[i].id_tipo_documento; 
            option.text = result.return[i].tipo_documento;
            select.add(option);
          }
        } else {
          swal(result.error);
        }
      },
      error: function (error) {
        swal("Problemas al conseguir los tipos de DNI");
      },
    });
  });