using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;
namespace FinalProject.Models
{
    public class Material
    {
        string numMaterial;
        string materialName;
        string idAmount;
        string materialClassification;

        DBservices dBservices;

        public Material()
        {
            dBservices = new DBservices();
        }

        public Material(string numMaterial, string materialName, string idAmount, string materialClassification)
        {
            this.numMaterial = numMaterial;
            this.materialName = materialName;
            this.idAmount = idAmount;
            this.materialClassification = materialClassification;
        }



        public string NumMaterial { get => numMaterial; set => numMaterial = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string IdAmount { get => idAmount; set => idAmount = value; }
        public string MaterialClassification { get => materialClassification; set => materialClassification = value; }

        public List<Material> Read()
        {
            //insert your code here

            return dBservices.getNumMaterial();

        }
    }
}