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
    public class SubMemberDetails
    {
        public int SubMemberDetailsID { get; set; }
        public int SubMemberTypeID { get; set; }
        public int SalesID { get; set; }
        public string Title { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string IDNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int RelationshipTypeID { get; set; }
        private bool _found = false;
        public bool Found { get { return _found; } }

        public string RelationShipTypeName
        {
            get
            {
                return RelationshipType.GetRelationshipType(this.RelationshipTypeID).Title;
            }
        }

        private static SubMemberDetails MakeObject(DataRow inputRow)
        {
            SubMemberDetails retValue = new SubMemberDetails();

            retValue.SubMemberDetailsID = (int)inputRow["ID"];
            retValue.SubMemberTypeID = (int)inputRow["SubMemberTypeID"];
            retValue.SalesID = (int)inputRow["SalesID"];
            retValue.Title = (string)inputRow["Title"];
            retValue.FirstName = Incognito.Decrypt((string)inputRow["FirstName"]);
            retValue.SecondName = Incognito.Decrypt((string)inputRow["SecondName"]);
            retValue.Surname = Incognito.Decrypt((string)inputRow["Surname"]);
            retValue.Gender = (string)inputRow["Gender"];
            retValue.RelationshipTypeID = (int)inputRow["RelationshipTypeID"];
            retValue.IDNumber = Incognito.Decrypt((string)inputRow["IDNumber"]);
            retValue.DateOfBirth = (DateTime)inputRow["DateOfBirth"];

            retValue._found = true;

            return retValue;
        }

        public static List<SubMemberDetails> GetSubMembers(int saleID)
        {
            List<SubMemberDetails> retVal = new List<SubMemberDetails>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID)
            };

            string sql = "select * from SubMemberDetails where SalesID = @saleID";

            DataTable data = Helper.DataAccess.ExecuteDataReader(sql, parm);
            for(int i=0; i< data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            data.Dispose();

            return retVal;
        }

        public static List<SubMemberDetails> GetSubMembers(int saleID, int subMemberTypeID)
        {
            List<SubMemberDetails> retVal = new List<SubMemberDetails>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID),
                new SqlParameter("@submemberTypeID", subMemberTypeID)
            };

            string sql = "select * from SubMemberDetails where SalesID = @saleID and SubMemberTypeID = @submemberTypeID";

            DataTable data = Helper.DataAccess.ExecuteDataReader(sql, parm);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            data.Dispose();

            return retVal;
        }

        public static List<SubMemberDetails> GetSubMembersBeneficiaryDetails(int saleID)
        {
            List<SubMemberDetails> retVal = new List<SubMemberDetails>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID),
            };

            string sql = "select * from SubMemberDetails where SalesID = @saleID and SubMemberTypeID = 2";

            DataTable data = Helper.DataAccess.ExecuteDataReader(sql, parm);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            data.Dispose();

            return retVal;
        }

        public static List<SubMemberDetails> GetSubMembersSpouseDetails(int saleID)
        {
            List<SubMemberDetails> retVal = new List<SubMemberDetails>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID),
            };

            string sql = "select * from SubMemberDetails where SalesID = @saleID and SubMemberTypeID = 3";

            DataTable data = Helper.DataAccess.ExecuteDataReader(sql, parm);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            data.Dispose();

            return retVal;
        }

        public static List<SubMemberDetails> GetSubMembersChildDetails(int saleID)
        {
            List<SubMemberDetails> retVal = new List<SubMemberDetails>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID),
            };

            string sql = "select * from SubMemberDetails where SalesID = @saleID and SubMemberTypeID = 5";

            DataTable data = Helper.DataAccess.ExecuteDataReader(sql, parm);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            data.Dispose();

            return retVal;
        }

        public static List<SubMemberDetails> GetSubMembersRiderDetails(int saleID)
        {
            List<SubMemberDetails> retVal = new List<SubMemberDetails>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID),
            };

            string sql = "select * from SubMemberDetails where SalesID = @saleID and SubMemberTypeID = 5";

            DataTable data = Helper.DataAccess.ExecuteDataReader(sql, parm);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            data.Dispose();

            return retVal;
        }

        public static List<SubMemberDetails> GetSubMembersParentDetails(int saleID)
        {
            List<SubMemberDetails> retVal = new List<SubMemberDetails>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID),
            };

            string sql = "select * from SubMemberDetails where SalesID = @saleID and SubMemberTypeID = 6";

            DataTable data = Helper.DataAccess.ExecuteDataReader(sql, parm);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            data.Dispose();

            return retVal;
        }

        public static List<SubMemberDetails> GetSubMembersFamilyRiderDetails(int saleID)
        {
            List<SubMemberDetails> retVal = new List<SubMemberDetails>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID),
            };

            string sql = "select * from SubMemberDetails where SalesID = @saleID and SubMemberTypeID = 5";

            DataTable data = Helper.DataAccess.ExecuteDataReader(sql, parm);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            data.Dispose();

            return retVal;
        }

        public static int SaveSubMemberDetails(int saleID, string title, string firstName,string secondName, string surname,string gender, int subMemberTypeID,string IDNumber, DateTime dateOfBirth, int relationshipTypeID)
        {
            return SaveSubMemberDetails(saleID, title, firstName, secondName, surname, gender, subMemberTypeID, IDNumber, dateOfBirth, relationshipTypeID, 0);
        }

        public static bool DeleteSubMemberDetails(int saleID, int subMemberTypeID)
        {
            bool retVal = false;

            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
                {
                new SqlParameter("@salesId", saleID),
                new SqlParameter("@submemberTypeID", subMemberTypeID)
                };

                string sql = "delete from SubMemberDetails where SalesID = @salesId and SubMemberTypeID = @submemberTypeID";
                DataAccess.ExecuteNoReader(sql, parm);

                retVal = true;
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retVal;
        }

        public static int SaveSubMemberDetails(int saleID, string title, string firstName,string secondName, string surname,string gender, int subMemberTypeID,string IDNumber, DateTime dateOfBirth, int relationshipTypeID, int ID)
        {
            int retval = 0;

            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
                {
                new SqlParameter("@salesId", saleID),
                new SqlParameter("@title", title),
                new SqlParameter("@firstName", Incognito.Encrypt(firstName)),
                new SqlParameter("@secondName", Incognito.Encrypt(secondName)),
                new SqlParameter("@surname", Incognito.Encrypt(surname)),
                new SqlParameter("@gender", gender),
                new SqlParameter("@submemberTypeID", subMemberTypeID),
                new SqlParameter("@IDNumber", Incognito.Encrypt(IDNumber)),
                new SqlParameter("@dateOfBirth", dateOfBirth),
                new SqlParameter("@relationshipTypeID", relationshipTypeID),
                new SqlParameter("@ID", ID),
                };

                string sql = "spSaveSubMemberDetails";

                retval = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }

        /// <summary>
        /// NEVER EXECUTE THIS, NO MATTER WHAT
        /// YOU WILL CORRUPT THE DATABASE, YOU WILL SUBMIT YOUR LAPTOP TO MANAGEMENT, LEAVE AND NEVER COME BACK.
        /// YOU WILL BE BETTER OFF IF YOU COMMITED SUICIDE. I AM LEAVING THIS HERE SHOULD THERE BE A NEED TO REVERSE THE ENCRYPTION, PEOPLE KNOW WHAT TO DO.
        /// I AM ALSO MAKING IT PRIVATE TO MINIMIZE THE CHANCE OF IT BEING CALLED ACCIDENTALLY FROM *NOT HERE*
        /// I don't know who you are. I don't know what you want. If you are looking for ransom, I can tell you I don't have money. 
        /// But what I do have are a very particular set of skills, skills I have acquired over a very long career. 
        /// Skills that make me a nightmare for people like you. If you do not run this method now, that'll be the end of it. I will not look for you, I will not pursue you. 
        /// But if you don't, I will look for you, I will find you, and I will kill you
        /// </summary>
        /// <returns></returns>
        private static int ApplyEncryptionToAll()
        {
            int retVal = 0;
            string sql = "select * from SubMemberDetails;";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                int saleID = Convert.ToInt32(results.Rows[i]["SalesID"]);
                string title = results.Rows[i]["Title"].ToString();
                string firstName = results.Rows[i]["FirstName"].ToString();
                string secondName = results.Rows[i]["SecondName"].ToString();
                string surname = results.Rows[i]["Surname"].ToString();
                string gender = results.Rows[i]["Gender"].ToString();
                string IDNumber = results.Rows[i]["IDNumber"].ToString();
                int subMemberTypeID = Convert.ToInt32(results.Rows[i]["SubMemberTypeID"]);
                DateTime dateOfBirth = Convert.ToDateTime(results.Rows[i]["DateOfBirth"]);
                int relationshipTypeID = Convert.ToInt32(results.Rows[i]["RelationshipTypeID"]);
                int ID = Convert.ToInt32(results.Rows[i]["ID"]);

                if (SaveSubMemberDetails(saleID, title, firstName, secondName, surname, gender, subMemberTypeID, IDNumber, dateOfBirth, relationshipTypeID, ID) > 0)
                {
                    retVal++;
                }
            }
            return retVal;
        }
    }
}
