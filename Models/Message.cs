using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DynamicChat.Models 
{
    public class Message 
    {
        public int MessageID { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        public string Content { get; set; }
    }
}