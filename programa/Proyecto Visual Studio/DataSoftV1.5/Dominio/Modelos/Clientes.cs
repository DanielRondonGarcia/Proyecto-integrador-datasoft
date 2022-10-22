using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Clientes
    {
        private int id;
        private string nombre;
        private string apellido;
        private int idTipdoc;
        private long telefono;
        private string correo;
        private int idSex;
        private string direccion;
        private int idBarrio;
        private string ID_Departamento;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int IdTipdoc { get => idTipdoc; set => idTipdoc = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public int IdSex { get => idSex; set => idSex = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int IdBarrio { get => idBarrio; set => idBarrio = value; }
        public string ID_Departamento1 { get => ID_Departamento; set => ID_Departamento = value; }
    }
}
