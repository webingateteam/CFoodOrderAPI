using CFoodOrder.Models.CFood.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CFoodOrder.Controllers
{
    public class CountryController : ApiController
    {
        public object ID { get; private set; }

        [HttpGet]
        [Route("api/Country/GetCountries")]
        public DataTable GetCountries(int active)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();

            try
            {

                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[GetCountries]";

                SqlParameter nam = new SqlParameter("@active", SqlDbType.Int);
                nam.Value = active;
                cmd.Parameters.Add(nam);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return dt;
        }




        [HttpPost]
        [Route("api/Country/InsUpdCountry")]
        public DataTable InsUpdCountry(country c)
        {

            DataTable dt1 = new DataTable();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[InsUpdCountry]";

            SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
            id.Value = c.Id;
            cmd.Parameters.Add(id);

            SqlParameter has = new SqlParameter("@HasOperations ", SqlDbType.Int);
            has.Value = c.HasOperations;
            cmd.Parameters.Add(has);



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            return dt1;




        }
        [HttpGet]
        [Route("api/Country/GetZipCodes")]
        public DataTable GetZipCodes(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetZipCodes";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = new SqlParameter("@par1", SqlDbType.Int);
            par1.Value = rc.par1;
            cmd.Parameters.Add(par1);

            SqlParameter par2 = new SqlParameter("@par2", SqlDbType.VarChar);
            par2.Value = rc.par2;
            cmd.Parameters.Add(par2);

            SqlParameter par3 = new SqlParameter("@par3", SqlDbType.VarChar);
            par3.Value = rc.par3;
            cmd.Parameters.Add(par3);

            SqlParameter par4 = new SqlParameter("@par4", SqlDbType.VarChar);
            par4.Value = rc.par4;
            cmd.Parameters.Add(par4);

            SqlParameter par5 = new SqlParameter("@par5", SqlDbType.VarChar);
            par5.Value = rc.par5;
            cmd.Parameters.Add(par5);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }


    }

}
