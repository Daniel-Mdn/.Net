using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();

            myconn.ConnectionString = "Data source=BEYONDO7; initial Catalog=Northwind; User ID=sa, pwd=123";

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

            Console.WriteLine("Escribar el customerID que desea modificar: ");
            string custId = Console.ReadLine();

            DataRow[] rwEmpresas = dtEmpresas.Select("CustomerID = '" + custId + "'");
            if (rwEmpresas.Length != 1)
            {
                Console.WriteLine("CustomerID no encontrado");
                Console.ReadLine();
                return;
            }
            DataRow rowMiEmpresa = rwEmpresas[0];
            string nombreActual = rowMiEmpresa["CompanyName"].ToString();
            Console.WriteLine("Nombre actual de la empresa " + nombreActual);
            Console.WriteLine("Ingrese el nuevo nombre de la empresa: ");
            string nuevoNombre = Console.ReadLine();
            rowMiEmpresa.BeginEdit();
            rowMiEmpresa["CompanyName"] = nuevoNombre;
            rowMiEmpresa.EndEdit();

            SqlCommand updCommmand = new SqlCommand();
            updCommmand.Connection = myconn;
            updCommmand.CommandText = "UPDATE Customers SET CompanyName= @CompanyName WHERE CustomerID = @CustomerID";
            updCommmand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50, "CompanyName");
            updCommmand.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");

            myadap.UpdateCommand = updCommmand;
            myadap.Update(dtEmpresas);


        }
    }
}
