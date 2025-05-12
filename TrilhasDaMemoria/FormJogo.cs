using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrilhasDaMemoria
{
    public partial class FormJogo : Form
    {
        // Propriedades do jogo
        private readonly Dificuldade dificuldade;
        private readonly List<Carta> cartas = new List<Carta>();
        private readonly Random random = new Random();
        private Carta? primeiraCarta = null;
        private Carta? segundaCarta = null;
        private int tentativas = 0;
        private int paresEncontrados = 0;
        private int totalPares = 0;
        private bool jogoEmAndamento = false;
        private System.Windows.Forms.Timer timerVirarCartas;
        private System.Windows.Forms.Timer timerJogo;
        private int tempoDecorrido = 0; // em segundos

        // Cores para as cartas
        private readonly Color[] cores = new Color[]
        {
            Color.LightPink, Color.LightBlue, Color.LightYellow,
            Color.LightGreen, Color.LightSalmon, Color.LightCoral,
            Color.Plum, Color.PeachPuff, Color.PaleTurquoise,
            Color.PaleGoldenrod, Color.MediumPurple, Color.MediumAquamarine,
            Color.LightSkyBlue, Color.LightSeaGreen, Color.LightGoldenrodYellow,
            Color.Khaki, Color.HotPink, Color.GreenYellow
        };

        // Simbolos para as cartas
        private readonly string[] simbolos = new string[]
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I",
            "J", "K", "L", "M", "N", "O", "P", "Q", "R"
        };

        /// <summary>
        /// Construtor do formulário de jogo
        /// </summary>
        /// <param name="dificuldade">Nível de dificuldade selecionado</param>
        public FormJogo(Dificuldade dificuldade)
        {
            InitializeComponent();
            this.dificuldade = dificuldade;

            // Configura os timers
            timerVirarCartas = new System.Windows.Forms.Timer();
            timerVirarCartas.Interval = 1000; // 1 segundo
            timerVirarCartas.Tick += TimerVirarCartas_Tick;

            timerJogo = new System.Windows.Forms.Timer();
            timerJogo.Interval = 1000; // 1 segundo
            timerJogo.Tick += TimerJogo_Tick;
        }

        /// <summary>
        /// Evento disparado quando o formulário é carregado
        /// </summary>
        private void FormJogo_Load(object sender, EventArgs e)
        {
            // Configura o formulário com base na dificuldade
            ConfigurarJogo();
            
            // Inicia o jogo
            IniciarJogo();
        }

        /// <summary>
        /// Configura o jogo com base na dificuldade selecionada
        /// </summary>
        private void ConfigurarJogo()
        {
            int linhas, colunas;

            // Define o número de linhas e colunas com base na dificuldade
            switch (dificuldade)
            {
                case Dificuldade.Facil:
                    linhas = 4;
                    colunas = 4;
                    this.Text = "Trilhas da Memória - Nível Fácil";
                    break;
                case Dificuldade.Medio:
                    linhas = 4;
                    colunas = 6;
                    this.Text = "Trilhas da Memória - Nível Médio";
                    break;
                case Dificuldade.Dificil:
                    linhas = 6;
                    colunas = 6;
                    this.Text = "Trilhas da Memória - Nível Difícil";
                    break;
                default:
                    linhas = 4;
                    colunas = 4;
                    this.Text = "Trilhas da Memória";
                    break;
            }

            // Calcula o número total de pares
            totalPares = (linhas * colunas) / 2;

            // Ajusta o tamanho do formulário com base no nível de dificuldade
            switch (dificuldade)
            {
                case Dificuldade.Facil:
                    this.ClientSize = new Size(600, 600);
                    break;
                case Dificuldade.Medio:
                    this.ClientSize = new Size(600, 600);
                    break;
                case Dificuldade.Dificil:
                    // Tela maior para o modo difícil
                    this.ClientSize = new Size(760, 760);
                    break;
                default:
                    this.ClientSize = new Size(900, 900);
                    break;
            }
            
            // Ajusta o tamanho do painel de informações para ocupar toda a largura da tela
            this.pnlInfo.Width = this.ClientSize.Width;
            
            // Ajusta a posição dos botões com base no nível de dificuldade
            AjustarPosicaoBotoes(dificuldade);

            // Cria e posiciona as cartas
            CriarCartas(linhas, colunas);

            // Atualiza as informações do jogo
            AtualizarInformacoes();
        }

        /// <summary>
        /// Cria as cartas do jogo
        /// </summary>
        /// <param name="linhas">Número de linhas</param>
        /// <param name="colunas">Número de colunas</param>
        private void CriarCartas(int linhas, int colunas)
        {
            // Limpa a lista de cartas existentes
            foreach (Carta carta in cartas)
            {
                this.Controls.Remove(carta);
            }
            cartas.Clear();

            // Cria os pares de cartas
            for (int i = 0; i < totalPares; i++)
            {
                // Cria duas cartas com o mesmo idPar
                Carta carta1 = new Carta(i * 2, i, simbolos[i], cores[i]);
                Carta carta2 = new Carta(i * 2 + 1, i, simbolos[i], cores[i]);

                // Adiciona as cartas à lista
                cartas.Add(carta1);
                cartas.Add(carta2);

                // Configura o evento de clique para as cartas
                carta1.Click += Carta_Click;
                carta2.Click += Carta_Click;
            }

            // Embaralha as cartas
            EmbaralharCartas();

            // Posiciona as cartas no formulário
            int index = 0;
            for (int linha = 0; linha < linhas; linha++)
            {
                for (int coluna = 0; coluna < colunas; coluna++)
                {
                    if (index < cartas.Count)
                    {
                        Carta carta = cartas[index];
                        // Ajusta o espaçamento das cartas de acordo com o nível de dificuldade
                        int espacoEntreCartas = 0;
                        
                        // Ajusta o espaçamento com base no número de cartas (nível de dificuldade)
                        switch (totalPares * 2) // Total de cartas
                        {
                            case 8: // Fácil (4x2)
                                espacoEntreCartas = 70; // Espaçamento mínimo para deixar as cartas extremamente juntas
                                break;
                            case 18: // Médio (6x3)
                                espacoEntreCartas = 65; // Espaçamento mínimo para deixar as cartas extremamente juntas
                                break;
                            case 32: // Difícil (8x4)
                                espacoEntreCartas = 40; // Espaçamento mínimo absoluto para deixar as cartas coladas
                                break;
                            default:
                                espacoEntreCartas = 100; // Valor padrão para outros casos
                                break;
                        }
                        
                        // Calcula o espaço disponível para as cartas com base no tamanho da tela
                        int areaJogoLargura = this.ClientSize.Width;
                        int areaJogoAltura = this.ClientSize.Height - 150; // Altura da tela menos o painel e margem
                        
                        // Centraliza as cartas na área disponível
                        int margemHorizontal = (areaJogoLargura - (colunas * espacoEntreCartas)) / 2;
                        int margemVertical = (areaJogoAltura - (linhas * espacoEntreCartas)) / 2;
                        
                        // Garante que as margens não sejam negativas
                        margemHorizontal = Math.Max(margemHorizontal, 20);
                        margemVertical = Math.Max(margemVertical, 20);
                        
                        carta.Location = new Point(coluna * espacoEntreCartas + margemHorizontal, linha * espacoEntreCartas + margemVertical);
                        this.Controls.Add(carta);
                        index++;
                    }
                }
            }
        }

        /// <summary>
        /// Embaralha as cartas aleatoriamente
        /// </summary>
        private void EmbaralharCartas()
        {
            // Embaralha a lista de cartas usando o algoritmo Fisher-Yates
            int n = cartas.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Carta carta = cartas[k];
                cartas[k] = cartas[n];
                cartas[n] = carta;
            }
        }

        /// <summary>
        /// Inicia um novo jogo
        /// </summary>
        private void IniciarJogo()
        {
            // Reinicia as variáveis do jogo
            primeiraCarta = null;
            segundaCarta = null;
            tentativas = 0;
            paresEncontrados = 0;
            tempoDecorrido = 0;
            jogoEmAndamento = true;

            // Reinicia todas as cartas
            foreach (Carta carta in cartas)
            {
                carta.Reiniciar();
            }

            // Embaralha as cartas
            EmbaralharCartas();

            // Atualiza as informações do jogo
            AtualizarInformacoes();

            // Inicia o timer do jogo
            timerJogo.Start();
        }

        /// <summary>
        /// Atualiza as informações exibidas no formulário
        /// </summary>
        private void AtualizarInformacoes()
        {
            lblTentativas.Text = $"Tentativas: {tentativas}";
            lblPares.Text = $"Pares: {paresEncontrados}/{totalPares}";
            lblTempo.Text = $"Tempo: {tempoDecorrido / 60:00}:{tempoDecorrido % 60:00}";
        }

        /// <summary>
        /// Evento disparado quando uma carta é clicada
        /// </summary>
        private void Carta_Click(object? sender, EventArgs e)
        {
            // Verifica se o jogo está em andamento
            if (!jogoEmAndamento) return;

            // Verifica se o sender é uma carta
            if (sender is not Carta carta) return;

            // Verifica se a carta já está virada ou encontrada
            if (carta.Virada || carta.Encontrada) return;

            // Verifica se já há duas cartas viradas
            if (primeiraCarta != null && segundaCarta != null) return;

            // Vira a carta
            carta.Virar();

            // Verifica se é a primeira ou a segunda carta
            if (primeiraCarta == null)
            {
                // É a primeira carta
                primeiraCarta = carta;
            }
            else
            {
                // É a segunda carta
                segundaCarta = carta;
                tentativas++;

                // Verifica se as cartas formam um par
                if (primeiraCarta.IdPar == segundaCarta.IdPar)
                {
                    // É um par!
                    primeiraCarta.MarcarEncontrada();
                    segundaCarta.MarcarEncontrada();
                    primeiraCarta = null;
                    segundaCarta = null;
                    paresEncontrados++;

                    // Verifica se todos os pares foram encontrados
                    if (paresEncontrados == totalPares)
                    {
                        // Jogo concluído!
                        FinalizarJogo();
                    }
                }
                else
                {
                    // Não é um par, aguarda um tempo e desvira as cartas
                    timerVirarCartas.Start();
                }

                // Atualiza as informações do jogo
                AtualizarInformacoes();
            }
        }

        /// <summary>
        /// Evento disparado pelo timer para desvirar as cartas que não formam um par
        /// </summary>
        private void TimerVirarCartas_Tick(object? sender, EventArgs e)
        {
            // Para o timer
            timerVirarCartas.Stop();

            // Desvira as cartas
            if (primeiraCarta != null && segundaCarta != null)
            {
                primeiraCarta.Desvirar();
                segundaCarta.Desvirar();
                primeiraCarta = null;
                segundaCarta = null;
            }
        }

        /// <summary>
        /// Evento disparado pelo timer do jogo para atualizar o tempo
        /// </summary>
        private void TimerJogo_Tick(object? sender, EventArgs e)
        {
            // Incrementa o tempo decorrido
            tempoDecorrido++;

            // Atualiza as informações do jogo
            AtualizarInformacoes();
        }

        /// <summary>
        /// Finaliza o jogo quando todos os pares são encontrados
        /// </summary>
        private void FinalizarJogo()
        {
            // Para o timer do jogo
            timerJogo.Stop();
            jogoEmAndamento = false;

            // Calcula o tempo em minutos e segundos
            int minutos = tempoDecorrido / 60;
            int segundos = tempoDecorrido % 60;

            // Exibe a mensagem de vitória
            MessageBox.Show(
                $"Parabéns! Você completou o jogo!\n\n" +
                $"Nível: {dificuldade}\n" +
                $"Tentativas: {tentativas}\n" +
                $"Tempo: {minutos:00}:{segundos:00}",
                "Trilhas da Memória - Vitória!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Evento disparado quando o botão Reiniciar é clicado
        /// </summary>
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Para o timer do jogo
            timerJogo.Stop();

            // Inicia um novo jogo
            IniciarJogo();
        }

        /// <summary>
        /// Evento disparado quando o botão Voltar é clicado
        /// </summary>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Para o timer do jogo
            timerJogo.Stop();

            // Volta para a tela de seleção de nível
            FormSelecaoNivel formSelecaoNivel = new FormSelecaoNivel();
            formSelecaoNivel.Show();
            this.Close();
        }

        /// <summary>
        /// Evento disparado quando o item de menu Sair é clicado
        /// </summary>
        private void MenuItemSair_Click(object sender, EventArgs e)
        {
            // Encerra a aplicação
            Application.Exit();
        }

        /// <summary>
        /// Evento disparado quando o formulário é fechado
        /// </summary>
        private void FormJogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Verifica se a tela de seleção de nível está aberta
            bool telaSelecaoAberta = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormSelecaoNivel)
                {
                    telaSelecaoAberta = true;
                    break;
                }
            }

            // Se a tela de seleção não estiver aberta, encerra a aplicação
            if (!telaSelecaoAberta)
            {
                Application.Exit();
            }
        }
        
        /// <summary>
        /// Ajusta a posição dos botões com base no nível de dificuldade
        /// </summary>
        /// <remarks>
        /// Para ajustar manualmente a posição dos botões:
        /// - Valores maiores de X movem o botão para a direita
        /// - Valores menores de X movem o botão para a esquerda
        /// - A coordenada Y (55) define a altura do botão no painel
        /// </remarks>
        private void AjustarPosicaoBotoes(Dificuldade nivel)
        {
            // Calcula a largura disponível para os botões
            int larguraDisponivel = this.pnlInfo.Width;
            
            // AJUSTE GLOBAL DA POSIÇÃO VERTICAL DOS BOTÕES
            // Altere este valor para mover todos os botões para cima ou para baixo
            int posicaoVerticalBotoes = 70;  // Valor original era 55, valores maiores movem para baixo
            
            // DEFINIÇÕES DE POSIÇÃO BASEADAS NO MODO FÁCIL
            // Posições de referência no modo Fácil (tela de 600x600)
            int facil_reiniciar_x = 35;   // Botão Reiniciar no modo Fácil
            int facil_voltar_x = 225;     // Botão Voltar no modo Fácil
            int facil_sair_x = 440;       // Botão Sair no modo Fácil
            
            // DEFINIÇÕES MANUAIS PARA O MODO DIFÍCIL
            // Você pode ajustar estas posições manualmente para o modo difícil
            int dificil_reiniciar_x = 38;  // Botão Reiniciar no modo Difícil
            int dificil_voltar_x = 230;     // Botão Voltar no modo Difícil
            int dificil_sair_x = 440;       // Botão Sair no modo Difícil
            
            // Largura de referência do modo Fácil (600 pixels)
            int larguraReferencia = 600;
            
            // Calcula as proporções relativas dos botões no modo Fácil
            double proporcaoReiniciar = (double)facil_reiniciar_x / larguraReferencia;
            double proporcaoVoltar = (double)facil_voltar_x / larguraReferencia;
            double proporcaoSair = (double)facil_sair_x / larguraReferencia;
            
            // Calcula as posições proporcionais para a tela atual
            int posicaoReiniciar = (int)(larguraDisponivel * proporcaoReiniciar);
            int posicaoVoltar = (int)(larguraDisponivel * proporcaoVoltar);
            int posicaoSair = (int)(larguraDisponivel * proporcaoSair);
            
            // Garante que os botões não fiquem fora da tela
            posicaoReiniciar = Math.Max(20, posicaoReiniciar);
            posicaoVoltar = Math.Max(posicaoReiniciar + 110, posicaoVoltar);
            posicaoSair = Math.Min(larguraDisponivel - 120, Math.Max(posicaoVoltar + 110, posicaoSair));
            
            // Define as posições dos botões com base no nível
            switch (nivel)
            {
                case Dificuldade.Facil:
                    // No modo fácil, usa as posições de referência
                    this.btnReiniciar.Location = new Point(facil_reiniciar_x, posicaoVerticalBotoes);
                    this.btnVoltar.Location = new Point(facil_voltar_x, posicaoVerticalBotoes);
                    this.btnSair.Location = new Point(facil_sair_x, posicaoVerticalBotoes);
                    break;
                    
                case Dificuldade.Medio:
                    // No modo médio, usa as proporções do modo fácil
                    this.btnReiniciar.Location = new Point(posicaoReiniciar, posicaoVerticalBotoes);
                    this.btnVoltar.Location = new Point(posicaoVoltar, posicaoVerticalBotoes);
                    this.btnSair.Location = new Point(posicaoSair, posicaoVerticalBotoes);
                    break;
                    
                case Dificuldade.Dificil:
                    // No modo difícil, usa as posições manuais definidas acima
                    this.btnReiniciar.Location = new Point(dificil_reiniciar_x, posicaoVerticalBotoes);
                    this.btnVoltar.Location = new Point(dificil_voltar_x, posicaoVerticalBotoes);
                    this.btnSair.Location = new Point(dificil_sair_x, posicaoVerticalBotoes);
                    break;
                    
                default:
                    // Posição padrão (usa as proporções do modo fácil)
                    this.btnReiniciar.Location = new Point(posicaoReiniciar, posicaoVerticalBotoes);
                    this.btnVoltar.Location = new Point(posicaoVoltar, posicaoVerticalBotoes);
                    this.btnSair.Location = new Point(posicaoSair, posicaoVerticalBotoes);
                    break;
            }
        }
    }
}
