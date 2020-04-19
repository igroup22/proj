using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;


namespace FinalProject.Models
{
    public class CInventory
    {

        string materialId;
        string materialName;
        string productionId;

        public string MaterialId { get => materialId; set => materialId = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string ProductionId { get => productionId; set => productionId = value; }

        public CInventory()
        {
            DBservices DB = new DBservices();
        }

        public CInventory(string materialId, string materialName, string productionId)
        {
            this.materialId = materialId;
            this.materialName = materialName;
            this.productionId = productionId;
        }

        public List<CInventory> ReadList()
        {
            DBservices DB = new DBservices();
            return DB.getinventirychecklist();

        }




    }
}