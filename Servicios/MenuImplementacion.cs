using edu.PR.EXAMEN4rep.Controladores;
using edu.PR.EXAMEN4rep.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace edu.PR.EXAMEN4rep.Servicios
{
    internal class MenuImplementacion : MenuInterfaz
    {
        FicherosInterfaz fi = new FicherosImplementacion();
        


        public int menuYSeleccionPrincipal()
        {
            int opcionUsuario;

            Console.WriteLine("#######################");
            Console.WriteLine("0. Cerrar Aplicación");
            Console.WriteLine("1. Registro de llegada");
            Console.WriteLine("2. Listado de consultas");
            Console.WriteLine("#######################");

            opcionUsuario = Convert.ToInt32(Console.ReadLine());
            return opcionUsuario;
        }




        private int menuYSeleccionListadoConsultas()
        {
            int opcionUsuario;

            Console.WriteLine("#######################");
            Console.WriteLine("0. Cerrar Aplicación");
            Console.WriteLine("1. mostrar consultas");
            Console.WriteLine("2. Imprimir consultas");
            Console.WriteLine("#######################");

            opcionUsuario = Convert.ToInt32(Console.ReadLine());
            return opcionUsuario;
        }


        public void accesoSubMenu()
        {
            OperativaInterfaz oi = new OperativaImplementacion();
            int opcionUsuario;
            bool cerrarMenu = false;

            do
            {
                try
                {
                    opcionUsuario = menuYSeleccionListadoConsultas();

                    switch (opcionUsuario)
                    {

                        case 0:
                            Console.WriteLine("Has seleccionado volver");
                            fi.escribirSeleccion("Has seleccionado volver");
                            cerrarMenu = true;
                            break;

                        case 1:

                            Console.WriteLine("Has seleccionado mostrar consultas");
                            accesoSubMenuMostrarConsultas();
                            fi.escribirSeleccion("Has seleccionado mostrar consultas");
                            break;

                        case 2:
                            Console.WriteLine("Has seleccionado imprimir consultas");
                            oi.imprimirConsultasF();
                            fi.escribirSeleccion("Has seleccionado imprimir consultas");
                            break;

                        default:
                            fi.escribirSeleccion("Ha seleccionado una opcion incorrecta");
                            Console.WriteLine("La opcion seleccionado es incorrecta");
                            break;




                    }





                }
                catch (Exception ex)
                {
                    fi.escribirFicheroErrores("Se ha producido un error" + ex.Message);
                    Console.WriteLine("Se ha producido un erro, intentelo más tarde");
                }

            } while (!cerrarMenu);
        }





        private int menuYSeleccionRegistros()
        {
            int opcionUsuario;

            Console.WriteLine("#######################");
            Console.WriteLine("0. Cerrar Aplicación");
            Console.WriteLine("1. Registro de llegada");            
            Console.WriteLine("#######################");

            opcionUsuario = Convert.ToInt32(Console.ReadLine());
            return opcionUsuario;
        }


        public void accesoSubMenuRegistros()
        {

            OperativaInterfaz oi = new OperativaImplementacion();


            int opcionUsuario;
            bool cerrarMenu = false;

            do
            {
                try
                {
                    opcionUsuario = menuYSeleccionRegistros();

                    switch (opcionUsuario)
                    {

                        case 0:
                            Console.WriteLine("Has seleccionado volver");
                            fi.escribirSeleccion("Has seleccionado volver");
                            cerrarMenu = true;
                            break;

                        case 1:

                            Console.WriteLine("Has seleccionado registro de llegada");
                            oi.registroLlegada();
                            fi.escribirSeleccion("Has seleccionado registro de llegada");
                            break;
                      

                        default:
                            fi.escribirSeleccion("Ha seleccionado una opcion incorrecta");
                            Console.WriteLine("La opcion seleccionado es incorrecta");
                            break;




                    }





                }
                catch (Exception ex)
                {
                    fi.escribirFicheroErrores("Se ha producido un error" + ex.Message);
                    Console.WriteLine("Se ha producido un erro, intentelo más tarde");
                }

            } while (!cerrarMenu);
        }


        public int menuYSeleccionMostrarConsultas()
        {
            int opcionUsuario;

            Console.WriteLine("#######################");
            Console.WriteLine("0. Volver");
            Console.WriteLine("1. Psicologia");
            Console.WriteLine("2. Traumatologia");
            Console.WriteLine("3. Fisioterapia");
            Console.WriteLine("#######################");

            opcionUsuario = Convert.ToInt32(Console.ReadLine());
            return opcionUsuario;
        }

        public void accesoSubMenuMostrarConsultas()
        {
            int opcionUsuario;
            bool cerrarMenu = false;
            string formato = "dd-MM-yyyy";

            do
            {
                try
                {
                    opcionUsuario = menuYSeleccionMostrarConsultas();

                    switch (opcionUsuario)
                    {

                        case 0:
                            Console.WriteLine("Has seleccionado volver");
                            fi.escribirSeleccion("Has seleccionado volver");

                            cerrarMenu = true;
                            break;

                        case 1:
                            
                            Console.WriteLine("Has seleccionado Psicologia");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Introduzca una fecha");
                            string fechaUString = Console.ReadLine();
                            DateTime fechaUP = DateTime.Parse(fechaUString);

                            bool encontrado3 = false;
                             

                            foreach (ClienteDto cliente in Program.listaClientes)
                            {
                                DateTime fechaCliente = cliente.FechaCita;
                                string fechaPString = fechaCliente.ToString("dd-MM-yyyy");
                                DateTime fechaP = DateTime.Parse(fechaPString);

                                if (cliente.Consulta.Equals("Psicología") && fechaUP.CompareTo(fechaP) == 0)
                                {
                                    Console.WriteLine(cliente.ToString());
                                    encontrado3 = true;
                                }

                            }
                            if (encontrado3 == false)
                            {
                                Console.WriteLine("No ha citas");
                            }

                            fi.escribirSeleccion("Has seleccionado Psicologia");
                            break;


                        case 2:
                            Console.WriteLine("Has seleccionado Traumatologia");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Introduzca una fecha");
                            string fechaUsuSt = Console.ReadLine();
                            DateTime fechaUsuDt = DateTime.Parse(fechaUsuSt);
                            bool encontrado = false;
                            foreach (ClienteDto cliente in Program.listaClientes)
                            {
                                DateTime fecha2 = cliente.FechaCita;
                                string fecha2String = fecha2.ToString("dd-MM-yyyy");
                                DateTime fechaF2 = DateTime.Parse(fecha2String);

                                if (cliente.Consulta.Equals("Traumatología") && fecha2.CompareTo(fechaUsuDt) == 0)
                                {
                                    encontrado = true;
                                    Console.WriteLine(cliente.ToString());
                                }

                            }
                            if (encontrado == false)
                            {
                                Console.WriteLine("No ha citas");
                            }

                            
                            fi.escribirSeleccion("Has seleccionado Traumatologia");
                            break;

                        case 3:
                            Console.WriteLine("Has seleccionado Fisioterapia");
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Introduzca una fecha");
                            string fechaUsu3 = Console.ReadLine();
                            DateTime fechaUsuDt3 = DateTime.Parse(fechaUsu3);

                            bool encontrado2 = false;
                            foreach (ClienteDto cliente in Program.listaClientes)
                            {
                                DateTime fecha3 = cliente.FechaCita;
                                string fecha3S = fecha3.ToString("dd-MM-yyyy");
                                DateTime fecha3Dt = DateTime.Parse(fecha3S);

                                if (cliente.Consulta.Equals("Fisioterapia") && fechaUsuDt3.CompareTo(fecha3Dt) == 0)
                                {
                                    Console.WriteLine(cliente.ToString());
                                    encontrado2 = true;
                                }

                            }
                            if (encontrado2 == false)
                            {
                                Console.WriteLine("No ha citas");
                            }
                            {

                            }
                            fi.escribirSeleccion("Has seleccionado Fisioterapia");
                            break;

                        default:

                            fi.escribirSeleccion("Ha seleccionado una opcion incorrecta");
                            Console.WriteLine("La opcion seleccionado es incorrecta");
                            break;




                    }





                }
                catch (Exception ex)
                {
                    fi.escribirFicheroErrores("Se ha producido un error" + ex.Message);
                    Console.WriteLine("Se ha producido un erro, intentelo más tarde");
                }

            } while (!cerrarMenu);
        }

        


    }
}
