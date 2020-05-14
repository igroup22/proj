using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using FinalProject.Models;

namespace FinalProject.Models.DB
{
    public class DBservices
    {

        public List<ShippingCertificates> getSCertificates()
        {
            List<ShippingCertificates> SCL = new List<ShippingCertificates>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM GLN_ShippingCertificate";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    ShippingCertificates a = new ShippingCertificates();

                    a.ShippingCertificate = Convert.ToInt32(dr["ShippingCertificate"]);
                    a.DateReceive = (string)(dr["DateReceive"]);
                    SCL.Add(a);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return SCL;
        }

        public SqlConnection Connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        public List<ShippingReceived> getSR()
        {
            List<ShippingReceived> SRL = new List<ShippingReceived>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM GLN_ShippingReceived";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    ShippingReceived a = new ShippingReceived();

                    a.NumMaterial = (string)(dr["NumMaterial"]);
                    a.ProductionID = (string)(dr["ProductionID"]);
                    a.AmountExcepted = Convert.ToInt32(dr["AmountExcepted"]);
                    a.AmountReceived = Convert.ToInt32(dr["AmountReceived"]);
                    a.ShippingCertificate = (string)(dr["ShippingCertificate"]);
                    SRL.Add(a);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return SRL;
        }

        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }

        public int updateSR(ShippingReceived shippingR)
        {

            int numEffected = 0;
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = Connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("UPDATE GLN_ShippingReceived SET  [NumMaterial]= '{0}',[ProductionID]= '{1}',[AmountExcepted]= '{2}', [AmountReceived]= '{3}',[ShippingCertificate] = '{4}' WHERE GLN_ShippingReceived.[NumMaterial]='{5}' and [ProductionID]= '{6}' and [ShippingCertificate] = '{7}'", shippingR.NumMaterial, shippingR.ProductionID, shippingR.AmountExcepted, shippingR.AmountReceived, shippingR.ShippingCertificate, shippingR.NumMaterial, shippingR.ProductionID, shippingR.ShippingCertificate);
            String cStr = sb.ToString();
            // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                numEffected += cmd.ExecuteNonQuery(); // execute the command

            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }


            return numEffected;
        }

        private String BuildInsertCommand(ShippingReceived shippingR)
        {
            String command;


            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}','{4}')", shippingR.NumMaterial, shippingR.ProductionID, shippingR.AmountExcepted, shippingR.AmountReceived, shippingR.ShippingCertificate);
            String prefix = "INSERT INTO GLN_ShippingReceived " + "(NumMaterial, ProductionID, AmountExcepted, AmountReceived, ShippingCertificate) ";
            command = prefix + sb.ToString();

            return command;
        }

        private String BuildInsertCommand(Employee emp)
        {
            String command;


            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}','{4}','{5}')", emp.EmployeeNum, emp.EmployeeFName, emp.EmployeeLName, emp.UserName, emp.UserPassword, emp.RoleNum);
            String prefix = "INSERT INTO GLN_employee " + "(EmployeeNum, EmployeeFName, EmployeeLName, UserName, UserPassword,RoleNum) ";
            command = prefix + sb.ToString();

            return command;
        }

        public int newmaterial(ShippingReceived shippingR)
        {
            SqlConnection con;
            SqlCommand cmd;


            try
            {
                con = Connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            String cStr = "";
            try
            {


                int numEffected = 0;
                cStr = BuildInsertCommand(shippingR);      // helper method to build the insert string
                cmd = CreateCommand(cStr, con);      // create the command
                numEffected += cmd.ExecuteNonQuery(); // execute the command



                return numEffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cStr);
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        public int InventoryUpdate(Inventory materialInventory)
        {
            int numEffected = 0;
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = Connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("UPDATE GLN_Inventory SET  [NumMaterial]= '{0}',[ProductionID]= '{1}',[AmountInventory]= '{2}' WHERE GLN_Inventory.[NumMaterial]='{3}' and [ProductionID]= '{4}'", materialInventory.NumMaterial, materialInventory.ProductionID, materialInventory.AmountInventory, materialInventory.NumMaterial, materialInventory.ProductionID);
            String cStr = sb.ToString();
            // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                numEffected += cmd.ExecuteNonQuery(); // execute the command

            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }


            return numEffected;
        }

        public List<Inventory> getinventiry()
        {
            List<Inventory> IN = new List<Inventory>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM GLN_Inventory";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                while (dr.Read())
                {
                    Inventory a = new Inventory();
                    a.NumMaterial = (string)(dr["NumMaterial"]);
                    a.ProductionID = (string)(dr["ProductionID"]);
                    a.AmountInventory = Convert.ToInt32(dr["AmountInventory"]);
                    IN.Add(a);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return IN;
        }

        public int postemp(Employee emp)
        {
            SqlConnection con;
            SqlCommand cmd;


            try
            {
                con = Connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            String cStr = "";
            try
            {


                int numEffected = 0;
                cStr = BuildInsertCommand(emp);      // helper method to build the insert string
                cmd = CreateCommand(cStr, con);      // create the command
                numEffected += cmd.ExecuteNonQuery(); // execute the command



                return numEffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cStr);
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        public Employee getemployee(string employeeNum)
        {
            Employee emp = new Employee();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM GLN_employee where EmployeeNum=" + employeeNum;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row


                    emp.EmployeeNum = (string)(dr["EmployeeNum"]);
                    emp.EmployeeFName = (string)(dr["EmployeeFName"]);
                    emp.EmployeeLName = (string)(dr["EmployeeLName"]);
                    emp.UserName = (string)(dr["UserName"]);
                    emp.UserPassword = (string)(dr["UserPassword"]);
                    emp.RoleNum = Convert.ToInt32(dr["RoleNum"]);

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return emp;

        }

        //public List<Employee> getemployee()
        //{
        //    List<Employee> emplist = new List<Employee>();
        //    SqlConnection con = null;

        //    try
        //    {
        //        con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

        //        String selectSTR = "SELECT * FROM GLN_employee ";
        //        SqlCommand cmd = new SqlCommand(selectSTR, con);

        //        // get a reader
        //        SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

        //        while (dr.Read())
        //        {   // Read till the end of the data into a row

        //            Employee emp = new Employee();
        //            emp.EmployeeNum = (string)(dr["EmployeeNum"]);
        //            emp.EmployeeFName = (string)(dr["EmployeeFName"]);
        //            emp.EmployeeLName = (string)(dr["EmployeeLName"]);
        //            emp.UserName = (string)(dr["UserName"]);
        //            emp.UserPassword = (string)(dr["UserPassword"]);
        //            emp.RoleNum = Convert.ToInt32(dr["RoleNum"]);
        //            emplist.Add(emp);
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return emplist;

        //}

        ///lee
        public List<Material> getNumMaterial()
        {
            List<Material> NumMaterialList = new List<Material>();
            SqlConnection con = null;
            SqlCommand cmd;


            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            try
            {

                String selectSTR = "SELECT * FROM GLN_Material";
                cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Material M = new Material();
                    M.NumMaterial = (string)dr["NumMaterial"];
                    //M.MaterialName = (string)dr["MaterialName"];
                    //M.IdAmount = (string)dr["IdAmount"];

                    NumMaterialList.Add(M);
                }

                return NumMaterialList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        ///post ראשון
        public int InsertExpenditureToDB(Expenditure expenditure)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = Connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = "";
            try
            {
                cStr = BuildInsertCommand(expenditure);      // helper method to build the insert string
                cmd = CreateCommand(cStr, con);      // create the command
                int numE = cmd.ExecuteNonQuery(); // execute the command
                int numEffected = Convert.ToInt32(cmd.ExecuteScalar());

                return numEffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cStr);
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }


        }
        private String BuildInsertCommand(Expenditure expenditure)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}')", expenditure.ExpenditureDate, expenditure.EmployeeNum, expenditure.ProductionID);
            String prefix = "INSERT INTO GLN_Expenditure " + "(ExpenditureDate, EmployeeNum, ProductionID) output INSERTED.ExpenditureNum ";

            command = prefix + sb.ToString();

            return command;


        }

        ///Post שני
        public int InsertMExpenditureToDB(Expenditure_Material MExpenditure)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = Connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            try
            {
                String cStr = "";
                //String cStr = "";
                int numEffected = 0;

                cStr = BuildInsertCommand(MExpenditure);      // helper method to build the insert string
                cmd = CreateCommand(cStr, con);             // create the command
                numEffected += cmd.ExecuteNonQuery(); // execute the command

                return numEffected;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();

                }
            }

        }
        private String BuildInsertCommand(Expenditure_Material MExpenditure)
        {
            String command;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Values({0}, '{1}' ,{2})", MExpenditure.ExpenditureNum, MExpenditure.NumMaterial, MExpenditure.Amount);
            String prefix = "INSERT INTO GLN_Expenditure_Material  " + "(ExpenditureNum,NumMaterial,Amount) ";
            command = prefix + sb.ToString();

            return command;
        }
        ///גל
        public List<CInventory> getinventirychecklist()
        {
            List<CInventory> ci = new List<CInventory>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT GLN_Inventory.NumMaterial, GLN_Material.MaterialName, GLN_Inventory.ProductionID FROM GLN_Inventory INNER JOIN GLN_Material ON(GLN_Inventory.NumMaterial = GLN_Material.NumMaterial)";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                while (dr.Read())
                {
                    CInventory c = new CInventory();
                    c.MaterialId = (string)(dr["NumMaterial"]);
                    c.MaterialName = (string)(dr["MaterialName"]);
                    c.ProductionId = (string)(dr["ProductionID"]);
                    ci.Add(c);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return ci;
        }

        // פוסט לטבלת ספירות (מספר ספירה-תאריך ספירה-מס עובד שביצע את הספירה)
        private String BuildInsertCommand(InvCheck Ic)
        {
            String command;


            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}')", Ic.CheckDate, Ic.EmployeeNum);
            String prefix = "INSERT INTO GLN_InventoryCheck " + "(CheckDate, EmployeeNumber) ";
            command = prefix + sb.ToString();

            return command;
        }


        public int InsertCheckToDB(InvCheck icheck)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = Connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = "";
            try
            {
                cStr = BuildInsertCommand(icheck);      // helper method to build the insert string
                cmd = CreateCommand(cStr, con);      // create the command
                int numE = cmd.ExecuteNonQuery(); // execute the command
                int numEffected = Convert.ToInt32(cmd.ExecuteScalar());

                return numEffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cStr);
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }


        }

        public List<ManagerCheck> ReadList()
        {
            List<ManagerCheck> SRL = new List<ManagerCheck>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select GLN_ICheckDetailes.NumMaterial,GLN_ICheckDetailes.ProductionID,GLN_Inventory.AmountInventory,GLN_ICheckDetailes.AmountCheck,GLN_ICheckDetailes.CheckNumber from GLN_ICheckDetailes inner join GLN_Inventory ON((GLN_Inventory.NumMaterial = GLN_ICheckDetailes.NumMaterial) AND(GLN_Inventory.ProductionID = GLN_ICheckDetailes.ProductionID))";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    ManagerCheck a = new ManagerCheck();

                    a.MaterialId = (string)(dr["NumMaterial"]);
                    a.ProductionId = (string)(dr["ProductionID"]);
                    a.InventoryAmount = Convert.ToInt32(dr["AmountInventory"]);
                    a.CheckAmount = Convert.ToInt32(dr["AmountCheck"]);
                    a.CheckNumber = Convert.ToInt32(dr["CheckNumber"]);
                    SRL.Add(a);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return SRL;
        }
        public List<Expenditure> returnexp()
        {
            List<Expenditure> exp = new List<Expenditure>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from GLN_Expenditure";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Expenditure a = new Expenditure();

               
                    a.ExpenditureNum = Convert.ToInt32(dr["ExpenditureNum"]);
                    a.ExpenditureDate = (string)(dr["ExpenditureDate"]);
                    a.EmployeeNum = (string)(dr["EmployeeNum"]);
                    a.ProductionID = (string)(dr["ProductionID"]);
                    exp.Add(a);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return exp;
        }
        public int InsertDetailsToDB(InvDetails details)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = Connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = "";
            try
            {
                cStr = BuildInsertCommand(details);      // helper method to build the insert string
                cmd = CreateCommand(cStr, con);      // create the command
                int numE = cmd.ExecuteNonQuery(); // execute the command
                int numEffected = Convert.ToInt32(cmd.ExecuteScalar());

                return numEffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cStr);
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }


        }

        private String BuildInsertCommand(InvDetails details)
        {
            String command;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Values({0}, '{1}' ,'{2}',{3})", details.CheckNumber, details.MaterialId, details.ProductionId, details.Amount);
            String prefix = "INSERT INTO GLN_ICheckDetailes  " + "(CheckNumber,NumMaterial,ProductionID, AmountCheck) ";
            command = prefix + sb.ToString();

            return command;
        }


    }
}
