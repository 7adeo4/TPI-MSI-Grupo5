let form = document.getElementById("form");
form.addEventListener("submit", function (e) {
    let name = document.getElementById("name");
    let lastName = document.getElementById("lastName");
    let email = document.getElementById("email");
    let password = document.getElementById("password");
    let confirmPass = document.getElementById("confirmPass");
    let phone = document.getElementById("phone");
    let acceptTerms = document.getElementsByName("acceptTerms");
    let validate = true;
    let checkTerms = false;
    e.preventDefault();

    if (name.value === "") {
       document.getElementById("alertName").innerHTML = "Bienvenido a este sitio"
        validate = false;
      } else if (!isNaN(name.value)) {
       document.getElementById("alertName").innerHTML = "Bienvenido a este sitio"
        validate = false;
      } else {
        document.getElementById("alertName").remove()
      }
});