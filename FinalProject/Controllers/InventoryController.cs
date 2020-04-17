using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class InventoryController : ApiController
    {
        // GET api/<controller>
        public List<Inventory> Get()
        {
            Inventory IN = new Inventory();
            return IN.getinventiry();

        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public int Put(Inventory materialInventory)
        {
            Inventory SR = new Inventory();
            return SR.InventoryUpdate(materialInventory);

        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}