using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();

            myconn.ConnectionString="Data source=LOCALHOST; initial Catalog=Northwind; User ID=sa, pwd=123";

            SqlCommand mycommand = new SqlCommand();
            mycommand.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
            mycommand.Connection = myconn;

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn) ;

            myconn.Open();
            SqlDataReader myrd = mycommand.ExecuteReader();

            dtEmpresas.Load(myrd);
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
