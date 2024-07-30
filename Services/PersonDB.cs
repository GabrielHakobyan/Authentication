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
                new Person()
                {
                    Email="Gabriel",
                    Password= "1234"
                },
                new Person()
                {
                    Email="Hakobyan",
                    Password= "4321"
                }
            };
        }
        public List<Person> Get => data;
    }
}
