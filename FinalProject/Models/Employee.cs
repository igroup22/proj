using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DB;
namespace FinalProject.Models
{
    public class Employee
    {
        String employeeNum;
        String employeeFName;
        String employeeLName;
        String userName;
        String userPassword;
        int roleNum;


        public Employee()
        { 
        }

        public Employee(string employeeNum, string employeeFName, string employeeLName, string userName, string userPassword, int roleNum)
        {
            this.employeeNum = employeeNum;
            this.employeeFName = employeeFName;
            this.employeeLName = employeeLName;
            this.userName = userName;
            this.userPassword = userPassword;
            this.roleNum = roleNum;
        }

        public string EmployeeNum { get => employeeNum; set => employeeNum = value; }
        public string EmployeeFName { get => employeeFName; set => employeeFName = value; }
        public string EmployeeLName { get => employeeLName; set => employeeLName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public int RoleNum { get => roleNum; set => roleNum = value; }
   
    public int postemp(Employee emp)
        {
            DBservices db = new DBservices();
            return db.postemp(emp);
        }

        public List<Employee> getemployee(string employ, string psw)
        {
            DBservices dbs = new DBservices();
            return dbs.getemployee(employ, psw);
        }
        //public List<Employee> getemployee()
        //{
        //    DBservices db = new DBservices();
        //    return db.getemployee();
        //}
    }
}