﻿using CFoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;

namespace CFoodOrder.Controllers
{
    public class appuserController : ApiController
    {
        [HttpGet]
        [Route("api/appuser/GetCustomerDetails")]

        public DataTable GetCustomerDetails(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetCustomerDetails";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = new SqlParameter("@par1", SqlDbType.Int);
            par1.Value = rc.par1;
            cmd.Parameters.Add(par1);

            SqlParameter par2 = new SqlParameter("@par2", SqlDbType.VarChar);
            par2.Value = rc.par2;
            cmd.Parameters.Add(par2);


            SqlParameter par5 = new SqlParameter("@par5", SqlDbType.VarChar);
            par5.Value = rc.par5;
            cmd.Parameters.Add(par5);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/AppUsers/Appusers")]
        public DataTable Appusers(UserAccount ocr)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdAppusers";

                cmd.Connection = conn;
                conn.Open();

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = ocr.flag;
                cmd.Parameters.Add(f);

                SqlParameter c = new SqlParameter("@Username", SqlDbType.VarChar, 20);
                c.Value = ocr.Username;
                cmd.Parameters.Add(c);

                SqlParameter ce = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                ce.Value = ocr.Email;
                cmd.Parameters.Add(ce);


                SqlParameter cm = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 20);
                cm.Value = ocr.Mobilenumber;
                cmd.Parameters.Add(cm);




                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


                if (ocr.flag == "I")
                {
                    //send email otp\
                    #region email opt

                    string eotp = dt.Rows[0]["Emailotp"].ToString();
                    string Mobilenumber = dt.Rows[0]["Mobilenumber"].ToString();


                    if (eotp != null)
                    {
                        try
                        {
                            MailMessage mail = new MailMessage();
                            string emailserver = ConfigurationManager.AppSettings["emailserver"].ToString();

                            string username = ConfigurationManager.AppSettings["username"].ToString();
                            string pwd = ConfigurationManager.AppSettings["password"].ToString();
                            string fromaddress = ConfigurationManager.AppSettings["fromaddress"].ToString();
                            string port = ConfigurationManager.AppSettings["port"].ToString();

                            SmtpClient SmtpServer = new SmtpClient(emailserver);

                            mail.From = new MailAddress(fromaddress);
                            mail.To.Add(ocr.Email);
                            mail.Subject = "User registration - Email OTP";
                            mail.IsBodyHtml = true;

                            string verifcodeMail = @"<table>
                                                                        <tr>
                                                                            <td>
                                                                                <h2>Thank you for registering with CFood APP</h2>
                                                                                <table width=\""760\"" align=\""center\"">
                                                                                    <tbody style='background-color:#f9a825;'>
                                                                                        <tr>
                                                                                            <td style=\""font-family:'Zurich BT',Arial,Helvetica,sans-serif;font-size:15px;text-align:left;line-height:normal;background-color:#f9a825;\"" >
                <div style='padding:10px;border:#0000FF solid 2px;'>    <br /><br />

                                                                       Your email OTP is:<h3>" + eotp + @" </h3>

                                                                      
                                                                                                <br/>
                                                                                                <br/>             

                                                                                                Warm regards,<br>
                                                                                                CFood Customer Service Team<br/><br />
                </div>
                                                                                            </td>
                                                                                        </tr>

                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>

                                                                    </table>";


                            mail.Body = verifcodeMail;
                            //SmtpServer.Port = 465;
                            //SmtpServer.Port = 587;
                            SmtpServer.Port = Convert.ToInt32(port);
                            SmtpServer.UseDefaultCredentials = false;

                            SmtpServer.Credentials = new NetworkCredential(username, pwd);
                            SmtpServer.EnableSsl = true;
                            //SmtpServer.TargetName = "STARTTLS/smtp.gmail.com";
                            SmtpServer.Send(mail);

                        }
                        catch (Exception ex)
                        {
                            //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
                        }

                    }

                    #endregion email otp
                }

                // Mobile OTP Send
                if (ocr.flag == "C")
                {
                    #region motp

                    string email = dt.Rows[0]["Email"].ToString();
                    string MOTP = dt.Rows[0]["Mobileotp"].ToString();


                    if (MOTP != null)
                    {
                        try
                        {
                            MailMessage mail = new MailMessage();
                            string emailserver = ConfigurationManager.AppSettings["emailserver"].ToString();

                            string username = ConfigurationManager.AppSettings["username"].ToString();
                            string pwd = ConfigurationManager.AppSettings["password"].ToString();
                            string fromaddress = ConfigurationManager.AppSettings["fromaddress"].ToString();
                            string port = ConfigurationManager.AppSettings["port"].ToString();

                            SmtpClient SmtpServer = new SmtpClient(emailserver);

                            mail.From = new MailAddress(fromaddress);
                            mail.To.Add(email);
                            mail.Subject = "User Mobile OTP";
                            mail.IsBodyHtml = true;

                            string verifcodeMail = @"<table>
                                                                        <tr>
                                                                            <td>
                                                                                <h2>Your Mobile OTP</h2>
                                                                                <table width=\""760\"" align=\""center\"">
                                                                                    <tbody style='background-color:#f9a825;'>
                                                                                        <tr>
                                                                                            <td style=\""font-family:'Zurich BT',Arial,Helvetica,sans-serif;font-size:15px;text-align:left;line-height:normal;background-color:#f9a825;\"" >
                <div style='padding:10px;border:#0000FF solid 2px;'>    <br /><br />

                                                                       Your Mobile OTP is:<h3>" + MOTP + @" </h3>

                                                                      
                                                                                                <br/>
                                                                                                <br/>             

                                                                                                Warm regards,<br>
                                                                                                CFood Customer Service Team<br/><br />
                </div>
                                                                                            </td>
                                                                                        </tr>

                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>

                                                                    </table>";


                            mail.Body = verifcodeMail;
                            //SmtpServer.Port = 465;
                            //SmtpServer.Port = 587;
                            SmtpServer.Port = Convert.ToInt32(port);
                            SmtpServer.UseDefaultCredentials = false;

                            SmtpServer.Credentials = new NetworkCredential(username, pwd);
                            SmtpServer.EnableSsl = true;
                            //SmtpServer.TargetName = "STARTTLS/smtp.gmail.com";
                            SmtpServer.Send(mail);

                        }
                        catch (Exception ex)
                        {
                            //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
                        }

                    }

                    #endregion motp
                }
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
        [Route("api/AppUsers/EOTPVerification")]
        public DataTable EOTPVerification(UserAccount ocr)
        {
            //int status = 0;
            DataTable tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
  
            try
            {

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EOTPverification";

                cmd.Connection = conn;

                SqlParameter q1 = new SqlParameter("@Email", SqlDbType.VarChar, 250);
                q1.Value = ocr.Email;
                cmd.Parameters.Add(q1);

                SqlParameter e = new SqlParameter("@Emailotp", SqlDbType.VarChar, 10);
                e.Value = ocr.EVerificationCode;
                cmd.Parameters.Add(e);

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = ocr.flag;
                cmd.Parameters.Add(f);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tbl);


            }
            catch (Exception ex)
            {
              
                tbl.Columns.Add("Code");
                tbl.Columns.Add("description");
                DataRow dr = tbl.NewRow();
                dr[0] = "ERR001";
                dr[1] = ex.Message;
                tbl.Rows.Add(dr);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
        
            }
            return tbl;

        
        }


        [HttpPost]
        [Route("api/appuser/InsUpdCustomerDetails")]

        public DataTable InsUpdCustomerDetails(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdCustomerDetails";
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
        [HttpPost]
        [Route("api/appuser/RegisterCustomer")]

        public DataTable RegisterCustomer(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "RegisterCustomer";
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
        [HttpGet]
        [Route("api/appuser/GetCustomerAppUsersList")]

        public DataTable GetCustomerAppUsersList(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetCustomerAppUsersList";
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
        [HttpPost]
        [Route("api/appuser/InsUpdCustomerAppUsers")]

        public DataTable InsUpdCustomerAppUsers(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdCustomerAppUsers";
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
        [HttpGet]
        [Route("api/appuser/VerifyMOTP")]

        public DataTable VerifyMOTP(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "VerifyMOTP";
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
        [HttpGet]
        [Route("api/appuser/VerifyPwdOTP")]

        public DataTable VerifyPwdOTP(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "VerifyPwdOTP";
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
        [HttpGet]
        [Route("api/appuser/ResetPassword")]

        public DataTable ResetPassword(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "ResetPassword";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = new SqlParameter("@par1", SqlDbType.Int);
            par1.Value = rc.par1;
            cmd.Parameters.Add(par1);





            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/appuser/ChangePassword")]

        public DataTable ChangePassword(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "ChangePassword";
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
        [HttpPost]
        [Route("api/appuser/InsUpdCustomerAppuserLogin")]

        public DataTable InsUpdCustomerAppuserLogin(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdCustomerAppuserLogin";
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
        [HttpGet]
        [Route("api/appuser/ValidateCustomerAppCredentails")]

        public DataTable ValidateCustomerAppCredentails(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "ValidateCustomerAppCredentails";
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


        [HttpPost]
        [Route("api/appuser/CustomerRating")]
        public DataTable CustomerRating(CustomerRating vb)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            StringBuilder str = new StringBuilder();
            try
            {

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "CustomerRating....");
                str.Append("Mobilenumber:" + vb.Mobilenumber + ",");
                str.Append("orderid:" + vb.orderid + ",");

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Input sent...." + str.ToString());

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CustomerRating";


                cmd.Parameters.Add("@Mobilenumber", SqlDbType.VarChar, 20).Value = vb.Mobilenumber;
                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = vb.orderid;
                cmd.Parameters.Add("@Rating", SqlDbType.Decimal).Value = vb.Rating;
                cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500).Value = vb.Comments;

                cmd.Connection = conn;

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                dt = ds.Tables[0];

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
