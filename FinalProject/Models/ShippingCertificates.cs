using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;

namespace FinalProject.Models
{
    public class ShippingCertificates
    {
        int shippingCertificate;
        String dateReceive;

        public ShippingCertificates(int shippingCertificate, string dateReceive)
        {
            this.shippingCertificate = shippingCertificate;
            this.dateReceive = dateReceive;
        }

        public int ShippingCertificate { get => shippingCertificate; set => shippingCertificate = value; }
        public string DateReceive { get => dateReceive; set => dateReceive = value; }
    
        public ShippingCertificates()
        {
        }
   



        public List<ShippingCertificates> getSCertificates()
        {
            DBservices DB = new DBservices();
            return DB.getSCertificates();
        }
    }
}