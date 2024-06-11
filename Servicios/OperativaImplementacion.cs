using edu.PR.EXAMEN4rep.Controladores;
using edu.PR.EXAMEN4rep.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.PR.EXAMEN4rep.Servicios
{
    internal class OperativaImplementacion : OperativaInterfaz
    {
        
        

        public void registroLlegada()
        {
            DateTime fechaActual = DateTime.Today;

            Console.WriteLine("Introduzca el DNI");
            string dni = Console.ReadLine();
            bool cita = false;

            

            foreach (ClienteDto cliente in Program.listaClientes)
            {
                
                
                    if (cliente.Dni.Equals(dni))
                    {
                    Console.WriteLine(String.Concat(" Espere su turno para la consulta de", cliente.Consulta, " en la sala de espera. Su especialista "));
                    cita = true;
                }
                    
                
            }

            

            if (cita == false)
            {
                Console.WriteLine("No dispone de cita previa para hoy.");

            }
          
            

        }

        
    }
}
