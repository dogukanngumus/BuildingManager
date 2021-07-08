using System.Collections.Generic;
using BuildingManager.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BuildingManager.Entities.Concrete
{
    public class User:IdentityUser, IEntity
    {
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarLicensePlate { get; set; }

        public List<Flat> Flats { get; set; }
    }
}