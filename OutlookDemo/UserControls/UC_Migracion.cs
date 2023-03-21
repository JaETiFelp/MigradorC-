using OutlookDemo.Controladores.GeneralController;
using OutlookDemo.Controladores.InventarioController;
using OutlookDemo.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Collections;
using OutlookDemo.Controladores.ContabilidadController;
using System.Net.NetworkInformation;

namespace OutlookDemo.UserControls
{
    public partial class UC_Migracion : UserControl
    {
        private ExcelController _excelCntrl;
        private InventarioController _inventarioCtrl;
        private GeneralController _generalCtrl;
        private ContabilidadController _contabilidadCtrl;

        private DataTable dtCliente;
        private string selectNombreTabla;
        private bool swValidado;
        private bool swMigrado;

        
        

        public UC_Migracion( string nombreServidor , string usuario, string contrasena , string baseDatos)
        {
            InitializeComponent();
            llenarComboBox();
            _excelCntrl = new ExcelController(nombreServidor,usuario, contrasena, baseDatos);
            _inventarioCtrl = new InventarioController(nombreServidor, usuario, contrasena, baseDatos);
            _generalCtrl = new GeneralController(nombreServidor, usuario, contrasena, baseDatos);
            _contabilidadCtrl = new ContabilidadController(nombreServidor, usuario, contrasena, baseDatos);

            this.swValidado = false;
            this.swMigrado = false;
            selectNombreTabla = "";
            this.btnComparar.Enabled = false;


        }
        private void limpiarComponentes() {
            this.label1.Text = "";
            this.label2.Text = "";
            this.label3.Text = "";
            this.swValidado = false;
            this.selectNombreTabla = "";
            this.dtCliente.Clear();
            this.txtArchivo.Text = "";
            this.txtPestana.Text = "";
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.SelectedItem = "";
            this.listError.BackColor = Color.White;
            this.listError.Items.Clear();
            btnMigrar.Enabled = true;
            if (dataGridView1.Rows.Count > 0) {
                this.dataGridView1.DataSource = null;
               // this.dataGridView1.Dispose();
                dataGridView1.Refresh();
            }
            
            
        }

        private void  llenarComboBox()
        {
            this.comboBox1.Items.Add("Producto");
            this.comboBox1.Items.Add("Cliente");
            this.comboBox1.Items.Add("Empleado");
            this.comboBox1.Items.Add("Proveedor");
            this.comboBox1.Items.Add("CxCobrar");
            this.comboBox1.Items.Add("CxPagar");

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;
            this.selectNombreTabla = selectedItem.ToString();
        }

        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            //Cargar Excel

            this._excelCntrl.listValidacion.Clear();
            this.listError.Items.Clear();

            if (txtPestana.Text != "")
            {
                string name = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    name = openFileDialog1.FileName;

                    dtCliente = this._excelCntrl.DevuelveExcel(name, txtPestana.Text);

                    txtArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + System.IO.Path.GetExtension(openFileDialog1.FileName);
                    dataGridView1.DataSource = dtCliente;
                    btnMigrar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Obligatorio ingresar Nombre de la Hoja del documento Excel");
            }

         }

        private void btnValidarExcel_Click_1(object sender, EventArgs e)
        {
            //VAlidar Excel
            int error = 0;

            listError.Items.Clear();
            if (dtCliente != null) { 
            
                    if (dtCliente.Rows.Count != 0)
                    {           
                
                        switch (this.selectNombreTabla)
                        {
                            case "Producto":
                                this.swValidado = this._excelCntrl.validarDatosProducto(dtCliente);//productos          ok
                        
                                break;

                            case "Cliente":
                                this.swValidado = this._excelCntrl.validarDatosClientes(dtCliente);//clientes    OK
                                break;

                            case "Empleado":
                                this.swValidado = this._excelCntrl.validarDatosEmpleados(dtCliente);//EMPLEADOS  OK
                                break;

                            case "Proveedor":
                                this.swValidado = this._excelCntrl.validarDatosProveedores(dtCliente);//PROVEEDOR   OK
                                break;
                            case "CxCobrar" :
                                this.swValidado = this._excelCntrl.validarDatosCxCobrar(dtCliente);//CxC
                                break;
                            case "CxPagar":
                            this.swValidado = this._excelCntrl.validarDatosCxPagar(dtCliente);//CxC
                                break;
                        default:
                                MessageBox.Show("no existe plantilla");
                                error = 1;
                                this.swValidado = false;
                                listError.BackColor = Color.White;
                                listError.Items.Clear();
                                break;
                        }
                        this.txtPestana.Text = this.selectNombreTabla;

                        Int32 l = _excelCntrl.listValidacion.Count;
                        if (l == 0)
                        {
                            if (error == 1) {
                            //listError.BackColor = Color.Gray;239, 154, 154
                            listError.BackColor = Color.FromArgb(239, 83, 80); //rojo
                            listError.Items.Add("no hay plantilla..!!");
                            }
                            else {
                            listError.BackColor = Color.FromArgb(129, 199, 132);//verde
                            listError.Items.Add("                                                                           ");
                            listError.Items.Add("                                                                           ");
                            listError.Items.Add($"                                         Plantilla:  {selectNombreTabla}   Validados Exitosamente..!!");
                            btnMigrar.Enabled = true;
                            }                    
                        }
                        else
                        {
                            listError.Enabled = true;
                        //listError.BackColor = Color.Gray;
                        listError.BackColor = Color.FromArgb(239, 83, 80);
                        for (int j = 0; j < l; j++)
                            {
                                listError.Items.Add(_excelCntrl.listValidacion[j].ToString());
                            }                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aùn no se ha importado el archivo Excel");
                    }
            }
        }

        

        private void listError_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMigrar_Click(object sender, EventArgs e)
        {
            //Migrar
            this.listError.Items.Clear();
            Int32 l=0;

            if ( this.swValidado) {

                switch (this.selectNombreTabla)
                {
                    case "Producto":
                        _inventarioCtrl.migrarTablaProducto(dtCliente);
                        this.swMigrado = true;
                        l = _inventarioCtrl.ErrorListMigrate.Count;
                        //MessageBox.Show(" migrardo Tabla Producto");
                        break;

                    case "Cliente":
                        _generalCtrl.migrarTablaCliente2(dtCliente);
                        this.swMigrado = true;
                        //MessageBox.Show(" migrardo Tabla Cliente");
                        l = _generalCtrl.ErrorListMigrate.Count;
                        break;

                    case "Empleado":                    
                        _generalCtrl.migrarTablaEmpleado2(dtCliente);
                        this.swMigrado = true;
                        //MessageBox.Show(" migrardo Tabla Empleado");
                        l = _generalCtrl.ErrorListMigrate.Count;
                        break;

                    case "Proveedor":
                        _generalCtrl.migrarTablaProveedores2(dtCliente);
                        this.swMigrado = true;
                        //MessageBox.Show(" migrardo Tabla proveedores");
                        l = _generalCtrl.ErrorListMigrate.Count;
                        break;

                    case "CxCobrar":
                        _contabilidadCtrl.migrarTablaCxCobrar2(dtCliente);
                        this.swMigrado = true;
                        l = _contabilidadCtrl.ErrorListMigrate.Count;
                        //MessageBox.Show(" Migrado Cuentas por Cobrar");
                        break;

                    case "CxPagar":
                        _contabilidadCtrl.migrarTablaCxPagar2(dtCliente);
                        this.swMigrado = true;
                        //MessageBox.Show(" Migrado tabla Cuentas por Pagar");
                        l = _contabilidadCtrl.ErrorListMigrate.Count;
                        break;

                    default:
                        this.swMigrado = false;
                        MessageBox.Show("Opcion invalida o No hay Plantilla para Migrar");                        
                        break;
                }

                
                if (l == 0)
                {

                    listError.BackColor = Color.FromArgb(129, 199, 132);//verde
                    //listError.BackColor = Color.Green;
                    listError.Items.Add($"");
                    listError.Items.Add($"");
                    listError.Items.Add($"");
                    listError.Items.Add($"                                                 PLANTILLA:  {this.selectNombreTabla}   M I G R A D O   E x i t o s a m e n t e...!!");
                 
                }
                else
                {
                    listError.Enabled = true;
                    //listError.BackColor = Color.Gray;
                    listError.BackColor = Color.FromArgb(239, 83, 80);
                    switch (this.selectNombreTabla)
                    {
                        case "Producto":
                            for (int j = 0; j < l; j++)
                            {
                                listError.Items.Add(_inventarioCtrl.ErrorListMigrate[j].ToString());
                            }
                            break;
                        case "Cliente":
                            for (int j = 0; j < l; j++)
                            {
                                listError.Items.Add(_generalCtrl.ErrorListMigrate[j].ToString());
                            }
                            break;
                        case "Empleado":
                            for (int j = 0; j < l; j++)
                            {
                                listError.Items.Add(_generalCtrl.ErrorListMigrate[j].ToString());
                            }
                            break;
                        case "Proveedor":
                            for (int j = 0; j < l; j++)
                            {
                                listError.Items.Add(_generalCtrl.ErrorListMigrate[j].ToString());
                            }
                            break;
                        case "CxCobrar":
                            for (int j = 0; j < l; j++)
                            {
                                listError.Items.Add(_contabilidadCtrl.ErrorListMigrate[j].ToString());
                            }
                            break;
                        case "CxPagar":
                            for (int j = 0; j < l; j++)
                            {
                                listError.Items.Add(_contabilidadCtrl.ErrorListMigrate[j].ToString());
                            }
                            break;
                        default:
                            MessageBox.Show("Opcion inválida");
                            break;
                    }

                    
                }
                btnMigrar.Enabled = false;

            }
            else
            {
                MessageBox.Show(" Falta validar Plantilla..!!");
                
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarComponentes();
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            //Comparar
            ArrayList listaError = new ArrayList();
            this.listError.Items.Clear();
            if (dtCliente != null)
            {
                if (dtCliente.Rows.Count != 0)
                {
                    switch (this.selectNombreTabla)
                    {
                        case "Producto":
                            this.swMigrado = _inventarioCtrl.compararExcel_TablaProducto(dtCliente);
                            listaError = _inventarioCtrl.ErrorListCompare;
                            break;

                        case "Cliente":
                            this.swMigrado = _generalCtrl.compararExcel_TablaCliente(dtCliente);
                            listaError = _generalCtrl.ErrorListCompare;
                            break;

                        case "Empleado":
                            //this.swMigrado =_generalCtrl.compararExcel_TablaEmpleado(dtCliente);
                            listaError = _generalCtrl.ErrorListCompare;
                            MessageBox.Show("Compara excel con tabla Empleado");
                            break;

                        case "Proveedor":
                            //this.swMigrado =_generalCtrl.compararExcel_TablaProveeedor(dtCliente);
                            listaError = _generalCtrl.ErrorListCompare;
                            MessageBox.Show("Compara excel con tabla Proveedor");

                            break;
                        case "CxCobrar":
                            //this.swMigrado =_generalCtrl.compararExcel_TablaCxCobrar(dtCliente);
                            listaError = _generalCtrl.ErrorListCompare;
                            MessageBox.Show("Compara excel con tabla CxCobrar");

                            break;
                        case "CxPagar":
                            //this.swMigrado =_generalCtrl.compararExcel_TablaCxPagar(dtCliente);
                            listaError = _generalCtrl.ErrorListCompare;
                            MessageBox.Show("Compara excel con tabla CxPagar");

                            break;

                        default:
                            this.swMigrado = false;
                            MessageBox.Show("Opcion invalida o No hay Plantilla para Comparar");
                            break;
                    }


                    if (listaError.Count == 0)
                    {
                        listError.BackColor = Color.Green;
                        listError.Items.Add($"Datos  plantilla Excel  y Datos Tabla {this.selectNombreTabla} son Iguales ..!!");
                    }
                    else
                    {
                        listError.Enabled = true;
                        listError.BackColor = Color.Gray;
                        for (int j = 0; j < listaError.Count; j++)
                        {
                            listError.Items.Add(listaError[j].ToString());
                        }
                    }

                }
            }
            //if (this.swMigrado)
            //{
                
            //}
            //else {
            //    MessageBox.Show("Falta migradar Plantilla..!!");
            //}          
        }





    }
}
