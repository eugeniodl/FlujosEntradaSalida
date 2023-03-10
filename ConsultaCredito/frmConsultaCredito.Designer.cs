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
            this.txtMostrar.Location = new System.Drawing.Point(11, 12);
            this.txtMostrar.Name = "txtMostrar";
            this.txtMostrar.Size = new System.Drawing.Size(667, 181);
            this.txtMostrar.TabIndex = 0;
            this.txtMostrar.Text = "";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(15, 221);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(128, 23);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "Abrir archivo";
            this.btnAbrir.UseVisualStyleBackColor = true;
            // 
            // btnCredito
            // 
            this.btnCredito.Enabled = false;
            this.btnCredito.Location = new System.Drawing.Point(149, 221);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(128, 23);
            this.btnCredito.TabIndex = 2;
            this.btnCredito.Text = "Saldos con créditos";
            this.btnCredito.UseVisualStyleBackColor = true;
            // 
            // btnDebito
            // 
            this.btnDebito.Enabled = false;
            this.btnDebito.Location = new System.Drawing.Point(283, 221);
            this.btnDebito.Name = "btnDebito";
            this.btnDebito.Size = new System.Drawing.Size(128, 23);
            this.btnDebito.TabIndex = 3;
            this.btnDebito.Text = "Saldos con débitos";
            this.btnDebito.UseVisualStyleBackColor = true;
            // 
            // btnCero
            // 
            this.btnCero.Enabled = false;
            this.btnCero.Location = new System.Drawing.Point(418, 221);
            this.btnCero.Name = "btnCero";
            this.btnCero.Size = new System.Drawing.Size(128, 23);
            this.btnCero.TabIndex = 4;
            this.btnCero.Text = "Saldos en cero";
            this.btnCero.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(552, 221);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(128, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmConsultaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 262);
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