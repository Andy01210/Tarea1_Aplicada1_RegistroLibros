namespace Registro.Services;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Registro.Context;
using Registro.Models;
using SQLitePCL;

public class LibroService(IDbContextFactory<Contexto> DbFactory)
    {
         public async Task<bool> Guardar(Libro p)
    {
        if(!await Existe(p.LibroId))
        {
           return await Insertar(p);
        }
        else
        {
            return await Modificar(p);
        }
        
        
    }
    private async Task<bool> Existe(int libroId)
    {
        
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Libro.AnyAsync(p => p.LibroId ==libroId);
    }

    private async Task<bool> Insertar(Libro libro)
    {
         await using var Contexto = await DbFactory.CreateDbContextAsync();
         Contexto.Libro.Add(libro);
        return await Contexto.SaveChangesAsync() > 0;
        
    }

    public async Task<bool> Modificar(Libro libro)
    {
         await using var Contexto = await DbFactory.CreateDbContextAsync();
         Contexto.Update(libro);
        return await Contexto.SaveChangesAsync() > 0;
        
    }

    public async Task<Libro?> Buscar(int libroId)
    {
         await using var Contexto = await DbFactory.CreateDbContextAsync();
      
        return await Contexto.Libro.AsNoTracking().FirstOrDefaultAsync(d=> d.LibroId == libroId);
        
    }

    public async Task<bool> Eliminar(int libroId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Libro.AsNoTracking().Where(d=> d.LibroId == libroId).ExecuteDeleteAsync()> 0;
        
    }

    public async Task<List<Libro>> Listar(Expression<Func<Libro, bool>>criterio)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Libro.AsNoTracking().ToListAsync();
        
    }

      public async Task<List<Libro>> ObtenerTodos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libro
            .AsNoTracking().ToListAsync();
    }
   
        



    }
   


    
    

