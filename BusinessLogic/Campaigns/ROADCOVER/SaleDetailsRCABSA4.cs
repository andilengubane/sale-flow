using System;
using Helper;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using Utils.Logger;

namespace BusinessLogic.Campaigns.ROADCOVER
{
    public class SaleDetailsRCABSA4
    {
        private const string CampaignName = "RCABSA4";

        #region Properties

        private bool _found = false;

        public int SaleID { get; set; }
        public decimal Premium { get; set; }
        public int BankID { get; set; }
        public int TitleID { get; set; }
        public int ProvinceID { get; set; }
        public string MemberType { get; set; }
        public string RoadCoverLeadID { get; set; }
        public string ConsFileNumber { get; set; }
        public string MemberNumber { get; set; }
        public string FileStatus { get; set; }
        public string VehicleDetail1 { get; set; }
        public string VehicleDetail2 { get; set; }
        public string VehicleDetail3 { get; set; }
        public string VehicleDetail4 { get; set; }
        public string VehicleDetail5 { get; set; }
        public string Product1 { get; set; }
        public string Product2 { get; set; }
        public string Product3 { get; set; }
        public string Product4 { get; set; }
        public string Product5 { get; set; }
        public DateTime? Date1 { get; set; }
        public DateTime? Date2 { get; set; }
        public DateTime? Date3 { get; set; }
        public DateTime? Date4 { get; set; }
        public DateTime? Date5 { get; set; }
        public string AllocatedTo { get; set; }
        public DateTime? DateAllocated { get; set; }
        public string AssetShortDescription { get; set; }
        public DateTime? DateExpiry { get; set; }
        public DateTime? DateFirstLicensed { get; set; }
        public string MakeDescription { get; set; }
        public string RegistrationNum { get; set; }
        public string DebitOrderDay { get; set; }
        public string Disposition { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int ProductID { get; set; }

        public bool Found
        {
            get
            { return _found; }
        }

        #endregion

        /// <summary>
        /// Retrieves Sales Details data from the database based on the passed sale ID.
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value containing the sale ID to use.</param>
        /// <returns>A <see cref="SaleDetailsRCABSA4"/> object populated with the database values retrieved using the passed sale ID.</returns>
        public static SaleDetailsRCABSA4 GetSaleDetails(int saleID)
        {
            SaleDetailsRCABSA4 retVal = new SaleDetailsRCABSA4();
            
            List<SqlParameter> parms = new List<SqlParameter>()            {
                
                new SqlParameter("@SaleID", saleID)
            };

            string sql = "spGetSaleDetailsRCABSA4";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }

        /// <summary>
        /// Creates a new Sales_Details_RCABSA4 entry in the database using the passed parameters.
        /// </summary>
        /// <param name="SaleID">An <see cref="int"/> value containing the sale ID the new entry will be linked to.</param>
        /// <param name="Premium">A <see cref="decimal"/> value containing the product premium for the sale.</param>
        /// <param name="BankID">An <see cref="int"/> value representing a foreign key to the Bank database table.</param>
        /// <param name="TitleID">An <see cref="int"/> value representing a foreign key to the Title database table. </param>
        /// <param name="ProvinceID">An <see cref="int"/> value representing a foreign key to the Province database table. </param>
        /// <param name="MemberType">A <see cref="string"/> value containing the member type/s ("Member", "Rider-Individual", "Rider-Family", "Rider-Asset" or "Dependent-Asset) for the sale.</param>
        /// <param name="RoadCoverLeadID">A <see cref="string"/> value containing the RoadCover unique lead ID (or "Our Reference" on the leads file).</param>
        /// <param name="ConsFileNumber">A <see cref="string"/> value containing the RoadCover Campaign ID.</param>
        /// <param name="MemberNumber">A <see cref="string"/> value containing the unique member number (assigned to each RoadCover customer).</param>
        /// <param name="FileStatus">A <see cref="string"/> value containing the lead file status.</param>
        /// <param name="VehicleDetail1">A <see cref="string"/> value containing vehicle make/manufacturer name.</param>
        /// <param name="VehicleDetail2">A <see cref="string"/> value containing vehicle model name.</param>
        /// <param name="VehicleDetail3">A <see cref="string"/> value containing registration number.</param>
        /// <param name="VehicleDetail4">A <see cref="string"/> value containing vehicle miscellaneous data.</param>
        /// <param name="VehicleDetail5">A second <see cref="string"/> value containing vehicle miscellaneous data.</param>
        /// <param name="Product1">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Product2">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Product3">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Product4">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Product5">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Date1">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="Date2">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="Date3">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="Date4">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="Date5">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="AllocatedTo"></param>
        /// <param name="DateAllocated"></param>
        /// <param name="AssetShortDescription"></param>
        /// <param name="DateExpiry"></param>
        /// <param name="DateFirstLicensed"></param>
        /// <param name="MakeDescription"></param>
        /// <param name="RegistrationNum">A <see cref="string"/> value containing vehicle registration number (over and above VehicleDetail3).</param>
        /// <param name="DebitOrderDay">A <see cref="string"/> value containing the day selected for debit order on the capture form.</param>
        /// <param name="Disposition">A <see cref="string"/> value signifying if a sale is saved for later, or submitted as a sale.</param>
        /// <param name="IsActive">A <see cref="bool"/> value denoting if the record is active or not.</param>
        /// <param name="DateCreated">A <see cref="DateTime"/> containing the creation date and time.</param>
        /// <param name="DateUpdated">A <see cref="DateTime"/> containing the date and time the record has been updated.</param>
        /// <param name="CreatedBy">A <see cref="string"/> containing the username of the user that created the record.</param>
        /// <param name="UpdatedBy">A <see cref="string"/> containing the username of the user that updated the record.</param>
        /// <param name="ProductID">An <see cref="int"/> value containing the unique ID of a corresponding RoadCoverProductCatalog record.</param>
        /// <returns>An <see cref="int"/> value containing the unique ID of the newly created record, or 0 if something went wrong.</returns>
        public static int CreateSaleDetail(int SaleID, decimal Premium, int BankID, int TitleID, int ProvinceID, string MemberType, string RoadCoverLeadID,
                                           string ConsFileNumber, string MemberNumber, string FileStatus, string VehicleDetail1,string VehicleDetail2,string VehicleDetail3,string VehicleDetail4,string VehicleDetail5,
                                           string Product1,string Product2,string Product3,string Product4,string Product5,DateTime? Date1,DateTime? Date2,
                                           DateTime? Date3,DateTime? Date4,DateTime? Date5,string AllocatedTo,DateTime? DateAllocated,string AssetShortDescription,DateTime? DateExpiry,
                                           DateTime? DateFirstLicensed,string MakeDescription,string RegistrationNum,string DebitOrderDay, string Disposition, bool IsActive, DateTime DateCreated, 
                                           DateTime DateUpdated, string CreatedBy, string UpdatedBy,string ProductID)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SaleID", SaleID),
                new SqlParameter("@Premium", Premium),
                new SqlParameter("@BankID", BankID),
                new SqlParameter("@TitleID", TitleID),
                new SqlParameter("@ProvinceID", ProvinceID),
                new SqlParameter("@MemberType", MemberType),
                new SqlParameter("@RoadCoverLeadID", RoadCoverLeadID),
                new SqlParameter("@ConsFileNumber", ConsFileNumber),
                new SqlParameter("@MemberNumber", MemberNumber),
                new SqlParameter("@FileStatus", FileStatus),
                new SqlParameter("@VehicleDetail1", VehicleDetail1),
                new SqlParameter("@VehicleDetail2", VehicleDetail2),
                new SqlParameter("@VehicleDetail3", VehicleDetail3),
                new SqlParameter("@VehicleDetail4", VehicleDetail4),
                new SqlParameter("@VehicleDetail5", VehicleDetail5),
                new SqlParameter("@Product1", Product1),
                new SqlParameter("@Product2", Product2),
                new SqlParameter("@Product3", Product3),
                new SqlParameter("@Product4", Product4),
                new SqlParameter("@Product5", Product5),
                new SqlParameter("@Date1", Date1),
                new SqlParameter("@Date2", Date2),
                new SqlParameter("@Date3", Date3),
                new SqlParameter("@Date4", Date4),
                new SqlParameter("@Date5", Date5),
                new SqlParameter("@AllocatedTo", AllocatedTo),
                new SqlParameter("@DateAllocated", DateAllocated),
                new SqlParameter("@AssetShortDescription", AssetShortDescription),
                new SqlParameter("@DateExpiry", DateExpiry),
                new SqlParameter("@DateFirstLicensed", DateFirstLicensed),
                new SqlParameter("@MakeDescription", MakeDescription),
                new SqlParameter("@RegistrationNumber", RegistrationNum),
                new SqlParameter("@DebitOrderDay", DebitOrderDay),
                new SqlParameter("@Disposition", Disposition),
                new SqlParameter("@IsActive", IsActive),
                new SqlParameter("@DateCreated",DateCreated),
                new SqlParameter("@DateUpdated",DateUpdated),
                new SqlParameter("@CreatedBy",CreatedBy),
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@ProductID",ProductID),
            };

            string sql = "spCreateSales_Details_RCABSA4";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        /// <summary>
        /// Updates a Sales_Details_RCABSA4 entry in the database using the passed parameters.
        /// </summary>
        /// <param name="SalesDetailsID">An <see cref="int"/> value containing the Sales_Details_RCABSA4 ID to process.</param>
        /// <param name="Premium">A <see cref="decimal"/> value containing the product premium for the sale.</param>
        /// <param name="BankID">An <see cref="int"/> value representing a foreign key to the Bank database table.</param>
        /// <param name="TitleID">An <see cref="int"/> value representing a foreign key to the Title database table. </param>
        /// <param name="ProvinceID">An <see cref="int"/> value representing a foreign key to the Province database table. </param>
        /// <param name="MemberType">A <see cref="string"/> value containing the member type/s ("Member", "Rider-Individual", "Rider-Family", "Rider-Asset" or "Dependent-Asset) for the sale.</param>
        /// <param name="RoadCoverLeadID">A <see cref="string"/> value containing the RoadCover unique lead ID (or "Our Reference" on the leads file).</param>
        /// <param name="ConsFileNumber">A <see cref="string"/> value containing the RoadCover Campaign ID.</param>
        /// <param name="MemberNumber">A <see cref="string"/> value containing the unique member number (assigned to each RoadCover customer).</param>
        /// <param name="FileStatus">A <see cref="string"/> value containing the lead file status.</param>
        /// <param name="VehicleDetail1">A <see cref="string"/> value containing vehicle make/manufacturer name.</param>
        /// <param name="VehicleDetail2">A <see cref="string"/> value containing vehicle model name.</param>
        /// <param name="VehicleDetail3">A <see cref="string"/> value containing registration number.</param>
        /// <param name="VehicleDetail4">A <see cref="string"/> value containing vehicle miscellaneous data.</param>
        /// <param name="VehicleDetail5">A second <see cref="string"/> value containing vehicle miscellaneous data.</param>
        /// <param name="Product1">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Product2">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Product3">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Product4">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Product5">A <see cref="string"/> value containing product information (usually blank).</param>
        /// <param name="Date1">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="Date2">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="Date3">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="Date4">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="Date5">A nullable <see cref="DateTime?"/> value.</param>
        /// <param name="AllocatedTo"></param>
        /// <param name="DateAllocated"></param>
        /// <param name="AssetShortDescription"></param>
        /// <param name="DateExpiry"></param>
        /// <param name="DateFirstLicensed"></param>
        /// <param name="MakeDescription"></param>
        /// <param name="RegistrationNum">A <see cref="string"/> value containing vehicle registration number (over and above VehicleDetail3).</param>
        /// <param name="DebitOrderDay">A <see cref="string"/> value containing the day selected for debit order on the capture form.</param>
        /// <param name="Disposition">A <see cref="string"/> value signifying if a sale is saved for later, or submitted as a sale.</param>        
        /// <param name="DateUpdated">A <see cref="DateTime"/> containing the date and time the record has been updated.</param>        
        /// <param name="UpdatedBy">A <see cref="string"/> containing the username of the user that updated the record.</param>
        /// <param name="ProductID">An <see cref="int"/> value containing the unique ID of a corresponding RoadCoverProductCatalog record.</param>
        /// <returns>An <see cref="int"/> value containing the unique ID of the updated record, or 0 if something went wrong.</returns>
        public static int UpdateSaleDetail(int SalesDetailsID, decimal Premium, int BankID, int TitleID, int ProvinceID, string MemberType, string RoadCoverLeadID,
                                           string ConsFileNumber, string MemberNumber, string FileStatus, string VehicleDetail1, string VehicleDetail2, string VehicleDetail3, string VehicleDetail4, string VehicleDetail5,
                                           string Product1, string Product2, string Product3, string Product4, string Product5, DateTime? Date1, DateTime? Date2,
                                           DateTime? Date3, DateTime? Date4, DateTime? Date5, string AllocatedTo, DateTime? DateAllocated, string AssetShortDescription, DateTime? DateExpiry,
                                           DateTime? DateFirstLicensed, string MakeDescription, string RegistrationNum, string DebitOrderDay, string Disposition, DateTime DateUpdated, string UpdatedBy, int ProductID)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SalesDetailsID", SalesDetailsID),
                new SqlParameter("@Premium", Premium),
                new SqlParameter("@BankID", BankID),
                new SqlParameter("@TitleID", TitleID),
                new SqlParameter("@ProvinceID", ProvinceID),
                new SqlParameter("@MemberType", MemberType),
                new SqlParameter("@RoadCoverLeadID", RoadCoverLeadID),
                new SqlParameter("@ConsFileNumber", ConsFileNumber),
                new SqlParameter("@MemberNumber", MemberNumber),
                new SqlParameter("@FileStatus", FileStatus),
                new SqlParameter("@VehicleDetails1", VehicleDetail1),
                new SqlParameter("@VehicleDetails2", VehicleDetail2),
                new SqlParameter("@VehicleDetails3", VehicleDetail3),
                new SqlParameter("@VehicleDetails4", VehicleDetail4),
                new SqlParameter("@VehicleDetails5", VehicleDetail5),
                new SqlParameter("@Product1", Product1),
                new SqlParameter("@Product2", Product2),
                new SqlParameter("@Product3", Product3),
                new SqlParameter("@Product4", Product4),
                new SqlParameter("@Product5", Product5),
                new SqlParameter("@Date1", Date1),
                new SqlParameter("@Date2", Date2),
                new SqlParameter("@Date3", Date3),
                new SqlParameter("@Date4", Date4),
                new SqlParameter("@Date5", Date5),
                new SqlParameter("@AllocatedTo", AllocatedTo),
                new SqlParameter("@DateAllocated", DateAllocated),
                new SqlParameter("@AssetShortDescription", AssetShortDescription),
                new SqlParameter("@DateExpiry", DateExpiry),
                new SqlParameter("@DateFirstLicensed", DateFirstLicensed),
                new SqlParameter("@MakeDescription", MakeDescription),
                new SqlParameter("@RegistrationNum", RegistrationNum),
                new SqlParameter("@DebitOrderDay", DebitOrderDay),
                new SqlParameter("@Disposition", Disposition),
                new SqlParameter("@DateUpdated",DateUpdated),                
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@ProductID",ProductID)

            };

            string sql = "spUpdateSales_Details_RCABSA4";

            DataAccess.ExecuteSpNoReader(sql, parm);

            return retval;
        }

        /// <summary>
        /// A mini-factory method that generates an object based on the data from a passed in database row.
        /// </summary>
        /// <param name="inputRow">A <see cref="DataRow"/> object containing the data to use when generating the new object.</param>
        /// <returns>A <see cref="SaleDetailsRCABSA4"/> object containing the data from the passed <see cref="DataRow"/> object.</returns>
        private static SaleDetailsRCABSA4 MakeObject(DataRow inputRow)
        {
            SaleDetailsRCABSA4 retValue = new SaleDetailsRCABSA4();

            retValue.SaleID = (int)inputRow["SaleID"];
            retValue.Premium = (decimal)inputRow["Premium"];
            retValue.BankID = (int)inputRow["BankID"];
            retValue.TitleID = (int)inputRow["TitleID"];
            retValue.ProvinceID = (int)inputRow["ProvinceID"];
            retValue.MemberType = (string)inputRow["MemberType"];
            retValue.RoadCoverLeadID = (string)inputRow["RoadCoverLeadID"];
            retValue.ConsFileNumber = (string)inputRow["ConsFileNumber"];
            retValue.MemberNumber = (string)inputRow["MemberNumber"];
            retValue.FileStatus = (string)inputRow["FileStatus"];
            retValue.VehicleDetail1 = (string)inputRow["VehicleDetail1"];
            retValue.VehicleDetail2 = (string)inputRow["VehicleDetail2"];
            retValue.VehicleDetail3 = (string)inputRow["VehicleDetail3"];
            retValue.VehicleDetail4 = (string)inputRow["VehicleDetail4"];
            retValue.VehicleDetail5 = (string)inputRow["VehicleDetail5"];
            retValue.Product1 = (string)inputRow["Product1"];
            retValue.Product2 = (string)inputRow["Product2"];
            retValue.Product3 = (string)inputRow["Product3"];
            retValue.Product4 = (string)inputRow["Product4"];
            retValue.Product5 = (string)inputRow["Product5"];
            retValue.Date1 = inputRow["Date1"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(inputRow["Date1"]);
            retValue.Date2 = inputRow["Date2"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(inputRow["Date2"]);
            retValue.Date3 = inputRow["Date3"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(inputRow["Date3"]);
            retValue.Date4 = inputRow["Date4"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(inputRow["Date4"]);
            retValue.Date5 = inputRow["Date5"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(inputRow["Date5"]);
            retValue.AllocatedTo = (string)inputRow["AllocatedTo"];
            retValue.DateAllocated = (inputRow["DateAllocated"] == DBNull.Value) ? (DateTime?)null : (DateTime)inputRow["DateAllocated"];
            retValue.AssetShortDescription = (string)inputRow["AssetShortDescription"];
            retValue.DateExpiry = (inputRow["DateExpiry"] == DBNull.Value) ? (DateTime?)null : (DateTime)inputRow["DateExpiry"];
            retValue.DateFirstLicensed = (inputRow["DateFirstLicensed"] == DBNull.Value) ? (DateTime?)null : (DateTime)inputRow["DateFirstLicensed"];
            retValue.MakeDescription = (string)inputRow["MakeDescription"];
            retValue.RegistrationNum = (string)inputRow["RegistrationNum"];
            retValue.DebitOrderDay = (string)inputRow["DebitOrderDay"];
            retValue.Disposition = (string)inputRow["Disposition"];
            retValue.IsActive = (bool)inputRow["IsActive"];
            retValue.ProductID = (int)inputRow["ProductID"];

            retValue._found = true;
            return retValue;
        }
    }
}
