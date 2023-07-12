using Helper;
using System;
using System.Linq;
using System.Text;
using System.Data;
using Utils.Logger;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLogic.Campaigns.ROADCOVER
{
    public class RoadCoverProducts
    {
        public int Id {get;set;}
	    public string CampaignName {get;set;}
	    public string SaleId {get;set;}
	    public string VehicleDetail {get;set;}
	    public string ProductDetail {get;set;} 
	    public DateTime DateAllocated {get;set;}
	    public string AssetShortDescription {get;set;}
	    public DateTime DateExpiry {get;set;}
	    public string FirstLicensed {get;set;}
	    public string MakeDescription {get;set;}
	    public string RegistrationNum {get;set;}
        public string Allocatedto { get; set; }

        public bool Found
        {
            get
            { return _found; }
        }
        private bool _found = false;
        public static RoadCoverProducts GetRoadCoverProductsDetails(int saleId ,string campaignName)
        {
            RoadCoverProducts roadCoverProducts = new RoadCoverProducts();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@SaleId", saleId),
                new SqlParameter("@CampaignName", campaignName)
            };

            string sql = "select * from [RoadCoverProducts] where SaleId = @SaleId AND CampaignName = @CampaignName";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                roadCoverProducts = MakeObject(results.Rows[0]);
            }
            return roadCoverProducts;
        }
        private static RoadCoverProducts MakeObject(DataRow inputRow)
        {
            RoadCoverProducts roadCoverProducts = new RoadCoverProducts();

            roadCoverProducts.Id = (int)inputRow["Id"];
            roadCoverProducts.SaleId = (string)inputRow["SaleID"];
           
            roadCoverProducts.CampaignName = (string)inputRow["CampaignName"];
            roadCoverProducts.VehicleDetail = (string)inputRow["VehicleDetail"];
            roadCoverProducts.ProductDetail = (string)inputRow["ProductDetailc"];
            roadCoverProducts.Allocatedto = (string)inputRow["Allocatedto"];
            roadCoverProducts.DateAllocated = (DateTime)inputRow["DateAllocated"];
            roadCoverProducts.AssetShortDescription = (string)inputRow["AssetShortDescription"];
            roadCoverProducts.DateExpiry = (DateTime)inputRow["DateExpiry"];
            roadCoverProducts.FirstLicensed = (string)inputRow["TelWork"];
            roadCoverProducts.MakeDescription = (string)inputRow["MakeDescription"];
            roadCoverProducts.RegistrationNum = (string)inputRow["RegistrationNum"];
           
            roadCoverProducts._found = true;
            return roadCoverProducts;
        }
    }
}
