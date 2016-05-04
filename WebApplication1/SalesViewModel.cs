using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SalesViewModel
    {

        public int SalesId { get; set; }
       
        public string Title { get; set; }
        
        public DateTime Date { get; set; }

        public string Client { get; set; }

        public string Address { get; set; }

        public double SalesPrice { get; set; }

        public double Commission { get; set; }

        public string Source { get; set; }

        public override string ToString() => $"[{SalesId}] {Title}";

    }
}