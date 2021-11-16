const form = document.getElementById('form');
const email = document.getElementById('email');
const password = document.getElementById('password');



form.addEventListener('submit', (e) => {
    e.preventDefault();
    // window.location.replace('Home.html');

    // const getEmailPass = () =>{
    axios({
        method: 'POST',
        url: 'https://localhost:5001/User/GetUserByEmailPass',
        data: {
            email: email.value,
            password: password.value,
        }

    }).then(res => {
         console.log(res.data) 
         console.log(res.data.return.idRol) 
         if(res.data.return.idRol == 3) window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/shippingRegister.html');
         if(res.data.return.idRol == 4) window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/updateWithdrawal.html');
         if(res.data.return.idRol == 1 || res.data.return.idRol == 2) window.location.assign('Home.html');
    })
        .catch(err => console.log(err))
    // }
});