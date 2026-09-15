using System.ComponentModel.DataAnnotations;
namespace Registro.Models;

public class Libro{
[Key] 
public int LibroId { get; set; } 
public string? Titulo { get; set; }

public string? Autor{get; set;}

public int AnoPublicacion{get; set;}

}
