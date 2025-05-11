namespace TrilhasDaMemoria
{
    internal static class Program
    {
        /// <summary>
        ///  Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Para dar suporte a Windows Visual Styles.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            
            // Inicia o aplicativo com o formulário de seleção de nível
            Application.Run(new FormSelecaoNivel());
        }
    }
}
