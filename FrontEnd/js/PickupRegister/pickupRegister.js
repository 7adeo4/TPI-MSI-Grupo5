


function agregarAlumno(nombre, apellido, curso, legajo, regular) {
    comando = {
      nombre: nombre,
      apellido: apellido,
      curso: curso,
      regular: regular,
      legajo: legajo
    };
  
    $.ajax({
      url: "https://localhost:5001/Alumnos/CrearAlumno",
      type: "POST",
      dataType: "json",
      contentType: "application/json",
      data: JSON.stringify(comando),
      success: function (result) {
        if (result.ok) {
          alert("alumno cargado");
          console.log(comando);
        } else {
          alert(result.error);
        }
      },
      error: function (error) {
        console.log(error);
      },
    });
  }
 