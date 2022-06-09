using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Lab02
{
    public class ManejadorArchivo
    {
        protected DataTable misContactos;
        
        public ManejadorArchivo()
        {
            this.misContactos = this.getTabla();
        }
        public void listar()
        {
            foreach (DataRow fila in this.misContactos.Rows)
            {
                if(fila.RowState != DataRowState.Deleted)
                {
                    foreach (DataColumn columna in this.misContactos.Columns)
                    {
                        Console.WriteLine("{0}: {1}", columna.ColumnName, fila[columna]);
                    }
                    Console.WriteLine();
                }
            }
        }
        public void nuevaFila()
        {
            DataRow nuevaFila = this.misContactos.NewRow();
            foreach (DataColumn col in this.misContactos.Columns)
            {
                Console.WriteLine("Ingrese {0}: ", col);
                nuevaFila[col] = Console.ReadLine();
            }
            this.misContactos.Rows.Add(nuevaFila);
        }
        public void editarFila()
        {
            Console.WriteLine("Ingrese el numero de fila a modificar: ");
            int idFila = int.Parse(Console.ReadLine());

            DataRow filaSeleccionada = this.misContactos.Rows[idFila - 1];
            for (int nroCol=1;  nroCol< this.misContactos.Columns.Count; nroCol++)
            {
                Console.WriteLine("Ingrese nuevo {0}", this.misContactos.Columns[nroCol].ColumnName);
                filaSeleccionada[nroCol] = Console.ReadLine();
            }

        }
        public void eliminarFila()
        {
            Console.WriteLine("Ingrese el numero de fila a eliminar: ");
            int idFila = int.Parse(Console.ReadLine());
            this.misContactos.Rows[idFila - 1].Delete();
        }
        public virtual DataTable getTabla()
        {
            return new DataTable();
        }
        public virtual void aplicaCambios()
        {

        }
    }
}
