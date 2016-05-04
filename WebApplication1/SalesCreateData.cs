using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SalesCreateData
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least two characters")]
        [MaxLength(128)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Client { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double SalesPrice { get; set; }

        [Required]
        public double Commission { get; set; }

        [Required]
        public string Source { get; set; }

        public override string ToString() => $"[New] {Title}";

    }
}