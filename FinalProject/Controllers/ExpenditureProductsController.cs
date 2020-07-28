using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace FinalProject.Controllers
{
    public class ExpenditureProductsController : ApiController
    {
        // GET: api/ExpenditureProducts

        [HttpGet]
        [Route("api/ExpenditureProducts/NumMaterialList")]
        public List<Material> GetMaterial()
        {
            Material m = new Material();
            return m.Read();
            //return null;
        }

        // GET api/<controller>
        [HttpGet]
        [Route("api/ExpenditureProducts/returnExM")]
        public List<Expenditure_Material> Get(string mispar)
        {
            Expenditure_Material ex = new Expenditure_Material();
            return ex.returnExM(mispar);
        }

        // GET: api/ExpenditureProducts/5
        public List<Inventory> Get()
        {
            Inventory inv = new Inventory();
            return inv.getinventiry();
        }

        // POST: api/ExpenditureProducts
        public int Post(Expenditure expenditure)

        {
            Expenditure e = new Expenditure();
            return e.insert(expenditure);
        }

        [HttpPost]
        [Route("api/ExpenditureProducts/insertMExpenditure")] //הכנסת סוג חומר(מס הוצאה,מקט פנימי וכמות)
        public void postMExpenditure([FromBody]Expenditure_Material MExpenditure)
        {
            Expenditure_Material O = new Expenditure_Material();
            O.insert(MExpenditure);
        }

        // PUT: api/ExpenditureProducts/5
        public int Put(Inventory materialInventory)
        {
            Inventory SR = new Inventory();
            return SR.InventoryUpdate(materialInventory);

        }

        // DELETE: api/ExpenditureProducts/5
        public void Delete(int id)
        {
        }
    }
}
