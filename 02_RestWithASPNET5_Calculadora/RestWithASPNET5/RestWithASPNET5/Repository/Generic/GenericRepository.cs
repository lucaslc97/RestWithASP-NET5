using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Model.Base;
using RestWithASPNET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySqlContext _context;

        private DbSet<T> DataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            DataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                DataSet.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return item;
        }

        public T Delete(long id)
        {
            var result = DataSet.SingleOrDefault(p => p.Id.Equals(id));


            if (result != null)
            { 
                try
                    {
                        DataSet.Remove(result);
                        _context.SaveChanges();
                    }
            catch (Exception)
                    {

                        throw;
                    }
            }
            return null;
        }

        public List<T> FindAll()
        {
            return DataSet.ToList();
        }

        public T FindbyId(long id)
        {
            return DataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = DataSet.SingleOrDefault(p => p.Id.Equals(item.Id));


            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public bool Exists(long id)
        {
            return DataSet.Any(p => p.Id.Equals(id));
        }
    }
}
