using Registro.Models;
using Microsoft.EntityFrameworkCore;
using Registro.Context;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

public class PrestamosServices(IDbContextFactory<Contexto> contextFactory)
{
    private async Task<bool> Existe(int prestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Prestamos.AnyAsync(d => d.PrestamoId == prestamoId);
    }

    private async Task<bool> Insertar(Prestamo prestamo)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Prestamos.Add(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Prestamo prestamo)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(prestamo);
        return await contexto.SaveChangesAsync()>0;
    }

    public async Task<bool> Guardar(Prestamo prestamo)
    {
        if(!await Existe(prestamo.PrestamoId))
        {
            return await Insertar(prestamo);
        }
        else
        {
            return await Modificar(prestamo);
        }
    }

    public async Task<bool> Eliminar(int prestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Prestamos.AsNoTracking().Where( d => d.PrestamoId == prestamoId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Prestamo?> Buscar(int prestamoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Prestamos.AsNoTracking().FirstOrDefaultAsync(d => d.PrestamoId == prestamoId);
    }

    public async Task<List<Prestamo>> ListarTodo()
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Prestamos.Include(p=> p.Libro).Include(p=>p.Estudiante).AsNoTracking().ToListAsync();
        
    }

    
    public async Task<List<Prestamo>> Listar(Expression<Func<Prestamo, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Prestamos.Where(criterio).Include(p=> p.Libro).Include(p=>p.Estudiante).AsNoTracking().ToListAsync();
        
    }
    
    





}
