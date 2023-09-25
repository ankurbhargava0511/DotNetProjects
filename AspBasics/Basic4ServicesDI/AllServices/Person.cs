using System.Collections.Generic;

namespace Basic4ServicesDI.AllServices
{
    public class Person
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Person() { }


    }

    public class Persons : IPersons
    {
        public List<Person> GetPerson()
        {
            List<Person> People = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person() { Id = i, Name = "Name" + i.ToString() };
                People.Add(person);

            }
            return People;
        }
    }
}
