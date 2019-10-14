using CFoodOrder.Models;
using CFoodOrder.Models;
using CFoodOrderAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;

namespace CFoodOrder.Controllers
{
    public class BussinessAppUsersController : ApiController
    {
        [HttpGet]
        [Route("api/BusinessAppUser/GetBusinessappusersuser")]
        public DataTable GetBusinessappusersuser(string acct, int uit)
        {
            DataTable dt = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            StringBuilder str = new StringBuilder();
            try
            {

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Get Business App User....");

                str.Append("UserAccountNo:" + acct + ",");
                str.Append("usertypeid:" + uit + ",");


                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Input sent...." + str.ToString());

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetBusinessAppusers";

                cmd.Connection = conn;

                SqlParameter uaccno = new SqlParameter("@UserAccountNo", SqlDbType.VarChar, 15);
                uaccno.Value = acct;
                cmd.Parameters.Add(uaccno);

                SqlParameter utd = new SqlParameter("@UserTypeId", SqlDbType.Int);
                utd.Value = uit;
                cmd.Parameters.Add(utd);
                //DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //dt = ds.Tables[0];
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "successful Get Business App User");
            }
            catch (Exception ex)
            {
                traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "Get Business App User...." + ex.Message.ToString());
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
        [HttpPost]
        [Route("api/BusinessAppUsers/InsUpdBusinessAppUsers")]
        public DataTable InsUpdBusinessAppUsers(BusinessAppuser ocr)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdBusinessAppUsers";
            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = ocr.flag;
            cmd.Parameters.Add(f);

            SqlParameter c = new SqlParameter("@Username", SqlDbType.VarChar, 20);
            c.Value = ocr.Username;
            cmd.Parameters.Add(c);

            SqlParameter ce = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            ce.Value = ocr.Email;
            cmd.Parameters.Add(ce);


            SqlParameter cm = new SqlParameter("@Mobileotp", SqlDbType.VarChar, 20);
            cm.Value = ocr.Mobileotp;
            cmd.Parameters.Add(cm);

            SqlParameter q1 = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            q1.Value = ocr.Password;
            cmd.Parameters.Add(q1);

            SqlParameter v = new SqlParameter("@Firstname", SqlDbType.VarChar, 50);
            v.Value = ocr.Firstname;
            cmd.Parameters.Add(v);

            SqlParameter v1 = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
            v1.Value = ocr.lastname;
            cmd.Parameters.Add(v1);

            SqlParameter v2 = new SqlParameter("@AuthTypeId", SqlDbType.VarChar, 50);
            v2.Value = ocr.AuthTypeId;
            cmd.Parameters.Add(v2);

            SqlParameter u = new SqlParameter("@AltPhonenumber", SqlDbType.VarChar, 50);
            u.Value = ocr.AltPhonenumber;
            cmd.Parameters.Add(u);

            SqlParameter u1 = new SqlParameter("@Altemail", SqlDbType.VarChar, 50);
            u1.Value = ocr.Altemail;
            cmd.Parameters.Add(u1);

            SqlParameter i = new SqlParameter("@AccountNumber", SqlDbType.VarChar, 50);
            i.Value = ocr.AccountNo;
            cmd.Parameters.Add(i);

            SqlParameter ct = new SqlParameter("@CountryId", SqlDbType.Int);
            ct.Value = ocr.CountryId;
            cmd.Parameters.Add(ct);

            SqlParameter cts = new SqlParameter("@CurrentStateId", SqlDbType.Int);
            cts.Value = ocr.CurrentStateId;
            cmd.Parameters.Add(cts);

            SqlParameter pd = new SqlParameter("@UserPhoto", SqlDbType.VarChar, -1);
            pd.Value = ocr.UserPhoto;
            cmd.Parameters.Add(pd);

            SqlParameter paym = new SqlParameter("@PaymentModeId", SqlDbType.Int);
            paym.Value = ocr.PaymentModeId;
            cmd.Parameters.Add(paym);

            SqlParameter ccode = new SqlParameter("@CCode", SqlDbType.VarChar, 10);
            ccode.Value = ocr.CCode;
            cmd.Parameters.Add(ccode);

            SqlParameter uaccno = new SqlParameter("@UserAccountNo", SqlDbType.VarChar, 50);
            uaccno.Value = ocr.UserAccountNo;
            cmd.Parameters.Add(uaccno);

            SqlParameter active = new SqlParameter("@Active", SqlDbType.Int);
            active.Value = ocr.Active;
            cmd.Parameters.Add(active);

            SqlParameter utd = new SqlParameter("@usertypeid", SqlDbType.Int);
            utd.Value = ocr.usertypeid;
            cmd.Parameters.Add(utd);
            
            SqlParameter dob = new SqlParameter("@dateofbirth", SqlDbType.Int);
            dob.Value = ocr.DateofBirth;
            cmd.Parameters.Add(dob);

            SqlParameter gdd = new SqlParameter("@Gender", SqlDbType.Int);
            gdd.Value = ocr.Gender;
            cmd.Parameters.Add(gdd);

            SqlParameter amount = new SqlParameter("@Amount", SqlDbType.Int);
            amount.Value = ocr.Amount;
            cmd.Parameters.Add(amount);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        [HttpPost]
        [Route("api/BusinessAppUsers/InsUpdBusinessAppUserLogin")]
        public DataTable InsUpdBusinessAppUserLogin(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Storedprocedure";
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
