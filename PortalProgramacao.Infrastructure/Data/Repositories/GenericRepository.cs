using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Data.Repositories
{

    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : Entity<TKey>
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public T? Get(TKey id)
        {
            try
            {
                return _context.Set<T>().FirstOrDefault(x => x.Id != null && x.Id.Equals(id));
            }
            catch(Exception ex)
            {
                //log the issue
                return null;
            }
        }

        public async Task<T?> GetAsync(TKey id)
        {
            try
            {
                return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id != null && x.Id.Equals(id));
            }
            catch(Exception ex)
            {
                 //log the issue
                return null;
            }
        }

        public void Save(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                //log the issue 
            }
            
        }

        public async Task SaveAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                 //log the issue
            }
        }

        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                //log the issue
            }
        }

        public void Delete(TKey id)
        {
            try
            {
                var entities = _context.Set<T>();
                var entityToRemove = entities.FirstOrDefault(x => x.Id != null && x.Id.Equals(id));
                if (entityToRemove != null)
                    entities.Remove(entityToRemove);
            }
            catch (Exception ex)
            {
                //log the issue
            }
        }
        public IQueryable<T> Entities => _context.Set<T>().AsQueryable();

    }
}
