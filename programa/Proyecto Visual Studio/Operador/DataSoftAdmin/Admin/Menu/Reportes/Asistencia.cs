using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.DAjustes;

namespace Operador
{
    public partial class Asistencia : Form
    {
        DReportes r = new DReportes();
        public Asistencia()
        {
            InitializeComponent();
        }
        public void mostrarAsistencia()
        {
            dgAsistencia.DataSource = r.Mostrar_Asistencia();
        }
        private void Asistencia_Load(object sender, EventArgs e)
        {
            mostrarAsistencia();
        }
    }
}
