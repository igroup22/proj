using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;

namespace FinalProject.Models
{
    public class InvCheck
    {
        int checkNumber;
        string checkDate;
        string employeeNum;
        
        DBservices db;

        public string CheckDate { get => checkDate; set => checkDate = value; }
        public string EmployeeNum { get => employeeNum; set => employeeNum = value; }
        public int CheckNumber { get => checkNumber; set => checkNumber = value; }

        public InvCheck()
        {
            DBservices db = new DBservices();
        }

        public InvCheck(int checkNumber, string checkDate, string employeeNum)
        {
            this.checkNumber = checkNumber;
            this.checkDate = checkDate;
            this.employeeNum = employeeNum;
        }

        public List<InvCheck> ReadNumber( string datenum)
        {
            DBservices db = new DBservices();
            return db.ReadNumber(datenum);
        }

        public int insert(InvCheck Icheck)
        {
            DBservices db = new DBservices();
            return db.InsertCheckToDB(Icheck);
        }
    }
}