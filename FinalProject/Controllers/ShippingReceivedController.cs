using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ShippingReceivedController : ApiController
    {
        // GET api/<controller>

        public List<ShippingReceived> Get()
        {
            ShippingReceived SC = new ShippingReceived();
            return SC.getSR();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public int Post(ShippingReceived shippingR)
        {
            ShippingReceived SR = new ShippingReceived();
            return SR.newmaterial(shippingR);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public int Put(ShippingReceived shippingR)
        {
            ShippingReceived SR = new ShippingReceived();
            return SR.updateSR(shippingR);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}