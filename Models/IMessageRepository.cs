using System.Linq;

namespace DynamicChat.Models 
{
    public interface IMessageRepository 
    {
        IQueryable<Message> Messages { get; }

        void SaveProduct(Message message);
    }
}