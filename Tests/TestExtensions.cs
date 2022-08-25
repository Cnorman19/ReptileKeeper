using ReptileKeeper.Core.Models;
using ReptileKeeper.Core.Models.Achievements.Trophies;
using ReptileKeeper.Core.Models.Areas.Identity.Account;
using ReptileKeeper.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Tests
{
    public static class TestExtensions
    {
        public static ApplicationDbContext ContextInitializer(this ApplicationDbContext context)
        {
            var users = new[]
            {
                new ApplicationUser { Id = "1",
                    Name = "John Doe",
                    Age = 25,
                    Location = "Michigan",
                    KeeperScore = 0,
                    CommunityScore = 0,
                    Achievements = new List<Trophy>(),
                    Collection = new List<Reptile>()

                }
            };

            var trophies = new[]
            {
                new Trophy { Id = "1",
                    Title = "Master Feeder",
                    Description = "Your amazing ability to captivate your animals hunger and provide the optimal conditions for consistant feeding make you stand out!",
                    DateAcquired = DateTime.Now,
                    ReasonForReceiving = "Successfully feed an animal in your collection 100 times in a row.",
                    RecipientId = "1" }

            };

            context.Users.AddRange(users);

            context.SaveChanges();

            return context;
        }
    }
}
