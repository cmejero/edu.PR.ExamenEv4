﻿using edu.PR.EXAMEN4rep.Controladores;
using edu.PR.EXAMEN4rep.Dtos;
using edu.PR.EXAMEN4rep.Utiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.PR.EXAMEN4rep.Servicios
{
    
        internal class FicherosImplementacion : FicherosInterfaz

        {

            public void escribirFicheroErrores(string mensaje)
            {
                StreamWriter st = null;
                try
                {
                    st = new StreamWriter(Program.rutaFicheroLogErrores, true);

                    st.WriteLine(mensaje);
                }
                catch (IOException io)
                {


                    Console.WriteLine("Se ha producido un error, intentelo más tarde");
                }
                finally
                {

                    if (st != null)
                    {
                        st.Close();
                    }

                }

            }

            public void escribirSeleccion(String mensaje)
            {

                StreamWriter st = null;

                st = new StreamWriter(Program.rutaFicheroSeleccion, true);

                st.WriteLine(mensaje);

                st.Close();

            }

            public void leerFichero()
            {
                StreamReader sr = null;

                try
                {
                    sr = new StreamReader(Program.rutaFicheroPacientes);

                    string lineas;
                bool asistenciaBool = false;
                

                while ((lineas = sr.ReadLine()) != null)
                {
                    string[] linea = lineas.Split(';');

                    ClienteDto cliente = new ClienteDto();

                    cliente.Id = crearId();
                    cliente.Dni = linea[0].Trim();
                    cliente.NombreCliente = linea[1].Trim();
                    cliente.Apellidos = linea[2].Trim();
                    cliente.Consulta = linea[3].Trim();
                    string fechaFichero = linea[4].Trim();
                    DateTime fecha = DateTime.Parse(fechaFichero);
                    cliente.FechaCita = fecha;
                    string asistencia = linea[5].Trim();

                    if (asistencia == "true")
                    {
                        asistenciaBool = true;
                    }
                    else if (asistencia == "false")
                    {
                        cliente.AsistenciaCita = false;
                    }
                    else
                    {
                        Console.WriteLine("El valor no corresponde");
                    }

                    Program.listaClientes.Add(cliente);
                }
                                 
                }
                catch (IOException io)
                {
                    escribirFicheroErrores("Se ha producido un error en metodo leer fichero: " + io.Message);
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }

                }

            }


            private long crearId()
            {
                long nuevoId;
                int tamanioLista = Program.listaClientes.Count;

                if (tamanioLista > 0)
                {
                    nuevoId = Program.listaClientes[tamanioLista - 1].Id + 1;
                }
                else
                {
                    nuevoId = 1;
                }
                return nuevoId;

            }

        }
    
}