namespace OutlookDemo.UserControls
{
    partial class UC_Configuracion
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Configuracion));
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtBD = new System.Windows.Forms.TextBox();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.uC_Chat3 = new OutlookDemo.UserControls.UC_Chat();
            this.uC_Chat2 = new OutlookDemo.UserControls.UC_Chat();
            this.uC_Chat1 = new OutlookDemo.UserControls.UC_Chat();
            this.uC_Chat4 = new OutlookDemo.UserControls.UC_Chat();
            this.SuspendLayout();
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 22;
            this.guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button2.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button2.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button2.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.CheckedState.Image")));
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(155)))));
            this.guna2Button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button2.Location = new System.Drawing.Point(369, 317);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(149, 43);
            this.guna2Button2.TabIndex = 3;
            this.guna2Button2.Text = "Conectar";
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(448, 183);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(136, 23);
            this.txtNombre.TabIndex = 7;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(448, 212);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(136, 23);
            this.txtUsuario.TabIndex = 9;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(448, 241);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(136, 23);
            this.txtContraseña.TabIndex = 11;
            // 
            // txtBD
            // 
            this.txtBD.Location = new System.Drawing.Point(448, 270);
            this.txtBD.Name = "txtBD";
            this.txtBD.Size = new System.Drawing.Size(136, 23);
            this.txtBD.TabIndex = 13;
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 5;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.White;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.ImageSize = new System.Drawing.Size(90, 90);
            this.guna2Button3.Location = new System.Drawing.Point(344, 88);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(210, 86);
            this.guna2Button3.TabIndex = 14;
            // 
            // uC_Chat3
            // 
            this.uC_Chat3.BackColor = System.Drawing.Color.White;
            this.uC_Chat3.ChatContent = "";
            this.uC_Chat3.ChatImage = null;
            this.uC_Chat3.ChatTitle = "Nombre Base Datos";
            this.uC_Chat3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uC_Chat3.Location = new System.Drawing.Point(216, 258);
            this.uC_Chat3.Name = "uC_Chat3";
            this.uC_Chat3.Size = new System.Drawing.Size(218, 35);
            this.uC_Chat3.TabIndex = 12;
            // 
            // uC_Chat2
            // 
            this.uC_Chat2.BackColor = System.Drawing.Color.White;
            this.uC_Chat2.ChatContent = "";
            this.uC_Chat2.ChatImage = null;
            this.uC_Chat2.ChatTitle = "Contraseña Servidor";
            this.uC_Chat2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uC_Chat2.Location = new System.Drawing.Point(216, 228);
            this.uC_Chat2.Name = "uC_Chat2";
            this.uC_Chat2.Size = new System.Drawing.Size(218, 35);
            this.uC_Chat2.TabIndex = 10;
            // 
            // uC_Chat1
            // 
            this.uC_Chat1.BackColor = System.Drawing.Color.White;
            this.uC_Chat1.ChatContent = "";
            this.uC_Chat1.ChatImage = null;
            this.uC_Chat1.ChatTitle = "Usuario Servidor";
            this.uC_Chat1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uC_Chat1.Location = new System.Drawing.Point(216, 199);
            this.uC_Chat1.Name = "uC_Chat1";
            this.uC_Chat1.Size = new System.Drawing.Size(218, 35);
            this.uC_Chat1.TabIndex = 8;
            // 
            // uC_Chat4
            // 
            this.uC_Chat4.BackColor = System.Drawing.Color.White;
            this.uC_Chat4.ChatContent = "";
            this.uC_Chat4.ChatImage = null;
            this.uC_Chat4.ChatTitle = "Nombre Servidor";
            this.uC_Chat4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uC_Chat4.Location = new System.Drawing.Point(216, 171);
            this.uC_Chat4.Name = "uC_Chat4";
            this.uC_Chat4.Size = new System.Drawing.Size(218, 35);
            this.uC_Chat4.TabIndex = 6;
            this.uC_Chat4.Load += new System.EventHandler(this.uC_Chat4_Load);
            // 
            // UC_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.txtBD);
            this.Controls.Add(this.uC_Chat3);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.uC_Chat2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.uC_Chat1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.uC_Chat4);
            this.Controls.Add(this.guna2Button2);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ForeColor = System.Drawing.Color.Coral;
            this.Location = new System.Drawing.Point(312, 97);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Configuracion";
            this.Size = new System.Drawing.Size(801, 511);
            this.Load += new System.EventHandler(this.UC_Configuracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private UC_Chat uC_Chat4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUsuario;
        private UC_Chat uC_Chat1;
        private System.Windows.Forms.TextBox txtContraseña;
        private UC_Chat uC_Chat2;
        private System.Windows.Forms.TextBox txtBD;
        private UC_Chat uC_Chat3;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}
