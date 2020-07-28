using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("api/Employee/getemployee")]
        public List<Employee> Get(string EmployeeNum, string UserPassword)
        {
            Employee em = new Employee();
            return em.getemployee(EmployeeNum, UserPassword);
        }



        //public List<Employee> Get()
        //{
        //    Employee em = new Employee();
        //    return em.getemployee();
        //}


        // POST api/<controller>
        public int Post(Employee emp)
        {
            Employee em = new Employee();
            return em.postemp(emp);
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