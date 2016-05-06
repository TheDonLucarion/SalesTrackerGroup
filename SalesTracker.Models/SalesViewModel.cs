using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesTracker.Models
{
    public class SalesViewModel
    {

        public int SalesId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SalesPrice { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Commission { get; set; }

        public string Source { get; set; }
    }
}