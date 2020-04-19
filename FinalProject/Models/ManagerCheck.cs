using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;

namespace FinalProject.Models
{
    public class ManagerCheck
    {
        string materialId;
        string productionId;
        int inventoryAmount;
        int checkAmount;
        int checkNumber;
        
        DBservices dBservices;

        public ManagerCheck(string materialId, string productionId, int inventoryAmount, int checkAmount, int checkNumber)
        {
            this.materialId = materialId;
            this.productionId = productionId;
            this.inventoryAmount = inventoryAmount;
            this.checkAmount = checkAmount;
            this.checkNumber = checkNumber;
        }

        public ManagerCheck()
        {
            DBservices db = new DBservices();
        }

        public string MaterialId { get => materialId; set => materialId = value; }
        public string ProductionId { get => productionId; set => productionId = value; }
        public int InventoryAmount { get => inventoryAmount; set => inventoryAmount = value; }
        public int CheckAmount { get => checkAmount; set => checkAmount = value; }
        public int CheckNumber { get => checkNumber; set => checkNumber = value; }

        public List<ManagerCheck> ReadList()
        {
            DBservices DB = new DBservices();
            return DB.ReadList();
        }

    }
}