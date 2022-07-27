using Microsoft.AspNetCore.Identity;

namespace ReptileKeeper.Core.Models.Areas.Identity.Account
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Reptile> Collection { get; set; }
    }
}
