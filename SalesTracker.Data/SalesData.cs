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
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required]
        public decimal SalesPrice { get; set; }

        [Required]
        public decimal CommPercentage { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required]
        public decimal TotalCommission { get; set; }

        [Required]
        public decimal ThirdPartyReferral { get; set; }

        [Required]
        public decimal RoyaltyFee { get; set; }

        [Required]
        public decimal AgentSplit { get; set; }

        [Required]
        public decimal ReloSplit { get; set; }

        [Required]
        public decimal Base { get; set; }

        [Required]
        public decimal APCF { get; set; }

        [Required]
        public decimal EnrollPCC { get; set; }

        [Required]
        public decimal CharitbaleContribution { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required]
        public decimal Commission { get; set; }

        [Required]
        public string Source { get; set; }
    }
}