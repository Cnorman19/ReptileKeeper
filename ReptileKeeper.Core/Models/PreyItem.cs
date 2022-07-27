using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Core.Models
{
    public class PreyItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PreyType { get; set; } = string.Empty;

        [Required]
        public string PreySize { get; set; } = string.Empty;
    }
}
