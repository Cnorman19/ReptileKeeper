using ReptileKeeper.Core.Models.Areas.Identity.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Core.Models
{
    public class Reptile
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser Owner { get; set; }

        [Required]
        public int AgeInMonths { get; set; }

        [Required]
        public int FeedFrequencyInDays;

        [Required]
        public decimal WeightInGrams { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string ScientificName { get; set; } = string.Empty;

        public IList<FeedingLog> FeedingLogs { get; set; }

        public IList<WeightLog> WeightLogs { get; set; }

    }
}
