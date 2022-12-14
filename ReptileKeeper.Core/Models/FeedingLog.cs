using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Core.Models
{
    public class FeedingLog
    {
        [Key]
        public string Id { get; set; }

        public bool AteSuccessfully { get; set; } = true;

        [Required]
        public DateTime DateFed { get; set; }

        public DateTime DateOfNextFeed { get; set; }

        [Required]
        public PreyItem? PreyItem { get; set; }

        [Required]
        public int QuantityFed { get; set; }

        [Required]
        public string ReptileFedId { get;set; }

        [ForeignKey("ReptileFedId")]
        public virtual Reptile ReptileFed { get; set; }

        private DateTime SetDateOfNextFeed(double feedingFrequencyInDays)
        {
            return this.DateOfNextFeed = this.DateFed.AddDays(feedingFrequencyInDays);
        }
    }
}
