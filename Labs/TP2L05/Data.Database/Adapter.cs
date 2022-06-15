using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {

        const string consKeyDefaultCnnString = "ConnStringExpress";
        private SqlConnection _sqlConn;
        public SqlConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }

        protected void OpenConnection()
        {

            var ConnectionString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            this.sqlConn = new SqlConnection(ConnectionString);
            this.sqlConn.Open();
        }

        protected void CloseConnection()
        {
            if (this.sqlConn.State == System.Data.ConnectionState.Open)
            {
                this.sqlConn.Close();
            }

            this.sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
