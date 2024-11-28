using System;
using PersonMicroservice.Model;

namespace PersonMicroservice.Services.Implementations
{
	public class PersonServiceImplementation: IPersonService
	{
        private volatile int count;

        public PersonServiceImplementation()
		{
		}

        public Person Create(Person person)
        {
            return MockPerson(person);
        }

        public void Delete(long id)
        {
            return;
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);

            }

            return people;
        }


        public Person FindById(long id)
        {
            return new Person
            {
                Id = id,
                FirstName = "Some Name",
                LastName = "Another LastName",
                Address = "Wonderfull address",
                Gender = "female"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Name" + i,
                LastName = "Last Name" + i,
                Address = "Some Address " + i,
                Gender = "Male"
            };
        }

        private Person MockPerson(Person p)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = p.FirstName,
                LastName = p.LastName,
                Address = p.Address,
                Gender = p.Gender
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }

}

