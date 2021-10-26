using RestWithASPNET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET5.Services.Implementations
{
    public class PersonServicesImplementations : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public Person Delete(long id)
        {
            return null;
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            };
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirtName = "Person Name" + i,
                LastName = "Person Last name" + i,
                Adress = "Some adress" + i,
                Gender = "Male"
            };
        }

        public Person FindbyId(long id)
        {
            return new Person
            {
                Id = 1,
                FirtName = "Lucas",
                LastName = "Cabral",
                Adress = "Duque de Caxias/RJ",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
