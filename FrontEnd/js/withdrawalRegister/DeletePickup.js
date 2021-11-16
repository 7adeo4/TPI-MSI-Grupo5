
// $(document).ready(function () {

//     mostrarTabla();
   

// });

// function DeletePickup(idPickup) {
  
//     comando = {
//       "idPickup": parseInt(idPickup)
      
//     };
  
//     $.ajax({
//       url: "https://localhost:5001/Pickup/DeletePickup",
//       type: "POST",
//       dataType: "json",
//       contentType: "application/json",
//       data: JSON.stringify(comando),
//       success: function (result) {
//         if (result.ok) {
//           alert("Retiro Eliminado");
//           console.log(comando);

//         mostrarTabla();
//         } else {
//           alert(result.error);
//         }
//       },
//       error: function (error) {
//         console.log(error);
//       },
//     });

    

//   }


  
// function mostrarTabla() {


//     $.ajax({
//         url: "https://localhost:5001/Pickup/GetListJoin",
//         type: "GET",
  
//         success: function (result) {
//             if (result.ok) {
//                 $("#cuerpoTabla").empty();
//                 for (var i = 0; i < result.return.$values.length; i++) {
//                     console.log('hola');
//                     var html = "<tr>";
                   
                    
//                     html += "<td>" + result.return.$values[i].idPickup.idPickup + "</td>";
//                     html += "<td>" + result.return.$values[i].idPickup.idDeliveryOrder + "</td>";                   
                    
//                     html += "<td>" + result.return.$values[i].idPickup.name + "</td>";
//                     html += "<td>" + result.return.$values[i].idDeliveryOrder.volume + "</td>";
//                     // html += "<td>" + result.return.$values[i].idPickup.deliveryDate + "</td>";

                   
//                     html +="<td><button type='button' id='btnEstado' class='btn btn-info' disabled> "+result.return.$values[i].idPickup.state1 + "</button></td>";
//                     // html += "<td><button  onclick=' DeletePickup(" +result.return.$values[i].state1 + ") ' > "+ result.return.$values[i].idPickup.state1 +"  </button></td>";
//                     html += "<td> <button type='button' id='btnActualizar' class='btn btn-outline-primary' data-bs-toggle='modal' data-bs-target='#ventanaModal'>Actualizar</button></td>";
//                     html +="<td><button type='button' onclick=' DeletePickup(" + result.return.$values[i].idPickup.idPickup + ") ' id='Aceptado' class='btn btn-outline-danger' data-bs-toggle='modal' data-bs-target='#ventanaModal2'>Eliminar</button></td>";
//                     // html += "<td><button  onclick=' DeletePickup(" + result.return.$values[i].idPickup.idPickup + ") ' >  Eliminar   </button></td>";
                   
//                     html += "</tr>";
            
//                     $("#cuerpoTabla").append(html);

//                     // var html2 = <button type="button" id="Aceptado" class="btn btn-success" data-bs-dismiss="modal">Aceptar</button>
//                     // $("#aceptarEliminar").append(html2);
            
//                 }              
                
//             } else {
//                 Swal.fire(result.error);  
//             }
//         },
//         error: function (error) {
//             console.log(error);
//         },
//     });

   
// }


$(document).ready(function () {
  mostrarTabla();
  var idATratar;
  var idEstadoTratar;
  

  $("#Aceptado2").click(function () {
    DeleteShipping();   
    
  });
  $("#Aceptado").click(function () {
    actualizarEstado();   
    
  });
  

});

function DeleteShipping() {
  comando = {
    "idPickup": parseInt(idATratar)
  };

  $.ajax({
    url: "https://localhost:5001/Pickup/DeletePickup",
    type: "POST",
    dataType: "json",
    contentType: "application/json",
    data: JSON.stringify(comando),
    success: function (result) {
      if (result.ok) {
        swal("Retiro Eliminado");
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
              "<td><button type='button' id='btnEstado" + result.return.$values[i].idPickup.idPickup +"' class='btn btn-info' disabled>" +
              result.return.$values[i].idPickup.state1 +
              "</button></td>";
              html +=
              "<td> <button type='button' onclick='estadoModal(\"#btnEstado" + result.return.$values[i].idPickup.idPickup +"\")' id='btnActualizar' class='btn btn-outline-primary' >Actualizar</button></td>";
          html +=
          "<td><button type='button' onclick='mostrarModal( \"#ventanaModal2\", "+ result.return.$values[i].idPickup.idPickup +")' class='btn btn-outline-danger'>Eliminar</button></td>";
         
          html += "</tr>";
          $("#cuerpoTabla").append(html);
         
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

function estadoModal(id) {
  $("#ventanaModal").modal("toggle");
  idEstadoTratar= id; 
   
}

function actualizarEstado(){debugger
  
  if ($(idEstadoTratar).hasClass('btn-info')) {
      $(idEstadoTratar).removeClass('btn-info').addClass('btn-warning');
      document.getElementById("Pregunta1").innerHTML =
          "¿Esta seguro que quiere cambiar el Estado a 'Retirado'?";
      $(idEstadoTratar).text('Listo para retirar');      
  }
  else if ($(idEstadoTratar).hasClass('btn-warning')) {
      $(idEstadoTratar).removeClass('btn-warning').addClass('btn-success');
      $(idEstadoTratar).text('Retirado')
      $(idEstadoTratar).attr('disabled', 'disabled');
      console.log("hola3");
  }
}