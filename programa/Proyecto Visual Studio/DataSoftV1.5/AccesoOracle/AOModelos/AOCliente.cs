using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoOracle.AOModelos
{
    public class AOCliente
    {
        private int ID;
        private string nombre;
        private string apellido;
        private int tipoDocumento;
        private long telefono;
        private string correo;
        private int sexo;
        private string direccion;
        private int departamento;
        private int ciudad;
        private int zona;
        private string documentoF;
        private long NDocumento;
        public int _ID1 { get => ID; set => ID = value; }
        public string _Nombre { get => nombre; set => nombre = value; }
        public string _Apellido { get => apellido; set => apellido = value; }
        public int _TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public long _Telefono { get => telefono; set => telefono = value; }
        public string _Correo { get => correo; set => correo = value; }
        public int _Sexo { get => sexo; set => sexo = value; }
        public string _Direccion { get => direccion; set => direccion = value; }
        public int _Departamento { get => departamento; set => departamento = value; }
        public int _Ciudad { get => ciudad; set => ciudad = value; }
        public int _Zona { get => zona; set => zona = value; }
        public string _DocumentoF { get => documentoF; set => documentoF = value; }
        public long _NDocumento1 { get => NDocumento; set => NDocumento = value; }

        public AOCliente() { }
        public AOCliente(int Id, string nombre, string apellido, int tipoDocumento, long telefono, string correo, int sexo, string direccion, int zona, string documen, long ndoc)
        {
            _ID1 = Id;
            _Nombre = nombre;
            _Apellido = apellido;
            _TipoDocumento = tipoDocumento;
            _Telefono = telefono;
            _Correo = correo;
            _Sexo = sexo;
            _Direccion = direccion;
            _Zona = zona;
            _DocumentoF = documen;
            _NDocumento1 = ndoc;
        }
        
    }
}
