using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.PR.EXAMEN4rep.Dtos
{
    internal class ClienteDto
    {
        long id;
        string dni = "aaaaa";
        string nombreCliente = "aaaaa";
        string apellidos = " aaaaa";
        string consulta = "aaaaa";
        DateTime fechaCita;
        bool asistenciaCita = false;

        public long Id { get => id; set => id = value; }
        public string Dni { get => dni; set => dni = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Consulta { get => consulta; set => consulta = value; }
        public DateTime FechaCita { get => fechaCita; set => fechaCita = value; }
        public bool AsistenciaCita { get => asistenciaCita; set => asistenciaCita = value; }


        override
            public string ToString()
        {


            string toString = String.Concat(dni,";", nombreCliente, ";", apellidos, ";", consulta, ";", fechaCita, ";", asistenciaCita);
            return toString;
        }
    }
}
