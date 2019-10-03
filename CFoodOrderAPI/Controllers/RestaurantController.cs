using CFoodOrder.Models;
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
          

            SqlParameter n = new SqlParameter("@name", SqlDbType.VarChar, 250);
            n.Value = rm.Name;
            cmd.Parameters.Add(n);

            SqlParameter e = new SqlParameter("@email", SqlDbType.VarChar,250);
            e.Value = rm.Emailid;
            cmd.Parameters.Add(e);

            SqlParameter sd = new SqlParameter("@shortdesc", SqlDbType.VarChar,250);
            sd.Value = rm.ShortDesc;
            cmd.Parameters.Add(sd);

            SqlParameter ii = new SqlParameter("@image", SqlDbType.VarChar,-1);
            ii.Value = rm.Image;
            cmd.Parameters.Add(ii);

            SqlParameter si = new SqlParameter("@shortimg", SqlDbType.VarChar, -1);
            si.Value = rm.ShortImage;
            cmd.Parameters.Add(si);

            SqlParameter w = new SqlParameter("@website", SqlDbType.VarChar, 50);
            w.Value = rm.website;
            cmd.Parameters.Add(w);

            SqlParameter pn = new SqlParameter("@primaryno", SqlDbType.VarChar, 50);
            pn.Value = rm.PrimaryContactNo;
            cmd.Parameters.Add(pn);

            SqlParameter pe = new SqlParameter("@primaryemail", SqlDbType.VarChar, 50);
            pe.Value = rm.PrimaryContactEmail;
            cmd.Parameters.Add(pe);

            SqlParameter c = new SqlParameter("@cityid", SqlDbType.Int);
            c.Value = rm.CityId;
            cmd.Parameters.Add(c);

            SqlParameter z = new SqlParameter("@zipcode", SqlDbType.Int);
            z.Value = rm.ZipCode;
            cmd.Parameters.Add(z);

            SqlParameter s = new SqlParameter("@stateid", SqlDbType.Int);
            s.Value = rm.StateId;
            cmd.Parameters.Add(s);

            SqlParameter ct = new SqlParameter("@ctryid", SqlDbType.Int);
            ct.Value = rm.CountryId;
            cmd.Parameters.Add(ct);

            SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar, 250);
            ff.Value = rm.flag;
            cmd.Parameters.Add(ff);

            SqlParameter Id1 = new SqlParameter("@Id", SqlDbType.Int);
            Id1.Value = rm.Id;
            cmd.Parameters.Add(Id1);

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
    }
}
