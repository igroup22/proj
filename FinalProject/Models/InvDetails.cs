using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;

namespace FinalProject.Models
{
    public class InvDetails
    {
        int checkNumber;
        string materialId;
        string productionId;
        int amount;
        DBservices dBservices;

        public InvDetails()
        {
            DBservices db = new DBservices();
        }
        public InvDetails(int checkNumber, string materialId, string productionId, int amount)
        {
            this.checkNumber = checkNumber;
            this.materialId = materialId;
            this.productionId = productionId;
            this.amount = amount;
        }

        public int CheckNumber { get => checkNumber; set => checkNumber = value; }
        public string MaterialId { get => materialId; set => materialId = value; }
        public string ProductionId { get => productionId; set => productionId = value; }
        public int Amount { get => amount; set => amount = value; }

        public int insert(InvDetails IDcheck)
        {
            DBservices db = new DBservices();
            return db.InsertDetailsToDB(IDcheck);
        }


    }
}