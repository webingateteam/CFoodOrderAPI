using CFoodOrder.Models;
using CFoodOrder.Models.CFood.Models;
using CFoodOrderAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CFoodOrder.Controllers
{
    public class FaqsController : ApiController
    {

        [HttpGet]
        [Route("api/Faqs/Getfaqs")]
        public DataTable Getfaqs()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();


            try
            {
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getfaqs....");

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Getfaqs";
                cmd.Connection = conn;

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(Tbl);
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getfaqs successful....");

            }
            catch (Exception ex)
            {
                traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "Getfaqs...." + ex.Message.ToString());
                //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
                Tbl.Columns.Add("Code");
                Tbl.Columns.Add("description");
                DataRow dr = Tbl.NewRow();
                dr[0] = "ERR001";
                dr[1] = ex.Message;
                Tbl.Rows.Add(dr);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                SqlConnection.ClearPool(conn);
            }
            // int found = 0;
            return Tbl;

        }

        [HttpPost]
        [Route("api/Faqs/faqsdetails")]
        public DataTable faqsdetails(FAQs f)
        {
            DataTable dt = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            StringBuilder str = new StringBuilder();
            try
            {
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "faqsdetails....");
                str.Append("Question:" + f.Question + ",");
                str.Append("Answer:" + f.Answer + ",");
                str.Append("Catid:" + f.Category + ",");

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Input sent...." + str.ToString());

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insupddelfaqs";

                cmd.Connection = conn;


                SqlParameter q = new SqlParameter("@Id", SqlDbType.Int);
                q.Value = f.Id;
                cmd.Parameters.Add(q);

                SqlParameter q1 = new SqlParameter("@Question", SqlDbType.VarChar, 500);
                q1.Value = f.Question;
                cmd.Parameters.Add(q1);

                SqlParameter e = new SqlParameter("@Answer", SqlDbType.VarChar, 500);
                e.Value = f.Answer;
                cmd.Parameters.Add(e);

                SqlParameter t = new SqlParameter("@Category", SqlDbType.Int);
                t.Value = f.Category;
                cmd.Parameters.Add(t);

                SqlParameter  sub= new SqlParameter("@SubCategory", SqlDbType.Int);
                sub.Value = f.SubCategory;
                cmd.Parameters.Add(sub);

                SqlParameter c = new SqlParameter("@CreatedOn", SqlDbType.Date);
                c.Value = f.CreatedOn;
                cmd.Parameters.Add(c);

                SqlParameter b = new SqlParameter("@createdby", SqlDbType.Int);
                b.Value = f.CreatedBy;
                cmd.Parameters.Add(b);



                SqlParameter f1 = new SqlParameter("@flag", SqlDbType.VarChar);
                f1.Value = f.flag;
                cmd.Parameters.Add(f1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "faqsdetails successful....");

            }
            catch (Exception ex)
            {
                traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "faqsdetails...." + ex.Message.ToString());
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
            return (dt);

            //Verify Passwordotp

        }
    }
}
