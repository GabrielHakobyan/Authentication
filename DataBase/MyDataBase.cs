using Authentication.Model;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataBase
{
    public class MyDataBase:DbContext
    {
       public DbSet<Persons> personsDb {  get; set; }
        public DbSet<Roles> rolesDb { get; set; }
        public MyDataBase(DbContextOptions<MyDataBase> options)
         : base(options)
        {
            Database.EnsureCreated(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonRolesConfiguration());
            modelBuilder.Entity<Roles>().HasData(
                new Roles {Id=1, Name="admin"},
                new Roles {Id=2, Name="user"}
                );
            modelBuilder.Entity<Persons>().HasData(new Persons
            {
                Id=1,
                Name = "Gabriel",
                Password = "1234",
                RolesId=1
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
