namespace TrilhasDaMemoria
{
    partial class FormJogo
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpa os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se os recursos gerenciados devem ser descartados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuJogo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNovoJogo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVoltar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSair = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblPares = new System.Windows.Forms.Label();
            this.lblTentativas = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuJogo});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(600, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuJogo
            // 
            this.menuJogo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNovoJogo,
            this.menuItemVoltar,
            this.menuItemSair});
            this.menuJogo.Name = "menuJogo";
            this.menuJogo.Size = new System.Drawing.Size(45, 20);
            this.menuJogo.Text = "Jogo";
            // 
            // menuItemNovoJogo
            // 
            this.menuItemNovoJogo.Name = "menuItemNovoJogo";
            this.menuItemNovoJogo.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuItemNovoJogo.Size = new System.Drawing.Size(180, 22);
            this.menuItemNovoJogo.Text = "Novo Jogo";
            this.menuItemNovoJogo.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // menuItemVoltar
            // 
            this.menuItemVoltar.Name = "menuItemVoltar";
            this.menuItemVoltar.ShortcutKeys = System.Windows.Forms.Keys.Escape;
            this.menuItemVoltar.Size = new System.Drawing.Size(180, 22);
            this.menuItemVoltar.Text = "Voltar ao Menu";
            this.menuItemVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // menuItemSair
            // 
            this.menuItemSair.Name = "menuItemSair";
            this.menuItemSair.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuItemSair.Size = new System.Drawing.Size(180, 22);
            this.menuItemSair.Text = "Sair";
            this.menuItemSair.Click += new System.EventHandler(this.MenuItemSair_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblTempo);
            this.pnlInfo.Controls.Add(this.lblPares);
            this.pnlInfo.Controls.Add(this.lblTentativas);
            this.pnlInfo.Controls.Add(this.btnReiniciar);
            this.pnlInfo.Controls.Add(this.btnVoltar);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(0, 400);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(600, 60);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTempo.Location = new System.Drawing.Point(300, 20);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(120, 21);
            this.lblTempo.TabIndex = 4;
            this.lblTempo.Text = "Tempo: 00:00";
            // 
            // lblPares
            // 
            this.lblPares.AutoSize = true;
            this.lblPares.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPares.Location = new System.Drawing.Point(180, 20);
            this.lblPares.Name = "lblPares";
            this.lblPares.Size = new System.Drawing.Size(80, 21);
            this.lblPares.TabIndex = 3;
            this.lblPares.Text = "Pares: 0/0";
            // 
            // lblTentativas
            // 
            this.lblTentativas.AutoSize = true;
            this.lblTentativas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTentativas.Location = new System.Drawing.Point(10, 20);
            this.lblTentativas.Name = "lblTentativas";
            this.lblTentativas.Size = new System.Drawing.Size(100, 21);
            this.lblTentativas.TabIndex = 2;
            this.lblTentativas.Text = "Tentativas: 0";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReiniciar.BackColor = System.Drawing.Color.LightBlue;
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReiniciar.Location = new System.Drawing.Point(430, 10);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(80, 40);
            this.btnReiniciar.TabIndex = 1;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoltar.BackColor = System.Drawing.Color.LightCoral;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVoltar.Location = new System.Drawing.Point(520, 10);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 40);
            this.btnVoltar.TabIndex = 0;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trilhas da Memória";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormJogo_FormClosed);
            this.Load += new System.EventHandler(this.FormJogo_Load);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlInfo;
        private Button btnVoltar;
        private Button btnReiniciar;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuJogo;
        private ToolStripMenuItem menuItemNovoJogo;
        private ToolStripMenuItem menuItemVoltar;
        private ToolStripMenuItem menuItemSair;
        private Label lblTentativas;
        private Label lblPares;
        private Label lblTempo;
    }
}
