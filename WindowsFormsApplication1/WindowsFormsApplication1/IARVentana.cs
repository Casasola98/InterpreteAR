using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{
    public partial class IARVentana : Form
    {
        public IARVentana(int tipoOperacion)
        {
            InitializeComponent();

            /*
            ExpresionAR.SelectionColor = Color.Red;
            ExpresionAR.SelectedText = "Hello";
            ExpresionAR.SelectionFont = new Font("Symbol", ExpresionAR.Font.Size, FontStyle.Regular);
            ExpresionAR.SelectionColor = Color.Brown;
            ExpresionAR.SelectedText = " Hello";
            */

            switch (tipoOperacion)
            {
                case 1:
                    label1.Text = "Selección";
                    lt2.Enabled = false;
                    lt2.Visible = false;
                    tabla2.Enabled = false;
                    tabla2.Visible = false;
                    tOps.Enabled = false;
                    break;
                case 2:
                    label1.Text = "Proyección Generalizada";
                    Contenido.Text = "Expresión";
                    lt2.Enabled = false;
                    lt2.Visible = false;
                    tabla2.Enabled = false;
                    tabla2.Visible = false;
                    tOps.Enabled = false;
                    break;
                case 3:
                    label1.Text = "Diferencia de Conjuntos";
                    tContenido.Enabled = false;
                    tOps.Enabled = false;
                    break;
                case 4:
                    label1.Text = "Producto Cartesiano";
                    tContenido.Enabled = false;
                    tOps.Enabled = false;
                    break;
                case 5:
                    label1.Text = "Intersección";
                    tContenido.Enabled = false;
                    tOps.Enabled = false;
                    break;
                case 6:
                    label1.Text = "División";
                    tContenido.Enabled = false;
                    tOps.Enabled = false;
                    break;
                case 7:
                    label1.Text = "Join";
                    tOps.Enabled = false;
                    break;
                case 8:
                    label1.Text = "Natural Join";
                    tContenido.Enabled = false;
                    tOps.Enabled = false;
                    break;
                case 9:
                    label1.Text = "Agregación";
                    lt2.Enabled = false;
                    lt2.Visible = false;
                    tabla2.Enabled = false;
                    tabla2.Visible = false;
                    tContenido.Enabled = false;
                    break;
                case 10:
                    label1.Text = "Agrupación";
                    Contenido.Text = "Atributos";
                    break;
                case 11:
                    label1.Text = "Unión";
                    tOps.Enabled = false;
                    tContenido.Enabled= false;
                    break;
                default:
                    break;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void IARVentana_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea cerrar el programa?","Cerrar", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (res == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
