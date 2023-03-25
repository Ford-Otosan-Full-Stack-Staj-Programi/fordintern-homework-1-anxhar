using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patikaOdevApi.Model;
public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
{
    private readonly ApiDbContext context;
    private DbSet<TEntity> entities;
    public GenericRepo(ApiDbContext context) 
    {
        this.context = context;
        this.entities = this.context.Set<TEntity>();
    }

    public List<TEntity> GetAll()
    {
        return entities.ToList();
    }
    public TEntity GetById(int entityID)
    {
        return entities.Find(entityID);
    }
    public void Insert(TEntity entity)
    {
        entities.Add(entity);
    }
    public void RemoveAsync(TEntity entity)
    {
        var column = entity.GetType().GetProperty("IsDeleted");
        if (column is not null)
        {
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
        }
        else
        {
            entities.Remove(entity);
        }
    }
    public void Update(TEntity entity)
    {
        entities.Update(entity);
    }
    public IEnumerable<>
}
