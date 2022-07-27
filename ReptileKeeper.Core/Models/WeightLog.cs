using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Core.Models
{
    public class WeightLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateWeighed { get; set; }

        [Required]
        public Reptile ReptileWeighed { get; set; }

        [Required]
        public int WeightInGrams { get; set; }
    }
}
