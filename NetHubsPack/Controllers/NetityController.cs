using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NetHubsPack.Models;

namespace NetHubsPack.Models
{
    public class NetityController : ApiController
    {
        List<Netity> nelist = new List<Netity> 
        { 
            new Netity { NetityID = 1, NetDetailList = null, NetityTypeID = 1 }, 
            new Netity { NetityID = 2, NetDetailList = null, NetityTypeID = 2 },
            new Netity { NetityID = 3, NetDetailList = null, NetityTypeID = 3 }, 
            new Netity { NetityID = 4, NetDetailList = null, NetityTypeID = 4 }, 
            new Netity { NetityID = 5, NetDetailList = null, NetityTypeID = 5 }
        };
       
        List<NetDetail> netDetailList = new List<NetDetail>
        { 
            new NetDetail { NetDetailID = 1, NetityID = 1, NetDetailTitle = "Weight", NetDetailValue="100 lbs" },
            new NetDetail { NetDetailID = 2, NetityID = 1, NetDetailTitle = "Height", NetDetailValue="100 ft"}
        };

        public IEnumerable<Netity> GetAllProducts()
        {
            nelist.ForEach(r => r.NetDetailList.AddRange(netDetailList));
            return nelist;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = nelist.FirstOrDefault((p) => p.NetityID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
