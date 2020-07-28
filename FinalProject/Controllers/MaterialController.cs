using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;
namespace FinalProject.Controllers
{
    public class MaterialController : ApiController
    {
        // GET api/<controller>
    

        // GET api/<controller>/5
        public List<Material> Get()
        {
            Material mt = new Material();
            return mt.Read();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}