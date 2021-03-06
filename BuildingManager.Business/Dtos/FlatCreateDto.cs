using System.Collections.Generic;

namespace BuildingManager.Business.Dtos
{
    public class FlatCreateDto
    {
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string TypeOfFlat{ get; set; }
        public string UserId { get; set; }
        public int BuildingId { get; set; }
        
        //------------------------------------------------
        public IEnumerable<BuildingDto> Buildings { get; set; } //id
        public IEnumerable<UserDto> Users { get; set; }//id
    }
}