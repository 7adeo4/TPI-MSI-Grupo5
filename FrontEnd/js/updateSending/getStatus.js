const getStatus = () => {
    const url = 'https://pokeapi.co/api/v2/pokemon';
    
    fetch(url)
      .then(response => response.json())
      .then(data => {
        let status = document.getElementById("status");
        let html = document.createElement("option")
        html.value = "";
        html.text = "Seleccione un estado";
        status.appendChild(html);
        for (let i = 0; i < 5; i++) {
          let option = document.createElement("option");
          // option.value = i;
          option.text = data.results[i].name;
          status.add(option);
        }
      })
      .catch(error =>console.log(error))
    }