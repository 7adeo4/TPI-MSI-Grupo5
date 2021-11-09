 const getTypeDocument = () => {
//   $(document).ready(function () {
//     $.ajax({
//       url: "https://localhost:5001/DocumentType/GetDocumentType",
//       type: "GET",
//       dataType: "json",
//       success: (result) => {
//         if (result.ok) {
//           var html = "<option value=''>Seleccione un tipo de DNI</option>";
//           $("#typeDni").append(html);
//           select = document.getElementById("typeDni");
//           for (let i = 0; i < result.return.length; i++) {
//             var option = document.createElement("option");
//             option.value = result.return[i].idTipoDocumento;
//             option.text = result.return[i].tipoDocumento1;
//             select.add(option);
//           }
//         } else {
//           swal(result.error);
//         }
//       },
//       error: function (error) {
//         swal("Problemas al conseguir los tipos de DNI");
//       },
//     });
//   });
// }
const url = 'https://pokeapi.co/api/v2/pokemon';

fetch(url)
  .then(response => response.json())
  .then(data => {
    let type = document.getElementById("typeDni");
    let html = document.createElement("option")
    html.value = "";
    html.text = "Seleccione un tipo de documento";
    type.appendChild(html);
    for (let i = 0; i < 5; i++) {
      let option = document.createElement("option");
      option.value = data.results[i].idDocumentType;
      option.text = data.results[i].document;
      type.add(option);
    }
  })
  .catch(error =>{
    swal("Error al traer los tipos de documentos")
    console.log(error)
  })
}