using Authentication.Model;
using Authentication.Services;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataBase
{
    public class OperationDb : IPersons
    {
        private readonly MyDataBase _dbContext;
        public OperationDb(MyDataBase dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Persons> GetAll(Persons pers)
        {
            return await _dbContext.personsDb
            .Where(a => a.Name == pers.Name && a.Password == pers.Password)
            .Include(a => a.roles).FirstOrDefaultAsync();
        }

        public IEnumerable<Roles> GetAllRoles()
        {

            return _dbContext.rolesDb.ToList();

        }

    }
}
