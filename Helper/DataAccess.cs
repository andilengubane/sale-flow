using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Helper
{
   
    public class DataAccess : System.Web.UI.Page
    {
        //public System.Security.Principal.IPrincipal User { get; set; }
        //public System.Dir
        private static string primaryConnection = ConfigurationManager.ConnectionStrings["primarySQL"].ConnectionString;

        #region Standard Data-Processig methods

        /// <summary>
        /// Executes a DML command (INSERT, UPDATE, DELETE, etc) against the database based on a passed query.
        /// </summary>
        /// <param name="query">A <see cref="string"/>string containing the DML command to execute. [Optional]</param>
        public static void ExecuteNoReader(string query, List<SqlParameter> parameters)
        {
            ExecuteNoReader(query, parameters, primaryConnection);
        }
        private static void ExecuteNoReader(string query, List<SqlParameter> parameters, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    LoadSqlCommandObject(cmd, parameters);

                    conn.Open();
                    cmd.CommandTimeout = 1200;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Executes a query against the database based on the string argument passed.
        /// </summary>
        /// <param name="query">A <see cref="string"/>string containing the query string to execute. [Optional]</param>
        /// <returns>A <see cref="DataTable"/>DataTable containing the data from the query, or an empty DataTable.</returns>
        public static DataTable ExecuteDataReader(string query, List<SqlParameter> parameters)
        {
            return ExecuteDataReader(query, parameters, primaryConnection);
        }
        private static DataTable ExecuteDataReader(string query, List<SqlParameter> parameters, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // please test this operates correctly.                        
                        LoadSqlCommandObject(cmd, parameters);
                        cmd.CommandTimeout = 1200;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Executes a query against the database based on a passed query and list of parameters.
        /// </summary>
        /// <param name="query">A <see cref="string"/> containing the paramatised query to execute.</param>
        /// <param name="parameters">A <see cref="List{SqlParameter}"/> of parameters pass to the database.</param>
        /// <returns>An <see cref="object"/> containing the data returned from the database</returns>
        public static Object ExecuteScalar(string query, List<SqlParameter> parameters)
        {
            return ExecuteScalar(query, parameters, primaryConnection);
        }
        private static Object ExecuteScalar(string query, List<SqlParameter> parameters, string connectionString)
        {
            Object retVal = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                LoadSqlCommandObject(ref cmd, parameters);
                cmd.CommandTimeout = 1200;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                retVal = cmd.ExecuteScalar();
                cmd.Dispose();
            }
            return retVal;
        }

        #endregion

        #region Simple (non-parametised) methods

        /// <summary>
        /// Executes a passed SQL query on the database server.
        /// </summary>
        /// <param name="query">A <see cref="string"/> containing the query to execute.</param>
        public static void ExecuteSimpleNoReader(string query)
        {
            ExecuteSimpleNoReader(query, primaryConnection);
        }
        private static void ExecuteSimpleNoReader(string query, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.CommandTimeout = 1200;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Executes a passed query on the database server.
        /// This method returns a scalar value.
        /// </summary>
        /// <param name="query">A <see cref="string"/> value containing the query to execute.</param>
        /// <returns>An <see cref="object"/> containing the data returned by the database.</returns>
        public static Object ExecuteSimpleScalar(string query)
        {
            return ExecuteSimpleScalar(query, primaryConnection);
        }
        private static Object ExecuteSimpleScalar(string query, string connectionString)
        {
            Object retVal = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandTimeout = 1200;
                cmd.Connection = con;
                retVal = cmd.ExecuteScalar();
                cmd.Dispose();
            }
            return retVal;
        }

        /// <summary>
        /// Executes a passed query on the database.
        /// </summary>
        /// <param name="query">A <see cref="string"/> containing the query to execute.</param>
        /// <returns>A <see cref="DataTable"/> object containing the data pulled from the database.</returns>
        public static DataTable ExecuteSimpleDataReader(string query)
        {
            return ExecuteSimpleDataReader(query, primaryConnection);
        }
        private static DataTable ExecuteSimpleDataReader(string query, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            cmd.CommandTimeout = 1200;
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        #endregion

        #region Stored Procedure Methods (Includes "Simple" methods)

        /// <summary>
        /// Executes a stored procedure based on the name and parameters passed.
        /// </summary>
        /// <param name="spquery">A <see cref="string"/>string containing the name of the stored procedure to execute.</param>
        /// <param name="parametersToLoad">A <see cref="System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}"/>list of SqlParameters to add to the passed SqlCommand. [Optional]</param>
        public static void ExecuteSpNoReader(string storedProc, List<SqlParameter> spParams)
        {
            ExecuteSpNoReader(storedProc, spParams, primaryConnection);
        }
        private static void ExecuteSpNoReader(string storedProc, List<SqlParameter> spParams, string connectionString)
        {
            List<SqlParameter> checkedParameters = NullToDBNull(spParams);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    LoadSqlCommandObject(cmd, checkedParameters);
                    cmd.CommandTimeout = 1200;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Executes a stored procedure based on the passed procedure name.
        /// This method executes a stored procedure with no parameters.
        /// </summary>
        /// <param name="storedProc">A <see cref="string"/> containing the name of the stored procedure to execute.</param>
        public static void ExecuteSimpleSPNoReader(string storedProc)
        {
            ExecuteSimpleSPNoReader(storedProc, primaryConnection);
        }
        private static void ExecuteSimpleSPNoReader(string storedProc, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.CommandTimeout = 1200;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Executes a stored procedure on the database using the passed stored procedure name, and list of paramaters.
        /// This method is for executing stored procedures that return scalar values.
        /// </summary>
        /// <param name="storedProc">A <see cref="string"> containing the name of the stored procedure to execute</param>
        /// <param name="parameters">A List of <see cref="SqlParameter"/> objects to pass to the stored procedure on the database server.</param>
        /// <returns>An <see cref="object"/> containing the value returned from the database.</returns>
        public static Object ExecuteSpScalar(string storedProc, List<SqlParameter> parameters)
        {
            return ExecuteSpScalar(storedProc, parameters, primaryConnection);
        }
        public static Object ExecuteSpScalar(string storedProc, List<SqlParameter> parameters, string connectionString)
        {
            List<SqlParameter> checkedParameters = NullToDBNull(parameters);

            Object retVal = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(storedProc, con);
                LoadSqlCommandObject(ref cmd, checkedParameters);
                cmd.CommandTimeout = 1200;
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                retVal = cmd.ExecuteScalar();
                cmd.Dispose();
            }
            return retVal;
        }

        /// <summary>
        /// Executes a stored procedure based on the stored procedure name passed.
        /// </summary>
        /// <param name="storedProc">A <see cref="string"/> containing the stored procedure name to execute.</param>
        /// <returns>A <see cref="DataTable"/> containing the data returned by the database.</returns>
        public static DataTable ExecuteSimpleSpDataReader(string storedProc)
        {
            return ExecuteSimpleSpDataReader(storedProc, primaryConnection);
        }
        private static DataTable ExecuteSimpleSpDataReader(string storedProc, string connectionString)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 1200;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Executes a stored procedure based on the stored procedure name and parameters passed.
        /// </summary>
        /// <param name="storedProc">A <see cref="string"/> containing the name of the stored procedure to execute.</param>
        /// <param name="parameters">A <see cref="List{SqlParameter}"/> containing the parameters to pass to the stored procedure.</param>
        /// <returns>A <see cref="DataTable"/> containing the data returned by the database.</returns>
        public static DataTable ExecuteSpDataReader(string storedProc, List<SqlParameter> parameters)
        {
            return ExecuteSpDataReader(storedProc, parameters, primaryConnection);
        }
        private static DataTable ExecuteSpDataReader(string storedProc, List<SqlParameter> parameters, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // please test this operates correctly.                        
                        LoadSqlCommandObject(cmd, parameters);
                        cmd.CommandTimeout = 1200;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Iterates through a list of database parameters, and sets the C# "null" value to 
        /// the more SQL Server-friendly DBNull.Value.
        /// </summary>
        /// <param name="parameters">A List of <see cref="SqlParameter"/> objects to process.</param>
        /// <returns>A List of <see cref="SqlParameter"/> objects that have had their "null" values changed to DBNull.Value.</returns>
        private static List<SqlParameter> NullToDBNull(List<SqlParameter> parameters)
        {
            List<SqlParameter> output = new List<SqlParameter>();

            foreach (SqlParameter parameter in parameters)
            {
                if (parameter.Value == null)
                    parameter.Value = DBNull.Value;

                output.Add(parameter);
            }

            return output;
        }

        /// <summary>
        /// Takes a list of SqlParamater objects and binds them to a SqlCommand.
        /// </summary>
        /// <param name="cmdToLoad">The <see cref="System.Data.SqlCommand"/>SqlCommand object that will have its SqlParameter collection initialized</param>
        /// <param name="parametersToLoad">A <see cref="System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}"/>list of SqlParameters to add to the passed SqlCommand. [Optional]</param>
        private static void LoadSqlCommandObject(SqlCommand cmdToLoad, List<SqlParameter> parametersToLoad = null)
        {
            try
            {
                // Check if the parameter list is null, and if not, add parameters!
                // Simple, ne? (Famous last words...)
                if (parametersToLoad != null)
                {
                    cmdToLoad.Parameters.AddRange(parametersToLoad.ToArray());
                }
                else
                {
                    return;
                }
            }
            catch
            {
                throw;
            }
        }
        private static void LoadSqlCommandObject(ref SqlCommand cmdToLoad, List<SqlParameter> parametersToLoad = null)
        {
            try
            {
                // Check if the parameter list is null, and if not, add parameters!
                // Simple, ne? (Famous last words...)
                if (parametersToLoad != null)
                {
                    cmdToLoad.Parameters.AddRange(parametersToLoad.ToArray());
                }
                else
                {
                    return;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Executes a list of commands againt the database.
        /// </summary>
        /// <param name="commandsToExecute">A <see cref="List{SqlCommand}"/> containing the <see cref="SqlCommand"/> objects to process.</param>
        public static void ExecuteNoReaderMultipleCommandTransaction(List<SqlCommand> commandsToExecute)
        {
            ExecuteNoReaderMultipleCommandTransaction(commandsToExecute, primaryConnection);
        }
        private static void ExecuteNoReaderMultipleCommandTransaction(List<SqlCommand> commandsToExecute, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction("AllOrNothing");

                for (int i = 0; i < commandsToExecute.Count; i++)
                {
                    commandsToExecute[i].Connection = con;
                    commandsToExecute[i].Transaction = trans;
                    commandsToExecute[i].ExecuteNonQuery();
                }

                trans.Commit();
            }
        }

        #endregion

        #region Security Methods

        public static void EncryptString(string stringToEncrypt)
        {
            throw new NotImplementedException();
        }

        public static string DeEncryptString(string encryptedString)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SMTPConfig methods

        /// <summary>
        /// Retrieves an SMTPConfig record from the database based on the passed name.
        /// </summary>
        /// <param name="name">A <see cref="string"/> value containing the name of the SMTPConfig to retrieve.</param>
        /// <returns>A <see cref="SMTPConfig"/> object containing the SMTPConfig record from the database.</returns>
        public static SMTPConfig getEmailConfig(string name)
        {
            using (IDbConnection conn = new SqlConnection(primaryConnection))
            {
                var result = conn.QuerySingle<SMTPConfig>("spGetSMTPConfig", new { ConfigName = name }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        #endregion

        #region AD Methods
        public string GetUsername()
        {
            string userName = string.Empty;
            //if (ConfigurationManager.AppSettings["Domain"].ToString() == "ALTRON")
            //{
            //    userName = WindowsIdentity.GetCurrent().Name;
            //}
            //else
            //{
            //    userName = User.Identity.Name;
            //}
            userName = WindowsIdentity.GetCurrent().Name;

            int lastindex = userName.LastIndexOf('\\');
            userName = userName.Substring(lastindex + 1);
            return userName;
        }
        public bool GrantSupervisor()
        {
            string username = GetUsername();
            bool grantlanguageaccess = false;
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["Domain"].ToString());
            GroupPrincipal supervisorgroup = GroupPrincipal.FindByIdentity(ctx, ConfigurationManager.AppSettings["SuperViserGroup"].ToString());
            foreach (UserPrincipal user in supervisorgroup.GetMembers(true))
            {
                if (user.SamAccountName == username)
                {
                    grantlanguageaccess = true;
                    break;
                }
            }
            return grantlanguageaccess;
        }
        #endregion

    }
}

