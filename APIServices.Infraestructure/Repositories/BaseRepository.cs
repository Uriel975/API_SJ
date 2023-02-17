using APIServices.Domain.Entities;
using APIServices.Domain.Interfaces;
using APIServices.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APIServices.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BDPServicesContext _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(BDPServicesContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        //Modificaciones
        public async Task<IEnumerable<T>> GetAll()
        {

            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
             await _entities.AddAsync(entity);
        }
        //Modificaciones
        public async Task Update(T entity)
        {

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);

        }

        // Nuevas lineas de codigo
        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expresssion)
        {
            return await _entities.Where(expresssion).AsNoTracking().ToListAsync();
        }
    }
}
