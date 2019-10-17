using CFoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace CFoodOrderAPI.Controllers
{
    public class DeliveryStaffLoginController : ApiController
    {
        [HttpPost]
        [Route("api/DeliveryStaffLogin/DStafflogin")]
        public DataTable DStafflogin(dstafflogin dl)
        {
            //LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DStafflogin....");

                StringBuilder str = new StringBuilder();
                str.Append("@loginlogout" + dl.loginlogout + ",");
                str.Append("@mobileno" + dl.Mobileno + ",");
                str.Append("@Reason" + dl.Reason + ",");
                str.Append("@LoginLatitude" + dl.LoginLatitude + ",");
                str.Append("@LoginLongitude" + dl.LoginLongitude + ",");

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DStafflogin Input sent...." + str.ToString());

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDeliveryStaffLogin";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@loginlogout", SqlDbType.Int);
                ff.Value = dl.loginlogout;
                cmd.Parameters.Add(ff);


                SqlParameter n = new SqlParameter("@mobileno", SqlDbType.VarChar, 20);
                n.Value = dl.Mobileno;
                cmd.Parameters.Add(n);

                SqlParameter j2 = new SqlParameter("@Reason", SqlDbType.VarChar, 500);
                j2.Value = dl.Reason;
                cmd.Parameters.Add(j2);

                SqlParameter h = new SqlParameter("@LoginLatitude", SqlDbType.Float);
                h.Value = dl.LoginLatitude;
                cmd.Parameters.Add(h);

                SqlParameter j = new SqlParameter("@LoginLongitude", SqlDbType.Float);
                j.Value = dl.LoginLongitude;
                cmd.Parameters.Add(j);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DStafflogin successful....");

            }
            catch (Exception ex)
            {
                //traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "DStafflogin...." + ex.Message.ToString());
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
        [Route("api/DeliveryStaffLogin/DStaffTracking")]

        public DataTable DStaffTracking(DeliverystaffTrack l)
        {
            // int Status = 1;
            //LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            DataTable currTripList = new DataTable();
            StringBuilder str = new StringBuilder();
            try
            {
                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DStaffTracking....");

                str.Append("Mobilenumber:" + l.Mobilenumber + ",");
                str.Append("Latitude:" + l.latitude + ",");
                str.Append("Longitude:" + l.longitude + ",");


                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Input sent...." + str.ToString());
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DStaffTracking";

                cmd.Connection = conn;


                SqlParameter MobileNumber = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 50);
                MobileNumber.Value = l.Mobilenumber;
                cmd.Parameters.Add(MobileNumber);

                SqlParameter Lat = new SqlParameter("@Latitude", SqlDbType.Float);
                Lat.Value = l.latitude;
                cmd.Parameters.Add(Lat);

                SqlParameter Lng = new SqlParameter("@Longitude", SqlDbType.Float);
                Lng.Value = l.longitude;
                cmd.Parameters.Add(Lng);

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(currTripList);
                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "TrackVehicle successful....");


                //if (currTripList.Rows.Count > 0)
                //    //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "TrackVehicle Output...." + currTripList.Rows[0]["BNo"].ToString());
                //else
                    //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "TrackVehicle Output....No bookings found");

            }
            catch (Exception ex)
            {
                //traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "TrackVehicle...." + ex.Message.ToString());
                //throw ex;
                //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
                currTripList.Columns.Add("Code");
                currTripList.Columns.Add("description");
                DataRow dr = currTripList.NewRow();
                dr[0] = "ERR001";
                dr[1] = ex.Message;
                currTripList.Rows.Add(dr);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                SqlConnection.ClearPool(conn);
            }

            return currTripList;
        }


        [HttpPost]
        [Route("api/DeliveryStaffLogin/DStaffRating")]
        public DataTable DStaffRating(DeliverystaffRating vb)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            StringBuilder str = new StringBuilder();
            try
            {

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DriverRatingToRide....");
                str.Append("Mobilenumber:" + vb.Mobilenumber + ",");
                str.Append("orderid:" + vb.orderid + ",");

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Input sent...." + str.ToString());

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeliveryStaffRating";


                cmd.Parameters.Add("@Mobilenumber", SqlDbType.VarChar, 20).Value = vb.Mobilenumber;
                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = vb.orderid;
                cmd.Parameters.Add("@DStaffRating", SqlDbType.Decimal).Value = vb.DStaffRating;                
                cmd.Parameters.Add("@DStaffComments", SqlDbType.VarChar, 500).Value = vb.DStaffComments;

                cmd.Connection = conn;

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                dt = ds.Tables[0];

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DriverRatingToRide successful....");

            }
            catch (Exception ex)
            {
                //traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "DriverRatingToRide...." + ex.Message.ToString());
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


        [HttpPost]
        [Route("api/DeliveryStaffLogin/ValidateCredentials")]
        public DataTable ValidateCredentials(dstafflogin b)
        {
            //LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "ValidateCredentials....");


                StringBuilder str = new StringBuilder();
                str.Append("@mobileNo" + b.Mobileno + ",");
                str.Append("@Password" + b.Password + ",");

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "ValidateCredentials Input sent...." + str.ToString());

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DStaffCredentials";
                cmd.Connection = conn;

                SqlParameter ss = new SqlParameter();
                ss.ParameterName = "@Mobileno";
                ss.SqlDbType = SqlDbType.VarChar;
                ss.Value = b.Mobileno;
                cmd.Parameters.Add(ss);
                SqlParameter dd = new SqlParameter();
                dd.ParameterName = "@Password";
                dd.SqlDbType = SqlDbType.VarChar;
                dd.Value = b.Password;
                cmd.Parameters.Add(dd);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "ValidateCredentials successful....");
            }
            catch (Exception ex)
            {
               // traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "ValidateCredentials...." + ex.Message.ToString());
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
