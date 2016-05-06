using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesTracker.Models
{
    public class SalesDetailModel
    {
        public int SalesId { get; set; }

        public DateTime Date { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SalesPrice { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal TotalCommission { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        public decimal ThirdPartyReferral { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        public decimal RoyaltyFee { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        public decimal AgentSplit { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        public decimal ReloSplit { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        public decimal Base { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal APCF { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal EnrollPCC { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal CharitbaleContribution { get; set; }

        public decimal Commission { get; set; }

        public string Source { get; set; }
    }
}