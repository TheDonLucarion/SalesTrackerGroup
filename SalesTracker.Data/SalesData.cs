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

        [Required]
        public float SalesPrice { get; set; }

        [Required]
        public float TotalCommission { get; set; }

        [Required]
        public float? ThirdPartyReferral { get; set; }

        [Required]
        public float RoyaltyFee { get; set; }

        [Required]
        public float? AgentSplit { get; set; }

        [Required]
        public float ReloSplit { get; set; }

        [Required]
        public float Base { get; set; }

        [Required]
        public float APCF { get; set; }

        [Required]
        public float? EnrollPCC { get; set; }

        [Required]
        public float? CharitbaleContribution { get; set; }

        [Required]
        public float Commission { get; set; }

        [Required]
        public string Source { get; set; }
    }
}