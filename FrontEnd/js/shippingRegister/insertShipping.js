insertUser = () => {
    let user = document.getElementById("user").value;
    let order = document.getElementById("order").value;
    let company = document.getElementById("company").value;
    let date = document.getElementById("date").value;
    let weight = document.getElementById("weight").value;
    let volume = document.getElementById("volume").value;
    let bags = document.getElementById("bags").value;
    

    command = {
        idShippingCompany: parseInt(company),
        idDeliveryOrder: parseInt(order),
        idUser: parseInt(user),
        weight: weight,
        volume: volume,        
        bagsQuantity: parseInt(bags),
        
    };

    fetch("https://localhost:5001/Usuario/AltaUsuario", {
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
        })
        .catch(error => {console.log(error)
            swal("Problemas con el servidor")})




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