using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro.Models;

public class Devolucion{

    [Key]
    public int DevolucionId{get; set;}
    [Required(ErrorMessage = "No hay prestamo para devolcer")]
    public int Pretsmaoid{get; set;}

    [ForeignKey("Pretsmaoid")]
    public Prestamo? prestamo{get; set;}

    public DateOnly FechaPrestamo{get; set;}

    public DateOnly FechaDevolucion{get; set;}
}
