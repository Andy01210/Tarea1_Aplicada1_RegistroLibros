using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Registro.Models;

public class Prestamo
{

    [Key]
    public int PrestamoId{get; set;}

    [Required(ErrorMessage = "Debe elegir un libro")]
    public int LibroId{ get; set;}

    [Required(ErrorMessage = "Debe elegir un estudiante")]
    public int EstudianteId{get; set;}

    [ForeignKey("LibroId")]
    public Libro? Libro { get; set; }

    [ForeignKey("EstudianteId")]
    [Required(ErrorMessage = "Debe elegir un estudiante")]
    public Estudiante? Estudiante { get; set; }

    [Required(ErrorMessage = "Debe ingresar la fecha en la que se realizo el prestamo")]
    public DateOnly FechaPrestamo{get; set;}

    [Required(ErrorMessage = "Debe ingresar la fecha de ddebolucion")]
    public DateOnly Fechadevolucion { get; set; }

    


}