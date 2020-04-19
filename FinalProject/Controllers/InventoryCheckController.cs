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
    public class InventoryCheckController : ApiController
    {
        // GET: api/InventoryCheck

        //[HttpGet]
        [Route("api/InventoryCheckController/MaterialList")]
        public List<CInventory> GetMaterialList()
        {
            CInventory ci = new CInventory();
            return ci.ReadList();
            //return null;
        }

        //[HttpGet]
        [Route("api/InventoryCheckController/MCheckList")]
        public List<ManagerCheck> GetMCheckList()
        {
            ManagerCheck MC = new ManagerCheck();
            return MC.ReadList();
            //return null;
        }

        ////[HttpGet]
        //[Route("api/InventoryCheckController/CheckNewCount")]
        //public List<InvCheck> MinvCheck()
        //{
        //    InvCheck c = new InvCheck();
        //    return c.getList();
        //    //return null;
        //}


        [HttpPost]
        [Route("api/InventoryCheck/InsertNewCheck")] //הכנסת סוג חומר(מס הוצאה,מקט פנימי וכמות)
        public int postNewCheck([FromBody]InvCheck NewICheck)
        {
            InvCheck c = new InvCheck();
            return c.insert(NewICheck);
        }

        [HttpPost]
        [Route("api/InventoryCheck/InsertCheckDetalis")] //הכנסת פרטי הוצאה לפי מספר הוצאה שקיבלנו מפוסט קודם
        // לפי - מספר ספירה, מקט, מחלקה וכמות
        public void postdetailsCheck([FromBody]InvDetails detailsC)
        {
            InvDetails c = new InvDetails();
            c.insert(detailsC);
        }



    }
}
