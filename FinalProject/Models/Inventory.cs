using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;
namespace FinalProject.Models
{
    public class Inventory
    {
        string numMaterial;
        string productionID;
        int amountInventory;

        public string NumMaterial { get => numMaterial; set => numMaterial = value; }
        public string ProductionID { get => productionID; set => productionID = value; }
        public int AmountInventory { get => amountInventory; set => amountInventory = value; }

        public Inventory(string numMaterial, string productionID, int amountInventory)
        {
            this.NumMaterial = numMaterial;
            this.ProductionID = productionID;
            this.AmountInventory = amountInventory;
        }
        public Inventory()
        {

        }
        public int InventoryUpdate(Inventory materialInventory)
        {
            DBservices DB = new DBservices();
            return DB.InventoryUpdate(materialInventory);
        }
        public List<Inventory> getinventiry()
        {
            DBservices DB = new DBservices();
            return DB.getinventiry();

        }
    }
}