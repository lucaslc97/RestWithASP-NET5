﻿using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repository.Implementations
{
    public class PersonRepositoryImplementations : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepositoryImplementations(MySqlContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }

        

        public Person FindbyId(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                 _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result =_context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

           
            return person;
        }

        public Person Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));


            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return null;
        }



        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
