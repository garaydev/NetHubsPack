using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetHubsPack.Models
{
    public class NetType
    {
        public int NetTypeID { get; set; }
        public int NetTypeDetailID { get; set; }
        public bool isNetTypeParent { get; set; }
        public int? NetTypeParentID { get; set; }
    }
}