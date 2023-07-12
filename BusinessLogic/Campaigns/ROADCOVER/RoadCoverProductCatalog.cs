using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Campaigns.ROADCOVER
{
    /// <summary>
    /// The RoadCoverProductCatalog class.
    /// Contains properties and methods for processing a RoadCover Product such as RoadCover Standalone, or AllRoad, etc.
    /// </summary>
    public class RoadCoverProductCatalog
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal IndividualRiderPrice { get; set; }
        public decimal FamilyRiderPrice { get; set; }
        public decimal VehiclePrice { get; set; }
        public int CampaignID { get; set; }

        /// <summary>
        /// Gets a list of products for a provided campaign ID.
        /// </summary>
        /// <param name="campaignID">An <see cref="int"/> value containing the campaign ID to use.</param>        
        /// <returns>A List of RoadCoverProductCatalog objects.</returns>
        public static List<RoadCoverProductCatalog> GetListOfCampaignProducts(int campaignID)
        {
            List<RoadCoverProductCatalog> output = new List<RoadCoverProductCatalog>();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignID", campaignID)
            };

            DataTable productData = Helper.DataAccess.ExecuteSpDataReader("spGetProductsForCampaign", parameters);

            foreach (DataRow row in productData.Rows)
            {
                RoadCoverProductCatalog product = new RoadCoverProductCatalog()
                {
                    ID = (int)row[0],
                    Name = row[1].ToString(),
                    BasePrice = (decimal)row[2],
                    IndividualRiderPrice = (decimal)row[3],
                    FamilyRiderPrice = (decimal)row[4],
                    VehiclePrice = (decimal)row[5],
                    CampaignID = (int)row[6]
                };

                output.Add(product);
            }

            return output;
        }
    
        /// <summary>
        /// Gets a single product's data from the RoadCoverProductCatalog database table based on the 
        /// passed productID.
        /// </summary>
        /// <param name="productID">An <see cref="int"/> value containing the product ID to retrieve.</param>
        /// <returns>A <see cref="RoadCoverProductCatalog"/> object that contains the necessary data, or an empty instance if said data was not found.</returns>
        public static RoadCoverProductCatalog GetRoadCoverProductCatalogByID(int productID)
        {
            RoadCoverProductCatalog output = new RoadCoverProductCatalog();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ProductCatalogID", productID)
            };

            DataTable productDataTable = Helper.DataAccess.ExecuteSpDataReader("spGetRoadCoverProductCatalogByID", parameters);

            if (productDataTable.Rows.Count > 0)
            {
                output.ID = (int)productDataTable.Rows[0]["ID"];
                output.Name = (string)productDataTable.Rows[0]["Name"];
                output.BasePrice = (decimal)productDataTable.Rows[0]["BasePrice"];
                output.IndividualRiderPrice = (decimal)productDataTable.Rows[0]["IndividualRiderPrice"];
                output.FamilyRiderPrice = (decimal)productDataTable.Rows[0]["FamilyRiderPrice"];
                output.VehiclePrice = (decimal)productDataTable.Rows[0]["VehiclePrice"];
                output.CampaignID = (int)productDataTable.Rows[0]["CampaignID"];

                return output;
            }
            else
            {
                return output;
            }
        }

        /// <summary>
        /// Gets a list of products from the database for the given name.
        /// A list is returned because some campaigns may share product names.        /// 
        /// </summary>
        /// <param name="productName">A <see cref="string"/> value containing the name of the product to fetch from the RoadCoverProductCatalog table.</param>
        /// <returns>A List of <see cref="RoadCoverProductCatalog"/> objects.</returns>
        public static List<RoadCoverProductCatalog> GetRoadCoverProductCatalogByName(string productName)
        {
            List<RoadCoverProductCatalog> output = new List<RoadCoverProductCatalog>();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ProductCatalogName", productName)
            };

            DataTable productDataTable = Helper.DataAccess.ExecuteSpDataReader("spGetRoadCoverProductCatalogByName", parameters);

            foreach (DataRow row in productDataTable.Rows)
            {
                RoadCoverProductCatalog product = new RoadCoverProductCatalog()
                {
                    ID = (int)row[0],
                    Name = row[1].ToString(),
                    BasePrice = (decimal)row[2],
                    IndividualRiderPrice = (decimal)row[3],
                    FamilyRiderPrice = (decimal)row[4],
                    VehiclePrice = (decimal)row[5],
                    CampaignID = (int)row[6]
                };

                output.Add(product);
            }

            return output;
        }        
    }
}
