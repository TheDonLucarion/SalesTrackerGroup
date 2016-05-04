using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SalesEditModel
    {
        [Required]
        public int SalesId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
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

    }
}