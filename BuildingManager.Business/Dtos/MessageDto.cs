using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingManager.Business.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
    }
}