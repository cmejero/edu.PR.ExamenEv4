using edu.PR.EXAMEN4rep.Dtos;
using edu.PR.EXAMEN4rep.Servicios;
using edu.PR.EXAMEN4rep.Utiles;

namespace edu.PR.EXAMEN4rep.Controladores
{
    internal class Program
    {
        // static public string rutaFichero = "C:\\Users\\Carlo\\OneDrive\\Escritorio\\FICHEROS\\";
        static public string rutaFichero = "C:\\Users\\Carlos\\Desktop\\FICHEROS\\Examen4\\";
        static public string rutaFicheroLogErrores = String.Concat(rutaFichero, Util.nombreFichero());
        //static public string rutaFicheroSeleccion = "C:\\Users\\Carlo\\OneDrive\\Escritorio\\FICHEROS\\ficheroSelecciones.txt";
        static public string rutaFicheroSeleccion = "C:\\Users\\Carlos\\Desktop\\FICHEROS\\Examen4\\ficheroSelecciones.txt";
        //static public string rutaFicheroPacientes = "C:\\Users\\Carlo\\OneDrive\\Escritorio\\FICHEROS\\pacientes.txt";
        static public string rutaFicheroPacientes = "C:\\Users\\Carlos\\Desktop\\FICHEROS\\Examen4\\pacientes.txt";
        static public List<ClienteDto> listaClientes = new List<ClienteDto>();


        static void Main(string[] args)
        {
            MenuInterfaz mi = new MenuImplementacion();
            FicherosInterfaz fi = new FicherosImplementacion();

            int opcionUsuario;
            bool cerrarMenu = false;

            fi.leerFichero();
            foreach (ClienteDto cliente in listaClientes)
            {
                Console.WriteLine(cliente);
            }

            do
            {
                try
                {
                    opcionUsuario = mi.menuYSeleccionPrincipal();

                    switch (opcionUsuario)
                    {

                        case 0:
                            Console.WriteLine("Has seleccionado cerrar Menu");
                            fi.escribirSeleccion("Has seleccionado cerrar Menu");
                            cerrarMenu = true;
                            break;

                        case 1:

                            Console.WriteLine("Has seleccionado registro de llegada");
                            fi.escribirSeleccion("Has seleccionado registro de llegada");
                            mi.accesoSubMenuRegistros();
                            break;

                        case 2:
                            Console.WriteLine("Has seleccionado listado de consultas");
                            fi.escribirSeleccion("Has seleccionado listado de consultas");
                            mi.accesoSubMenu();
                            break;

                        default:
                            fi.escribirSeleccion("ha selecciona una opcion incorrecta");
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

