using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Lab02
{
    class ManejadorArchivoTxt: ManejadorArchivo
    {
        private string _connectionString;

        public string connectionString
        {
            get {
                return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\gitRepositorio\.Net\Unidades\Unidad4\Lab02\bin\Debug;" +
                "Extended Properties='text;HDR=Yes;FMT=Delimited'";
            }
        }
        
        public override DataTable getTabla()
        {
            using (OleDbConnection Conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmdSelect = new OleDbCommand("select * from agenda.txt", Conn);
                Conn.Open();
                OleDbDataReader reader = cmdSelect.ExecuteReader();
                DataTable contactos = new DataTable();
                if (reader != null)
                {
                    contactos.Load(reader);
                }
                Conn.Close();
                return contactos;
            }
        }
        public override void aplicaCambios()
        {
            using (OleDbConnection Conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into agenda.txt values (@id, @nombre, @Apellido, @email, @telefono)", Conn);
                cmdInsert.Parameters.Add("@id", OleDbType.Integer);
                cmdInsert.Parameters.Add("@nombre", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@apellido", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@email", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@telefono", OleDbType.VarChar);

                OleDbCommand cmdUpdate = new OleDbCommand("update agenda.txt set nombre=@nombre, apellido=@Apellido, e-mail=@email, telefono=@telefono where id=@id", Conn);
                cmdInsert.Parameters.Add("@id", OleDbType.Integer);
                cmdInsert.Parameters.Add("@nombre", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@apellido", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@email", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@telefono", OleDbType.VarChar);

                OleDbCommand cmdDelete = new OleDbCommand("delete from agenda.txt where id=@id", Conn);
                cmdInsert.Parameters.Add("@id", OleDbType.Integer);

                DataTable filasNuevas = this.misContactos.GetChanges(DataRowState.Added);
                DataTable filasModificadas = this.misContactos.GetChanges(DataRowState.Modified);
                DataTable filasEliminadas = this.misContactos.GetChanges(DataRowState.Deleted);

                Conn.Open();

                if (filasNuevas!= null)
                {
                    foreach (DataRow fila in filasNuevas.Rows)
                    {
                        cmdInsert.Parameters["@id"].Value = fila["id"];
                        cmdInsert.Parameters["@nombre"].Value = fila["nombre"];
                        cmdInsert.Parameters["@email"].Value = fila["e-mail"];
                        cmdInsert.Parameters["@apellido"].Value = fila["apellido"];
                        cmdInsert.Parameters["@telefono"].Value = fila["telefono"];
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                if (filasModificadas != null)
                {
                    foreach (DataRow fila in filasModificadas.Rows)
                    {
                        cmdInsert.Parameters["@id"].Value = fila["id"];
                        cmdInsert.Parameters["@nombre"].Value = fila["nombre"];
                        cmdInsert.Parameters["@email"].Value = fila["e-mail"];
                        cmdInsert.Parameters["@apellido"].Value = fila["apellido"];
                        cmdInsert.Parameters["@telefono"].Value = fila["telefono"];
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                if (filasEliminadas!= null)
                {
                    foreach (DataRow fila in filasEliminadas.Rows)
                    {
                        cmdInsert.Parameters["@id"].Value = fila["id", DataRowVersion.Original];
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
