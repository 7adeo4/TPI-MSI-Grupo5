const getRol = () => {
  
  const url = 'https://pokeapi.co/api/v2/pokemon';

  fetch(url)
    .then(response => response.json())
    .then(data => {
      let rol = document.getElementById("rolUser");
      let html = document.createElement("option")
      html.value = "";
      html.text = "Seleccione un rol";
      rol.appendChild(html);
      for (let i = 0; i < 5; i++) {
        let option = document.createElement("option");
        option.value = data.results[i].idRol;
        option.text = data.results[i].rol;
        rol.add(option);
      }
    })
    .catch(error =>{
      swal("Error al traer los roles")
      console.log(error)
    })
}
