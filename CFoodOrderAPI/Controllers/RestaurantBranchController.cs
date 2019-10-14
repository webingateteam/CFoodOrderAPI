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
    public class RestaurantBranchController : ApiController
    {
        [HttpPost]
        [Route("api/RestaurantBranch/InsUpdRestaurantBranchDetails")]
        public DataTable InsUpdRestaurantBranchDetails(dummy rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdRestaurantBranchDetails";
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
        [Route("api/RestaurantBranch/AddRestaurantBranch")]
        public DataTable AddRestaurantBranch(RestaurantBranches rc)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "InsUpdRestaurantBranches";
            cmd.CommandType = CommandType.StoredProcedure;

            //            @id int,
            //@resid int,
            //@name varchar(50),
            //@shortdesc varchar(250) = null,
            //@latitude decimal(18, 0) = null,
            //@longitude decimal(18, 0) = null,
            //@address varchar(max),
            //@Nearestlandmark varchar(50) = null,
            //@image image = null,
            //@shortimg image = null,
            //@rating decimal = null,
            //@mindelivery time(7) = null,
            //@city varchar(50) = null,
            //@state varchar(50) = null,
            //@country varchar(50) = null,
            //@zipcode varchar(50) = null,
            //@website varchar(50) = null,
            //@email varchar(50) = null,
            //@primaryno varchar(50) = null,
            //@registeredby varchar(50) = null,
            //@altno varchar(50) = null,
            //@flag varchar(10)

            SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
            id.Value = rc.Id;
            cmd.Parameters.Add(id);

            SqlParameter  resid= new SqlParameter("@resid", SqlDbType.Int);
            resid.Value = rc.RestaurantId;
            cmd.Parameters.Add(resid);

            SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar,50);
            name.Value = rc.Name;
            cmd.Parameters.Add(name);

            SqlParameter shortdesc = new SqlParameter("@shortdesc", SqlDbType.VarChar,250);
            shortdesc.Value = rc.ShortDesc;
            cmd.Parameters.Add(shortdesc);

            SqlParameter longitude = new SqlParameter("@longitude", SqlDbType.Decimal);
            longitude.Value = rc.longitude;
            cmd.Parameters.Add(longitude);

            SqlParameter latitude = new SqlParameter("@latitude", SqlDbType.Decimal);
            latitude.Value = rc.latitude;
            cmd.Parameters.Add(latitude);

            SqlParameter address = new SqlParameter("@address", SqlDbType.VarChar,-1);
            address.Value = rc.address;
            cmd.Parameters.Add(address);

            SqlParameter Nearestlandmark = new SqlParameter("@Nearestlandmark", SqlDbType.VarChar, 250);
            Nearestlandmark.Value = rc.NearestLandmark;
            cmd.Parameters.Add(Nearestlandmark);

            SqlParameter image = new SqlParameter("@image", SqlDbType.Image);
            image.Value = rc.Image;
            cmd.Parameters.Add(image);

            SqlParameter shortimg = new SqlParameter("@shortimg", SqlDbType.Image);
            shortimg.Value = rc.ShortImage;
            cmd.Parameters.Add(shortimg);

            SqlParameter rating = new SqlParameter("@rating", SqlDbType.Decimal );
            rating.Value = rc.rating;
            cmd.Parameters.Add(rating);

            SqlParameter mindelivery = new SqlParameter("@mindelivery", SqlDbType.DateTime, 7);
            mindelivery.Value = rc.minimumdeliverytime;
            cmd.Parameters.Add(mindelivery);

            SqlParameter city = new SqlParameter("@city", SqlDbType.VarChar);
            city.Value = rc.City;
            cmd.Parameters.Add(city);

            SqlParameter state = new SqlParameter("@state", SqlDbType.VarChar);
            state.Value = rc.State;
            cmd.Parameters.Add(state);

            SqlParameter country = new SqlParameter("@country", SqlDbType.VarChar, 50);
            country.Value = rc.Country;
            cmd.Parameters.Add(country);

            SqlParameter zipcode = new SqlParameter("@zipcode", SqlDbType.VarChar, 250);
            zipcode.Value = rc.Zipcode;
            cmd.Parameters.Add(zipcode);

            SqlParameter website = new SqlParameter("@website", SqlDbType.VarChar);
            website.Value = rc.website;
            cmd.Parameters.Add(website);

            SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
            email.Value = rc.emailid;
            cmd.Parameters.Add(email);

            SqlParameter primaryno = new SqlParameter("@primaryno", SqlDbType.VarChar, 250);
            primaryno.Value = rc.primaryphonenumber;
            cmd.Parameters.Add(primaryno);

            SqlParameter registeredby = new SqlParameter("@registeredby", SqlDbType.VarChar);
            registeredby.Value = rc.RegisteredBy;
            cmd.Parameters.Add(registeredby);

            SqlParameter altno = new SqlParameter("@altno", SqlDbType.VarChar);
            altno.Value = rc.altphonenumber;
            cmd.Parameters.Add(altno);


            SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
            flag.Value = rc.flag;
            cmd.Parameters.Add(flag);
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
