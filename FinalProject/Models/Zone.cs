using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;
namespace FinalProject.Models
{
    public class Zone
    {
        double area;
        string mClassification;
        string production;
        double amountN;
        double x;
        double y;
        double z;
        string iD;
        string expenditureDate;

        public Zone(double area, string mClassification, string production, double amountN, double x, double y, double z, string iD, string expenditureDate)
        {
            this.area = area;
            this.mClassification = mClassification;
            this.production = production;
            this.amountN = amountN;
            this.x = x;
            this.y = y;
            this.z = z;
            this.iD = iD;
            this.expenditureDate = expenditureDate;
        }
        public Zone()
        {
           
        }

        public double Area { get => area; set => area = value; }
        public string MClassification { get => mClassification; set => mClassification = value; }
        public string Production { get => production; set => production = value; }
        public double AmountN { get => amountN; set => amountN = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }
        public string ID { get => iD; set => iD = value; }
        public string ExpenditureDate { get => expenditureDate; set => expenditureDate = value; }

        public int updatez(Zone zed)
        {
            DBservices DB = new DBservices();
            return DB.updatez(zed);
        }

        
        public List<Zone> returnZone()
        {
            DBservices db = new DBservices();
            return db.returnZone();
        }
    }
}
    
