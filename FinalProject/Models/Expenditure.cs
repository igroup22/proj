using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;
namespace FinalProject.Models
{

    public class Expenditure
    {
        int expenditureNum;
        string expenditureDate;
        string employeeNum;
        string productionID;

        DBservices dBservices;
        public Expenditure(int expenditureNum, string expenditureDate, string employeeNum, string productionID)
        {
            this.ExpenditureNum = expenditureNum;
            this.ExpenditureDate = expenditureDate;
            this.EmployeeNum = employeeNum;
            this.ProductionID = productionID;
        }

        public int ExpenditureNum { get => expenditureNum; set => expenditureNum = value; }
        public string ExpenditureDate { get => expenditureDate; set => expenditureDate = value; }
        public string EmployeeNum { get => employeeNum; set => employeeNum = value; }
        public string ProductionID { get => productionID; set => productionID = value; }

        public Expenditure()
        {
            dBservices = new DBservices();
        }

        public int insert(Expenditure expenditure)
        {
            DBservices db = new DBservices();
            return db.InsertExpenditureToDB(expenditure);
        }
        public List<Expenditure> returnExpenditure()
        {
            DBservices db = new DBservices();
            return db.returnExpenditure();
        }
    }
}