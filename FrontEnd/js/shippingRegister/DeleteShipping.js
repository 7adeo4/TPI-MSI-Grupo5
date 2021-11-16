
$(document).ready(function () {
    mostrarTabla();
    var idATratar;
  
    $("#Aceptado2").click(function () {
      DeleteShipping();
      alert("Se borró con éxito");
      // $("#ventanaModal2").modal("toggle");
    });
  });
  
  function DeleteShipping() {
    comando = {
      "idShipping": parseInt(idATratar)
    };
  
    $.ajax({
      url: "https://localhost:5001/Shipping/DeleteShipping",
      type: "POST",
      dataType: "json",
      contentType: "application/json",
      data: JSON.stringify(comando),
      success: function (result) {
        if (result.ok) {
          alert("Envío Eliminado");
          console.log(comando);
  
          mostrarTabla();
        } else {
          alert(result.error);
        }
      },
      error: function (error) {
        console.log(error);
      }
    });
  }
  
  function mostrarModal(idModal, id) {
    $(idModal).modal("toggle");
    idATratar = id;  
  }
  
  function mostrarTabla() {
    $.ajax({
      url: "https://localhost:5001/Pickup/GetListJoin",
      type: "GET",
  
      success: function (result) {
        if (result.ok) {
          $("#cuerpoTabla").empty();
          for (var i = 0; i < result.return.$values.length; i++) {
            
            let f = new Intl.DateTimeFormat('en');
            let a = f.formatToParts();
            // var id = result.return.$values[i].idPickup.idPickup;
            var html = "<tr>";
  
            html += "<td>" + result.return.$values[i].idPickup.idPickup + "</td>";
            html +=
              "<td>" +
              result.return.$values[i].idPickup.idDeliveryOrder +
              "</td>";
            html +=
              "<td>" + result.return.$values[i].idDeliveryOrder.volume + "</td>";
  
            html += "<td>" + result.return.$values[i].idPickup.name + "</td>";
            html += "<td>" + result.return.$values[i].idPickup.deliveryDate + "</td>";
  
            html +=
              "<td><button type='button' id='btnEstado' class='btn btn-info' disabled> " +
              result.return.$values[i].idPickup.state1 +
              "</button></td>";
            // html += "<td><button  onclick=' DeletePickup(" +result.return.$values[i].state1 + ") ' > "+ result.return.$values[i].idPickup.state1 +"  </button></td>";
            html +=
              "<td> <button type='button' id='btnActualizar' class='btn btn-outline-primary' data-bs-toggle='modal' data-bs-target='#ventanaModal'>Actualizar</button></td>";
            html +=
            "<td><button type='button' onclick='mostrarModal( \"#ventanaModal2\", "+ result.return.$values[i].idPickup.idPickup +")' class='btn btn-outline-danger'>Eliminar</button></td>";
            
            // html += "<td><button  onclick=' DeletePickup(" + result.return.$values[i].idPickup.idPickup + ") ' >  Eliminar   </button></td>";
  
            // + result.return.$values[i].idPickup.idPickup
            html += "</tr>";
            $("#cuerpoTabla").append(html);
            // var html2 = <button type="button" id="Aceptado" class="btn btn-success" data-bs-dismiss="modal">Aceptar</button>
            // $("#aceptarEliminar").append(html2);
          }
        } else {
          Swal.fire(result.error);
        }
      },
      error: function (error) {
        console.log(error);
      }
    });
  }