const getCompany = () => {
const url = 'https://pokeapi.co/api/v2/pokemon';

fetch(url)
  .then(response => response.json())
  .then(data => {
    let company = document.getElementById("company");
    let html = document.createElement("option")
    html.value = "";
    html.text = "Seleccione una empresa";
    company.appendChild(html);
    for (let i = 0; i < 5; i++) {
      let option = document.createElement("option");
      // option.value = i;
      option.text = data.results[i].name;
      company.add(option);
    }
  })
  .catch(error =>console.log(error))
}