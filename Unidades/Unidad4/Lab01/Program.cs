using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para generar el archivo agenda.xml con los datos de agenda.txt");
            Console.ReadKey();
            EscribirXML();
            Console.WriteLine("Documento generado correctamente. \n\n Presione una tecla para ver su contenido");
            Console.ReadKey();
            Console.WriteLine();
            LeerXML();
                        
            Console.ReadKey();
        }

        private static void LeerXML()
        {
            XmlTextReader lectorXML = new XmlTextReader("agendaXml.xml");
            string tagAnterior = "";
            while (lectorXML.Read())
            {
                if (lectorXML.NodeType == XmlNodeType.Element)
                {
                    tagAnterior = lectorXML.Name;
                }
                else if (lectorXML.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(tagAnterior + ": " + lectorXML.Value);
                }
            }
            lectorXML.Close();
        }

        private static void EscribirXML()
        {
            XmlTextWriter escritorXML = new XmlTextWriter("agendaxml.xml", null);
            escritorXML.Formatting = Formatting.Indented;
            escritorXML.WriteStartDocument(true);
            escritorXML.WriteStartElement("DocumentElement");
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string [] valores= linea.Split(';');
                    escritorXML.WriteStartElement("Contactos");
                    escritorXML.WriteStartElement("Nombre");
                    escritorXML.WriteValue(valores[0]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("Apellido");
                    escritorXML.WriteValue(valores[1]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("E-Mail");
                    escritorXML.WriteValue(valores[2]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("Telefono");
                    escritorXML.WriteValue(valores[3]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteEndElement();
                }
            }while(linea!=null);
            escritorXML.WriteEndElement();
            escritorXML.WriteEndDocument();
            escritorXML.Close();
            lector.Close();
        }

        private static void Escribir()
        {
            StreamWriter escritor = File.AppendText("agenda.txt");
            Console.WriteLine("Ingrese nuevos contactos");
            string rta = "S";
            while (rta == "S") {
                Console.WriteLine("Ingrese nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Ingrese apellido: ");
                string apellido = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Ingrese e-mail: ");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Ingrese telefono: ");
                string telefono = Console.ReadLine();
                escritor.WriteLine(nombre + ";" + apellido + ";" + email + ";" + telefono + ";");
                Console.WriteLine("¿Desea ingresar otro contacto? (S/N)");
                rta =Console.ReadLine().ToUpper();
            }

            escritor.Close();
        }

        private static void Leer()
        {
            //FileStream lector = new FileStream("agenda.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            //while (lector.Length > lector.Position) 
            //{
            //    Console.Write((char)lector.ReadByte());  
            //}
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            Console.WriteLine("Nombre\tApellido\tE-Mail\t\t\tTelefono");
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string[] valores = linea.Split(';');
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", valores[0], valores[1], valores[2], valores[3]);
                }
            } while (linea != null);
            lector.Close();
        }
    }
}
