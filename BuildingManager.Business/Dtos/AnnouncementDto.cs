using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingManager.Business.Dtos
{
    public class AnnouncementDto
    {
        public int Id { get; set; }
        public string AnnouncementText { get; set; }
    }
}