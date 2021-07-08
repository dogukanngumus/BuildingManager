using System.ComponentModel;

namespace BuildingManager.Web.Enums
{
     public static class Roles
        {
            public const string Admin = "Admin";
            public const string User = "User";
    
        }
    
        public enum RoleTypes : byte
        {
            [Description(Roles.Admin)]
            Admin = 1,
            [Description(Roles.User)]
            Resident =2
        }
}