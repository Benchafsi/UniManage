using System.Data.SqlClient;

namespace UniversityDatabaseManagementWebApp.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;

        //no instances of this class should be available
        private DBHelper() { }

        public static SqlConnection? GetConnection()
        {
            try
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                string url = configurationManager.GetConnectionString("DefaultConnection");
                conn = new SqlConnection(url);
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static void CloseConnection()
        {
            if (conn is not null)
            {
                conn.Close();
            }
        }
    }
}
