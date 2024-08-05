using Authentication.Model;

namespace Authentication.Services
{
    public interface IPersons
    {
        Task<Persons> GetAll(Persons pers);
        IEnumerable<Roles> GetAllRoles();
    }
}
