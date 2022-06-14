using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtAlumnos = new DataTable("Alumnos");
            DataColumn colNombre = new DataColumn("Nombre", typeof(string));
            DataColumn colApellido = new DataColumn("Apellido", typeof(string));
            dtAlumnos.Columns.Add(colApellido);
            dtAlumnos.Columns.Add(colNombre);
            Console.WriteLine("Listado de Alumnos");
            DataRow rwAlumno = dtAlumnos.NewRow();
            rwAlumno["Apellido"] = "Perez";
            rwAlumno["Nombre"] = "Juan";

            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2["Apellido"] = "Perez";
            rwAlumno2["Nombre"] = "Marcelo";
            dtAlumnos.Rows.Add(rwAlumno2);

            foreach (DataRow row in dtAlumnos.Rows)
            {
                Console.WriteLine(row["Apellido"].ToString() + ", " + row["Nombre"].ToString());
            }
            Console.ReadLine();
        }
        
    }
}
