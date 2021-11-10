using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using RestWithASPNET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Business.Implementations
{
    public class PersonBusinessImplementations : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementations(IRepository<Person> repository)
        {
            _repository = repository;
        }
        public List<Person> FindAll()
        {

            return _repository.FindAll();
        }

        

        public Person FindbyId(long id)
        {
            return _repository.FindbyId(id);
        }
        public Person Create(Person person)
        {

            return _repository.Create(person);
        }
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public Person Delete(long id)
        {

            _repository.Delete(id);

            return null;
        }
     
    }
}
