using System;
using System.Configuration;

namespace TrilhasDaMemoria
{
    /// <summary>
    /// Classe para gerenciar as configurações do jogo
    /// </summary>
    public static class Configuracoes
    {
        /// <summary>
        /// Obtém o título do jogo definido no arquivo de configuração
        /// </summary>
        public static string TituloJogo
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["TituloJogo"] ?? "Trilhas da Memória";
                }
                catch
                {
                    return "Trilhas da Memória";
                }
            }
        }

        /// <summary>
        /// Obtém a versão do jogo definida no arquivo de configuração
        /// </summary>
        public static string VersaoJogo
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["VersaoJogo"] ?? "1.0.0";
                }
                catch
                {
                    return "1.0.0";
                }
            }
        }

        /// <summary>
        /// Obtém o tempo para virar as cartas definido no arquivo de configuração (em milissegundos)
        /// </summary>
        public static int TempoVirarCartas
        {
            get
            {
                try
                {
                    string valor = ConfigurationManager.AppSettings["TempoVirarCartas"] ?? "1000";
                    if (int.TryParse(valor, out int tempo) && tempo > 0)
                    {
                        return tempo;
                    }
                    return 1000; // Valor padrão: 1 segundo
                }
                catch
                {
                    return 1000; // Valor padrão: 1 segundo
                }
            }
        }

        /// <summary>
        /// Obtém o título completo do jogo com a versão
        /// </summary>
        public static string TituloCompletoJogo
        {
            get
            {
                return $"{TituloJogo} v{VersaoJogo}";
            }
        }
    }
}
