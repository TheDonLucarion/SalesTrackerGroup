using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SalesDetailModel
    {
        
        public DateTime Date { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public double SalesPrice { get; set; }

        public double TotalCommission { get; set; }

        public float? ThirdPartyReferral { get; set; }

        public float RoyaltyFee { get; set; }

        public float? AgentSplit { get; set; }

        public float ReloSplit { get; set; }

        public float Base { get; set; }

        public float APCF { get; set; }

        public float? EnrollPCC { get; set; }

        public float? CharitbaleContribution { get; set; }

        public string Source { get; set; }
    }
}