using RestWithASPNET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindbyId(long id);
        List<Person> FindAll();
        Person Update(Person person);
        Person Delete(long id);
        
    }
}
