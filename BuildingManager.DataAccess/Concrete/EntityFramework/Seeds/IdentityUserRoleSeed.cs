using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Seeds
{
    public class IdentityUserRoleSeed:IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {  
            string ADMIN_ID ="02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ADMIN_ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            builder.HasData(new IdentityUserRole<string> {
                RoleId = ADMIN_ROLE_ID, 
                UserId = ADMIN_ID 
            });
        }
    }
}