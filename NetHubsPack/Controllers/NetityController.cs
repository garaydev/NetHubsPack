using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NetHubsPack.Models;

namespace NetHubsPack.Controllers
{
    public class NetityController : ApiController
    {
        List<Netity> nelist = new List<Netity> 
        { 
            new Netity { NetityID = 1, NetityName = "R6700", NetityPrice = 100.50M, NetDetailList = null, NetityTypeID = 1 }, 
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

        List<NetType> nTypesList = new List<NetType>()
        {
            new NetType { NetTypeID = 1, NetTypeDetailID = 1, isNetTypeParent = true, NetTypeParentID = null }
        };

        List<NetTypeDetail> nTypDetailList = new List<NetTypeDetail>()
        {
            new NetTypeDetail { NetTypeDetailID = 1 , NetTypeDetailTitle = "Home Router", NetTypeDetailDescr = ""}
        };

        public IEnumerable<Netity> GetAllProducts()
        {
            nelist.ForEach(r => r.NetDetailList = new List<NetDetail>());
            nelist.ForEach(r => r.NetDetailList.AddRange(netDetailList));

            Netity NentOne = nelist.FirstOrDefault();
            NetType NentTypeOne = nTypesList.FirstOrDefault();
            if (NentOne != null && NentTypeOne != null)
            {
                NentTypeOne.NetTypeDetailID = nTypDetailList.FirstOrDefault().NetTypeDetailID;
                NentOne.NetityTypeID = NentTypeOne.NetTypeID;
            }

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
