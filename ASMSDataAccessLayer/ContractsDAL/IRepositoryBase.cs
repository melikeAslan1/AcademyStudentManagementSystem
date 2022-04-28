using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASMSDataAccessLayer.ContractsDAL
{
    public interface IRepositoryBase<T, Id> where T: class, new() //bu T abstract olmayacak yani new lenebilir.
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null, 
            string includeEntities=null ); 

        // includeEntities inner join ile ilişkide olduğu entity getirecektir.
       T GetFirstOrDefault(Expression<Func<T, bool>> filter=null,
            string includeEntities = null);
            
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

    }
}
