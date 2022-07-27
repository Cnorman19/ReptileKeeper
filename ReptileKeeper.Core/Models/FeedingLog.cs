using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Core.Models
{
    public class FeedingLog
    {
        [Key]
        public int Id { get; set; }

        public bool AteSuccessfully { get; set; } = true;

        [Required]
        public DateTime DateFed { get; set; }

        public DateTime DateOfNextFeed { get; set; }

        [Required]
        public PreyItem? PreyItem { get; set; }

        [Required]
        public int QuantityFed { get; set; }

        [Required]
        public Reptile? ReptileFed { get; set; }

        private DateTime SetDateOfNextFeed(double feedingFrequencyInDays)
        {
            return this.DateOfNextFeed = this.DateFed.AddDays(feedingFrequencyInDays);
        }
    }
}
