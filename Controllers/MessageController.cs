using Microsoft.AspNetCore.Mvc;
using DynamicChat.Models;
using System.Linq;

namespace DynamicChat.Controllers 
{
    public class MessageController : Controller 
    {
        private IMessageRepository repository;
        
        public MessageController(IMessageRepository repo) 
        {
            repository = repo;
        }

        public ViewResult Index() => View();
        public ViewResult List() => View(repository.Messages);
        public ViewResult Edit(int messageId) =>
            View(repository.Messages
                .FirstOrDefault(m => m.MessageID == messageId));
    }
}