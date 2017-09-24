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
    public partial class Form1 : Form
    {
        bool _login = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void selecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(1);
            OperacionesR.ShowDialog();
        }

        private void proyecciónGeneralizadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(2);
            OperacionesR.ShowDialog();
        }

        private void diferenciaDeConjuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(3);
            OperacionesR.ShowDialog();
        }

        private void productoCartesianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(4);
            OperacionesR.ShowDialog();
        }

        private void intersecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(5);
            OperacionesR.ShowDialog();
        }

        private void divisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(6);
            OperacionesR.ShowDialog();
        }

        private void renombrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(7);
            OperacionesR.ShowDialog();
        }

        private void naturalJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(8);
            OperacionesR.ShowDialog();
        }

        private void agregaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(9);
            OperacionesR.ShowDialog();
        }

        private void agrupaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(10);
            OperacionesR.ShowDialog();
        }

        private void uniónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IARVentana OperacionesR = new IARVentana(11);
            OperacionesR.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea cerrar el programa?", "Cerrar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _login = true;

            if (_login)
            {
                btnLogin.Enabled = false;
                btnLogin.Visible = false;
                Menus.Enabled = true;
            }
        }
    }
}
