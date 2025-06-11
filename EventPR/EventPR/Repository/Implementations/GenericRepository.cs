using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var existingEntity = await _dbSet.FindAsync(entity.Id);
        if (existingEntity == null) return null;

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        return existingEntity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        entity.IsDeletet = true;
        _dbSet.Update(entity);
        return true;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking()
            .Where(e => !e.IsDeletet)
            .ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeletet);
        
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

