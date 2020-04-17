using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;
namespace FinalProject.Models
{
    public class ShippingReceived
    {
        string numMaterial;
        string productionID;
        int amountExcepted;
        int amountReceived;
        string shippingCertificate;

     
        public ShippingReceived()
        {
      
        }

        public ShippingReceived(string numMaterial, string productionID, int amountExcepted, int amountReceived, string shippingCertificate)
        {
            this.NumMaterial = numMaterial;
            this.ProductionID = productionID;
            this.AmountExcepted = amountExcepted;
            this.AmountReceived = amountReceived;
            this.ShippingCertificate = shippingCertificate;
        }

        public string NumMaterial { get => numMaterial; set => numMaterial = value; }
        public string ProductionID { get => productionID; set => productionID = value; }
        public int AmountExcepted { get => amountExcepted; set => amountExcepted = value; }
        public int AmountReceived { get => amountReceived; set => amountReceived = value; }
        public string ShippingCertificate { get => shippingCertificate; set => shippingCertificate = value; }

        public List<ShippingReceived> getSR()
        {
            DBservices DB = new DBservices();
            return DB.getSR();
        }

        public int updateSR(ShippingReceived shippingR)
        {
            DBservices DB = new DBservices();
            return DB.updateSR(shippingR);
        }
        public int newmaterial(ShippingReceived shippingR)
        {
            DBservices DB = new DBservices();
            return DB.newmaterial(shippingR);
        }

   
    }
}