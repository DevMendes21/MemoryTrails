using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrilhasDaMemoria
{
    public partial class FormSelecaoNivel : Form
    {
        public FormSelecaoNivel()
        {
            InitializeComponent();
        }

        private void FormSelecaoNivel_Load(object sender, EventArgs e)
        {
            // Centraliza o formulário na tela
            this.CenterToScreen();
        }

        private void btnFacil_Click(object sender, EventArgs e)
        {
            // Inicia o jogo no nível fácil (4x4 = 16 cartas = 8 pares)
            FormJogo formJogo = new FormJogo(Dificuldade.Facil);
            formJogo.Show();
            this.Hide();
        }

        private void btnMedio_Click(object sender, EventArgs e)
        {
            // Inicia o jogo no nível médio (6x4 = 24 cartas = 12 pares)
            FormJogo formJogo = new FormJogo(Dificuldade.Medio);
            formJogo.Show();
            this.Hide();
        }

        private void btnDificil_Click(object sender, EventArgs e)
        {
            // Inicia o jogo no nível difícil (6x6 = 36 cartas = 18 pares)
            FormJogo formJogo = new FormJogo(Dificuldade.Dificil);
            formJogo.Show();
            this.Hide();
        }
    }
}
