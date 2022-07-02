using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            Jogo novoJogo = new Jogo(false, txtCaixaIP.Text);
            Visible = false;

            if (!novoJogo.IsDisposed)
            {
                novoJogo.ShowDialog();
            }

            Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jogo novoJogo = new Jogo(true);
            Visible = false;

            if (!novoJogo.IsDisposed)
            {
                novoJogo.ShowDialog();
            }

            Visible = true;

        }
    }
}
