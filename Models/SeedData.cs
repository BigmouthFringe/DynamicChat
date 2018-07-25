using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DynamicChat.Models 
{
    public static class SeedData 
    {
        public static void EnsurePopulated(IApplicationBuilder app) 
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
            if (!context.Messages.Any()) {
                context.Messages.AddRange(
                    new Message {
                        Sender = "Mike1337", Content = "Well, hello there!" },
                    new Message {
                        Sender = "Fringe", Content = "General Kenobi" },
                    new Message {
                        Sender = "Ewan", Content = "The Hell?!" }
                );
                context.SaveChanges();
            }
        }
    }
}