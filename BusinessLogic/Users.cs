using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;
using System.Configuration;
using System.Security.Principal;

namespace BusinessLogic
{
    public class Users
    {
        private bool _found = false;
                
        public int ID { get; set; }
        public string ADUserName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVerificationAgent { get; set; }
        public int AgentCode { get; set; }
        public string IDNumber { get; set; }
        public string EmployeeNo { get; set; }
        public string Password { get; set; }
        public string TeamLeader { get; set; }
        public bool Found { get { return _found; } }

        public List<Languages> UserLanguages
        {
            get
            {
                return Languages.GetLanguagesByUserID(this.ID);
            }
        }

        /// <summary>
        /// Mini-factory method for creating <see cref="Users"/> objects.
        /// </summary>
        /// <param name="inputRow">A <see cref="DataRow"/> object that contains the necessary data from the Users Database table.</param>
        /// <returns>A <see cref="Users"/> object containing the data from the database as per the passed <see cref="DataRow"/> object.</returns>
        private static Users MakeObject(DataRow inputRow)
        {
            Users retVal = new Users();

            retVal.ID = (int)inputRow["ID"];
            retVal.ADUserName = inputRow["ADUserName"].ToString();
            retVal.IDNumber = inputRow["IDNumber"].ToString();
            retVal.EmployeeNo = inputRow["EmployeeNo"].ToString();
            retVal.IsAdmin = (bool)inputRow["IsAdmin"];
            retVal.IsVerificationAgent = (bool)inputRow["IsVerificationAgent"];
            retVal.AgentCode = (int)inputRow["AgentCode"];
            retVal.Password = Incognito.Decrypt((string)inputRow["Password"]);
            retVal.TeamLeader = (string)inputRow["TeamLeader"];
            retVal._found = true;

            return retVal;
        }
        
        /// <summary>
        /// Retrieves a <see cref="Users"/> object based on the Active Directory Username passed in.
        /// </summary>
        /// <param name="ADUserName">A <see cref="string"/> value containing the Active Directory username to use.</param>
        /// <returns>A <see cref="Users"/> object containing the data pertaining to the passed Active Directory username.</returns>
        public static Users GetUserByUsername(string ADUserName)
        {
            Users retVal = new Users();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ADUserName", ADUserName)
            };

            string sql = "spGetUsersByUsername";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }


        /// <summary>
        /// Retrieves a user based on a passed VICIDial agent code.
        /// </summary>
        /// <param name="agentCode">An <see cref="int"/> value containing the VICIDial agent code to use.</param>
        /// <returns>A <see cref="Users"/> object containing the data related to the passed VICIDial agent code.</returns>
        public static Users GetValidatedUser(int agentCode)
        {
            Users retVal = null;
            List<Users> results = GetUserByAgentCode(agentCode);
            if (results.Count > 0)
            { retVal = results[0]; }
            else
            {
                retVal = new Users();
            }
            return retVal;
        }

        /// <summary>
        /// The method that does the actual work of getting user data based on the passed VICIDial agent code.
        /// </summary>
        /// <param name="agentCode">An <see cref="int"/> value containing the VICIDial agent code.</param>
        /// <returns>A <see cref="Users"/> object containing the data associated with the passed agent code.</returns>
        public static List<Users> GetUserByAgentCode(int agentCode)
        {
            List<Users> retVal = new List<Users>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@AgentCode", agentCode)
            };

            string sql = "spGetUserByAgentCode";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);

            for(int i=0; i< results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            return retVal;
        }

        /// <summary>
        /// The method that does the actual work of getting user data based on the Active Directory Username.
        /// </summary>
        /// <param name="ADUsername">An <see cref="int"/> value containing the VICIDial agent code.</param>
        /// <returns>A <see cref="Users"/> object containing the data associated with the passed agent code.</returns>
        public static List<Users> GetUserByADUsername(string aDUserName)
        {
            List<Users> retVal = new List<Users>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ADUserName", aDUserName)
            };

            string sql = "spGetUserByDomainUsername";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            return retVal;
        }
        public static Users GetValidatedADUser(string ADUserName)
        {
            Users retVal = null;
            List<Users> results = GetUserByADUsername(ADUserName);
            if (results.Count > 0)
            { retVal = results[0]; }
            else
            {
                retVal = new Users();
            }
            return retVal;
        }

        /// <summary>
        /// Retrieves a user based on a passed unique ID from the Users database table.
        /// </summary>
        /// <param name="userID">An <see cref="int"/> value containing the unique Users database table ID.</param>
        /// <returns>A <see cref="Users"/> object containing the data pertaining to the passed unique Users table ID.</returns>
        public static Users GetUserByID(int userID)
        {
            Users retVal = new Users();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@UserID", userID)
            };

            string sql = "spGetUserByID";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }

        /// <summary>
        /// Retrieves all users stored in the database.
        /// </summary>
        /// <returns>A list of <see cref="Users"/> objects for each row from the Users database table.</returns>
        public static List<Users> GetAllUsers()
        {
            List<Users> retVal = new List<Users>();
            string sql = "";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for(int i=0; i< results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();

            return retVal;
        }

        /// <summary>
        /// Wrapper method for saving user details to the database.
        /// </summary>
        /// <param name="ADUserName">A <see cref="string"/> value containing the Active Directory username.</param>
        /// <param name="isAdmin">A <see cref="bool"/> value signifying if the user in question should be an admin or not.</param>
        /// <param name="agentCode">An <see cref="int"/> value containing a VICIDial agent code.</param>
        /// <param name="iDNumber">A <see cref="string"/> value containing the ID number of the user.</param>
        /// <param name="employeeNo">A <see cref="string"/> value containing the employee number of the user.</param>
        /// <param name="password">A <see cref="string"/> value containing the password for the user.</param>
        /// <param name="teamleader">A <see cref="string"/> value containing the name of the user's team leader.</param>
        /// <param name="isVerificationAgent">A <see cref="bool"/> value signifying if the user is a Verification Agent or not.</param>
        /// <returns>An <see cref="int"/> value containing the ID of the new <see cref="Users"/> object, or 0 if something went wrong.</returns>
        public static int SaveUserDetails(string ADUserName, bool isAdmin, int agentCode, string iDNumber, string employeeNo, string password, string teamleader, bool isVerificationAgent)
        {
            return SaveUserDetails(0, ADUserName, isAdmin, agentCode, iDNumber, employeeNo, password, teamleader, isVerificationAgent);
        }

        /// <summary>
        /// The actual method that saves a user to the database.
        /// </summary>
        /// <param name="ID">An <see cref="int"/> value containing either 0 (for new users) or the ID of the user to save.</param>
        /// <param name="ADUserName">A <see cref="string"/> value containing the Active Directory username.</param>
        /// <param name="isAdmin">A <see cref="bool"/> value signifying if the user in question should be an admin or not.</param>
        /// <param name="agentCode">An <see cref="int"/> value containing a VICIDial agent code.</param>
        /// <param name="iDNumber">A <see cref="string"/> value containing the ID number of the user.</param>
        /// <param name="employeeNo">A <see cref="string"/> value containing the employee number of the user.</param>
        /// <param name="password">A <see cref="string"/> value containing the password for the user.</param>
        /// <param name="teamleader">A <see cref="string"/> value containing the name of the user's team leader.</param>
        /// <param name="isVerificationAgent">A <see cref="bool"/> value signifying if the user is a Verification Agent or not.</param>
        /// <returns>An <see cref="int"/> value containing the ID of the new <see cref="Users"/> object, or 0 if something went wrong.</returns>
        public static int SaveUserDetails(int ID, string ADUserName, bool isAdmin, int agentCode, string iDNumber, string employeeNo, string password, string teamleader, bool isVerificationAgent)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@ADUserName", ADUserName),
                new SqlParameter("@isAdmin", isAdmin),
                new SqlParameter("@agentCode", agentCode),
                new SqlParameter("@iDNumber", iDNumber),
                new SqlParameter("@employeeNo", employeeNo),
                new SqlParameter("@teamleader", teamleader),
                new SqlParameter("@isVerificationAgent", isVerificationAgent),
                new SqlParameter("@password", Incognito.Encrypt(password)),
                new SqlParameter("@ID", ID)
            };

            string sql = "spSaveUser";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
    }
}
