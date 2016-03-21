using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDBEntities
{
    public class QuotationSummary
    {
        public int QuotationID { get; set; }
        public string QuotationNo { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime QuotationDate { get; set; }
        public decimal? TotalVolume { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool IsSent { get; set; }
    }
}
