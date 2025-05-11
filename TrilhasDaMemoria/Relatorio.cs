using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TrilhasDaMemoria
{
    /// <summary>
    /// Classe responsável por gerar relatórios do jogo
    /// </summary>
    public static class Relatorio
    {
        /// <summary>
        /// Gera um relatório com informações do jogo e capturas de tela
        /// </summary>
        /// <param name="diretorioDestino">Diretório onde o relatório será salvo</param>
        /// <param name="incluirCodigo">Indica se o código-fonte deve ser incluído no relatório</param>
        /// <returns>True se o relatório foi gerado com sucesso</returns>
        public static bool GerarRelatorio(string diretorioDestino, bool incluirCodigo = true)
        {
            try
            {
                // Cria o diretório de destino se não existir
                if (!Directory.Exists(diretorioDestino))
                {
                    Directory.CreateDirectory(diretorioDestino);
                }

                // Caminho do arquivo de relatório
                string caminhoRelatorio = Path.Combine(diretorioDestino, "Relatorio_TrilhasDaMemoria.html");

                // Cria o diretório para as imagens
                string diretorioImagens = Path.Combine(diretorioDestino, "Imagens");
                if (!Directory.Exists(diretorioImagens))
                {
                    Directory.CreateDirectory(diretorioImagens);
                }

                // Gera o conteúdo do relatório
                StringBuilder sb = new StringBuilder();

                // Cabeçalho HTML
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLine("<html lang=\"pt-br\">");
                sb.AppendLine("<head>");
                sb.AppendLine("    <meta charset=\"UTF-8\">");
                sb.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
                sb.AppendLine("    <title>Relatório - Trilhas da Memória</title>");
                sb.AppendLine("    <style>");
                sb.AppendLine("        body { font-family: Arial, sans-serif; line-height: 1.6; margin: 0; padding: 20px; }");
                sb.AppendLine("        h1 { color: #2c3e50; text-align: center; }");
                sb.AppendLine("        h2 { color: #3498db; margin-top: 30px; }");
                sb.AppendLine("        .container { max-width: 1200px; margin: 0 auto; }");
                sb.AppendLine("        .screenshot { margin: 20px 0; text-align: center; }");
                sb.AppendLine("        .screenshot img { max-width: 100%; border: 1px solid #ddd; box-shadow: 0 0 10px rgba(0,0,0,0.1); }");
                sb.AppendLine("        .code { background-color: #f8f8f8; border: 1px solid #ddd; padding: 15px; overflow-x: auto; font-family: 'Courier New', monospace; }");
                sb.AppendLine("        table { width: 100%; border-collapse: collapse; margin: 20px 0; }");
                sb.AppendLine("        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
                sb.AppendLine("        th { background-color: #f2f2f2; }");
                sb.AppendLine("    </style>");
                sb.AppendLine("</head>");
                sb.AppendLine("<body>");
                sb.AppendLine("    <div class=\"container\">");

                // Título e introdução
                sb.AppendLine("        <h1>Relatório do Projeto - Trilhas da Memória</h1>");
                sb.AppendLine("        <p>Este relatório apresenta o desenvolvimento e funcionamento do jogo educativo de memória \"Trilhas da Memória\", desenvolvido em C# utilizando Windows Forms.</p>");

                // Descrição do projeto
                sb.AppendLine("        <h2>1. Descrição do Projeto</h2>");
                sb.AppendLine("        <p>Trilhas da Memória é um jogo educativo que desafia os jogadores a encontrar pares de cartas correspondentes, exercitando a memória e a concentração. O jogo oferece três níveis de dificuldade e registra o desempenho do jogador.</p>");

                // Funcionalidades
                sb.AppendLine("        <h2>2. Funcionalidades</h2>");
                sb.AppendLine("        <ul>");
                sb.AppendLine("            <li>Seleção de nível de dificuldade (Fácil, Médio, Difícil)</li>");
                sb.AppendLine("            <li>Grade de cartas com lógica de memória</li>");
                sb.AppendLine("            <li>Contagem de tentativas e tempo</li>");
                sb.AppendLine("            <li>Verificação de acertos e mensagens de vitória</li>");
                sb.AppendLine("            <li>Sistema de reinício de jogo</li>");
                sb.AppendLine("            <li>Instalador executável</li>");
                sb.AppendLine("        </ul>");

                // Níveis de dificuldade
                sb.AppendLine("        <h2>3. Níveis de Dificuldade</h2>");
                sb.AppendLine("        <table>");
                sb.AppendLine("            <tr><th>Nível</th><th>Tamanho do Tabuleiro</th><th>Número de Cartas</th><th>Número de Pares</th></tr>");
                sb.AppendLine("            <tr><td>Fácil</td><td>4x4</td><td>16</td><td>8</td></tr>");
                sb.AppendLine("            <tr><td>Médio</td><td>6x4</td><td>24</td><td>12</td></tr>");
                sb.AppendLine("            <tr><td>Difícil</td><td>6x6</td><td>36</td><td>18</td></tr>");
                sb.AppendLine("        </table>");

                // Capturas de tela
                sb.AppendLine("        <h2>4. Capturas de Tela</h2>");

                // Aqui seriam adicionadas as capturas de tela
                sb.AppendLine("        <p>As capturas de tela serão geradas durante a execução do jogo.</p>");
                sb.AppendLine("        <div class=\"screenshot\">");
                sb.AppendLine("            <h3>Tela de Seleção de Nível</h3>");
                sb.AppendLine("            <p>Esta é a tela inicial onde o jogador seleciona o nível de dificuldade.</p>");
                sb.AppendLine("            <img src=\"Imagens/tela_selecao.png\" alt=\"Tela de Seleção de Nível\">");
                sb.AppendLine("        </div>");

                sb.AppendLine("        <div class=\"screenshot\">");
                sb.AppendLine("            <h3>Jogo em Andamento - Nível Fácil</h3>");
                sb.AppendLine("            <p>Exemplo do jogo no nível fácil com algumas cartas viradas.</p>");
                sb.AppendLine("            <img src=\"Imagens/jogo_facil.png\" alt=\"Jogo em Andamento - Nível Fácil\">");
                sb.AppendLine("        </div>");

                sb.AppendLine("        <div class=\"screenshot\">");
                sb.AppendLine("            <h3>Jogo em Andamento - Nível Médio</h3>");
                sb.AppendLine("            <p>Exemplo do jogo no nível médio com algumas cartas viradas.</p>");
                sb.AppendLine("            <img src=\"Imagens/jogo_medio.png\" alt=\"Jogo em Andamento - Nível Médio\">");
                sb.AppendLine("        </div>");

                sb.AppendLine("        <div class=\"screenshot\">");
                sb.AppendLine("            <h3>Jogo em Andamento - Nível Difícil</h3>");
                sb.AppendLine("            <p>Exemplo do jogo no nível difícil com algumas cartas viradas.</p>");
                sb.AppendLine("            <img src=\"Imagens/jogo_dificil.png\" alt=\"Jogo em Andamento - Nível Difícil\">");
                sb.AppendLine("        </div>");

                sb.AppendLine("        <div class=\"screenshot\">");
                sb.AppendLine("            <h3>Mensagem de Vitória</h3>");
                sb.AppendLine("            <p>Mensagem exibida quando o jogador completa o jogo.</p>");
                sb.AppendLine("            <img src=\"Imagens/vitoria.png\" alt=\"Mensagem de Vitória\">");
                sb.AppendLine("        </div>");

                // Estrutura do projeto
                sb.AppendLine("        <h2>5. Estrutura do Projeto</h2>");
                sb.AppendLine("        <p>O projeto foi estruturado com as seguintes classes principais:</p>");
                sb.AppendLine("        <ul>");
                sb.AppendLine("            <li><strong>FormSelecaoNivel</strong>: Tela inicial para seleção do nível de dificuldade</li>");
                sb.AppendLine("            <li><strong>FormJogo</strong>: Tela principal onde ocorre o jogo</li>");
                sb.AppendLine("            <li><strong>Carta</strong>: Classe que representa cada carta do jogo</li>");
                sb.AppendLine("            <li><strong>Dificuldade</strong>: Enum que define os níveis de dificuldade</li>");
                sb.AppendLine("            <li><strong>Instalador</strong>: Classe responsável por criar o pacote de instalação</li>");
                sb.AppendLine("            <li><strong>Relatorio</strong>: Classe responsável por gerar este relatório</li>");
                sb.AppendLine("        </ul>");

                // Código comentado
                if (incluirCodigo)
                {
                    sb.AppendLine("        <h2>6. Código Comentado</h2>");
                    sb.AppendLine("        <p>A seguir, são apresentados os principais trechos de código do projeto com comentários explicativos.</p>");

                    // Classe Carta
                    sb.AppendLine("        <h3>6.1. Classe Carta</h3>");
                    sb.AppendLine("        <p>Esta classe representa cada carta do jogo e herda de Button para facilitar a interação.</p>");
                    sb.AppendLine("        <div class=\"code\">");
                    sb.AppendLine("<pre>");
                    sb.AppendLine("public class Carta : Button");
                    sb.AppendLine("{");
                    sb.AppendLine("    // Propriedades da carta");
                    sb.AppendLine("    public int Id { get; private set; }        // ID único da carta");
                    sb.AppendLine("    public int IdPar { get; private set; }     // ID do par correspondente");
                    sb.AppendLine("    public bool Virada { get; private set; }   // Indica se a carta está virada");
                    sb.AppendLine("    public bool Encontrada { get; private set; } // Indica se a carta já foi encontrada");
                    sb.AppendLine("    ");
                    sb.AppendLine("    // Cores para os diferentes estados da carta");
                    sb.AppendLine("    private readonly Color corFrente;          // Cor quando a carta está virada");
                    sb.AppendLine("    private readonly Color corVerso = Color.SteelBlue; // Cor quando a carta está com o verso para cima");
                    sb.AppendLine("    private readonly Color corEncontrada = Color.LightGreen; // Cor quando o par foi encontrado");
                    sb.AppendLine("    ");
                    sb.AppendLine("    // Imagem ou texto a ser exibido na frente da carta");
                    sb.AppendLine("    private readonly string conteudo;");
                    sb.AppendLine("    ");
                    sb.AppendLine("    // Métodos para virar, desvirar e marcar cartas como encontradas...");
                    sb.AppendLine("}");
                    sb.AppendLine("</pre>");
                    sb.AppendLine("        </div>");

                    // Lógica do jogo
                    sb.AppendLine("        <h3>6.2. Lógica Principal do Jogo</h3>");
                    sb.AppendLine("        <p>Este trecho de código mostra a lógica principal do jogo quando uma carta é clicada.</p>");
                    sb.AppendLine("        <div class=\"code\">");
                    sb.AppendLine("<pre>");
                    sb.AppendLine("private void Carta_Click(object? sender, EventArgs e)");
                    sb.AppendLine("{");
                    sb.AppendLine("    // Verifica se o jogo está em andamento");
                    sb.AppendLine("    if (!jogoEmAndamento) return;");
                    sb.AppendLine("");
                    sb.AppendLine("    // Verifica se o sender é uma carta");
                    sb.AppendLine("    if (sender is not Carta carta) return;");
                    sb.AppendLine("");
                    sb.AppendLine("    // Verifica se a carta já está virada ou encontrada");
                    sb.AppendLine("    if (carta.Virada || carta.Encontrada) return;");
                    sb.AppendLine("");
                    sb.AppendLine("    // Verifica se já há duas cartas viradas");
                    sb.AppendLine("    if (primeiraCarta != null && segundaCarta != null) return;");
                    sb.AppendLine("");
                    sb.AppendLine("    // Vira a carta");
                    sb.AppendLine("    carta.Virar();");
                    sb.AppendLine("");
                    sb.AppendLine("    // Verifica se é a primeira ou a segunda carta");
                    sb.AppendLine("    if (primeiraCarta == null)");
                    sb.AppendLine("    {");
                    sb.AppendLine("        // É a primeira carta");
                    sb.AppendLine("        primeiraCarta = carta;");
                    sb.AppendLine("    }");
                    sb.AppendLine("    else");
                    sb.AppendLine("    {");
                    sb.AppendLine("        // É a segunda carta");
                    sb.AppendLine("        segundaCarta = carta;");
                    sb.AppendLine("        tentativas++;");
                    sb.AppendLine("");
                    sb.AppendLine("        // Verifica se as cartas formam um par");
                    sb.AppendLine("        if (primeiraCarta.IdPar == segundaCarta.IdPar)");
                    sb.AppendLine("        {");
                    sb.AppendLine("            // É um par!");
                    sb.AppendLine("            primeiraCarta.MarcarEncontrada();");
                    sb.AppendLine("            segundaCarta.MarcarEncontrada();");
                    sb.AppendLine("            primeiraCarta = null;");
                    sb.AppendLine("            segundaCarta = null;");
                    sb.AppendLine("            paresEncontrados++;");
                    sb.AppendLine("");
                    sb.AppendLine("            // Verifica se todos os pares foram encontrados");
                    sb.AppendLine("            if (paresEncontrados == totalPares)");
                    sb.AppendLine("            {");
                    sb.AppendLine("                // Jogo concluído!");
                    sb.AppendLine("                FinalizarJogo();");
                    sb.AppendLine("            }");
                    sb.AppendLine("        }");
                    sb.AppendLine("        else");
                    sb.AppendLine("        {");
                    sb.AppendLine("            // Não é um par, aguarda um tempo e desvira as cartas");
                    sb.AppendLine("            timerVirarCartas.Start();");
                    sb.AppendLine("        }");
                    sb.AppendLine("");
                    sb.AppendLine("        // Atualiza as informações do jogo");
                    sb.AppendLine("        AtualizarInformacoes();");
                    sb.AppendLine("    }");
                    sb.AppendLine("}");
                    sb.AppendLine("</pre>");
                    sb.AppendLine("        </div>");
                }

                // Conclusão
                sb.AppendLine("        <h2>7. Conclusão</h2>");
                sb.AppendLine("        <p>O projeto Trilhas da Memória foi desenvolvido com sucesso, atendendo a todos os requisitos especificados. O jogo oferece uma experiência educativa e divertida, com diferentes níveis de dificuldade para atender a diversos públicos.</p>");
                sb.AppendLine("        <p>O código foi estruturado de forma organizada e bem comentada, facilitando futuras manutenções e melhorias. O instalador permite uma fácil distribuição do jogo para os usuários finais.</p>");

                // Rodapé
                sb.AppendLine("        <hr>");
                sb.AppendLine($"        <p><em>Relatório gerado em: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}</em></p>");

                // Fechamento HTML
                sb.AppendLine("    </div>");
                sb.AppendLine("</body>");
                sb.AppendLine("</html>");

                // Escreve o conteúdo no arquivo
                File.WriteAllText(caminhoRelatorio, sb.ToString());

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao gerar o relatório: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        /// <summary>
        /// Captura a tela de um formulário e salva como imagem
        /// </summary>
        /// <param name="form">Formulário a ser capturado</param>
        /// <param name="caminhoImagem">Caminho onde a imagem será salva</param>
        /// <returns>True se a captura foi bem-sucedida</returns>
        public static bool CapturarTela(Form form, string caminhoImagem)
        {
            try
            {
                // Cria um bitmap do tamanho do formulário
                using (Bitmap bitmap = new Bitmap(form.Width, form.Height))
                {
                    // Desenha o formulário no bitmap
                    form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));

                    // Salva o bitmap como imagem
                    bitmap.Save(caminhoImagem);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao capturar a tela: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }
    }
}
