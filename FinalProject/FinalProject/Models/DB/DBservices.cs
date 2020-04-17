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

        public List<Material_certificate> GetMT()
        {

            List<Material_certificate> MCL = new List<Material_certificate>();
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM GLN_Material_certificate";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader();//(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Material_certificate a = new Material_certificate();

                    a.NumMaterial = Convert.ToInt32(dr["NumMaterial"]);
                    a.ShippingCertificate = (string)(dr["ShippingCertificate"]);
                    a.Amountcertificate = Convert.ToInt32(dr["Amountcertificate"]);

                    MCL.Add(a);
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
            return MCL;
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


    }
}