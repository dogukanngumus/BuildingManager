using System.Collections.Generic;
using BuildingManager.Core.Entities;

namespace BuildingManager.Entities.Concrete
{
    public class Building:IEntity   
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public byte TotalFlat { get; set; }

        public List<Flat> Flats { get; set; }
    }
}