using Authentication.Model;
using Authentication.Services;

namespace Authentication.DataBase
{
    public class OperationDb : IPersons
    {
        public IEnumerable<Persons> GetAll()
        {
            using(MyDataBase db = new MyDataBase())
            {
                return db.personsDb.ToList();
            }
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            using(MyDataBase db = new())
            {
                return db.rolesDb.ToList();
            }
        }
    }
}
