using CFoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CFoodOrder.Controllers
{
    public class orderpaymentController : ApiController
    {

        [HttpPost]
        [Route("api/orderpayment/OrderItemslist")]
        public DataTable OrderItemslist(List<MenuItems> A)
        {
            //int orderid = 0;
            //int count = 0;
            //SqlTransaction Trans = null;
            //DataTable dt = new DataTable();
            //SqlConnection con = new SqlConnection();
            //try
            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "InsUpdDelOrder";
            //    con.Open();

            //    Trans = con.BeginTransaction();
            //    cmd.Transaction = Trans;

            //    foreach (MenuItems m in list)
            //    {

            //        if (count == 0)
            //        {

            //            cmd.Parameters.Add(new SqlParameter("@RestId", SqlDbType.Int)).SqlValue = m.RestaurantId;
            //            cmd.Parameters.Add(new SqlParameter("@customerid", SqlDbType.Int)).SqlValue = m.customerid;
            //            cmd.Parameters.Add(new SqlParameter("@RestBranchId", SqlDbType.Int)).SqlValue = m.RestBranchId;
            //            cmd.Parameters.Add(new SqlParameter("@totalQuantity", SqlDbType.Int)).SqlValue = m.totalQuantity;
            //            cmd.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal)).SqlValue = m.totalamount;
            //            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.VarChar)).SqlValue = m.flag;

            //            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //            da.Fill(dt);
            //            orderid = (int)dt.Rows[0]["Id"];
            //        }
            //        else if (count > 0)
            //        {

            //            try
            //            {
            //                cmd.Parameters.Clear();
            //                cmd.CommandType = CommandType.StoredProcedure;
            //                cmd.CommandText = "InsUpdDelOrderDetails";
            //                cmd.Parameters.Add(new SqlParameter("@orderid", SqlDbType.Int)).SqlValue = orderid;
            //                cmd.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.Int)).SqlValue = m.ItemId;
            //                cmd.Parameters.Add(new SqlParameter("@ItemPrice", SqlDbType.Decimal)).SqlValue = m.ItemPrice;
            //                cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)).SqlValue = m.Quantity;
            //                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.VarChar)).SqlValue = m.flag;
            //                cmd.ExecuteScalar();

            //            }
            //            catch (Exception ex)
            //            {
            //                throw ex;
            //            }

            //        }
            //        count = count + 1;
            //    }
            //    Trans.Commit();
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    dt.Columns.Add("Code");
            //    dt.Columns.Add("description");
            //    DataRow dr = dt.NewRow();
            //    dr[0] = "ERR001";
            //    dr[1] = ex.Message;
            //    dt.Rows.Add(dr);
            //    try
            //    {
            //        if (Trans != null)
            //            Trans.Rollback();
            //    }
            //    catch { }

            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }

            //}
            //finally
            //{
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}
            //return dt;


            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelOrder";
                con.Open();


                if (A.Count != 0)
                {

                    cmd.Parameters.Add(new SqlParameter("@RestId", SqlDbType.Int)).SqlValue = A[0].RestaurantId;
                    cmd.Parameters.Add(new SqlParameter("@customerid", SqlDbType.Int)).SqlValue = A[0].customerid;
                    cmd.Parameters.Add(new SqlParameter("@RestBranchId", SqlDbType.Int)).SqlValue = A[0].RestBranchId;
                    cmd.Parameters.Add(new SqlParameter("@totalQuantity", SqlDbType.Int)).SqlValue = A[0].totalQuantity;
                    cmd.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal)).SqlValue = A[0].totalamount;
                    cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.VarChar)).SqlValue = A[0].flag;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    cmd.Parameters.Clear();

                    int orderid = (int)dt.Rows[0]["Id"];

                    foreach (MenuItems m in A)
                    {
                        try
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "InsUpdDelOrderDetails";
                            cmd.Parameters.Add(new SqlParameter("@orderid", SqlDbType.Int)).SqlValue = orderid;
                            cmd.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.Int)).SqlValue = m.ItemId;
                            cmd.Parameters.Add(new SqlParameter("@ItemPrice", SqlDbType.Decimal)).SqlValue = m.ItemPrice;
                            cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)).SqlValue = m.Quantity;
                            cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.VarChar)).SqlValue = m.flag;
                            cmd.ExecuteScalar();
                            cmd.Parameters.Clear();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
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
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;

        }



        [HttpGet]
        [Route("api/orderpayment/GetOrderPaymentDetails")]

        public DataTable GetOrderPaymentDetails(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetOrderPaymentDetails";
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

           

            SqlParameter par5 = new SqlParameter("@par5", SqlDbType.VarChar);
            par5.Value = rc.par5;
            cmd.Parameters.Add(par5);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/orderpayment/InsUpdOrderPaymentDetails")]

        public DataTable InsUpdOrderPaymentDetails(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdOrderPaymentDetails";
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
