using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ZoneController : ApiController
    {
        // GET api/<controller>
        public List<Zone> Get()
        {
            Zone zn = new Zone();
            return zn.returnZone();
        }

     

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public int Put(Zone zed)
        {
            Zone z = new Zone();
            return z.updatez(zed);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}