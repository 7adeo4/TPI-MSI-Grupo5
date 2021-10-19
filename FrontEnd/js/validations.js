// let form = document.getElementById("form");
// form.addEventListener("submit", function (e) {
//   let name = document.getElementById("name");
//   let lastName = document.getElementById("lastName");
//   let email = document.getElementById("email");
//   let password = document.getElementById("password");
//   let confirmPass = document.getElementById("confirmPass");
//   let phone = document.getElementById("phone");
//   let acceptTerms = document.getElementsByName("acceptTerms");
//   let validate = true;
//   let checkTerms = false;
//   e.preventDefault();

//   let error = document.createElement("div");
//   let div = document.getElementById("alertName");
//   if (name.value === "") {
//     error.innerHTML="<span>Please enter a name</span>";
//     div.appendChild(error);
//     validate = false;
//     console.log(error);
//   } else if (!isNaN(name.value)) {
//     document.getElementById("alertName").innerHTML = "Bienvenido a este sitio"
//     validate = false;
//   } else {
//     div.removeChild(error);
//   }
// });

const form = document.getElementById('form');
const inputs = document.querySelectorAll('#form input');

const expresions = {
	// usuario: /^[a-zA-Z0-9\_\-]{4,16}$/, // Letras, numeros, guion y guion_bajo
	name: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
	lastName: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
	password: /^.{4,12}$/, // 4 a 12 digitos.
	email: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
	phone: /^\d{7,14}$/, // 7 a 14 numeros.
	dni: /^\d{7,14}$/ // 7 a 14 numeros.
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
			// validarPassword2();
		break;
		case "confirmPass":
			// validarPassword2();
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
	if(expresion.test(input.value)){
		document.getElementById(`grupo__${campo}`).classList.remove('form__grupo-incorrecto');
		document.getElementById(`grupo__${campo}`).classList.add('form__grupo-correcto');
		document.querySelector(`#grupo__${campo} i`).classList.add('fa-check-circle');
		document.querySelector(`#grupo__${campo} i`).classList.remove('fa-times-circle');
		// document.querySelector(`#grupo__${campo} .form__input-error`).classList.remove('form__input-error-activo');
		campos[campo] = true;
	} else {
		document.getElementById(`grupo__${campo}`).classList.add('form__grupo-incorrecto');
		document.getElementById(`grupo__${campo}`).classList.remove('form__grupo-correcto');
		document.querySelector(`#grupo__${campo} i`).classList.add('fa-times-circle');
		document.querySelector(`#grupo__${campo} i`).classList.remove('fa-check-circle');
		// document.querySelector(`#grupo__${campo} .form__input-error`).classList.add('form__input-error-activo');
		campos[campo] = false;
	}
}

// const validarPassword2 = () => {
// 	const inputPassword1 = document.getElementById('password');
// 	const inputPassword2 = document.getElementById('confirmPass');

// 	if(inputPassword1.value !== inputPassword2.value){
// 		document.getElementById(`grupo__password2`).classList.add('form__grupo-incorrecto');
// 		document.getElementById(`grupo__password2`).classList.remove('form__grupo-correcto');
// 		document.querySelector(`#grupo__password2 i`).classList.add('fa-times-circle');
// 		document.querySelector(`#grupo__password2 i`).classList.remove('fa-check-circle');
// 		document.querySelector(`#grupo__password2 .form__input-error`).classList.add('form__input-error-activo');
// 		campos['password'] = false;
// 	} else {
// 		document.getElementById(`grupo__password2`).classList.remove('form__grupo-incorrecto');
// 		document.getElementById(`grupo__password2`).classList.add('form__grupo-correcto');
// 		document.querySelector(`#grupo__password2 i`).classList.remove('fa-times-circle');
// 		document.querySelector(`#grupo__password2 i`).classList.add('fa-check-circle');
// 		document.querySelector(`#grupo__password2 .form__input-error`).classList.remove('form__input-error-activo');
// 		campos['password'] = true;
// 	}
// }

inputs.forEach((input) => {
	input.addEventListener('keyup', validateform);
	input.addEventListener('blur', validateform);
});

form.addEventListener('submit', (e) => {
	e.preventDefault();

	// const terminos = document.getElementById('terminos');
	// if(campos.usuario && campos.nombre && campos.password && campos.correo && campos.telefono && terminos.checked ){
	// 	form.reset();

	// 	document.getElementById('form__mensaje-exito').classList.add('form__mensaje-exito-activo');
	// 	setTimeout(() => {
	// 		document.getElementById('form__mensaje-exito').classList.remove('form__mensaje-exito-activo');
	// 	}, 5000);

	// 	document.querySelectorAll('.form__grupo-correcto').forEach((icono) => {
	// 		icono.classList.remove('form__grupo-correcto');
	// 	});
	// } else {
	// 	document.getElementById('form__mensaje').classList.add('form__mensaje-activo');
	// }
});