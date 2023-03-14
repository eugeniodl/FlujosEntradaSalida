namespace ConsultaCredito
{
    partial class frmConsultaCredito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMostrar = new System.Windows.Forms.RichTextBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnCredito = new System.Windows.Forms.Button();
            this.btnDebito = new System.Windows.Forms.Button();
            this.btnCero = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMostrar
            // 
            this.txtMostrar.Location = new System.Drawing.Point(35, 32);
            this.txtMostrar.Name = "txtMostrar";
            this.txtMostrar.Size = new System.Drawing.Size(751, 185);
            this.txtMostrar.TabIndex = 0;
            this.txtMostrar.Text = "";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(37, 240);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(145, 23);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "Abrir archivo";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCredito
            // 
            this.btnCredito.Enabled = false;
            this.btnCredito.Location = new System.Drawing.Point(188, 240);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(145, 23);
            this.btnCredito.TabIndex = 2;
            this.btnCredito.Text = "Saldos con crédito";
            this.btnCredito.UseVisualStyleBackColor = true;
            this.btnCredito.Click += new System.EventHandler(this.obtenerSaldos_Click);
            // 
            // btnDebito
            // 
            this.btnDebito.Enabled = false;
            this.btnDebito.Location = new System.Drawing.Point(339, 240);
            this.btnDebito.Name = "btnDebito";
            this.btnDebito.Size = new System.Drawing.Size(145, 23);
            this.btnDebito.TabIndex = 3;
            this.btnDebito.Text = "Saldos con débito";
            this.btnDebito.UseVisualStyleBackColor = true;
            this.btnDebito.Click += new System.EventHandler(this.obtenerSaldos_Click);
            // 
            // btnCero
            // 
            this.btnCero.Enabled = false;
            this.btnCero.Location = new System.Drawing.Point(490, 240);
            this.btnCero.Name = "btnCero";
            this.btnCero.Size = new System.Drawing.Size(145, 23);
            this.btnCero.TabIndex = 4;
            this.btnCero.Text = "Saldos en cero";
            this.btnCero.UseVisualStyleBackColor = true;
            this.btnCero.Click += new System.EventHandler(this.obtenerSaldos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(641, 240);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(145, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmConsultaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 293);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCero);
            this.Controls.Add(this.btnDebito);
            this.Controls.Add(this.btnCredito);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.txtMostrar);
            this.Name = "frmConsultaCredito";
            this.Text = "Consulta de crédito";
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox txtMostrar;
        private Button btnAbrir;
        private Button btnCredito;
        private Button btnDebito;
        private Button btnCero;
        private Button btnSalir;
    }
}