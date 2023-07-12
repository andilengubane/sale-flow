using System;
using Helper;
using System.Linq;
using System.Text;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Verification
    {
        public int VerificationID { get; set; }
        public int SaleID { get; set; }
        public int UserID { get; set; }
        public DateTime TimeOpened { get; set; }
        public DateTime TimeFinished { get; set; }
        public int WorkflowStepID { get; set; }
        public string Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsActive { get; set; }

        private static Verification MakeObject(DataRow inputRow)
        {
            Verification verification = new Verification();

            verification.VerificationID = (int)inputRow["VerificationID"];
            verification.SaleID = (int)inputRow["SaleID"];
            verification.UserID = (int)inputRow["UserID"];
            verification.TimeOpened = (DateTime)inputRow["TimeOpened"];
            verification.TimeFinished = (DateTime)inputRow["TimeFinished"];
            verification.WorkflowStepID = (int)inputRow["WorkflowStepID"];
            verification.Comments = (string)inputRow["Comments"];
            verification.DateCreated = (DateTime)inputRow["DateCreated"];
            verification.DateUpdated = (DateTime)inputRow["DateUpdated"];
            verification.IsActive = (bool)inputRow["IsActive"];

            return verification;
        }
        public static List<Verification> GetVerificationDetails(int saleId)
        {
            List<Verification> roadCoverProducts = new List<Verification>();

            string sql = "select * from Verification Where WorkFlowStepID = 4 And SaleId = "+ saleId + " order by VerificationID asc;";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                roadCoverProducts.Add(MakeObject(results.Rows[i]));
            }
            return roadCoverProducts;
        }
    }
}
