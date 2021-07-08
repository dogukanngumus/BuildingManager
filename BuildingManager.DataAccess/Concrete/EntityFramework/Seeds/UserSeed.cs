using BuildingManager.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Seeds
{
    public class UserSeed:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            string ADMIN_ID ="02174cf0–9412–4cfe-afbf-59f706d72cf6";
            var appUser = new User() { 
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                EmailConfirmed = true, 
                IdentificationNumber = "11111111111",
                NormalizedEmail = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName="ADMIN"
            };
            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            appUser.PasswordHash = ph.HashPassword(appUser, "admin123admin");

            //seed user
            builder.HasData(appUser);
        }
    }
}