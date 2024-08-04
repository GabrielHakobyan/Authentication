using Authentication.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.DataBase
{
    public class PersonRolesConfiguration : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            builder.HasOne(e => e.roles)
                .WithMany(a => a.Persons)
                .HasForeignKey(c => c.RolesId);
        }
    }
}
