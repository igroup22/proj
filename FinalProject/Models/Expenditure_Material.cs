using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;
namespace FinalProject.Models
{
    public class Expenditure_Material
    {
        int expenditureNum;
        string numMaterial;
        int amount;
        DBservices dBservices;

        public Expenditure_Material(int expenditureNum, string numMaterial, int amount)
        {
            this.expenditureNum = expenditureNum;
            this.numMaterial = numMaterial;
            this.amount = amount;
        }


        public int ExpenditureNum { get => expenditureNum; set => expenditureNum = value; }
        public string NumMaterial { get => numMaterial; set => numMaterial = value; }
        public int Amount { get => amount; set => amount = value; }

        public Expenditure_Material()
        {
            dBservices = new DBservices();
        }

        public void insert(Expenditure_Material MExpenditure)
        {
            //insert your code here
            dBservices.InsertMExpenditureToDB(MExpenditure);

        }
        public List<Expenditure_Material> returnExM(string mispar)
        {
            DBservices db = new DBservices();
            return db.returnExM(mispar);
        }
    }
}