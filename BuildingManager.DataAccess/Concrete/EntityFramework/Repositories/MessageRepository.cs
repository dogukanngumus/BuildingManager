using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class MessageRepository: Repository<Message>, IMessageRepository
    {
        public MessageRepository(BuildingManagerDbContext context) : base(context)
        {
        }
    }
}