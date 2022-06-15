using Business.Logic;
using System;
using Business.Entities;
using System.Collections.Generic;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _UsuarioNegocio;

        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }

        public void Menu()
        {
            int opcion = 0;
            while (opcion!=6)
            {
                Console.Clear();
                Console.WriteLine("1- Listado General");
                Console.WriteLine("2- Consulta");
                Console.WriteLine("3- Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        Eliminar();
                        break;
                    default:
                        break;
                }
            }

        }

        private void Agregar()
        {
            try
            {
                Console.Clear();
                UsuarioNegocio = new UsuarioLogic();
                Usuario usr = new Usuario();
                Console.WriteLine("Ingrese nombre:");
                usr.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Apellido:");
                usr.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese Nombre de Usuario:");
                usr.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese E-Mail:");
                usr.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese Clave:");
                usr.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese Habilitacion de usuario (1-Si/otro-No):");
                usr.Habilitado = (Console.ReadLine() == "1");
                usr.State = BusinessEntity.States.New;
                UsuarioNegocio.Save(usr);
                Console.WriteLine();
                Console.WriteLine("Su ID es: {0}", usr.ID);

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        private void Eliminar()
        {
            try
            {
                UsuarioNegocio = new UsuarioLogic();
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a eliminar:");
                int id = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(id);
                Console.WriteLine("El usuario fue eliminado con exito");
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        private void Consultar()
        {
            try
            {
                UsuarioNegocio = new UsuarioLogic();
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a consultar:");
                int id = int.Parse(Console.ReadLine());
                MostrarDatos(UsuarioNegocio.GetOne(id));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        private void Modificar()
        {
            try
            {
                Console.Clear();
                UsuarioNegocio = new UsuarioLogic();
                Console.WriteLine("Ingrese el ID de usuario a modificar");
                int id = int.Parse(Console.ReadLine());
                Usuario usr=UsuarioNegocio.GetOne(id);
                Console.WriteLine("Ingrese nombre:");
                usr.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Apellido:");
                usr.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese Nombre de Usuario:");
                usr.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese E-Mail:");
                usr.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese Clave:");
                usr.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese Habilitacion de usuario (1-Si/otro-No):");
                usr.Habilitado= (Console.ReadLine()=="1");
                usr.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usr);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        private void ListadoGeneral()
        {
            Console.Clear();
            UsuarioNegocio = new UsuarioLogic();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        private void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\t Nombre: {0}", usr.Nombre);
            Console.WriteLine("\t\t Apellido: {0}", usr.Apellido);
            Console.WriteLine("\t\t Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\t Clave: {0}", usr.Clave);
            Console.WriteLine("\t\t Email: {0}", usr.EMail);
            Console.WriteLine("\t\t Habilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }
    }
}
