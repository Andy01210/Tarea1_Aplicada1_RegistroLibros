namespace Registro.Context;
using Microsoft.EntityFrameworkCore;
using Registro.Models;


public class Contexto: DbContext{

    public Contexto(DbContextOptions<Contexto> options): base(options){

    }
    public DbSet<Libro> Libro {get; set;}

}