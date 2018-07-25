using System.Collections.Generic;
using System.Linq;

namespace DynamicChat.Models 
{
    public class FakeMessageRepository : IMessageRepository 
    {
        public IQueryable<Message> Messages => new List<Message> {
            new Message { Sender = "Mike1337", Content = "Well, hello there!" },
            new Message { Sender = "Fringe", Content = "Obiwan Kenobi" },
            new Message { Sender = "Ewan", Content = "The Hell?!" }
        }.AsQueryable<Message>();
    }
}