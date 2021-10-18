$("#submit").click(function () {
    let name = $("#name").val();
    let lastName = $("#lastName").val();
    let dni = $("#dni").val();
    let typeDni = $("#typeDni").val();
    let email = $("#email").val();
    let phone = $("#phone").val();
    let rolUser = $("#rolUser").val();
    let password = $("#password").val();
    
    insertUser(name,lastName, dni, typeDni, email, phone, rolUser, password);
    
});

insertUser = (name, lastName, dni, typeDni, email, phone , rolUser, password) => {
    command = {
        name: name,
        lastName: lastName,
        dni: dni,
        calle: calle,
        typeDni: parseInt(typeDni),
        email: email,
        phone: phone,
        rolUser: parseInt(rolUser),
        password: password,
    };

    $.ajax({
        url: "https://localhost:5001/Socios/CrearSocio",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json",
        data: JSON.stringify(command),
        success: function (result) {
            if (result.ok) {
                swal("Vaaaaamooo lxs piii");
            } else {
                swal(result.error);
            }
        },
        error: function (error) {
            swal("Problemas en el servidor");
        },
    });
}