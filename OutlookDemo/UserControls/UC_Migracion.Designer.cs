namespace OutlookDemo.UserControls
{
    partial class UC_Migracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Migracion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPestana = new System.Windows.Forms.TextBox();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listError = new System.Windows.Forms.ListBox();
            this.btnComparar = new Guna.UI2.WinForms.Guna2Button();
            this.btnMigrar = new Guna.UI2.WinForms.Guna2Button();
            this.btnValidarExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnCargarExcel = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPestana
            // 
            this.txtPestana.Location = new System.Drawing.Point(435, 20);
            this.txtPestana.Name = "txtPestana";
            this.txtPestana.Size = new System.Drawing.Size(150, 23);
            this.txtPestana.TabIndex = 9;
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.btnLimpiar);
            this.PanelHeader.Controls.Add(this.dataGridView1);
            this.PanelHeader.Controls.Add(this.listError);
            this.PanelHeader.Controls.Add(this.btnComparar);
            this.PanelHeader.Controls.Add(this.btnMigrar);
            this.PanelHeader.Controls.Add(this.btnValidarExcel);
            this.PanelHeader.Controls.Add(this.btnCargarExcel);
            this.PanelHeader.Controls.Add(this.label3);
            this.PanelHeader.Controls.Add(this.comboBox1);
            this.PanelHeader.Controls.Add(this.txtArchivo);
            this.PanelHeader.Controls.Add(this.label1);
            this.PanelHeader.Controls.Add(this.label2);
            this.PanelHeader.Controls.Add(this.txtPestana);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(900, 608);
            this.PanelHeader.TabIndex = 11;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BorderRadius = 5;
            this.btnLimpiar.CheckedState.Parent = this.btnLimpiar;
            this.btnLimpiar.CustomImages.Parent = this.btnLimpiar;
            this.btnLimpiar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.HoverState.Parent = this.btnLimpiar;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(668, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.ShadowDecoration.Parent = this.btnLimpiar;
            this.btnLimpiar.Size = new System.Drawing.Size(31, 36);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 323);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(900, 285);
            this.dataGridView1.TabIndex = 0;
            // 
            // listError
            // 
            this.listError.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.listError.FormattingEnabled = true;
            this.listError.ItemHeight = 17;
            this.listError.Location = new System.Drawing.Point(2, 172);
            this.listError.Name = "listError";
            this.listError.Size = new System.Drawing.Size(1012, 157);
            this.listError.TabIndex = 21;
            this.listError.SelectedIndexChanged += new System.EventHandler(this.listError_SelectedIndexChanged);
            // 
            // btnComparar
            // 
            this.btnComparar.BackColor = System.Drawing.Color.Transparent;
            this.btnComparar.BorderRadius = 22;
            this.btnComparar.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnComparar.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnComparar.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnComparar.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnComparar.CheckedState.Image")));
            this.btnComparar.CheckedState.Parent = this.btnComparar;
            this.btnComparar.CustomImages.Parent = this.btnComparar;
            this.btnComparar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(155)))));
            this.btnComparar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComparar.ForeColor = System.Drawing.Color.White;
            this.btnComparar.HoverState.Parent = this.btnComparar;
            this.btnComparar.Image = global::OutlookDemo.Properties.Resources.excel;
            this.btnComparar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnComparar.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnComparar.Location = new System.Drawing.Point(667, 127);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.ShadowDecoration.Parent = this.btnComparar;
            this.btnComparar.Size = new System.Drawing.Size(179, 43);
            this.btnComparar.TabIndex = 20;
            this.btnComparar.Text = "Comparar Excel || Base Datos";
            this.btnComparar.UseTransparentBackground = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // btnMigrar
            // 
            this.btnMigrar.BackColor = System.Drawing.Color.Transparent;
            this.btnMigrar.BorderRadius = 22;
            this.btnMigrar.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMigrar.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnMigrar.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnMigrar.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnMigrar.CheckedState.Image")));
            this.btnMigrar.CheckedState.Parent = this.btnMigrar;
            this.btnMigrar.CustomImages.Parent = this.btnMigrar;
            this.btnMigrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(155)))));
            this.btnMigrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMigrar.ForeColor = System.Drawing.Color.White;
            this.btnMigrar.HoverState.Parent = this.btnMigrar;
            this.btnMigrar.Image = ((System.Drawing.Image)(resources.GetObject("btnMigrar.Image")));
            this.btnMigrar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMigrar.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnMigrar.ImageSize = new System.Drawing.Size(25, 25);
            this.btnMigrar.Location = new System.Drawing.Point(417, 128);
            this.btnMigrar.Name = "btnMigrar";
            this.btnMigrar.ShadowDecoration.Parent = this.btnMigrar;
            this.btnMigrar.Size = new System.Drawing.Size(171, 43);
            this.btnMigrar.TabIndex = 19;
            this.btnMigrar.Text = "Migrar Excel";
            this.btnMigrar.UseTransparentBackground = true;
            this.btnMigrar.Click += new System.EventHandler(this.btnMigrar_Click);
            // 
            // btnValidarExcel
            // 
            this.btnValidarExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnValidarExcel.BorderRadius = 22;
            this.btnValidarExcel.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnValidarExcel.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnValidarExcel.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnValidarExcel.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnValidarExcel.CheckedState.Image")));
            this.btnValidarExcel.CheckedState.Parent = this.btnValidarExcel;
            this.btnValidarExcel.CustomImages.Parent = this.btnValidarExcel;
            this.btnValidarExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(155)))));
            this.btnValidarExcel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarExcel.ForeColor = System.Drawing.Color.White;
            this.btnValidarExcel.HoverState.Parent = this.btnValidarExcel;
            this.btnValidarExcel.Image = global::OutlookDemo.Properties.Resources.excel;
            this.btnValidarExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnValidarExcel.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnValidarExcel.Location = new System.Drawing.Point(148, 128);
            this.btnValidarExcel.Name = "btnValidarExcel";
            this.btnValidarExcel.ShadowDecoration.Parent = this.btnValidarExcel;
            this.btnValidarExcel.Size = new System.Drawing.Size(171, 43);
            this.btnValidarExcel.TabIndex = 18;
            this.btnValidarExcel.Text = "Validar Excel";
            this.btnValidarExcel.UseTransparentBackground = true;
            this.btnValidarExcel.Click += new System.EventHandler(this.btnValidarExcel_Click_1);
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarExcel.BorderRadius = 22;
            this.btnCargarExcel.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCargarExcel.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnCargarExcel.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnCargarExcel.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnCargarExcel.CheckedState.Image")));
            this.btnCargarExcel.CheckedState.Parent = this.btnCargarExcel;
            this.btnCargarExcel.CustomImages.Parent = this.btnCargarExcel;
            this.btnCargarExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(155)))));
            this.btnCargarExcel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarExcel.ForeColor = System.Drawing.Color.White;
            this.btnCargarExcel.HoverState.Parent = this.btnCargarExcel;
            this.btnCargarExcel.Image = global::OutlookDemo.Properties.Resources.excel;
            this.btnCargarExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCargarExcel.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnCargarExcel.Location = new System.Drawing.Point(152, 28);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.ShadowDecoration.Parent = this.btnCargarExcel;
            this.btnCargarExcel.Size = new System.Drawing.Size(171, 43);
            this.btnCargarExcel.TabIndex = 17;
            this.btnCargarExcel.Text = "Cargar Excel";
            this.btnCargarExcel.UseTransparentBackground = true;
            this.btnCargarExcel.Click += new System.EventHandler(this.btnCargarExcel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(160, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Seleccionar Plantilla BD:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(367, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(218, 25);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(435, 49);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(150, 23);
            this.txtArchivo.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(364, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Archivo:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(364, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Pestaña:";
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.PanelHeader);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 0);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(900, 608);
            this.panelBody.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UC_Migracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.panelBody);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.Location = new System.Drawing.Point(312, 97);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Migracion";
            this.Size = new System.Drawing.Size(900, 608);
            this.PanelHeader.ResumeLayout(false);
            this.PanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPestana;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button btnCargarExcel;
        private Guna.UI2.WinForms.Guna2Button btnComparar;
        private Guna.UI2.WinForms.Guna2Button btnMigrar;
        private Guna.UI2.WinForms.Guna2Button btnValidarExcel;
        private System.Windows.Forms.ListBox listError;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
    }
}
