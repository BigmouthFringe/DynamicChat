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
    }
}