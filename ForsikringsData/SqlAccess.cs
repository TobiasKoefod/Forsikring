using System.Data;
using System.Data.SqlClient;

namespace NP_ForsikringsData

{
    class SqlAccess
    {
        SqlConnection connection = null;

        string cs = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=Forsikring";

        public SqlAccess()
        {
            TryConnect();
            ExecuteSql("Select * from Kunde");
        }
        public bool TryConnect()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = cs;
                connection.Open();
                connection.Close();
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;                   
        }
        public DataTable ExecuteSql(string sql)
        {
            // Open new connection.
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            // Create sql command.
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            // Exceute sql command
            DataTable table = ExecuteCmd(cmd);
            // Close the connetion.
            connection.Close();
            return table;
        }
        private DataTable ExecuteCmd(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            return table;
        }
    }
}
