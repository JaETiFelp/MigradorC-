using Guna.UI2.WinForms;
using OutlookDemo.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookDemo
{
    public partial class Form1 : Form
    {

        private UC_Configuracion uc_config;
        private UC_Migracion uc_migra;

        private bool sesion;
        

        public Form1()
        {
            InitializeComponent();
            sesion = false;
        }

        private void togglePanelMain(string name)
        {
            this.panel2.Controls.Clear();
            switch (name)
            {
                case "configuracion":
                    if (this.uc_config == null)
                    {
                        this.uc_config = new UC_Configuracion();                        
                        this.panel2.Controls.Add(this.uc_config);
                        this.uc_config.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uc_config.Location = new System.Drawing.Point(0, 0);
                        this.uc_config.Name = "configuracion";
                        this.Size = new System.Drawing.Size(1200, 608);
                        this.uc_config.TabIndex = 0;
                        if (this.uc_config.sesion == true) { this.sesion = this.uc_config.sesion; }
                    }
                    else { 
                        this.panel2.Controls.Add(uc_config);
                        if (this.uc_config.sesion == true)
                        {
                            this.sesion = this.uc_config.sesion;
                            //this.panel2.Controls.Add(uc_migra);                            
                        }
                    }
                    break;
                case "migracion":
                    
                        //MessageBox.Show($"SESION:  {this.uc_config.sesion}" );
                        if (this.uc_migra == null)
                        {
                            this.uc_migra = new UC_Migracion(
                                 this.uc_config.nombreServidor , this.uc_config.usuario,this.uc_config.contrasena, this.uc_config.baseDatos
                                );
                            this.panel2.Controls.Add(this.uc_migra);
                            this.uc_migra.Dock = System.Windows.Forms.DockStyle.Fill;
                            this.uc_migra.Location = new System.Drawing.Point(0, 0);
                            this.uc_migra.Name = "migracion";
                            this.Size = new System.Drawing.Size(1200, 608);
                            this.uc_migra.TabIndex = 0;
                        }
                        else { 
                        this.panel2.Controls.Add(uc_migra); 
                        }

                    
                   
                    break;
              

                default:
                    break;

            }

        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 119, b.Location.Y - 30);
            imgSlide.SendToBack();
            
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            
            //moveImageBox(sender);
            //this.togglePanelMain("configuracion");

        }
        private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        {

            moveImageBox(sender);
            if (this.sesion == true)
            {
                this.togglePanelMain("migracion");
            }
            else {
                this.togglePanelMain("configuracion");
            }
            

        }
        private void guna2Button5_CheckedChanged(object sender, EventArgs e)
        {

            moveImageBox(sender);
            if (this.sesion == true)
            {
                this.togglePanelMain("migracion");
            }
            else
            {
                this.togglePanelMain("configuracion");
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            
          

        }

        private void uC_Inbox1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

       

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
