using System;
using System.IO;
using System.Windows.Forms;

namespace TrilhasDaMemoria
{
    /// <summary>
    /// Classe responsável por criar um instalador para o jogo
    /// </summary>
    public static class Instalador
    {
        /// <summary>
        /// Cria um pacote de instalação do jogo
        /// </summary>
        /// <param name="diretorioDestino">Diretório onde o instalador será criado</param>
        /// <returns>True se o instalador foi criado com sucesso</returns>
        public static bool CriarInstalador(string diretorioDestino)
        {
            try
            {
                // Cria o diretório de destino se não existir
                if (!Directory.Exists(diretorioDestino))
                {
                    Directory.CreateDirectory(diretorioDestino);
                }

                // Caminho do diretório do aplicativo
                string diretorioApp = Application.StartupPath;

                // Cria o diretório para o instalador
                string diretorioInstalador = Path.Combine(diretorioDestino, "Instalador_TrilhasDaMemoria");
                if (!Directory.Exists(diretorioInstalador))
                {
                    Directory.CreateDirectory(diretorioInstalador);
                }

                // Copia os arquivos necessários para o diretório do instalador
                CopiarArquivosInstalador(diretorioApp, diretorioInstalador);

                // Cria um arquivo batch para instalação
                CriarArquivoBatchInstalacao(diretorioInstalador);

                // Cria um arquivo readme com instruções
                CriarArquivoReadme(diretorioInstalador);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao criar o instalador: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        /// <summary>
        /// Copia os arquivos necessários para o diretório do instalador
        /// </summary>
        /// <param name="diretorioOrigem">Diretório de origem dos arquivos</param>
        /// <param name="diretorioDestino">Diretório de destino para os arquivos</param>
        private static void CopiarArquivosInstalador(string diretorioOrigem, string diretorioDestino)
        {
            // Copia o executável principal
            File.Copy(
                Path.Combine(diretorioOrigem, "TrilhasDaMemoria.exe"),
                Path.Combine(diretorioDestino, "TrilhasDaMemoria.exe"),
                true);

            // Copia as DLLs necessárias
            string[] arquivosDll = Directory.GetFiles(diretorioOrigem, "*.dll");
            foreach (string arquivoDll in arquivosDll)
            {
                string nomeArquivo = Path.GetFileName(arquivoDll);
                File.Copy(
                    arquivoDll,
                    Path.Combine(diretorioDestino, nomeArquivo),
                    true);
            }

            // Copia os arquivos de recursos (se existirem)
            string diretorioRecursos = Path.Combine(diretorioOrigem, "Resources");
            if (Directory.Exists(diretorioRecursos))
            {
                string diretorioRecursosDestino = Path.Combine(diretorioDestino, "Resources");
                if (!Directory.Exists(diretorioRecursosDestino))
                {
                    Directory.CreateDirectory(diretorioRecursosDestino);
                }

                string[] arquivosRecursos = Directory.GetFiles(diretorioRecursos);
                foreach (string arquivoRecurso in arquivosRecursos)
                {
                    string nomeArquivo = Path.GetFileName(arquivoRecurso);
                    File.Copy(
                        arquivoRecurso,
                        Path.Combine(diretorioRecursosDestino, nomeArquivo),
                        true);
                }
            }
        }

        /// <summary>
        /// Cria um arquivo batch para facilitar a instalação
        /// </summary>
        /// <param name="diretorioInstalador">Diretório onde o arquivo será criado</param>
        private static void CriarArquivoBatchInstalacao(string diretorioInstalador)
        {
            string caminhoArquivoBatch = Path.Combine(diretorioInstalador, "Instalar.bat");

            // Conteúdo do arquivo batch
            string conteudoBatch =
                "@echo off\n" +
                "echo Instalando Trilhas da Memória...\n" +
                "echo.\n" +
                "set /p destino=Digite o caminho para instalar (ou pressione Enter para instalar em %%ProgramFiles%%\\TrilhasDaMemoria): \n" +
                "if \"%%destino%%\"==\"\" set destino=%%ProgramFiles%%\\TrilhasDaMemoria\n" +
                "echo.\n" +
                "echo Instalando em: %%destino%%\n" +
                "echo.\n" +
                "if not exist \"%%destino%%\" mkdir \"%%destino%%\"\n" +
                "xcopy /s /y *.* \"%%destino%%\" /exclude:Instalar.bat\n" +
                "echo.\n" +
                "echo Criando atalho na área de trabalho...\n" +
                "echo Set oWS = WScript.CreateObject(\"WScript.Shell\") > %%temp%%\\createShortcut.vbs\n" +
                "echo sLinkFile = \"%%userprofile%%\\Desktop\\Trilhas da Memória.lnk\" >> %%temp%%\\createShortcut.vbs\n" +
                "echo Set oLink = oWS.CreateShortcut(sLinkFile) >> %%temp%%\\createShortcut.vbs\n" +
                "echo oLink.TargetPath = \"%%destino%%\\TrilhasDaMemoria.exe\" >> %%temp%%\\createShortcut.vbs\n" +
                "echo oLink.Save >> %%temp%%\\createShortcut.vbs\n" +
                "cscript //nologo %%temp%%\\createShortcut.vbs\n" +
                "del %%temp%%\\createShortcut.vbs\n" +
                "echo.\n" +
                "echo Instalação concluída com sucesso!\n" +
                "echo.\n" +
                "echo Pressione qualquer tecla para sair...\n" +
                "pause > nul\n";

            // Escreve o conteu00fado no arquivo
            File.WriteAllText(caminhoArquivoBatch, conteudoBatch);
        }

        /// <summary>
        /// Cria um arquivo readme com instruções de instalação
        /// </summary>
        /// <param name="diretorioInstalador">Diretório onde o arquivo será criado</param>
        private static void CriarArquivoReadme(string diretorioInstalador)
        {
            string caminhoArquivoReadme = Path.Combine(diretorioInstalador, "LEIAME.txt");

            // Conteúdo do arquivo readme
            string conteudoReadme =
                "=== TRILHAS DA MEMÓRIA - INSTRUÇÕES DE INSTALAÇÃO ===\n\n" +
                "1. Para instalar o jogo, execute o arquivo 'Instalar.bat'.\n" +
                "2. Siga as instruções na tela para escolher o diretório de instalação.\n" +
                "3. Um atalho será criado na área de trabalho.\n\n" +
                "Requisitos mínimos:\n" +
                "- Windows 7 ou superior\n" +
                "- .NET 6.0 ou superior\n" +
                "- Resolução mínima de tela: 800x600\n\n" +
                "Em caso de problemas, verifique se o .NET 6.0 está instalado em seu computador.\n" +
                "Você pode baixar o .NET 6.0 em: https://dotnet.microsoft.com/download/dotnet/6.0\n\n" +
                "=== COMO JOGAR ===\n\n" +
                "1. Inicie o aplicativo e selecione o nível de dificuldade\n" +
                "2. Clique nas cartas para virá-las\n" +
                "3. Tente encontrar todos os pares correspondentes\n" +
                "4. O jogo termina quando todos os pares forem encontrados\n\n" +
                "Divirta-se!\n";

            // Escreve o conteudo no arquivo
            File.WriteAllText(caminhoArquivoReadme, conteudoReadme);
        }
    }
}
