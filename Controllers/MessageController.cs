using Microsoft.AspNetCore.Mvc;
using DynamicChat.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace DynamicChat.Controllers 
{
    [Authorize]
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
        
        [HttpPost]
        public IActionResult Edit(Message message) {
            if (ModelState.IsValid) {
                repository.SaveProduct(message);
                TempData["message"] = $"{message.Sender} has been saved";
                return RedirectToAction("Index");
            } else {
                // there is something wrong with the data values
                return View(message);
            }
        }

        public ViewResult Create() => View("Edit", new Message());
    }
}