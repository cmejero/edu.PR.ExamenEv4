using edu.PR.EXAMEN4rep.Controladores;
using edu.PR.EXAMEN4rep.Dtos;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.PR.EXAMEN4rep.Servicios
{
    internal class OperativaImplementacion : OperativaInterfaz
    {

        MenuInterfaz mi =new MenuImplementacion();

        public void registroLlegada()
        {
            DateTime fechaActual = DateTime.Now;
            string formato = fechaActual.ToString("dd-MM-yyyy");
            DateTime fecha = DateTime.Parse(formato);

            Console.WriteLine("Introduzca el DNI");
            string dni = Console.ReadLine();
            bool cita = false;



            foreach (ClienteDto cliente in Program.listaClientes)
            {

                DateTime fechaC = cliente.FechaCita;
                string fomatoC = fechaC.ToString("dd-MM-yyyy");
                DateTime fechaCliente = DateTime.Parse(fomatoC);
                DateTime fechaModif = fechaCliente.AddHours(-1);

                if (cliente.Dni.Equals(dni) && fecha.CompareTo(fechaCliente) == 0) 
                {
                    Console.WriteLine(String.Concat(" Espere su turno para la consulta de ", cliente.Consulta, " en la sala de espera. Su especialista "));
                    cita = true;
                }
                


            }



            if (cita == false)
            {
                Console.WriteLine("No dispone de cita previa para hoy.");

            }



        }
        public void imprimirConsultasF()
        {

            Console.WriteLine("Introduzca una fecha");
            string fecha = Console.ReadLine();
            DateTime fechaD = DateTime.Parse(fecha);
            string consulta = "";
            int opcionUsuario;
            bool volver = false;

            do
            {
                try
                {
                    opcionUsuario = mi.menuYSeleccionMostrarConsultas();

                    switch (opcionUsuario)
                    {

                        case 0:
                            volver = true;
                            break;
                        case 1:
                            consulta = "Psicología";
                            break;
                        case 2:

                            consulta = "Traumatología";
                            break;
                        case 3:

                            consulta = "Fisioterapia";
                            break;

                        default:

                            Console.WriteLine("La opcion indicada no es correcta");
                            break;

                    }

                }
                catch (Exception e)
                {



                }
            } while (!volver);

            StreamWriter st = null;
            try
            {


                foreach (ClienteDto cliente in Program.listaClientes)
                {

                    DateTime fechaC = cliente.FechaCita;
                    string formatoString = fechaC.ToString("dd-MM-yyyy");
                    DateTime fechaCliente = DateTime.Parse(formatoString);

                    if (fechaD.CompareTo(fechaCliente) == 0 && cliente.Consulta.Equals(consulta))
                    {

                        st = new StreamWriter(Program.rutaFicheroCitas);

                        st.WriteLine(cliente.ToString(","));


                    }


                }

            }
            catch (Exception io)
            {

            }
            finally {
            if(st != null)
                {

                st.Close(); }
            
            }
        }
    }
}
