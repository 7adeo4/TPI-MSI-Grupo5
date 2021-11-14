const form = document.getElementById('form');
const inputs = document.querySelectorAll('#form input');
const selects = document.querySelectorAll('#form select');
const closeSesion = document.getElementById('closeSesion');
// getTypeDocument();
// getRol();

const expresions = {
    // usuario: /^[a-zA-Z0-9\_\-]{4,16}$/, // Letras, numeros, guion y guion_bajo
    reason: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
    password: /^.{4,12}$/, // 4 a 12 digitos.
    email: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
    phone: /^\d{9,14}$/, // 7 a 14 numeros.
    dni: /^\d{7,10}$/ // 7 a 14 numeros.
}

const attributes = {
    reason: false,
    password: false,
    email: false,
    phone: false,
    dni: false,
    rolUser: false,
    typeDni: false,
}

const validateform = (e) => {
    switch (e.target.name) {
        case "reason":
            validate(expresions.reason, e.target, 'reason');
            break;
        case "lastName":
            validate(expresions.lastName, e.target, 'lastName');
            break;
        case "password":
            validate(expresions.password, e.target, 'password');
            validateConfirmPass();
            break;
        case "confirmPass":
            validateConfirmPass();
            break;
        case "email":
            validate(expresions.email, e.target, 'email');
            break;
        case "phone":
            validate(expresions.phone, e.target, 'phone');
            break;
        case "dni":
            validate(expresions.dni, e.target, 'dni');
            break;
        case "rolUser":
            validateRolUser();
            break;
    }
}
const validate = (expresion, input, attribute) => {
    if (expresion.test(input.value)) {
        document.getElementById(`group__${attribute}`).classList.remove('form__group-incorrect');
        document.getElementById(`group__${attribute}`).classList.add('form__group-correct');
        document.querySelector(`#group__${attribute} i`).classList.add('fa-check-circle');
        document.querySelector(`#group__${attribute} i`).classList.remove('fa-times-circle');
        attributes[attribute] = true;
    } else {
        document.getElementById(`group__${attribute}`).classList.add('form__group-incorrect');
        document.getElementById(`group__${attribute}`).classList.remove('form__group-correct');
        document.querySelector(`#group__${attribute} i`).classList.add('fa-times-circle');
        document.querySelector(`#group__${attribute} i`).classList.remove('fa-check-circle');
        attributes[attribute] = false;
    }
}
const validateRolUser = () => {
    const rolUser = document.getElementById('rolUser');
    if (rolUser.value == "" || rolUser.value == 0) {
        document.getElementById(`group__rolUser`).classList.add('form__group-incorrect');
        document.getElementById(`group__rolUser`).classList.remove('form__group-correct');
        document.querySelector(`#group__rolUser i`).classList.add('fa-times-circle');
        document.querySelector(`#group__rolUser i`).classList.remove('fa-check-circle');
        attributes.rolUser = false;
    } else {
        document.getElementById(`group__rolUser`).classList.remove('form__group-incorrect');
        document.getElementById(`group__rolUser`).classList.add('form__group-correct');
        document.querySelector(`#group__rolUser i`).classList.remove('fa-times-circle');
        document.querySelector(`#group__rolUser i`).classList.add('fa-check-circle');
        attributes.rolUser = true;
    }
}

// closeSesion.addEventListener('onclick', goLogOut);

inputs.forEach((input) => {
    input.addEventListener('keyup', validateform);
    input.addEventListener('blur', validateform);
});

selects.forEach((select) => {
    select.addEventListener('keyup', validateform);
    select.addEventListener('blur', validateform);
});

form.addEventListener('submit', (e) => {
    e.preventDefault();
    const terms = document.getElementById('terms');
    if (attributes.dni && attributes.reason && attributes.password && attributes.email && attributes.lastName && attributes.phone) {
        setEmail();
        window.location.replace('Home.html');
        form.reset();
        document.getElementById('form__success-message').classList.add('form__success-message-active');
        setTimeout(() => {
            document.getElementById('form__success-message').classList.remove('form__success-message-active');
        }, 5000);
        document.getElementById('form__message').classList.remove('form__message-active');
        document.getElementById('terms-message').classList.remove('terms-message-active');
        document.querySelectorAll('.form__group-correct').forEach((icono) => {
            icono.classList.remove('form__group-correct');
        });
    }
    else {
        document.getElementById('form__message').classList.add('form__message-active');
    }
});