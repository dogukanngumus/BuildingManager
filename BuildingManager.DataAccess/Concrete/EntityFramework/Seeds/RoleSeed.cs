using BuildingManager.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Seeds
{
    public class RoleSeed:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            string ADMIN_ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            string USER_ROLE_ID = "3ff7ef98-b936-486f-81ca-c0b73056bb08";
            builder.HasData(new Role { 
                    Name = "Admin", 
                    NormalizedName = "Admin", 
                    Id = ADMIN_ROLE_ID,
                    ConcurrencyStamp = ADMIN_ROLE_ID
                },
                new Role { 
                    Name = "User", 
                    NormalizedName = "User", 
                    Id = USER_ROLE_ID,
                    ConcurrencyStamp = USER_ROLE_ID
                });
        }
    }
}