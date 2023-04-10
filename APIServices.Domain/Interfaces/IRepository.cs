using APIServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {

        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expresssion);


    }
}
