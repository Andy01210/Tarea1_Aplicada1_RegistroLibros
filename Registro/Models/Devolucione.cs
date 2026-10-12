using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro.Models;

public class Devolucion
{
    [Key]
    public int DevolucionId { get; set; }

    [Required(ErrorMessage = "No hay préstamo para devolver")]
    public int PrestamoId { get; set; }

    [ForeignKey("PrestamoId")]
    public Prestamo? prestamo { get; set; }

    public DateOnly FechaPrestamo { get; set; }
    public DateOnly FechaDevolucion { get; set; }
}