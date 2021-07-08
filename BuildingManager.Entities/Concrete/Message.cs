using BuildingManager.Core.Entities;

namespace BuildingManager.Entities.Concrete
{
    public class Message:IEntity
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
    }
}