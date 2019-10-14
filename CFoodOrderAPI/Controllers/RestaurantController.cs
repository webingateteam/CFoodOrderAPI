using CFoodOrder.Models;
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
    public class RestaurantController : ApiController
    {
        [HttpPost]
        [Route("api/Restaurant/InsUpdDelRestaurantDetails")]
        public DataTable InsUpdDelRestaurantDetails(RestaurantDetails rd)
        {
            DataTable dt = new DataTable();


            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdDelRestaurantDetails";
            cmd.CommandType = CommandType.StoredProcedure;

            //       (@resid int
            //      , @resbranchid int
            //       , @featurecatid int
            //        , @featureid int
            //         , @desc varchar(max)
            //,@flag varchar
            //      , @Id
            SqlParameter description = new SqlParameter("@desc", SqlDbType.VarChar, -1);
            description.Value = rd.Descripiton;
            cmd.Parameters.Add(description);

            SqlParameter restaurantid = new SqlParameter("@resid", SqlDbType.Int);
            restaurantid.Value = rd.RestaurantId;
            cmd.Parameters.Add(restaurantid);

            SqlParameter resbranchid = new SqlParameter("@resbranchid", SqlDbType.Int);
            resbranchid.Value = rd.RestaurantBranchId;
            cmd.Parameters.Add(resbranchid);

            SqlParameter featurecatid = new SqlParameter("@featurecatid", SqlDbType.Int);
            featurecatid.Value = rd.FeatureCategoryId;
            cmd.Parameters.Add(featurecatid);

            SqlParameter featureid = new SqlParameter("@featureid", SqlDbType.Int);
            featureid.Value = rd.FeatureId;
            cmd.Parameters.Add(featureid);

           

            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Value = rd.Id;
            cmd.Parameters.Add(Id);

            SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
            flag.Value = rd.flag;
            cmd.Parameters.Add(flag);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


        [HttpPost]
        [Route("api/Restaurant/RegisterRestaurant")]
        public DataTable RegisterRestaurant(RestaurantMaster rm)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdDelRestaurantMaster";
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar, 50);
            name.Value = rm.Name;
            cmd.Parameters.Add(name);

            SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar, 50);
            email.Value = rm.Emailid;
            cmd.Parameters.Add(email);

            SqlParameter shortdesc = new SqlParameter("@shortdesc", SqlDbType.VarChar, 250);
            shortdesc.Value = rm.ShortDesc;
            cmd.Parameters.Add(shortdesc);

            SqlParameter image = new SqlParameter("@image", SqlDbType.VarChar, -1);
            image.Value = rm.Image;
            cmd.Parameters.Add(image);

            SqlParameter shortimg = new SqlParameter("@shortimg", SqlDbType.VarChar, -1);
            shortimg.Value = rm.ShortImage;
            cmd.Parameters.Add(shortimg);

            SqlParameter website = new SqlParameter("@website", SqlDbType.VarChar, 50);
            website.Value = rm.website;
            cmd.Parameters.Add(website);

            SqlParameter primaryno = new SqlParameter("@primaryno", SqlDbType.VarChar, 50);
            primaryno.Value = rm.PrimaryContactNo;
            cmd.Parameters.Add(primaryno);

            SqlParameter primaryemail = new SqlParameter("@primaryemail", SqlDbType.VarChar, 50);
            primaryemail.Value = rm.PrimaryContactEmail;
            cmd.Parameters.Add(primaryemail);

            SqlParameter cityid = new SqlParameter("@cityid", SqlDbType.Int);
            cityid.Value = rm.CityId;
            cmd.Parameters.Add(cityid);

            SqlParameter zipcode = new SqlParameter("@zipcode", SqlDbType.Int);
            zipcode.Value = rm.ZipCode;
            cmd.Parameters.Add(zipcode);

            SqlParameter stateid = new SqlParameter("@stateid", SqlDbType.Int);
            stateid.Value = rm.StateId;
            cmd.Parameters.Add(stateid);

            SqlParameter ctryid = new SqlParameter("@ctryid", SqlDbType.Int);
            ctryid.Value = rm.CountryId;
            cmd.Parameters.Add(ctryid);

            SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar, 250);
            flag.Value = rm.flag;
            cmd.Parameters.Add(flag);

            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Value = rm.Id;
            cmd.Parameters.Add(Id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/Restaurant/InsUpdRestaurantCusines")]
            public DataTable InsUpdRestaurantCusines(RestaurantCusines rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdRestaurantCusines";
            cmd.CommandType = CommandType.StoredProcedure;

            //@id int,
            //@resid int,
            //@branchid int,
            //@CusinieId int,
            //@flag int

            SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
            id.Value = rc.Id;
            cmd.Parameters.Add(id);

            SqlParameter resid = new SqlParameter("@resid", SqlDbType.Int);
            resid.Value = rc.RestaurantId;
            cmd.Parameters.Add(resid);

            SqlParameter branchid = new SqlParameter("@branchid", SqlDbType.Int);
            branchid.Value = rc.RestaurantBranchId;
            cmd.Parameters.Add(branchid);

            SqlParameter CusinieId = new SqlParameter("@CusinieId", SqlDbType.Int);
            CusinieId.Value = rc.CusinieId;
            cmd.Parameters.Add(CusinieId);

            SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar,10);
            flag.Value = rc.flag;
            cmd.Parameters.Add(flag);


             SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }


        [HttpGet]
        [Route("api/Restaurant/GetRestaurantList")]
        public DataTable GetRestaurantList()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetRestaurantMaster";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }


        [HttpGet]
        [Route("api/Restaurant/GetRestaurantListById")]
        public DataTable GetRestaurantListById(int Id)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetRestaurantListById";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).SqlValue = Id;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }


        [HttpPost]
        [Route("api/Restaurant/InsUpdRestaurantDocs")]
        public DataTable InsUpdRestaurantDocs(dummy rc)
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

       
        [HttpGet]
        [Route("api/Restaurant/GetRestaurantDashboard")]
        public DataTable GetRestaurantDashboard(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetRestaurantDashboard";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = new SqlParameter("@par1", SqlDbType.Int);
            par1.Value = rc.par1;
            cmd.Parameters.Add(par1);

            SqlParameter par2 = new SqlParameter("@par2", SqlDbType.VarChar);
            par2.Value = rc.par2;
            cmd.Parameters.Add(par2);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }


        [HttpGet]
        [Route("api/Restaurant/GetResOrdersHistory")]
        public DataTable GetResOrdersHistory(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetResOrdersHistory";
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
        [Route("api/Restaurant/GetResPendingOrder")]
        public DataTable GetResPendingOrder(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetResPendingOrder";
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
        [Route("api/Restaurant/GetRestaurantOrders")]
        public DataTable GetRestaurantOrders(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "GetRestaurantOrders";
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
        [Route("api/Restaurant/ResOnlineOffine")]
        public DataTable ResOnlineOffine(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "ResOnlineOffine";
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
        [Route("api/Restaurant/InsUpdResMenuCategories")]
        public DataTable InsUpdResMenuCategories(menuCategories rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdDelResMenuCategories";
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter Id = new SqlParameter("@id", SqlDbType.Int);
            Id.Value = rc.Id;
            cmd.Parameters.Add(Id);

            SqlParameter resid = new SqlParameter("@ResId", SqlDbType.Int);
            resid.Value = rc.ResId;
            cmd.Parameters.Add(resid);

            SqlParameter Resbid = new SqlParameter("@ResBranchId", SqlDbType.Int);
            Resbid.Value = rc.ResBId;
            cmd.Parameters.Add(Resbid);

            SqlParameter MenuCategoryId = new SqlParameter("@MenuCategoryId", SqlDbType.Int);
            MenuCategoryId.Value = rc.MenuCategoryId;
            cmd.Parameters.Add(MenuCategoryId);

            SqlParameter par1 = new SqlParameter("@MenuCategoryName", SqlDbType.VarChar, 250);
            par1.Value = rc.MenuCategoryName;
            cmd.Parameters.Add(par1);

            SqlParameter par2 = new SqlParameter("@description", SqlDbType.VarChar, 250);
            par2.Value = rc.Description;
            cmd.Parameters.Add(par2);

            SqlParameter par3 = new SqlParameter("@cuisinetype", SqlDbType.Int);
            par3.Value = rc.CusinieTypeId;
            cmd.Parameters.Add(par3);

            SqlParameter par4 = new SqlParameter("@Active", SqlDbType.Int);
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
