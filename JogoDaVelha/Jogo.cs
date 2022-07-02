using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace JogoDaVelha
{
    public partial class Jogo : Form
    {
        public Jogo(bool ehHost, string IP = null)
        {
            InitializeComponent();
            recebeMensagem.DoWork += RecebeMensagem_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            if (ehHost)
            {
                iconeUsuario = 'X';
                iconeOponente = 'O';
                servidor = new TcpListener(System.Net.IPAddress.Any, 5732);
                servidor.Start();
                sock = servidor.AcceptSocket();
            }
            else
            {
                iconeUsuario = 'O';
                iconeOponente = 'X';

                try
                {
                    cliente = new TcpClient(IP, 5732);
                    sock = cliente.Client;
                    recebeMensagem.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }

        }

        private void RecebeMensagem_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ChecaEstado())
            {
                return;
            }

            MantemTabuleiro();
            lblRodada.Text = "Vez do Oponente!";
            RecebeMovimento();
            lblRodada.Text = "Sua vez!";

            if (!ChecaEstado())
            {
                LiberaTabuleiro();
            }
            
        }

        private char iconeUsuario;
        private char iconeOponente;
        private Socket sock;
        private BackgroundWorker recebeMensagem = new BackgroundWorker();
        private TcpListener servidor = null;
        private TcpClient cliente;
       
        private bool ChecaEstado()
        {
            //Verifica Horizontais

            if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                if (button1.Text[0] == iconeUsuario)
                {
                    lblRodada.Text = "Você Ganhou!";
                    MessageBox.Show("Você Ganhou!");
                    MantemTabuleiro();
                }
                else
                {
                    lblRodada.Text = "Você Perdeu!";
                    MessageBox.Show("Você Perdeu");
                    MantemTabuleiro();
                }
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                if (button4.Text[0] == iconeUsuario)
                {
                    lblRodada.Text = "Você Ganhou!";
                    MessageBox.Show("Você Ganhou!");
                    MantemTabuleiro();
                }
                else
                {
                    lblRodada.Text = "Você Perdeu!";
                    MessageBox.Show("Você Perdeu");
                    MantemTabuleiro();
                }
                return true;
            }
            else if(button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                if (button7.Text[0] == iconeUsuario)
                {
                    lblRodada.Text = "Você Ganhou!";
                    MessageBox.Show("Você Ganhou!");
                    MantemTabuleiro();
                }
                else
                {
                    lblRodada.Text = "Você Perdeu!";
                    MessageBox.Show("Você Perdeu");
                    MantemTabuleiro();
                }
                return true;
            }
            //Verifica Verticais
            else if(button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
                if (button1.Text[0] == iconeUsuario)
                {
                    lblRodada.Text = "Você Ganhou!";
                    MessageBox.Show("Você Ganhou!");
                    MantemTabuleiro();
                }
                else
                {
                    lblRodada.Text = "Você Perdeu!";
                    MessageBox.Show("Você Perdeu");
                    MantemTabuleiro();
                }
                return true;
            }
            else if(button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                if (button2.Text[0] == iconeUsuario)
                {
                    lblRodada.Text = "Você Ganhou!";
                    MessageBox.Show("Você Ganhou!");
                    MantemTabuleiro();
                }
                else
                {
                    lblRodada.Text = "Você Perdeu!";
                    MessageBox.Show("Você Perdeu");
                    MantemTabuleiro();
                }
                return true;
            }
            else if(button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                if (button3.Text[0] == iconeUsuario)
                {
                    lblRodada.Text = "Você Ganhou!";
                    MessageBox.Show("Você Ganhou!");
                    MantemTabuleiro();
                }
                else
                {
                    lblRodada.Text = "Você Perdeu!";
                    MessageBox.Show("Você Perdeu");
                    MantemTabuleiro();
                }
                return true;
            }
            //Verifica Diagonais
            else if(button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                if (button1.Text[0] == iconeUsuario)
                {
                    lblRodada.Text = "Você Ganhou!";
                    MessageBox.Show("Você Ganhou!");
                    MantemTabuleiro();
                }
                else
                {
                    lblRodada.Text = "Você Perdeu!";
                    MessageBox.Show("Você Perdeu");
                    MantemTabuleiro();
                }
                return true;
            }
            else if(button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (button3.Text[0] == iconeUsuario)
                {
                    lblRodada.Text = "Você Ganhou!";
                    MessageBox.Show("Você Ganhou!");
                    MantemTabuleiro();
                }
                else
                {
                    lblRodada.Text = "Você Perdeu!";
                    MessageBox.Show("Você Perdeu");
                    MantemTabuleiro();
                }
                return true;
            }
            //Verifica Empate
            else if(button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                lblRodada.Text = "Empate!";
                MessageBox.Show("Empate!");
                MantemTabuleiro();
                return true;
            }
            return false;
        }

        private void MantemTabuleiro()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

        }

        private void LiberaTabuleiro()
        {
            if (button1.Text == "")
            {
                button1.Enabled = true;
            }
            if (button2.Text == "")
            {
                button2.Enabled = true;
            }
            if (button3.Text == "")
            {
                button3.Enabled = true;
            }
            if (button4.Text == "")
            {
                button4.Enabled = true;
            }
            if (button5.Text == "")
            {
                button5.Enabled = true;
            }
            if (button6.Text == "")
            {
                button6.Enabled = true;
            }
            if (button7.Text == "")
            {
                button7.Enabled = true;
            }
            if (button8.Text == "")
            {
                button8.Enabled = true;
            }
            if (button9.Text == "")
            {
                button9.Enabled = true;
            }
        }

        private void RecebeMovimento()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);

            if (buffer[0] == 1)
            {
                button1.Text = iconeOponente.ToString();
            }

            if (buffer[0] == 2)
            {
                button2.Text = iconeOponente.ToString();
            }

            if (buffer[0] == 3)
            {
                button3.Text = iconeOponente.ToString();
            }

            if (buffer[0] == 4)
            {
                button4.Text = iconeOponente.ToString();
            }

            if (buffer[0] == 5)
            {
                button5.Text = iconeOponente.ToString();
            }

            if (buffer[0] == 6)
            {
                button6.Text = iconeOponente.ToString();
            }

            if (buffer[0] == 7)
            {
                button7.Text = iconeOponente.ToString();
            }

            if (buffer[0] == 8)
            {
                button8.Text = iconeOponente.ToString();
            }

            if (buffer[0] == 9)
            {
                button9.Text = iconeOponente.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] numero = { 1 };
            sock.Send(numero);
            button1.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] numero = { 2 };
            sock.Send(numero);
            button2.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] numero = { 3 };
            sock.Send(numero);
            button3.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] numero = { 4 };
            sock.Send(numero);
            button4.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] numero = { 5 };
            sock.Send(numero);
            button5.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] numero = { 6 };
            sock.Send(numero);
            button6.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] numero = { 7 };
            sock.Send(numero);
            button7.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] numero = { 8 };
            sock.Send(numero);
            button8.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] numero = { 9 };
            sock.Send(numero);
            button9.Text = iconeUsuario.ToString();
            recebeMensagem.RunWorkerAsync();
        }

        private void Jogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            recebeMensagem.WorkerSupportsCancellation = true;
            recebeMensagem.CancelAsync();

            if(servidor != null)
            {
                servidor.Stop();
            }
        }

        
    }
}
