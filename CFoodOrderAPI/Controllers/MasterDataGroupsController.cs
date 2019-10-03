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
    public class MasterDataGroupsController : ApiController
    {
        [HttpGet]
        [Route("api/MasterDataGroups/GetMasterDataGroups")]
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
                cmd.CommandText = "[dbo].[GetMasterDataGroups]";

               

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
        [Route("api/MasterDataGroups/InsUpDelMasterDataGroups")]
        public DataTable InsUpDelMasterDataGroups(MasterDataGroups m)
        {
            DataTable dt1 = new DataTable();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[InsUpDelMasterDataGroups]";

            SqlParameter fa = new SqlParameter("@flag", SqlDbType.VarChar, 10);
            fa.Value = m.flag;
            cmd.Parameters.Add(fa);

            SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
            id.Value = m.Id;
            cmd.Parameters.Add(id);

            SqlParameter nam = new SqlParameter("@Name", SqlDbType.VarChar, 50);
            nam.Value =m.Name;
            cmd.Parameters.Add(nam);

            SqlParameter des = new SqlParameter("@Description", SqlDbType.VarChar, 50);
            des.Value = m.Description;
            cmd.Parameters.Add(des);

            SqlParameter ac = new SqlParameter("@Active", SqlDbType.Int);
            ac.Value = m.Active;
            cmd.Parameters.Add(ac);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            return dt1;


        }
    }
}
