using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrilhasDaMemoria
{
    /// <summary>
    /// Classe que representa uma carta do jogo da memória
    /// </summary>
    public class Carta : Button
    {
        // Propriedades da carta
        public int Id { get; private set; }        // ID único da carta
        public int IdPar { get; private set; }     // ID do par correspondente
        public bool Virada { get; private set; }   // Indica se a carta está virada
        public bool Encontrada { get; private set; } // Indica se a carta já foi encontrada
        
        // Cores para os diferentes estados da carta
        private readonly Color corFrente;          // Cor quando a carta está virada
        private readonly Color corVerso = Color.SteelBlue; // Cor quando a carta está com o verso para cima
        private readonly Color corEncontrada = Color.LightGreen; // Cor quando o par foi encontrado
        
        // Imagem ou texto a ser exibido na frente da carta
        private readonly string conteudo;
        
        /// <summary>
        /// Construtor da carta
        /// </summary>
        /// <param name="id">ID único da carta</param>
        /// <param name="idPar">ID do par correspondente</param>
        /// <param name="conteudo">Texto ou símbolo a ser exibido na frente da carta</param>
        /// <param name="corFrente">Cor da frente da carta</param>
        public Carta(int id, int idPar, string conteudo, Color corFrente)
        {
            // Inicializa as propriedades
            this.Id = id;
            this.IdPar = idPar;
            this.conteudo = conteudo;
            this.corFrente = corFrente;
            
            // Configura a aparência inicial da carta
            this.Virada = false;
            this.Encontrada = false;
            this.Font = new Font("Arial", 20, FontStyle.Bold);
            this.Size = new Size(60, 60); // Tamanho muito reduzido para garantir que todas as cartas apareçam na tela
            this.BackColor = corVerso;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 2;
            this.FlatAppearance.BorderColor = Color.Black;
            this.Text = "";
        }
        
        /// <summary>
        /// Vira a carta para mostrar seu conteúdo
        /// </summary>
        public void Virar()
        {
            if (!Encontrada && !Virada)
            {
                Virada = true;
                this.Text = conteudo;
                this.BackColor = corFrente;
            }
        }
        
        /// <summary>
        /// Desvira a carta para esconder seu conteúdo
        /// </summary>
        public void Desvirar()
        {
            if (!Encontrada && Virada)
            {
                Virada = false;
                this.Text = "";
                this.BackColor = corVerso;
            }
        }
        
        /// <summary>
        /// Marca a carta como encontrada (quando seu par é encontrado)
        /// </summary>
        public void MarcarEncontrada()
        {
            Encontrada = true;
            Virada = true;
            this.BackColor = corEncontrada;
            this.Enabled = false; // Desabilita o botão para não poder ser clicado novamente
        }
        
        /// <summary>
        /// Reinicia o estado da carta para o início do jogo
        /// </summary>
        public void Reiniciar()
        {
            Virada = false;
            Encontrada = false;
            this.Text = "";
            this.BackColor = corVerso;
            this.Enabled = true;
        }
    }
}
