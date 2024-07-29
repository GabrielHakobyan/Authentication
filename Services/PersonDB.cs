using Authentication.AuthModel;
using System.Net.WebSockets;

namespace Authentication.Services
{
    public class PersonDB : IPerson
    {
        private readonly List<Person> data;
        public PersonDB()
        {
            data = new List<Person>()
            {
                new Person("Gabriel","1234"),
                new Person("Hakobyan","4321")
            };
        }
        public List<Person> Get => data;
    }
}
