using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CFoodOrder.Models;

namespace CFoodOrderAPI.Controllers
{
    public class TransactionMasterController : ApiController
    {
        [HttpGet]

        public DataTable getTransactionMaster()
        {
            DataTable Tbl = new DataTable();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getTroubleTicketingDetails credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getTransactionMaster";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getTroubleTicketingDetails Credentials completed.");
            // int found = 0;
            return Tbl;
        }

        [HttpPost]

        public DataTable saveTroubleTicketingDetails(TransactionMaster n)
        {
            DataTable Tbl = new DataTable();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveTroubleTicketingDetails credentials....");
            try
            {
                //connect to database
                SqlConnection conn = new SqlConnection();
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTransactionMaster";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@flag";
                gs.SqlDbType = SqlDbType.VarChar;
                gs.Value = n.flag;
                cmd.Parameters.Add(gs);

            

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@Amount";
                gsa.SqlDbType = SqlDbType.Decimal;
                gsa.Value = n.Amount;
                cmd.Parameters.Add(gsa);


                SqlParameter gssa = new SqlParameter();
                gssa.ParameterName = "@Charges";
                gssa.SqlDbType = SqlDbType.Decimal;
                gssa.Value = n.Charges;
                cmd.Parameters.Add(gssa);

                SqlParameter gsad = new SqlParameter();
                gsad.ParameterName = "@Discount";
                gsad.SqlDbType = SqlDbType.Decimal;
                gsad.Value = n.Discount;
                cmd.Parameters.Add(gsad);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@TotalAmount";
                gid.SqlDbType = SqlDbType.Decimal;
                gid.Value = n.TotalAmount;
                cmd.Parameters.Add(gid);

             


                // cmd.ExecuteScalar();

                // DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(Tbl);
                //Tbl = ds.Tables[0];
                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveTroubleTicketingDetails Credentials completed.");

            }
            catch (Exception ex)
            {
                throw ex;
                //traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveTroubleTicketingDetails:" + ex.Message);
            }

            // int found = 0;
            return Tbl;

        }
    }
}
