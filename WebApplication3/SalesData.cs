using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesTracker.Data
{
    [Table("Sales")]
    public class SalesData
    {
        [Key]
        public int SalesId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Column(TypeName ="datetime2")]
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