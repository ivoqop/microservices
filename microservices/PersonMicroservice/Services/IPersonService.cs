using System;
using PersonMicroservice.Model;

namespace PersonMicroservice.Services
{
	public interface IPersonService
	{
		Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}

