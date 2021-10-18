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
            option.value = result.return[i].idTipoDocumento; 
            option.text = result.return[i].tipoDocumento1;
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