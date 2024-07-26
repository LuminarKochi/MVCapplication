using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MVCapplication.Models
{
    public class StateDistrictDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestCon"].ConnectionString;
        SqlConnection con;
        public StateDistrictDB()
        {
            con = new SqlConnection(connectionString);
        }
        public List<stclass1> Selectstates()
        {
            var getdata = new List<stclass1>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_state", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var o = new stclass1
                    {
                        sId = Convert.ToInt32(sdr["StateId"]),//set //(same as table field name)
                        sName = sdr["StateName"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch(Exception ex)
            {
                if(con.State== ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
        public List<dtclass> Selectdistricts(int stateId)
        {
            var getdata = new List<dtclass>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_districts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stid", stateId);//get
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var o = new dtclass
                    {
                        dId = Convert.ToInt32(sdr["DId"]),//set //(same as table field name)
                        dName = sdr["DName"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }
}