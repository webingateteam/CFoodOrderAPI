using CFoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CFoodOrderAPI.Controllers
{
    public class ItemsController : ApiController
    {

        [HttpGet]
        [Route("api/Items/GetDeliveryItems")]
        public DataTable GetDeliveryItems(int orderid)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "GetDeliveryItems";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@orderid", SqlDbType.Int)).SqlValue = orderid;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt.Columns.Add("Code");
                dt.Columns.Add("description");
                DataRow dr = dt.NewRow();
                dr[0] = "ERR001";
                dr[1] = ex.Message;
                dt.Rows.Add(dr);
            }
            return dt;
        }


        [HttpPost]
        [Route("api/Items/Itemschecking")]
        public DataTable Itemschecking(Itemschecking vb)
        {
            DataTable dt = new DataTable();            
            //LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            StringBuilder str = new StringBuilder();
            try
            {                
                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "CustomerRating....");
                str.Append("@ItemId:" + vb.ItemId + ",");
                str.Append("@orderid:" + vb.orderid + ",");
                str.Append("@Isavailable:" + vb.Isavailable + ",");

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Input sent...." + str.ToString());

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsupdDelItemsChecking";


                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = vb.ItemId;
                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = vb.orderid;
                cmd.Parameters.Add("@Isavailable", SqlDbType.Int).Value = vb.Isavailable;                

                cmd.Connection = conn;

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(dt);                

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "CustomerRating successful....");

            }
            catch (Exception ex)
            {
                //traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "CustomerRating...." + ex.Message.ToString());
                //throw ex;
                //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
                dt.Columns.Add("Code");
                dt.Columns.Add("description");
                DataRow dr = dt.NewRow();
                dr[0] = "ERR001";
                dr[1] = ex.Message;
                dt.Rows.Add(dr);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                SqlConnection.ClearPool(conn);
            }
            return dt;
        }
    }
}
