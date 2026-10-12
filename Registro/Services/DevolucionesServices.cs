using Registro.Models;
using Microsoft.EntityFrameworkCore;
using Registro.Context;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

public class DevolucionesServices(IDbContextFactory<Contexto> contextFactory)
{
    private async Task<bool> Existe(int devolucionId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Devoluciones.AnyAsync(d => d.DevolucionId == devolucionId);
    }

    private async Task<bool> Insertar(Devolucion devolucion)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Devoluciones.Add(devolucion);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Devolucion devolucion)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
         contexto.Devoluciones.Update(devolucion);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Devolucion devolucion)
    {
        if(!await Existe(devolucion.DevolucionId))
        {
            return await Insertar(devolucion);
        }
        else
        {
            return await Modificar(devolucion);
        }
    }

    public async Task<bool> Eliminar(int devolucionId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Devoluciones.AsNoTracking().Where( d => d.DevolucionId == devolucionId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Devolucion?> Buscar(int devolucionId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Devoluciones.AsNoTracking().FirstOrDefaultAsync(d => d.DevolucionId == devolucionId);
    }

    public async Task<List<Devolucion>> ListarTodo()
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Devoluciones.Include(p=> p.prestamo.Libro).Include(p=>p.prestamo.Estudiante).AsNoTracking().ToListAsync();
    }

    
    public async Task<List<Devolucion>> Listar(Expression<Func<Devolucion, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Devoluciones.Where(criterio).Include(p=> p.prestamo.Estudiante).Include(p=>p.prestamo.Libro).AsNoTracking().ToListAsync();
        
    }
}
