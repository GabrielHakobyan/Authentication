using Authentication.AuthModel;

namespace Authentication.Services
{
    public interface IPerson
    {
        List<Person> Get { get; }
    }
}
