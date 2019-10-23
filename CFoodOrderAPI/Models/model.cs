using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFoodOrder.Models
{
   
        
        public class MenuItems
        {
    
            public int Id { get; set; }
            public string MenuItemName { get; set; }
            public string description { get; set; }
            public Decimal price { get; set; }
            public Decimal rating { get; set; }
            public string recipe { get; set; }
            public string Photo { get; set; }
            public int MenuCategoryId { get; set; }
            public int RestaurantId { get; set; }
            public int RestaurantBranchId { get; set; }
            public string flag { get; set; }

            public int customerid { get; set; }
            public int RestBranchId { get; set; }
            public int totalQuantity { get; set; }
            public int ItemId { get; set; }
            public int Quantity { get; set; }
             public int paymentid { get; set; }
            public Decimal totalamount { get; set; }
            public Decimal ItemPrice { get; set; }
            public Decimal customerlat { get; set; }
            public Decimal customerlog { get; set; }
            public string customeraddress { get; set; }
        List<OrderItemslist> orderItemslist { get; set; }

     }

        public class OrderItemslist {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
            public string flag { get; set; }
            public Decimal ItemPrice { get; set; }
            public int orderid { get; set; }
   
        }

        public class AlertConfigurations
        {
            public int Id { get; set; }
            public int RoleId { get; set; }
            public int AlertTypeId { get; set; }
            public string AlertItems { get; set; }
        }
    public class roledetails
    {
        public int Id { get; set; }


        public string ObjectName { get; set; }

        public string Path { get; set; }
    }

            public class AppUserDetails
            {
                public int Id { get; set; }
                public string Username { get; set; }
                public string Email { get; set; }
                public string Mobilenumber { get; set; }
                public string Password { get; set; }
                public string Mobileotp { get; set; }
                public string Emailotp { get; set; }
                public string Passwordotp { get; set; }
                public int StatusId { get; set; }
                public DateTime? CreatedOn { get; set; }
                public DateTime? Mobileotpsenton { get; set; }
                public DateTime? emailotpsenton { get; set; }
                public int noofattempts { get; set; }
                public string Firstname { get; set; }
                public string lastname { get; set; }
                public int AuthTypeId { get; set; }
                public string AltPhonenumber { get; set; }
                public string Altemail { get; set; }
                public string AccountNo { get; set; }
                public decimal Amount { get; set; }
                public string UserPhoto { get; set; }
                public int Gender { get; set; }
                public int CurrentStateId { get; set; }
                public int CountryId { get; set; }
                public int PaymentModeId { get; set; }
                public int Active { get; set; }
                public string CCode { get; set; }
                public string UserAccountNo { get; set; }
                public DateTime? DOB { get; set; }
                public string PromoCode { get; set; }
                public string UserSocialId { get; set; }
                public string Loginby { get; set; }
            }
            public class Appusers
            {
                public int Id { get; set; }
                public string Username { get; set; }
                public string Email { get; set; }
                public string Mobilenumber { get; set; }
                public string Password { get; set; }
                public string Mobileotp { get; set; }
                public string Emailotp { get; set; }
                public string Passwordotp { get; set; }
                public int StatusId { get; set; }
                public DateTime? CreatedOn { get; set; }
                public DateTime? Mobileotpsenton { get; set; }
                public DateTime? emailotpsenton { get; set; }
                public int noofattempts { get; set; }
                public string Firstname { get; set; }
                public string lastname { get; set; }
                public int AuthTypeId { get; set; }
                public string AltPhonenumber { get; set; }
                public string Altemail { get; set; }
                public string AccountNo { get; set; }
                public decimal Amount { get; set; }
                public string UserPhoto { get; set; }
                public int Gender { get; set; }
                public int CurrentStateId { get; set; }
                public int CountryId { get; set; }
                public int PaymentModeId { get; set; }
                public int Active { get; set; }
                public string CCode { get; set; }
                public string UserAccountNo { get; set; }
                public DateTime? DOB { get; set; }
                public string PromoCode { get; set; }
            }
            public class BussinessAppuser
            {
                public int Id { get; set; }
                public string Username { get; set; }
                public string Email { get; set; }
                public string Mobilenumber { get; set; }
                public string Password { get; set; }
                public string Mobileotp { get; set; }
                public string Emailotp { get; set; }
                public string Passwordotp { get; set; }
                public int StatusId { get; set; }
                public DateTime? CreatedOn { get; set; }
                public DateTime? Mobileotpsenton { get; set; }
                public DateTime? emailotpsenton { get; set; }
                public int noofattempts { get; set; }
                public string Firstname { get; set; }
                public string lastname { get; set; }
                public int AuthTypeId { get; set; }
                public string AltPhonenumber { get; set; }
                public string Altemail { get; set; }
                public string AccountNo { get; set; }
                public decimal Amount { get; set; }
                public string UserPhoto { get; set; }
                public int Gender { get; set; }
                public int CurrentStateId { get; set; }
                public int CountryId { get; set; }
                public int PaymentModeId { get; set; }
                public int Active { get; set; }
                public string CCode { get; set; }
                public string UserAccountNo { get; set; }
                public int usertypeid { get; set; }
                public string Loginby { get; set; }
                public DateTime? DateofBirth { get; set; }
                public string UserSocialId { get; set; }
            }

            public class BusinessAppUser
            {
                //public int Id { get; set; }
                public string flag { get; set; }
                //public int id { get; set; }
                public int userId { get; set; }
                public string Username { get; set; }

                public string Email { get; set; }
                public string Mobilenumber { get; set; }
                public string Password { get; set; }
                public String EVerificationCode { get; set; }
                public DateTime EVerifiedOn { get; set; }
                public int IsEmailVerified { get; set; }
                public String MVerificationCode { get; set; }
                public string Passwordotp { get; set; }
                public DateTime MVerifiedOn { get; set; }
                public int IsMobileVerified { get; set; }

                public DateTime CreatedOn { get; set; }
                public int ENoOfAttempts { get; set; }
                public int MNoOfAttempts { get; set; }
                public string Firstname { get; set; }
                public string lastname { get; set; }
                public int AuthTypeId { get; set; }
                public string AltPhonenumber { get; set; }
                public string Altemail { get; set; }
                public string AccountNo { get; set; }
                public string NewPassword { get; set; }
                public object Mobileotp { get; set; }

                public object Emailotp { get; set; }

                public int Gender { get; set; }
                public string UserPhoto { get; set; }

                public decimal Amount { get; set; }
                public int CountryId { get; set; }
                public int PaymentModeId { get; set; }
                public int CurrentStateId { get; set; }
                public int Active { get; set; }
                public string CCode { get; set; }
                public string UserAccountNo { get; set; }
                public int usertypeid { get; set; }

                public string Address { get; set; }
                public int change { get; set; }
                public int type { get; set; }
                public int ownerId { get; set; }

                public string RegistrationNo { get; set; }
                public string VPhoto { get; set; }
                public string VehicleType { get; set; }
                public int isDriverOwned { get; set; }

                public int VehicleTypeId { get; set; }

                public int VehicleGroupId { get; set; }

            }
            public class country
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Latitude { get; set; }
                public string Longitude { get; set; }
                public string ISOCode { get; set; }
                public int HasOperations { get; set; }
                public string flag { get; set; }
                public string Code { get; set; }
                public string FlagLocation { get; set; }
            }
            public class DemoRequest
            {
                public int Id { get; set; }
                public DateTime? Datetime { get; set; }
                public string BusinessName { get; set; }
                public string Email { get; set; }
                public string MobileNumber { get; set; }
                public int CountryId { get; set; }
                public string LoginNo { get; set; }
                public DateTime? Emailsenton { get; set; }
                public DateTime? Otpsent { get; set; }
                public string Reviewed { get; set; }
                public string Notification { get; set; }
                public string DashboardUsername { get; set; }
                public string DashboardPwd { get; set; }
                public string CustomerAppUsername { get; set; }
                public string BusinessAppUsername { get; set; }
                public string CustomerAppPwd { get; set; }
                public string BusinessAppPwd { get; set; }
                public string OtpBusinessApp { get; set; }
                public string OtpCustomerApp { get; set; }
                public DateTime? Emailsent { get; set; }
                public DateTime Otpsenton { get; set; }
                public DateTime ReviewedOn { get; set; }
                public DateTime NotifiedOn { get; set; }
                public int ReviewedBy { get; set; }
                public int EmailSentBy { get; set; }
                public int StatusId { get; set; }
            }
            public class EditHistory
            {
                public int Id { get; set; }
                public string Field { get; set; }
                public string SubItem { get; set; }
                public string Comment { get; set; }
                public DateTime Date { get; set; }
                public string ChangedBy { get; set; }
                public string ChangedType { get; set; }
                public string Task { get; set; }
            }
            public class EditHistoryDetails
            {
                public int Id { get; set; }
                public int EditHistoryId { get; set; }
                public string FromValue { get; set; }
                public string ToValue { get; set; }
                public string ChangeType { get; set; }
                public string Field1 { get; set; }
                public string Field2 { get; set; }
            }
            public class EWallet
            {
                public int Id { get; set; }
                public string UserAccountNo { get; set; }
                public string Mobilenumber { get; set; }
                public int Status { get; set; }
                public string Mobileotp { get; set; }
                public string Createdon { get; set; }
                public DateTime MOTPSentOn { get; set; }
            }
            public class EWalletTransactions
            {
                public int Id { get; set; }
                public DateTime Date { get; set; }
                public DateTime Time { get; set; }
                public string Mobilenumber { get; set; }
                public string GatewayId { get; set; }
                public decimal Amount { get; set; }
                public string Comments { get; set; }
                public string TransactionId { get; set; }
                public int TransactionMode { get; set; }
                public int StatusId { get; set; }
                public string appuser { get; set; }
                public int SourceApp { get; set; }
            }
            public class FAQs
            {
                public int Id { get; set; }
                public string Question { get; set; }
                public string Answer { get; set; }
                public DateTime CreatedOn { get; set; }
                public string CreatedBy { get; set; }
                public int AppType { get; set; }
                public int Category { get; set; }
                public int SubCategory { get; set; }
                public string flag { get; set; }
            }
            public class MasterDataGroups
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string flag { get; set; }
                public int Active { get; set; }
                public object Description { get; internal set; }
            }
            public class MasterDatatypes
            {

                public string flag { get; set; }
                public int Id { get; set; }
                public string Name { get; set; }
                public string Description { get; set; }
                public int Active { get; set; }
                public int TypeGroupId { get; set; }
                public string listkey { get; set; }
                public string listvalue { get; set; }
            }
            //public class menuCategories
            //{
            //    public int Id { get; set; }
            //    public string MenuCategoryName { get; set; }
            //    public string Description { get; set; }
            //    public string Active { get; set; }
            //    public string CusinieTypeId { get; set; }

            //}
            //public class NotificationConfiguration
            //{
            //    public int Id { get; set; }
            //    public int RoleId { get; set; }
            //    public int NotificationId { get; set; }
            //}
            //public class Notifications
            //{
            //    public int Id { get; set; }
            //    public int RoleId { get; set; }
            //    public int UserId { get; set; }
            //    public string Title { get; set; }
            //    public string Message { get; set; }
            //    public DateTime CreatedOn { get; set; }
            //    public DateTime UpdatedOn { get; set; }
            //    public int UpdatedBy { get; set; }
            //    public int StateId { get; set; }
            //    public int StatusId { get; set; }
            //    public int CategoryId { get; set; }
            //    public int SubCategoryId { get; set; }
            //    public int Active { get; set; }
            //}
            //public class ObjectAccesses
            //{
            //    public int Id { get; set; }
            //    public int ObjectId { get; set; }
            //    public int TypeId { get; set; }
            //    public string Name { get; set; }
            //    public int AccessId { get; set; }
            //}
            //public class Objects
            //{
            //    public int Id { get; set; }
            //    public string Name { get; set; }
            //    public string Description { get; set; }
            //    public string Path { get; set; }
            //    public int Active { get; set; }
            //    public int ParentId { get; set; }
            //    public string RootObjectId { get; set; }
            //}
            //public class OrderDetails
            //{
            //    public int Id { get; set; }
            //    public string orderid { get; set; }
            //    public string customerid { get; set; }
            //    public string productname { get; set; }
            //    public string quantity { get; set; }
            //    public string orderdate { get; set; }

            //}
            ////public class RestaurantBranches
            ////{
            ////    public int Id { get; set; }
            ////    public int RestaurantId { get; set; }
            ////    public string Name { get; set; }
            ////    public string ShortDesc { get; set; }
            ////    public decimal latitude { get; set; }
            ////    public decimal longitude { get; set; }
            ////    public string address { get; set; }
            ////    public string NearestLandmark { get; set; }
            ////    public string Image { get; set; }
            ////    public string ShortImage { get; set; }
            ////    public decimal rating { get; set; }
            ////    public DateTime minimumdeliverytime { get; set; }
            ////    public string City { get; set; }
            ////    public string State { get; set; }
            ////    public string Country { get; set; }
            ////    public string Zipcode { get; set; }
            ////    public string website { get; set; }
            ////    public string emailid { get; set; }
            ////    public string primaryphonenumber { get; set; }
            ////    public string altphonenumber { get; set; }
            ////    public string RegisteredBy { get; set; }
            ////    public string flag { get; set; }
            ////}
            //public class RestaurantCusines
            //{
            //    public int Id { get; set; }
            //    public int RestaurantId { get; set; }
            //    public int RestaurantBranchId { get; set; }
            //    public int CusinieId { get; set; }
            //}
            //public class Users
            //{
            //    public int Id { get; set; }
            //    public string FirstName { get; set; }
            //    public string MiddleName { get; set; }
            //    public string LastName { get; set; }
            //    public string MobileNo { get; set; }
            //    public string EmailId { get; set; }
            //    public string UserCode { get; set; }
            //    public string Address { get; set; }
            //    public string Status { get; set; }
            //    public string Active { get; set; }
            //    public string Photo { get; set; }

            //}
            //public class UserRoles
            //{
            //    public int Id { get; set; }
            //    public int UserId { get; set; }
            //    public int RoleId { get; set; }
            //    public int CompanyId { get; set; }
            //    public string insupdflag { set; get; }


            //}
            //public class UserLogins
            //{
            //    public int Id { get; set; }
            //    public string LoginInfo { get; set; }
            //    public string PassKey { get; set; }
            //    public int UserId { get; set; }
            //    public string salt { get; set; }
            //    public int Active { get; set; }
            //}
            //public class TroubleTicketDetails
            //{
            //    public int Id { get; set; }
            //    public string Type { get; set; }
            //    public string Tno { get; set; }
            //    public string createdto { get; set; }
            //    public string createdby { get; set; }
            //    public string assignto { get; set; }
            //    public string raisedtime { get; set; }
            //    public string IssueDetails { get; set; }
            //    public string StatusId { get; set; }
            //    public string TicketTitle { get; set; }
            //}
            //public class TroubleTickets
            //{
            //    public int Id { get; set; }
            //    public string PhoneNumber { get; set; }
            //    public int Userid { get; set; }
            //    public string EmailId { get; set; }
            //    public DateTime CreatedOn { get; set; }
            //    public string Onbehalfofph { get; set; }
            //    public string Title { get; set; }
            //    public int Catid { get; set; }
            //    public string Description { get; set; }
            //    public string TicketNo { get; set; }
            //    public int StatusId { get; set; }
            //    public int Emailsent { get; set; }
            //    public int Smssent { get; set; }
            //    public int TicketTypeId { get; set; }
            //    public string Name { get; set; }
            //    public string Category { get; set; }
            //    public string Subject { get; set; }
            //}
           
            //public class TransactionDetails
            //{
            //    public int Id { get; set; }
            //    public string TransId { get; set; }
            //    public int TotalAmt { get; set; }
            //    public string PaymentId { get; set; }
            //    public string BTPOSid { get; set; }
            //}
            //public class TrackHistory
            //{
            //    public int Id { get; set; }
            //    public string Field { get; set; }
            //    public string SubItem { get; set; }
            //    public string Comment { get; set; }
            //    public string Date { get; set; }
            //    public string ChangedBy { get; set; }
            //    public string Task { get; set; }
            //    public string ChangedType { get; set; }
            //}
            //public class RestaurantDetails
            //{
            //    public int Id { get; set; }
            //    public int RestaurantId { get; set; }
            //    public int FeatureCategoryId { get; set; }
            //    public int FeatureId { get; set; }
            //    public string Descripiton { get; set; }

            //}

            //public class RestaurantMaster
            //{
            //    public int Id { get; set; }
            //    public string Name { get; set; }
            //    public string ShortImage { get; set; }
            //    public string Image { get; set; }
            //    public string website { get; set; }
            //    public string Emailid { get; set; }
            //    public string PrimaryContactNo { get; set; }
            //    public string PrimaryContactEmail { get; set; }
            //    public int CityId { get; set; }
            //    public int StateId { get; set; }

            //    public int CountryId { get; set; }
            //    public string ZipCode { get; set; }


            //}

            //public class RestaurantMenuCategories
            //{
            //    public int Id { get; set; }
            //    public int RestaurantId { get; set; }
            //    public int RestaurantBranchId { get; set; }
            //    public int MenuCategoryId { get; set; }
            //}

            //public class RestaurantStaff
            //{
            //    public int Id { get; set; }
            //    public int RestaurantId { get; set; }
            //    public int RestaurantBranchId { get; set; }
            //    public int UserId { get; set; }
            //    public string FirstName { get; set; }
            //    public string LastName { get; set; }
            //    public string MiddleName { get; set; }
            //    public string Emailid { get; set; }
            //    public string UserCode { get; set; }
            //    public string Address { get; set; }
            //    public string Status { get; set; }
            //    public string Active { get; set; }
            //    public string Photo { get; set; }

            //}
            //public class Restauranttags
            //{
            //    public int Id { get; set; }
            //    public int RestaurantId { get; set; }
            //    public int TagId { get; set; }


            //}

            //public class RestaurantTimings
            //{
            //    public int Id { get; set; }
            //    public int RestaurantId { get; set; }
            //    public int RestaurantBranchId { get; set; }
            //    public int WeekdayId { get; set; }
            //    public DateTime StartTime { get; set; }
            //    public DateTime EndTime { get; set; }

            //}
            //public class RMenuCustomizations
            //{
            //    public int Id { get; set; }
            //    public int RestaurantId { get; set; }
            //    public int RestaurantBranchId { get; set; }
            //    public string MenuItemName { get; set; }
            //    public string Descryption { get; set; }
            //    public int RMenuItemsId { get; set; }
            //    public decimal pricing { get; set; }
            //    public string LongDescryption { get; set; }
            //    public decimal Rating { get; set; }


            //}
            //public class RoleObjectAccesses
            //{
            //    public int Id { get; set; }
            //    public int RoleId { get; set; }
            //    public int ObjectId { get; set; }
            //    public int AcessId { get; set; }
            //}
            //public class Roles
            //{
            //    public int Id { get; set; }
            //    public string Name { get; set; }

            //    public string Descryption { get; set; }
            //    public int Active { get; set; }
            //    public int IsPublic { get; set; }
            //}
            //public class States
            //{
            //    public int Id { get; set; }
            //    public string Name { get; set; }
            //    public decimal Latitude { get; set; }
            //    public decimal Longitude { get; set; }
            //    public string Code { get; set; }
            //    public int CountryId { get; set; }



            //}
            public class paymentdetails
            {
                public string flag { get; set; }
                public int Id { get; set; }
                public int PaymentId { get; set; }
                public string cardcategory { get; set; }
                public string status { get; set; }
                public int gatewayid { get; set; }
                public string transactiontype { get; set; }


                public string servicetype { get; set; }

                public int Transactionid { get; set; }
                public string Transaction_Number { get; set; }
                public int Amount { get; set; }
                public int Paymentmode { get; set; }

                public int Pnr_Id { get; set; }
                public string Pnr_No { get; set; }
                public string Gateway_transId { get; set; }
                public int TransactionStatus { get; set; }
            }


        
        public class cart
        {
            public int Id { get; set; }
            public int quantity{ get; set; }
            public int ProuductId { get; set; }
            public DateTime createdDate { get; set; }
            public int shopingcartId { get; set; }
           

        }

        public class resrating
        {
            public int rating { get; set; }
            public int id { get; set; }
        }

        public class dummy
        {
            public int par1 { get; set; }
            public string par2 { get; set; }
            public string par3 { get; set; }
            public string par4 { get; set; }
            public string par5 { get; set; }
        }
        public class UserLogin
        {
            public int Id { set; get; }
            public int UserId { set; get; }

            public string LoginInfo { set; get; }
            public string Passkey { set; get; }
            public string Salt { set; get; }
            public string Active { set; get; }
            public string UserAccountNo { get; set; }
            public string Password { get; set; }

        }

        public class UserAccount
        {
            public string flag { get; set; }
            public int id { get; set; }
            public int userId { get; set; }
            public string Username { get; set; }

            public string Email { get; set; }
            public string Mobilenumber { get; set; }
            public string Password { get; set; }
            public String EVerificationCode { get; set; }
            public DateTime EVerifiedOn { get; set; }
            public int IsEmailVerified { get; set; }
            public String MVerificationCode { get; set; }
            public string Passwordotp { get; set; }
            public DateTime MVerifiedOn { get; set; }
            public int IsMobileVerified { get; set; }
            public string Photo { get; set; }
            public int Status { get; set; }

            public DateTime CreatedOn { get; set; }
            public int ENoOfAttempts { get; set; }
            public int MNoOfAttempts { get; set; }
            public string Firstname { get; set; }
            public string lastname { get; set; }
            public int AuthTypeId { get; set; }
            public string AltPhonenumber { get; set; }
            public string Altemail { get; set; }
            public string AccountNo { get; set; }
            public string NewPassword { get; set; }
            public object Mobileotp { get; set; }

            public object Emailotp { get; set; }

            public int Gender { get; set; }
            public string UserPhoto { get; set; }

            public decimal Amount { get; set; }
            public int CountryId { get; set; }
            public int PaymentModeId { get; set; }
            public int CurrentStateId { get; set; }
            public int Active { get; set; }
            public string CCode { get; set; }
            public string UserAccountNo { get; set; }

        }
      
        //public class AppUserDetails
        //{
        //    public int Id { get; set; }
        //    public string Username { get; set; }
        //    public string Email { get; set; }
        //    public string Mobilenumber { get; set; }
        //    public string Password { get; set; }
        //    public string Mobileotp { get; set; }
        //    public string Emailotp { get; set; }
        //    public string Passwordotp { get; set; }
        //    public int StatusId { get; set; }
        //    public DateTime? CreatedOn { get; set; }
        //    public DateTime? Mobileotpsenton { get; set; }
        //    public DateTime? emailotpsenton { get; set; }
        //    public int noofattempts { get; set; }
        //    public string Firstname { get; set; }
        //    public string lastname { get; set; }
        //    public int AuthTypeId { get; set; }
        //    public string AltPhonenumber { get; set; }
        //    public string Altemail { get; set; }
        //    public string AccountNo { get; set; }
        //    public decimal Amount { get; set; }
        //    public string UserPhoto { get; set; }
        //    public int Gender { get; set; }
        //    public int CurrentStateId { get; set; }
        //    public int CountryId { get; set; }
        //    public int PaymentModeId { get; set; }
        //    public int Active { get; set; }
        //    public string CCode { get; set; }
        //    public string UserAccountNo { get; set; }
        //    public DateTime? DOB { get; set; }
        //    public string PromoCode { get; set; }
        //    public string UserSocialId { get; set; }
        //    public string Loginby { get; set; }
        //}
        //public class Appusers
        //{
        //    public int Id { get; set; }
        //    public string Username { get; set; }
        //    public string Email { get; set; }
        //    public string Mobilenumber { get; set; }
        //    public string Password { get; set; }
        //    public string Mobileotp { get; set; }
        //    public string Emailotp { get; set; }
        //    public string Passwordotp { get; set; }
        //    public int StatusId { get; set; }
        //    public DateTime? CreatedOn { get; set; }
        //    public DateTime? Mobileotpsenton { get; set; }
        //    public DateTime? emailotpsenton { get; set; }
        //    public int noofattempts { get; set; }
        //    public string Firstname { get; set; }
        //    public string lastname { get; set; }
        //    public int AuthTypeId { get; set; }
        //    public string AltPhonenumber { get; set; }
        //    public string Altemail { get; set; }
        //    public string AccountNo { get; set; }
        //    public decimal Amount { get; set; }
        //    public string UserPhoto { get; set; }
        //    public int Gender { get; set; }
        //    public int CurrentStateId { get; set; }
        //    public int CountryId { get; set; }
        //    public int PaymentModeId { get; set; }
        //    public int Active { get; set; }
        //    public string CCode { get; set; }
        //    public string UserAccountNo { get; set; }
        //    public DateTime? DOB { get; set; }
        //    public string PromoCode { get; set; }
        //}
        public class BusinessAppuser
        {
            public int Id { get; set; }
            public string change { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Mobilenumber { get; set; }
            public string Password { get; set; }
            public string Mobileotp { get; set; }
            public string Emailotp { get; set; }
            public string Passwordotp { get; set; }
            public int StatusId { get; set; }
            public DateTime? CreatedOn { get; set; }
            public DateTime? Mobileotpsenton { get; set; }
            public DateTime? emailotpsenton { get; set; }
            public int noofattempts { get; set; }
            public string Firstname { get; set; }
            public string lastname { get; set; }
            public int AuthTypeId { get; set; }
            public string AltPhonenumber { get; set; }
            public string Altemail { get; set; }
            public string AccountNo { get; set; }
            public decimal Amount { get; set; }
            public string UserPhoto { get; set; }
            public int Gender { get; set; }
            public int CurrentStateId { get; set; }
            public int CountryId { get; set; }
            public int PaymentModeId { get; set; }
            public int Active { get; set; }
            public string CCode { get; set; }
            public string UserAccountNo { get; set; }
            public int usertypeid { get; set; }
            public string Loginby { get; set; }
            public DateTime? DateofBirth { get; set; }
            public string UserSocialId { get; set; }
            public string flag { get; set; }
        }
        public class RMenuItems
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public int RestaurantBranchId { get; set; }
            public string MenuItemName { get; set; }
            public string description { get; set; }
            public string photo { get; set; }
            public decimal price { get; set; }
            public decimal rating { get; set; }
            public string recipe { get; set; }
            public string flag { get; set; }
        }
        //public class country
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Latitude { get; set; }
        //    public string Longitude { get; set; }
        //    public string ISOCode { get; set; }
        //    public int HasOperations { get; set; }
        //    public string flag { get; set; }
        //    public string Code { get; set; }
        //    public string FlagLocation { get; set; }
        //}
        //public class DemoRequest
        //{
        //    public int Id { get; set; }
        //    public DateTime? Datetime { get; set; }
        //    public string BusinessName { get; set; }
        //    public string Email { get; set; }
        //    public string MobileNumber { get; set; }
        //    public int CountryId { get; set; }
        //    public string LoginNo { get; set; }
        //    public DateTime? Emailsenton { get; set; }
        //    public DateTime? Otpsent { get; set; }
        //    public string Reviewed { get; set; }
        //    public string Notification { get; set; }
        //    public string DashboardUsername { get; set; }
        //    public string DashboardPwd { get; set; }
        //    public string CustomerAppUsername { get; set; }
        //    public string BusinessAppUsername { get; set; }
        //    public string CustomerAppPwd { get; set; }
        //    public string BusinessAppPwd { get; set; }
        //    public string OtpBusinessApp { get; set; }
        //    public string OtpCustomerApp { get; set; }
        //    public DateTime? Emailsent { get; set; }
        //    public DateTime Otpsenton { get; set; }
        //    public DateTime ReviewedOn { get; set; }
        //    public DateTime NotifiedOn { get; set; }
        //    public int ReviewedBy { get; set; }
        //    public int EmailSentBy { get; set; }
        //    public int StatusId { get; set; }
        //}
        //public class EditHistory
        //{
        //    public int Id { get; set; }
        //    public string Field { get; set; }
        //    public string SubItem { get; set; }
        //    public string Comment { get; set; }
        //    public DateTime Date { get; set; }
        //    public string ChangedBy { get; set; }
        //    public string ChangedType { get; set; }
        //    public string Task { get; set; }
        //    public int edithistoryid { get; set; }
        //}
        //public class EditHistoryDetails
        //{
        //    public int Id { get; set; }
        //    public int EditHistoryId { get; set; }
        //    public string FromValue { get; set; }
        //    public string ToValue { get; set; }
        //    public string ChangeType { get; set; }
        //    public string Field1 { get; set; }
        //    public string Field2 { get; set; }
        //}
        //public class EWallet
        //{
        //    public int Id { get; set; }
        //    public string UserAccountNo { get; set; }
        //    public string Mobilenumber { get; set; }
        //    public int Status { get; set; }
        //    public string Mobileotp { get; set; }
        //    public string Createdon { get; set; }
        //    public DateTime MOTPSentOn { get; set; }
        //}
        //public class EWalletTransactions
        //{
        //    public int Id { get; set; }
        //    public DateTime Date { get; set; }
        //    public DateTime Time { get; set; }
        //    public string Mobilenumber { get; set; }
        //    public string GatewayId { get; set; }
        //    public decimal Amount { get; set; }
        //    public string Comments { get; set; }
        //    public string TransactionId { get; set; }
        //    public int TransactionMode { get; set; }
        //    public int StatusId { get; set; }
        //    public string appuser { get; set; }
        //    public int SourceApp { get; set; }
        //}
        //public class FAQs
        //{
        //    public int Id { get; set; }
        //    public string Question { get; set; }
        //    public string Answer { get; set; }
        //    public DateTime CreatedOn { get; set; }
        //    public string CreatedBy { get; set; }
        //    public int AppType { get; set; }
        //    public int Category { get; set; }
        //    public int SubCategory { get; set; }
        //    public string flag { get; set; }
        //}
        //public class MasterDataGroups
        //{
        //    public string flag { get; set; }
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Description { get; set; }
        //    public int Active { get; set; }
        //}
        //public class MasterDatatypes
        //{
        //    public string flag { get; set; }
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Description { get; set; }
        //    public int Active { get; set; }
        //    public int TypeGroupId { get; set; }
        //    public string listkey { get; set; }
        //    public string listvalue { get; set; }
        //}
        public class menuCategories
        {
            public int Id { get; set; }
            public int ResId { get; set; }
            public int ResBId { get; set; }
            public int MenuCategoryId { get; set; }
            public string MenuCategoryName { get; set; }
            public string Description { get; set; }
            public string Active { get; set; }
            public int CusinieTypeId { get; set; }
            public string flag { get; set; }
        }
        public class NotificationConfiguration
        {
            public int Id { get; set; }
            public int RoleId { get; set; }
            public int NotificationId { get; set; }
        }
        public class Notifications
        {
            public int Id { get; set; }
            public int RoleId { get; set; }
            public int UserId { get; set; }
            public string Title { get; set; }
            public string Message { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime UpdatedOn { get; set; }
            public int UpdatedBy { get; set; }
            public int StateId { get; set; }
            public int StatusId { get; set; }
            public int CategoryId { get; set; }
            public int SubCategoryId { get; set; }
            public int Active { get; set; }
        }
        public class ObjectAccesses
        {
            public int Id { get; set; }
            public int ObjectId { get; set; }
            public int TypeId { get; set; }
            public string Name { get; set; }
            public int AccessId { get; set; }
        }
        public class Objects
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Path { get; set; }
            public int Active { get; set; }
            public int ParentId { get; set; }
            public string RootObjectId { get; set; }
        }
        public class OrderDetails
        {
            public int Id { get; set; }
            public string orderid { get; set; }
            public string customerid { get; set; }
            public string productname { get; set; }
            public string quantity { get; set; }
            public string orderdate { get; set; }

        }
        public class RestaurantBranches
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public string Name { get; set; }
            public string ShortDesc { get; set; }
            public decimal latitude { get; set; }
            public decimal longitude { get; set; }
            public string address { get; set; }
            public string NearestLandmark { get; set; }
            public string Image { get; set; }
            public string ShortImage { get; set; }
            public decimal rating { get; set; }
            public DateTime? minimumdeliverytime { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Zipcode { get; set; }
            public string website { get; set; }
            public string emailid { get; set; }
            public string primaryphonenumber { get; set; }
            public string altphonenumber { get; set; }
            public string RegisteredBy { get; set; }
            public string flag { get; set; }
        }
        public class RestaurantCusines
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public int RestaurantBranchId { get; set; }
            public int CusinieId { get; set; }
            public string flag { get; set; }
        }
        public class Users
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string MobileNo { get; set; }
            public string EmailId { get; set; }
            public string UserCode { get; set; }
            public string Address { get; set; }
            public string Status { get; set; }
            public string Active { get; set; }
            public string Photo { get; set; }

        }
        public class UserRoles
        {
            public string insupdflag { get; set; }
            public int Id { get; set; }
            public int UserId { get; set; }
            public int RoleId { get; set; }
            public int CompanyId { get; set; }
        }
        public class UserLogins
        {
            public int Id { get; set; }
            public string LoginInfo { get; set; }
            public string PassKey { get; set; }
            public int UserId { get; set; }
            public string salt { get; set; }
            public int Active { get; set; }
        }
        public class TroubleTicketDetails
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Tno { get; set; }
            public string createdto { get; set; }
            public string createdby { get; set; }
            public string assignto { get; set; }
            public string raisedtime { get; set; }
            public string IssueDetails { get; set; }
            public string StatusId { get; set; }
            public string TicketTitle { get; set; }
        }
        public class TroubleTickets
        {
            public int Id { get; set; }
            public string PhoneNumber { get; set; }
            public int Userid { get; set; }
            public string EmailId { get; set; }
            public DateTime CreatedOn { get; set; }
            public string Onbehalfofph { get; set; }
            public string Title { get; set; }
            public int Catid { get; set; }
            public string Description { get; set; }
            public string TicketNo { get; set; }
            public int StatusId { get; set; }
            public int Emailsent { get; set; }
            public int Smssent { get; set; }
            public int TicketTypeId { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Subject { get; set; }
        }
    public class TransactionMaster
    {
        public int Id { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? TransactionTime { get; set; }
        public decimal Amount { get; set; }
        public int StatusId { get; set; }
        public decimal Charges { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string TransRefId { get; set; }
        public string TransGatewayId { get; set; }
        public int TransCatId { get; set; }
        public int TransModeId { get; set; }
        public int TransactionTypeId { get; set; }
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public string Code { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public string AccountCode { get; set; }
        public string TransCode { get; set; }
        public string CreatedByCreatedBy { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentDesc { get; set; }
        public string PaymentType { get; set; }
        public string flag { get; set; }
    }
    public class TransactionDetails
        {
            public int Id { get; set; }
            public string TransId { get; set; }
            public int TotalAmt { get; set; }
            public string PaymentId { get; set; }
            public string BTPOSid { get; set; }
        }
        public class TrackHistory
        {
            public int Id { get; set; }
            public string Field { get; set; }
            public string SubItem { get; set; }
            public string Comment { get; set; }
            public string Date { get; set; }
            public string ChangedBy { get; set; }
            public string Task { get; set; }
            public string ChangedType { get; set; }
        }
        public class RestaurantDetails
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public int RestaurantBranchId { get; set; }
            public int FeatureCategoryId { get; set; }
            public int FeatureId { get; set; }
            public string Descripiton { get; set; }
            public string flag { get; set; }
        }

        public class RestaurantMaster
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ShortImage { get; set; }
            public string ShortDesc { get; set; }
            public string Image { get; set; }
            public string website { get; set; }
            public string Emailid { get; set; }
            public string PrimaryContactNo { get; set; }
            public string PrimaryContactEmail { get; set; }
            public int CityId { get; set; }
            public int StateId { get; set; }

            public int CountryId { get; set; }
            public string ZipCode { get; set; }
            public string flag { get; set; }


        }

        public class RestaurantMenuCategories
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public int RestaurantBranchId { get; set; }
            public int MenuCategoryId { get; set; }
        }

        public class RestaurantStaff
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public int RestaurantBranchId { get; set; }
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string Emailid { get; set; }
            public string UserCode { get; set; }
            public string Address { get; set; }
            public string Status { get; set; }
            public string Active { get; set; }
            public string Photo { get; set; }

        }
        public class Restauranttags
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public int TagId { get; set; }


        }

        public class RestaurantTimings
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public int RestaurantBranchId { get; set; }
            public int WeekdayId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }

        }
        public class RMenuCustomizations
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public int RestaurantBranchId { get; set; }
            public string MenuItemName { get; set; }
            public string Descryption { get; set; }
            public int RMenuItemsId { get; set; }
            public decimal pricing { get; set; }
            public string LongDescryption { get; set; }
            public decimal Rating { get; set; }


        }
        public class RoleObjectAccesses
        {
            public int Id { get; set; }
            public int RoleId { get; set; }
            public int ObjectId { get; set; }
            public int AcessId { get; set; }
        }
        public class Roles
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Descryption { get; set; }
            public int Active { get; set; }
            public int IsPublic { get; set; }
        }
        public class States
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
            public string Code { get; set; }
            public int CountryId { get; set; }



        }
        public class DeliveryStaff
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Mobilenumber { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public string Mobileotp { get; set; }
            public string Emailotp { get; set; }
            public string Passwordotp { get; set; }
            public int StatusId { get; set; }
            public DateTime? CreatedOn { get; set; }
            public DateTime? Mobileotpsenton { get; set; }
            public DateTime? emailotpsenton { get; set; }
            public string noofattempts { get; set; }
            public string Firstname { get; set; }
            public string lastname { get; set; }
            public int AuthTypeId { get; set; }
            public string AltPhonenumber { get; set; }
            public string Altemail { get; set; }
            public string AccountNo { get; set; }
            public decimal Amount { get; set; }
            public string UserPhoto { get; set; }
            public int Gender { get; set; }
            public int CurrentStateId { get; set; }
            public int CountryId { get; set; }
            public int Active { get; set; }
            public string CCode { get; set; }
            public string UserAccountNo { get; set; }
            public string DOB { get; set; }
            public string flag { get; set; }
        }

    public class dstafflogin
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public int DSId { get; set; }       
        public string Reason { get; set; }
        public int StatusId { get; set; }

        public float LoginLatitude { get; set; }

        public float LoginLongitude { get; set; }
        public float LogoutLatitude { get; set; }

        public float LogoutLongitude { get; set; }
        public int loginlogout { get; set; }
        public string Mobileno { get; set; }
        public string Password { get; set; }
    }

    public class DeliverystaffTrack
    {
        public string Mobilenumber { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }        
        public int StatusId { get; set; }
    }

    public class DeliverystaffRating
    {
        //public string Mobilenumber { get; set; }
        public decimal DStaffRating { get; set; }
        public string DStaffComments { get; set; }
        public int orderid { get; set; }
        public int flag { get; set; }
    }

    

    public class CustomerRating
    {
        public string Mobilenumber { get; set; }
        public decimal Rating { get; set; }
        public string Comments { get; set; }
        public int orderid { get; set; }
    }

    public class Itemschecking
    {
        public int orderid { get; set; }
        public int ItemId { get; set; }
        public int Isavailable { get; set; }
    }

    public class dstafforder
    {
        public int orderid { get; set; }
        public int statusid { get; set; }
        public int dstaffid { get; set; }
        public float dellat { get; set; }
        public float dellong { get; set; }
    }

    public class deliverycomplete
    {
        public int orderid { get; set; }
        public int statusid { get; set; }
        public int dstaffid { get; set; }

    }

}