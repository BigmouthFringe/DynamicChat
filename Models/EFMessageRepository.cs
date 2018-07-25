using System.Collections.Generic;
using System.Linq;

namespace DynamicChat.Models 
{
    public class EFMessageRepository : IMessageRepository 
    {
        private ApplicationDbContext context;

        public EFMessageRepository(ApplicationDbContext ctx) 
        {
            context = ctx;
        }
        
        public IQueryable<Message> Messages => context.Messages;

        public void SaveProduct(Message message) 
        {
            if (message.MessageID == 0) {
                context.Messages.Add(message);
            } else {
                Message dbEntry = context.Messages
                    .FirstOrDefault(m => m.MessageID == message.MessageID);
                if (dbEntry != null) {
                    dbEntry.Sender = message.Sender;
                    dbEntry.Content = message.Content;
                }
            }
            context.SaveChanges();
        }
    }
}