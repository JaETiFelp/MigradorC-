using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookDemo.UserControls
{
    public partial class UC_Configuracion : UserControl
    {
        public string nombreServidor { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string baseDatos { get; set; }

        public bool sesion { get; set; }
        public UC_Configuracion()
        {
            InitializeComponent();
            this.nombreServidor = "";
            this.usuario = "";
            this.contrasena = "";
            this.baseDatos = "";
            this.sesion= false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void uC_Chat4_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //txtUsuario.Text = "sa";
            //txtContraseña.Text = "AEGRmsSis1";
            //txtBD.Text = "FarmaciaLaLuz";//"AP";
            if (txtNombre.Text != "" && txtUsuario.Text != "" && txtContraseña.Text != "" && txtBD.Text != "")
            {
                this.nombreServidor = txtNombre.Text;
                this.usuario = txtUsuario.Text;
                this.contrasena = txtContraseña.Text;
                this.baseDatos = txtBD.Text;
                this.sesion = true;

            }
            else
            {
                this.sesion = false;
                MessageBox.Show("los campos son de llenado obligatorio");
            }
        }

        private void UC_Configuracion_Load(object sender, EventArgs e)
        {

        }
    }
}
