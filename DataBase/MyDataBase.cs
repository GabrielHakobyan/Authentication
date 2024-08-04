using Authentication.Model;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataBase
{
    public class MyDataBase:DbContext
    {
       public DbSet<Persons> personsDb {  get; set; }
        public DbSet<Roles> rolesDb { get; set; }
        public MyDataBase() => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonRolesConfiguration());
            modelBuilder.Entity<Roles>().HasData(
                new Roles { Name="admin"},
                new Roles { Name="user"}
                );
            modelBuilder.Entity<Persons>().HasData(new Persons
            {
                Name = "Gabriel",
                Password = "1234",
                RolesId = 1,
            });
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //            new User { Id = 1, Name = "Tom", Age = 37 },
        //            new User { Id = 2, Name = "Bob", Age = 41 },
        //            new User { Id = 3, Name = "Sam", Age = 24 }
        //    );
        //}
    }
}
