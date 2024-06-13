using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.PR.EXAMEN4rep.Utiles
{
    internal static class Util
    {


        public static string nombreFichero()
        {
            string ruta = "9";
            try
            {
                DateTime fechaActual = DateTime.Now;

                string fechaString = fechaActual.ToString("ddMMyyyy");

                ruta = String.Concat("-log", fechaString, ".txt");




            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error intentelo más tarde");
            }
            return ruta;
        }

        public static string citas()
        {

            string nombreRuta = "";

            try
            {
                DateTime fechaActual = DateTime.Today;

                string fechaString = fechaActual.ToString("ddMMyyyy");

                nombreRuta = String.Concat("citasConAsistencia-", fechaString, ".txt");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error, intentelo más tarde");
            }             
                return nombreRuta;
            

        }

        
    }
}
