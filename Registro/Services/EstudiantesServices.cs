using Registro.Models;
using Registro.Context;
using Microsoft.EntityFrameworkCore;



namespace Registro.Services;

public class EstudiantesServices{

private readonly IDbContextFactory<Contexto> contextFactory;

    private async Task<bool> Existe(int estudianteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AnyAsync(E => E.EstudianteId == estudianteId);
    }

    private async Task<bool> Insertar(Estudiante estudiante)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Estudiantes.Add(estudiante);
        return await  contexto.SaveChangesAsync() > 0;
        
    }

    public async Task<bool> Modificar(Estudiante estudiante)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(estudiante);
        return await contexto.SaveChangesAsync() > 0;
        
        
    }

    public async Task<bool> Guardar(Estudiante estudiante)
    {
        if(!await Existe(estudiante.EstudianteId))
        {
           return await  Insertar(estudiante);
        }
        else
        {
            return await Modificar(estudiante);
        }
        

    }

    public async Task<Estudiante?> Buscar(int estudianteid)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return contexto.Estudiantes.Include(I => I.EstudianteId).Include(I=> I.Nombre).FirstOrDefault(I => I.EstudianteId == estudianteid);
    }

    public async Task<bool> Eliminar(int estudianteId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
       return await contexto.Estudiantes.AsNoTracking().Where(I => I.EstudianteId == estudianteId).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Estudiante>> Listar()
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AsNoTracking().ToListAsync();
    }
}