using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;


namespace BusinessLogic
{
    public class PersonalDetails
    {
        private bool _found = false;

        public int PersonalDetailsID { get; set; }
        public int SaleID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Initials { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelWork { get; set; }
        public string TelCell { get; set; }
        public string TelHome { get; set; }
        public string TelFax { get; set; }
        public string Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public decimal GrossIncome { get; set; }
        
        public bool Found
        {
            get
            { return _found; }
        }

        public static PersonalDetails GetPersonalDetails(int saleId)
        {
            PersonalDetails retVal = new PersonalDetails();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@SaleID", saleId)
            };

            string sql = "spGetPersonalDetailsBySaleID";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
     
        public static int SavePersonalDetails(int saleID, string title, string initials ,string firstName,string secondName, string surname, string IdNumber, string passportNumber, DateTime dateOfBirth, 
            string telWork, string telCell, string telHome, string telFax, string gender, string address1, string address2, string address3, string address4, string city, string postalCode,
            string email, decimal grossIncome)
        {
            int retval = 0;

            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@SaleID", saleID),
                    new SqlParameter("@Title", title),
                    new SqlParameter("@Initials", initials),
                    new SqlParameter("@FirstName", Incognito.Encrypt(firstName)),
                    new SqlParameter("@SecondName", Incognito.Encrypt(secondName)),
                    new SqlParameter("@Surname", Incognito.Encrypt(surname)),
                    new SqlParameter("@IDNumber", Incognito.Encrypt(IdNumber)),
                    new SqlParameter("@PassportNumber", Incognito.Encrypt(passportNumber)),
                    new SqlParameter("@DateOfBirth", dateOfBirth),
                    new SqlParameter("@TelWork", telWork),
                    new SqlParameter("@TelCell", telCell),
                    new SqlParameter("@TelHome", telHome),
                    new SqlParameter("@TelFax", telFax),
                    new SqlParameter("@Gender", gender),
                    new SqlParameter("@Address1", Incognito.Encrypt(address1)),
                    new SqlParameter("@Address2", Incognito.Encrypt(address2)),
                    new SqlParameter("@Address3", Incognito.Encrypt(address3)),
                    new SqlParameter("@Address4", Incognito.Encrypt(address4)),
                    new SqlParameter("@City", city), 
                    new SqlParameter("@PostalCode", Incognito.Encrypt(postalCode)),
                    new SqlParameter("@Email", Incognito.Encrypt(email)),
                    new SqlParameter("@GrossIncome", grossIncome)
                };

                string sql = "spSavePersonalDetails";

                retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }

        private static PersonalDetails MakeObject(DataRow inputRow)
        {
            PersonalDetails retValue = new PersonalDetails();

            retValue.PersonalDetailsID = (int)inputRow["ID"];
            retValue.SaleID = (int)inputRow["SaleID"];
            retValue.Title =  (string)inputRow["Title"];
            retValue.Initials = (string)inputRow["Initials"];
            retValue.FirstName = Incognito.Decrypt((string)inputRow["FirstName"]);
            retValue.SecondName = Incognito.Decrypt((string)inputRow["SecondName"]);
            retValue.Surname = Incognito.Decrypt((string)inputRow["Surname"]);
            retValue.IDNumber = Incognito.Decrypt((string)inputRow["IDNumber"]);
            retValue.PassportNumber = Incognito.Decrypt((string)inputRow["PassportNumber"]);
            retValue.DateOfBirth = (DateTime)inputRow["DateOfBirth"];
            retValue.TelWork = (string)inputRow["TelWork"];
            retValue.TelCell = (string)inputRow["TelCell"];
            retValue.TelHome = (string)inputRow["TelHome"];
            retValue.TelFax = (string)inputRow["TelFax"];
            retValue.Gender = (string)inputRow["Gender"];
            retValue.Address1 = Incognito.Decrypt((string)inputRow["Address1"]);
            retValue.Address2 = Incognito.Decrypt((string)inputRow["Address2"]);
            retValue.Address3 = Incognito.Decrypt((string)inputRow["Address3"]);
            retValue.Address4 = Incognito.Decrypt((string)inputRow["Address4"]);
            retValue.City = (string)inputRow["City"];
            retValue.PostalCode = Incognito.Decrypt((string)inputRow["PostalCode"]);
            retValue.Email = Incognito.Decrypt((string)inputRow["Email"]);
            retValue.GrossIncome = (decimal)inputRow["GrossIncome"];

            retValue._found = true;

            return retValue;
        }

        public static int ApplyEncryptionToAll()
        {
            int retVal = 0;
            string sql = "select * from PersonalDetails where ID >= 6578;";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);

            for(int i=0; i<results.Rows.Count; i++)
            {
                int saleID = Convert.ToInt32(results.Rows[i]["SaleID"]);
                string title = results.Rows[i]["Title"].ToString();
                string initials = results.Rows[i]["Initials"].ToString();
                string firstName = results.Rows[i]["firstName"].ToString();
                string secondName = results.Rows[i]["SecondName"].ToString();
                string surname = results.Rows[i]["Surname"].ToString();
                string IdNumber = results.Rows[i]["IDNumber"].ToString();
                string passportNumber = results.Rows[i]["PassportNumber"].ToString();
                DateTime dateOfBirth = Convert.ToDateTime(results.Rows[i]["DateOfBirth"]);
                string telWork = results.Rows[i]["TelWork"].ToString();
                string telCell = results.Rows[i]["TelCell"].ToString();
                string telHome = results.Rows[i]["TelHome"].ToString();
                string telFax = results.Rows[i]["TelFax"].ToString();
                string gender = results.Rows[i]["Gender"].ToString();
                string address1 = results.Rows[i]["Address1"].ToString();
                string address2 = results.Rows[i]["Address2"].ToString();
                string address3 = results.Rows[i]["Address3"].ToString();
                string address4 = results.Rows[i]["Address4"].ToString();
                string city = results.Rows[i]["City"].ToString();
                string postalCode = results.Rows[i]["PostalCode"].ToString();
                string email = results.Rows[i]["Email"].ToString();
                decimal grossIncome = Convert.ToDecimal(results.Rows[i]["GrossIncome"]);

                if (SavePersonalDetails(saleID, title, initials, firstName, secondName, surname, IdNumber, passportNumber, dateOfBirth, telWork, telCell, telHome, telFax, gender
                    , address1, address2, address3, address4, city, postalCode, email, grossIncome)>0)
                {
                    retVal++;
                }
            }

            return retVal;
        }
    }
}
