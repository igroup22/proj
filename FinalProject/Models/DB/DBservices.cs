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
        public List<Expenditure_Material> returnExM(string mispar)
        {
            List<Expenditure_Material> SCL = new List<Expenditure_Material>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM GLN_Expenditure_Material where ExpenditureNum='" + mispar + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Expenditure_Material a = new Expenditure_Material();

                    a.ExpenditureNum = Convert.ToInt32(dr["ExpenditureNum"]);
                    a.NumMaterial = (string)(dr["NumMaterial"]);
                    a.Amount = Convert.ToInt32(dr["Amount"]);
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
        //public List<ShippingCertificates> getSCertificates()
        //{
        //    List<ShippingCertificates> SCL = new List<ShippingCertificates>();
        //    SqlConnection con = null;

        //    try
        //    {
        //        con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

        //        String selectSTR = "SELECT * FROM GLN_ShippingCertificate";
        //        SqlCommand cmd = new SqlCommand(selectSTR, con);

        //        // get a reader
        //        SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

        //        while (dr.Read())
        //        {   // Read till the end of the data into a row
        //            ShippingCertificates a = new ShippingCertificates();

        //            a.ShippingCertificate = Convert.ToInt32(dr["ShippingCertificate"]);
        //            a.DateReceive = (string)(dr["DateReceive"]);
        //            SCL.Add(a);
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
        //    return SCL;
        //}

        public List<Expenditure> returnExpenditure()
        {
            List<Expenditure> SCL = new List<Expenditure>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM GLN_Expenditure";
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

        public List<Zone> returnZone()
        {
            List<Zone> SCL = new List<Zone>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "  select                                                        "
                                     + " [Area]                                                      "
                                     + ",'MClassification' = ISNULL([MClassification],'אזור מת')    "
                                     + ",'Production' = ISNULL([Production],'אין מוצר')             "
                                     + ",'AmountN'=ISNULL([AmountN],'2')                                                 "
                                     + ",[X]                                                         "
                                     + ",[Y]                                                         "
                                     + ",[Z]                                       "
                                     + ",'ID'=ISNULL([ID],'11111')                                   "
                                     + ",'ExpenditureDate'=ISNULL([ExpenditureDate],'1/1/1899')      "
                                     + "                                                             "
                                     + " from[GLN_Zone1]                                           "
                                     + "ORDER BY Y ASC ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Zone a = new Zone();

                    a.Area = (float)Convert.ToDouble(dr["Area"]);
                    a.MClassification = (string)(dr["MClassification"]);
                    a.Production = (string)(dr["Production"]);
                    a.AmountN = (float)Convert.ToDouble(dr["AmountN"]);
                    a.X = (float)Convert.ToDouble(dr["X"]);
                    a.Y = (float)Convert.ToDouble(dr["Y"]);
                    a.Z = (float)Convert.ToDouble(dr["Z"]);
                    a.ID = (string)(dr["ID"]);
                    a.ExpenditureDate = (string)(dr["ExpenditureDate"]);

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

        //public List<Zone> returnZone()
        //{
        //    List<Zone> SCL = new List<Zone>();
        //    SqlConnection con = null;

        //    try
        //    {
        //        con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

        //        String selectSTR = "SELECT * FROM GLN_Zone";
        //        SqlCommand cmd = new SqlCommand(selectSTR, con);

        //        // get a reader
        //        SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

        //        while (dr.Read())
        //        {   // Read till the end of the data into a row
        //            Zone a = new Zone();

        //            a.Area = Convert.ToInt32(dr["Area"]);
        //            a.MClassification = (string)(dr["MClassification"]);
        //            a.Production = (string)(dr["Production"]);
        //            a.AmountN = Convert.ToInt32(dr["AmountN"]);
        //            a.X = Convert.ToInt32(dr["X"]);
        //            a.Y = Convert.ToInt32(dr["Y"]);
        //            a.Z = Convert.ToInt32(dr["Z"]);
        //            a.ID = (string)(dr["ID"]);
        //            a.ExpenditureDate = (string)(dr["ExpenditureDate"]);

        //            SCL.Add(a);
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
        //    return SCL;
        //}
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
        public int updatez(Zone zed)
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

            sb.AppendFormat("UPDATE GLN_Zone1 SET  [Area]= '{0}',[Production]= '{1}',[AmountN]={2},[ID]= '{3}', [ExpenditureDate]= '{4}' WHERE GLN_Zone1.[X]='{5}' and GLN_Zone1.[Y]= '{6}' and GLN_Zone1.[Z] = '{7}'", zed.Area, zed.Production, zed.AmountN, zed.ID, zed.ExpenditureDate, zed.X, zed.Y, zed.Z);
            //sb.AppendFormat("UPDATE GLN_Zone1 SET  [Area]= {0},[MClassification]= '{1}',[Production]= '{2}',[AmountN]={3},[ID]= '{4}', [ExpenditureDate]= '{5}' WHERE GLN_Zone1.[X]={6} and GLN_Zone1.[Y]= {7} and GLN_Zone1.[Z] = {8}", zed.Area,zed.MClassification, zed.Production,zed.AmountN,zed.X, zed.Y, zed.Z, zed.ID, zed.ExpenditureDate);
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
        public List<Employee> getemployee(string employ, string psw)
        {
            List<Employee> EML = new List<Employee>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM GLN_employee where EmployeeNum='" + employ + "' AND UserPassword='" + psw + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    Employee e = new Employee();
                    e.EmployeeNum = (string)(dr["EmployeeNum"]);
                    e.EmployeeFName = (string)(dr["EmployeeFName"]);
                    e.EmployeeLName = (string)(dr["EmployeeLName"]);
                    e.UserName = (string)(dr["UserName"]);
                    e.UserPassword = (string)(dr["UserPassword"]);

                    e.RoleNum = Convert.ToInt16(dr["RoleNum"]);

                    EML.Add(e);
                }

                return EML;
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
                    M.MaterialName = (string)dr["MaterialName"];
                    M.IdAmount = (string)dr["IdAmount"];
                    M.MaterialClassification = (string)dr["MaterialClassification"];

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








        public List<InvCheck> ReadNumber(string datenum)
        {

            List<InvCheck> INC = new List<InvCheck>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create the connection
                String selectSTR = "SELECT * FROM GLN_InventoryCheck WHERE CheckNumber=(SELECT MAX(CheckNumber) FROM GLN_InventoryCheck WHERE CheckDate='" + datenum + "')";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    InvCheck ic = new InvCheck();
                    ic.CheckNumber = Convert.ToInt16(dr["CheckNumber"]);
                    ic.CheckDate = (string)(dr["CheckDate"]);
                    ic.EmployeeNum = (string)(dr["EmployeeNumber"]);

                    INC.Add(ic);
                }

                return INC;

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



            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO GLN_InventoryCheck (CheckDate, EmployeeNumber)output INSERTED.CheckNumber Values('{0}', '{1}')", icheck.CheckDate, icheck.EmployeeNum);
            String cStr = sb.ToString();
            // helper method to build the insert string

            cmd = CreateCommand(cStr, con);      // create the command

            try
            {

                int numE = cmd.ExecuteNonQuery(); // execute the command
                int numEffected = Convert.ToInt32(cmd.ExecuteScalar());

                return numEffected;

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

        }


        public List<ManagerCheck> ReadList()
        {
            List<ManagerCheck> SRL = new List<ManagerCheck>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT DISTINCT GLN_ICheckDetailes.NumMaterial,GLN_ICheckDetailes.ProductionID,GLN_Inventory.AmountInventory,GLN_ICheckDetailes.AmountCheck,GLN_ICheckDetailes.CheckNumber from GLN_ICheckDetailes inner join GLN_Inventory ON((GLN_Inventory.NumMaterial = GLN_ICheckDetailes.NumMaterial) AND(GLN_Inventory.ProductionID = GLN_ICheckDetailes.ProductionID))";
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
            int numEffected = 0;

            try
            {
                cStr = BuildInsertCommand(details);      // helper method to build the insert string
                cmd = CreateCommand(cStr, con);      // create the command
                int numE = cmd.ExecuteNonQuery(); // execute the command
                //numEffected = Convert.ToInt32(cmd.ExecuteScalar());
                numEffected += cmd.ExecuteNonQuery();

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
