using System.ComponentModel.DataAnnotations;

namespace Registro.Models;

public class Estudiante{

    [Key]
    public int EstudianteId{get; set;}

    [Required (ErrorMessage="El nombre debe ser obligatorio")]
    public string Nombre{get; set;}

    [Required (ErrorMessage="La direccion debe ser obligatoria")]
    public string Direccion{get; set;}

    [Required (ErrorMessage="Email debe ser obligatorio")]
    public string Email{get; set;}

    [Required (ErrorMessage="Fecha de nacimiento debe ser obligatoria")]
    public DateOnly FechaDeNacimiento{get; set;}

}