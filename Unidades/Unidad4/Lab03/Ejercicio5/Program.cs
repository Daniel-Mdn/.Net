using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();

            myconn.ConnectionString = "server=localhost;user id=root;password=root;database=net";

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);
            myconn.Open();

            myadap.Fill(dtEmpresas);

            myconn.Close();

            Console.WriteLine("Listado de empresas: ");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idEmpresa = rowEmpresa["CustomerID"].ToString();
                string nombreEmpresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idEmpresa + " - " + nombreEmpresa);
            }
            Console.ReadLine();

        }
    }
}
