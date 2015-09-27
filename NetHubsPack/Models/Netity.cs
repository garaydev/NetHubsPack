using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetHubsPack.Models
{
    public class Netity
    {
        public int NetityID { get; set; }
        public int NetityTypeID { get; set; }
        public int ManuCompanyID { get; set; }
        public string NetityName { get; set; }
        public decimal NetityPrice { get; set; }
        public List<NetDetail> NetDetailList { get; set; }
    }
}