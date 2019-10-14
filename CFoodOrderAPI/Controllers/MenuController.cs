using CFoodOrder.Models;
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
    public class MenuController : ApiController
    {
        [HttpPost]
        [Route("api/Menu/InsUpdRestaurantMenu")]
        public DataTable InsUpdRestaurantMenu(MenuItems rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "InsUpdDelRestMenuItemConfig";
                cmd.CommandType = CommandType.StoredProcedure;


                //cmd.Parameters.Add(new SqlParameter("@RestaurantId", SqlDbType.Int).SqlValue = rc.RestaurantId);
                //cmd.Parameters.Add(new SqlParameter("@RestaurantBranchId", SqlDbType.Int).SqlValue = rc.RestaurantBranchId);

                SqlParameter par1 = new SqlParameter("@MenuItemName", SqlDbType.VarChar, 250);
                par1.Value = rc.MenuItemName;
                cmd.Parameters.Add(par1);

                SqlParameter par2 = new SqlParameter("@description", SqlDbType.VarChar, 250);
                par2.Value = rc.description;
                cmd.Parameters.Add(par2);

                SqlParameter par3 = new SqlParameter("@price", SqlDbType.Decimal);
                par3.Value = rc.price;
                cmd.Parameters.Add(par3);

                SqlParameter par4 = new SqlParameter("@rating", SqlDbType.Decimal);
                par4.Value = rc.rating;
                cmd.Parameters.Add(par4);

                SqlParameter par5 = new SqlParameter("@recipe", SqlDbType.VarChar, 250);
                par5.Value = rc.recipe;
                cmd.Parameters.Add(par5);

                SqlParameter par6 = new SqlParameter("@Photo", SqlDbType.VarChar, -1);
                par6.Value = rc.Photo;
                cmd.Parameters.Add(par6);

                SqlParameter par7 = new SqlParameter("@MenuCategoryId", SqlDbType.Int);
                par7.Value = rc.MenuCategoryId;
                cmd.Parameters.Add(par7);

                SqlParameter par8 = new SqlParameter("@Id", SqlDbType.Int);
                par8.Value = rc.Id;
                cmd.Parameters.Add(par8);

                SqlParameter par9 = new SqlParameter("@flag", SqlDbType.VarChar, 10);
                par9.Value = rc.flag;
                cmd.Parameters.Add(par9);

                SqlParameter par10 = new SqlParameter("@RestaurantId", SqlDbType.Int);
                par10.Value = rc.RestaurantId;
                cmd.Parameters.Add(par10);

                SqlParameter par11 = new SqlParameter("@RestaurantBranchId", SqlDbType.Int);
                par11.Value = rc.RestaurantBranchId;
                cmd.Parameters.Add(par11);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) {
                throw ex;
            }

            return dt;
        }
        [HttpPost]
        [Route("api/Menu/InsUpdRestaurantMenuItem")]
        public DataTable InsUpdRestaurantMenuItem(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdRestaurantMenuItem";
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
        [Route("api/Menu/GetRestaurantMenu")]
        public DataTable GetRestaurantMenu(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetRestaurantMenu";
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
        [Route("api/Menu/GetRestaurantMenuItems")]
        public DataTable GetRestaurantMenuItems(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetRestaurantMenuItems";
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
        [Route("api/Menu/GetItemDetails")]
        public DataTable GetItemDetails(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetItemDetails";
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
        [Route("api/Menu/InsUpdItemDetails")]
        public DataTable InsUpdItemDetails(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdItemDetails";
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
        [Route("api/Menu/InsUpdDelMenuItems")]
        public DataTable InsUpdMenu(MenuItems rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "InsUpdDelMenuItems";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par1 = new SqlParameter("@MenuItemName", SqlDbType.VarChar, 250);
                par1.Value = rc.MenuItemName;
                cmd.Parameters.Add(par1);

                SqlParameter par2 = new SqlParameter("@description", SqlDbType.VarChar, 250);
                par2.Value = rc.description;
                cmd.Parameters.Add(par2);

                SqlParameter par3 = new SqlParameter("@price", SqlDbType.Decimal);
                par3.Value = rc.price;
                cmd.Parameters.Add(par3);

                SqlParameter par4 = new SqlParameter("@rating", SqlDbType.Decimal);
                par4.Value = rc.rating;
                cmd.Parameters.Add(par4);

                SqlParameter par5 = new SqlParameter("@recipe", SqlDbType.VarChar, 250);
                par5.Value = rc.recipe;
                cmd.Parameters.Add(par5);

                SqlParameter par6 = new SqlParameter("@Photo", SqlDbType.VarChar, -1);
                par6.Value = rc.Photo;
                cmd.Parameters.Add(par6);

                SqlParameter par7 = new SqlParameter("@MenuCategoryId", SqlDbType.Int);
                par7.Value = rc.MenuCategoryId;
                cmd.Parameters.Add(par7);

                SqlParameter par8 = new SqlParameter("@Id", SqlDbType.Int);
                par8.Value = rc.Id;
                cmd.Parameters.Add(par8);

                SqlParameter par9 = new SqlParameter("@flag", SqlDbType.VarChar,10);
                par9.Value = rc.flag;
                cmd.Parameters.Add(par9);

                

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) {
                throw ex;
          }
        
            return dt;
        }

        [HttpPost]
        [Route("api/Menu/InsUpdMenuCategories")]
        public DataTable InsUpdMenuCategories(menuCategories rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdDelMenuCategories";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = new SqlParameter("@Categoryname", SqlDbType.VarChar, 250);
            par1.Value = rc.MenuCategoryName;
            cmd.Parameters.Add(par1);

            SqlParameter par2 = new SqlParameter("@desc", SqlDbType.VarChar, 250);
            par2.Value = rc.Description;
            cmd.Parameters.Add(par2);

            SqlParameter par3 = new SqlParameter("@cuisineTypeId", SqlDbType.Int);
            par3.Value = rc.CusinieTypeId;
            cmd.Parameters.Add(par3);

            SqlParameter par4 = new SqlParameter("@active", SqlDbType.Int);
            par4.Value = rc.Active;
            cmd.Parameters.Add(par4);

            SqlParameter par5 = new SqlParameter("@flag", SqlDbType.VarChar);
            par5.Value = rc.flag;
            cmd.Parameters.Add(par5);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

       


    }
}
