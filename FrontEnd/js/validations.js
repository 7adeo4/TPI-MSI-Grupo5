const form = document.getElementById('form');
const inputs = document.querySelectorAll('#form input');

const expresions = {
	// usuario: /^[a-zA-Z0-9\_\-]{4,16}$/, // Letras, numeros, guion y guion_bajo
	name: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
	lastName: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
	password: /^.{4,12}$/, // 4 a 12 digitos.
	email: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
	phone: /^\d{9,14}$/, // 7 a 14 numeros.
	dni: /^\d{7,10}$/ // 7 a 14 numeros.
}

const campos = {
	name: false,
	lastName: false,
	password: false,
	email: false,
	phone: false,
	dni: false
}

const validateform = (e) => {
	switch (e.target.name) {
		case "name":
			validate(expresions.name, e.target, 'name');
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
	}
}

const validate = (expresion, input, campo) => {
	if (expresion.test(input.value)) {
		document.getElementById(`group__${campo}`).classList.remove('form__group-incorrect');
		document.getElementById(`group__${campo}`).classList.add('form__group-correct');
		document.querySelector(`#group__${campo} i`).classList.add('fa-check-circle');
		document.querySelector(`#group__${campo} i`).classList.remove('fa-times-circle');
		// document.querySelector(`#group__${campo} .form__input-error`).classList.remove('form__input-error-activo');
		campos[campo] = true;
	} else {
		document.getElementById(`group__${campo}`).classList.add('form__group-incorrect');
		document.getElementById(`group__${campo}`).classList.remove('form__group-correct');
		document.querySelector(`#group__${campo} i`).classList.add('fa-times-circle');
		document.querySelector(`#group__${campo} i`).classList.remove('fa-check-circle');
		// document.querySelector(`#group__${campo} .form__input-error`).classList.add('form__input-error-activo');
		campos[campo] = false;
	}
}

const validateConfirmPass = () => {
	const inputPassword1 = document.getElementById('password');
	const inputPassword2 = document.getElementById('confirmPass');

	if (inputPassword1.value !== inputPassword2.value) {
		document.getElementById(`group__confirmPass`).classList.add('form__group-incorrect');
		document.getElementById(`group__confirmPass`).classList.remove('form__group-correct');
		document.querySelector(`#group__confirmPass i`).classList.add('fa-times-circle');
		document.querySelector(`#group__confirmPass i`).classList.remove('fa-check-circle');
		// document.querySelector(`#group__confirmPass .form__input-error`).classList.add('form__input-error-activo');
		campos['password'] = false;
	} else {
		document.getElementById(`group__confirmPass`).classList.remove('form__group-incorrect');
		document.getElementById(`group__confirmPass`).classList.add('form__group-correct');
		document.querySelector(`#group__confirmPass i`).classList.remove('fa-times-circle');
		document.querySelector(`#group__confirmPass i`).classList.add('fa-check-circle');
		// document.querySelector(`#group__confirmPass .form__input-error`).classList.remove('form__input-error-activo');
		campos['password'] = true;
	}
}

inputs.forEach((input) => {
	input.addEventListener('keyup', validateform);
	input.addEventListener('blur', validateform);
});

form.addEventListener('submit', (e) => {
	e.preventDefault();

	const terms = document.getElementById('terms');
	if (campos.dni && campos.name && campos.password && campos.email && campos.lastName && campos.phone) {
		if (!terms.checked) {
			document.getElementById('terms-message').classList.add('terms-message-active');
		}
		else {
			insertUser();
			form.reset();

			document.getElementById('form__success-message').classList.add('form__success-message-active');
			setTimeout(() => {
				document.getElementById('form__success-message').classList.remove('form__success-message-active');
			}, 5000);
			document.getElementById('form__message').classList.remove('form__message-active');

			document.querySelectorAll('.form__group-correct').forEach((icono) => {
				icono.classList.remove('form__group-correct');
			});
		}
	}
	else {
		document.getElementById('form__message').classList.add('form__message-active');
	}
});