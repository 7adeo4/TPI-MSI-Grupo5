insertUser = () => {
    let name = document.getElementById("name").value;
    let lastName = document.getElementById("lastName").value;
    let dni = document.getElementById("dni").value;
    let typeDni = document.getElementById("typeDni").value;
    let email = document.getElementById("email").value;
    let phone = document.getElementById("phone").value;
    let rolUser = document.getElementById("rolUser").value;
    let password = document.getElementById("password").value;

    command = {
        name: name,
        surname: lastName,
        documentNumber: dni,
        idDocumentType: parseInt(typeDni),
        email: email,
        phone: phone,
        idRol: parseInt(rolUser),
        password: password,
    };

    fetch("https://localhost:5001/User/RegisterUser", {
        method: 'POST',
        body: JSON.stringify(command),
        headers: {
            "Content-type": "application/json"
        }
    })
        .then(res => res.json())
        .then(data => {
            console.log(data)
            if (data === 'error') console.log(result.error);
            else swal('Datos ingresados correctamente');
            window.location.replace('Home.html');
        })
        .catch(error => {
            console.log(error)
            swal("Problemas con el servidor")
        })




    // $.ajax({
    //     url: "https://localhost:5001/Usuario/AltaUsuario",
    //     type: "POST",
    //     dataType: "JSON",
    //     contentType: "application/json",
    //     data: JSON.stringify(command),
    //     success: function (result) {
    //         if (result.ok) {
    //             swal("Vaaaaamooo lxs piii");
    //         } else {
    //             swal(result.error);
    //         }
    //     },
    //     error: function (error) {
    //         swal("Problemas en el servidor");
    //     },

    // });
}
