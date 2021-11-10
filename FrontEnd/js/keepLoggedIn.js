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
getEmail();
