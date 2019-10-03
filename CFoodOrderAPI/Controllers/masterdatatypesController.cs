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
    public class masterdatatypesController : ApiController
    {
        [HttpGet]
        [Route("api/masterdatatypes/GetMasterDataTypes")]
        public DataTable GetMasterDataGroups()
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();

            try
            {

                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[GetMasterDataTypes]";



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return dt;
        }



        [HttpGet]
        [Route("api/masterdatatypes/GetDataTypesByGroupId")]
        public DataTable GetDataTypesByGroupId(int grpid)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();

            try
            {

                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTypesByGroupId";

                SqlParameter id = new SqlParameter("@gid", SqlDbType.Int);
                id.Value = grpid;
                cmd.Parameters.Add(id);

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
        [Route("api/masterdatatypes/InSUpDMasterDataTypes")]
        public DataTable InSUpDMasterDataTypes(MasterDatatypes m1)
        {
            DataTable dt1 = new DataTable();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[InSUpDMasterDataTypes]";

           

            SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
            id.Value = m1.Id;
            cmd.Parameters.Add(id);

            SqlParameter nam = new SqlParameter("@Name", SqlDbType.VarChar, 50);
            nam.Value = m1.Name;
            cmd.Parameters.Add(nam);

            SqlParameter des = new SqlParameter("@Description", SqlDbType.VarChar, 50);
            des.Value = m1.Description;
            cmd.Parameters.Add(des);

            SqlParameter ac = new SqlParameter("@Active", SqlDbType.Int);
            ac.Value = m1.Active;
            cmd.Parameters.Add(ac);

            SqlParameter t = new SqlParameter("@TypeGroupId", SqlDbType.Int);
            t.Value = m1.TypeGroupId;
            cmd.Parameters.Add(t);

            SqlParameter l = new SqlParameter("@listkey", SqlDbType.VarChar, 10);
            l.Value = m1.listkey;
            cmd.Parameters.Add(l);

            SqlParameter lv = new SqlParameter("@listvalue", SqlDbType.VarChar, 20);
            lv.Value = m1.listvalue;
            cmd.Parameters.Add(lv);

            SqlParameter fa = new SqlParameter("@flag", SqlDbType.VarChar, 10);
            fa.Value = m1.flag;
            cmd.Parameters.Add(fa);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            return dt1;


        }
    }
}