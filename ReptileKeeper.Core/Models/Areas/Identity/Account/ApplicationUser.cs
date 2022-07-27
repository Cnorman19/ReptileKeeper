using Microsoft.AspNetCore.Identity;
using ReptileKeeper.Core.Models.Achievements.Trophies;

namespace ReptileKeeper.Core.Models.Areas.Identity.Account
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Reptile> Collection { get; set; }

        public IList<Trophy> Achievements { get; set; }

        public int KeeperScore { get; set; }

        public int CommunityScore { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
