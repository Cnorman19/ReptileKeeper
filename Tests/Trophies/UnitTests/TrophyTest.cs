using Microsoft.EntityFrameworkCore;
using ReptileKeeper.Core.Interfaces;
using ReptileKeeper.Core.Models;
using ReptileKeeper.Core.Models.Achievements.Trophies;
using ReptileKeeper.Core.Models.Areas.Identity.Account;
using ReptileKeeper.DataAccess.Data;
using ReptileKeeper.Services.Trophies;
using ReptileKeeper.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Tests.Trophies.UnitTests
{
    public class TrophyTest
    {
        private readonly ApplicationDbContext _context;

        public TrophyTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            _context.Database.EnsureCreated();

            _context.ContextInitializer();
        }

        [Fact]
        public async Task TestCreateTrophy_InputIsMoqTrophy_ShouldReturnTrophyObject()
        {
            var query = new TrophyService(_context);

            var trophy = new Trophy
            {
                Id = "1",
                Title = "Master Feeder",
                Description = "Your amazing ability to captivate your animals hunger and provide the optimal conditions for consistant feeding make you stand out!",
                DateAcquired = DateTime.Now,
                ReasonForReceiving = "Successfully feed an animal in your collection 100 times in a row.",
                RecipientId = "1"
            };

            var result = await query.CreateAsync(trophy);

            Assert.NotNull(result);

            Assert.Equal(trophy.Id, result?.Id);
        }
    }
}
