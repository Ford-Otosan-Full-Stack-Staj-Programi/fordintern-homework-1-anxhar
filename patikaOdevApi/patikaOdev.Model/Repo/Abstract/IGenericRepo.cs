using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patikaOdevApi.Model;

public interface IGenericRepo<TEntity> where TEntity : class
{
    TEntity GetById(int entityID);
    void Insert(TEntity entity);
    void RemoveAsync(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GetAll();

}
