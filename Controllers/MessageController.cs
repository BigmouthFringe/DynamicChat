using Microsoft.AspNetCore.Mvc;
using DynamicChat.Models;

namespace DynamicChat.Controllers 
{
    public class MessageController : Controller 
    {
        private IMessageRepository repository;
        
        public MessageController(IMessageRepository repo) 
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Messages);
    }
}