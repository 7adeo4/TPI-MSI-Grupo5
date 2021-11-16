
const formLogin = document.getElementById('formLogin');
const emailLogin = document.getElementById('emailLogin');
const passwordLogin = document.getElementById('passwordLogin');
const emailLoginNav = document.getElementById('userNav');
let nameSurname
let keepLog = false;

const goLogOut = (e) => {
    keepLog = false;
    localStorage.setItem("keepLog", keepLog);
    window.location.replace('../joinPage.html');
}

const goLogIn = () => {
    keepLog = true;
    localStorage.setItem("keepLog", keepLog);
    window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/Home.html');
}

const verifyLogin = () => {
    if (!localStorage.getItem("keepLog")) {
        window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/Home.html');
    }
    else {
        window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/login.html')
    }
}

const getEmailPass = () => {
    axios({
        method: 'POST',
        url: 'https://localhost:5001/User/GetUserByEmailPass',
        data: {
            email: emailLogin.value,
            password: passwordLogin.value,
        }
    }).then(res => {
        if (res.data.return.idRol == 1 || res.data.return.idRol == 2) window.location.assign('Home.html');
        if (res.data.return.idRol == 3) window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/shippingRegister.html');
        if (res.data.return.idRol == 4) window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/updateWithdrawal.html');
        nameSurname = res.data.return.name + ' ' + res.data.return.surname
        localStorage.setItem("userPassword", nameSurname);
    })
        .catch(err => {
            console.log(err)
            swal("Email o contraseña incorrecto")
        })
}









