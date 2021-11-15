
let keepLog = false;
localStorage.setItem("keepLog", keepLog);
let emailOpen;
// if (insertUser()) {
//     emailOpen = document.getElementById("Email").value;
// }
const setEmail = () => {
    emailOpen = document.getElementById("email").value;
    localStorage.setItem("email", emailOpen);
}

const getEmail = () => {
    document.getElementById("userEmail").textContent = localStorage.getItem("email");
    // document.getElementById("userEmail").disabled = true;
    console.log(localStorage.getItem("email"));
}
// getEmail();

const goLogOut = (e) => {
    keepLog = false;
    localStorage.setItem("keepLog", keepLog);
    window.location.replace('../joinPage.html');
    console.log(localStorage.getItem("keepLog"));
}

const goLogIn = () => {
    keepLog = true;
    localStorage.setItem("keepLog", keepLog);
    window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/Home.html');
    console.log(localStorage.getItem("keepLog"));
}

const verifyLogin = () => {
    if (!localStorage.getItem("keepLog")) {
        window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/Home.html');
    }
    else {
        window.location.assign('http://127.0.0.1:5500/TPI-MSI-Grupo5/FrontEnd/views/login.html')
    }
}




