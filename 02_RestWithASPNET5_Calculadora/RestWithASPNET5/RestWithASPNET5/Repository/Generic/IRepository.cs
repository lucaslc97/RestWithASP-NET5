using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindbyId(long id);
        List<T> FindAll();
        T Update(T item);
        T Delete(long id);

    }
}
