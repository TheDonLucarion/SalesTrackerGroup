using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public decimal SalesPrice { get; set; }

        public decimal TotalCommission { get; set; }

        public decimal ThirdPartyReferral { get; set; }

        public decimal RoyaltyFee { get; set; }

        public decimal AgentSplit { get; set; }

        public decimal ReloSplit { get; set; }

        public decimal Base { get; set; }

        public decimal APCF { get; set; }

        public decimal EnrollPCC { get; set; }

        public decimal CharitbaleContribution { get; set; }

        public decimal Commission { get; set; }

        public string Source { get; set; }
    }
}