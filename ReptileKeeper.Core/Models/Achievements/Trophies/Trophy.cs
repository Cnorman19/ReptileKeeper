using ReptileKeeper.Core.Models.Areas.Identity.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Core.Models.Achievements.Trophies
{
    public class Trophy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ReasonForReceiving { get; set; }

        [Required]
        public DateTime DateAcquired { get; set; }

        [Required]
        public int RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public virtual ApplicationUser Recipient { get; set; }
    }
}
