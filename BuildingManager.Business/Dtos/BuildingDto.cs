using System.ComponentModel.DataAnnotations;

namespace BuildingManager.Business.Dtos
{
    public class BuildingDto
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public byte TotalFlat { get; set; }
    }
}