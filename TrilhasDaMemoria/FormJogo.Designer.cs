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
            // Removido o MenuStrip para evitar erros de compilação
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblPares = new System.Windows.Forms.Label();
            this.lblTentativas = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            // menuStrip removido
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // MenuStrip removido para evitar erros de compilação
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
            // Adicionar botão Sair
            this.btnSair = new System.Windows.Forms.Button();
            this.btnSair.Location = new System.Drawing.Point(100, 80);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(180, 50);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSair.Click += new System.EventHandler(this.MenuItemSair_Click);
            this.pnlInfo.Controls.Add(this.btnSair);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(0, 750);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1200, 150);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTempo.Location = new System.Drawing.Point(800, 25);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(220, 32);
            this.lblTempo.TabIndex = 4;
            this.lblTempo.Text = "Tempo: 00:00";
            // 
            // lblPares
            // 
            this.lblPares.AutoSize = true;
            this.lblPares.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPares.Location = new System.Drawing.Point(500, 25);
            this.lblPares.Name = "lblPares";
            this.lblPares.Size = new System.Drawing.Size(180, 32);
            this.lblPares.TabIndex = 3;
            this.lblPares.Text = "Pares: 0/0";
            // 
            // lblTentativas
            // 
            this.lblTentativas.AutoSize = true;
            this.lblTentativas.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTentativas.Location = new System.Drawing.Point(100, 25);
            this.lblTentativas.Name = "lblTentativas";
            this.lblTentativas.Size = new System.Drawing.Size(200, 32);
            this.lblTentativas.TabIndex = 2;
            this.lblTentativas.Text = "Tentativas: 0";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReiniciar.BackColor = System.Drawing.Color.LightBlue;
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReiniciar.Location = new System.Drawing.Point(500, 80);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(180, 50);
            this.btnReiniciar.TabIndex = 1;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoltar.BackColor = System.Drawing.Color.LightCoral;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVoltar.Location = new System.Drawing.Point(900, 80);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(180, 50);
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
            this.ClientSize = new System.Drawing.Size(1200, 900);
            this.Controls.Add(this.pnlInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trilhas da Memória";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormJogo_FormClosed);
            this.Load += new System.EventHandler(this.FormJogo_Load);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            // MenuStrip removido
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlInfo;
        private Button btnVoltar;
        private Button btnReiniciar;
        private Button btnSair;
        // MenuStrip removido para evitar erros de compilação
        private Label lblTentativas;
        private Label lblPares;
        private Label lblTempo;
    }
}
