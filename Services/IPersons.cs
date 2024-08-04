using Authentication.Model;

namespace Authentication.Services
{
    public interface IPersons
    {
        IEnumerable<Persons> GetAll();
        IEnumerable<Roles> GetAllRoles();
    }
}
