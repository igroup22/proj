using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;
namespace FinalProject.Models
{
    public class Material_certificate
    {
        int numMaterial;
        string shippingCertificate;
        int amountcertificate;

        public Material_certificate()     
        {       }

        public Material_certificate(int numMaterial, string shippingCertificate, int amountcertificate)
        {
            this.NumMaterial = numMaterial;
            this.ShippingCertificate = shippingCertificate;
            this.Amountcertificate = amountcertificate;
        }

        public int NumMaterial { get => numMaterial; set => numMaterial = value; }
        public string ShippingCertificate { get => shippingCertificate; set => shippingCertificate = value; }
        public int Amountcertificate { get => amountcertificate; set => amountcertificate = value; }

     

    }
}