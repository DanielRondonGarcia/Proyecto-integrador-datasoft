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
namespace Gerente.Menu.Reportes
{
    public partial class ReporteAuditoria : Form
    {
        public ReporteAuditoria()
        {
            InitializeComponent();
        }
        DReportes r = new DReportes();
        public void MostrarAuditoria()
        {
            dgAuditoria.DataSource = r.Mostrar_Auditoria();
        }
        private void ReporteAuditoria_Load(object sender, EventArgs e)
        {
            MostrarAuditoria();
        }
    }
}
