
using OutlookDemo.Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OutlookDemo.Controladores
{
    public class ExcelController
    {
        private DocumentoExcel _excel;

        private string[] arrayHeader;
        public ArrayList listValidacion { get; set; }
        public ExcelController(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {
            _excel = new DocumentoExcel(nombreSer, usuarioSer, passSer, bdSer);
            listValidacion = new ArrayList();

        }
        public DataTable DevuelveExcel(string archivo, string pestaña)
        {
            DataSet dsOriginal = _excel.DevuelveExcel(archivo, pestaña);
            DataTable dt1 = dsOriginal.Tables[0] as DataTable;
            return dt1;

        }
        
        // MODULO INVENTARIO
        public bool validarDatosProducto(DataTable dtCliente)
        {
            listValidacion.Clear();
            bool sw = true;

            var longitudFila = dtCliente.Rows.Count;
            var longitudCol = dtCliente.Columns.Count;

            arrayHeader = new string[longitudCol];

            int fila = 1;
            foreach (DataRow row in dtCliente.Rows)
            {
                int columna = 1;
                foreach (DataColumn column in dtCliente.Columns)
                {
                    string headerTipoDato = dtCliente.Columns[columna - 1].ColumnName;
                    string cad = headerTipoDato.Substring(headerTipoDato.Length - 1, 1);
                   
                    var dato = row[column];


                    if (fila == 1)
                    {
                        arrayHeader[columna - 1] = dato.ToString();
                    }
                    else
                    {                        
                        switch (columna)
                        {
                            case 1:  //Entero ID
                                bool success = Int32.TryParse(dato.ToString(), out Int32 x);
                                if (!success)
                                {
                                    if (dato.ToString() != "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: ID, dato: {dato.ToString()} válido, en [ {fila - 1} - {columna} ]");
                                    }
                                }
                                break;
                            case 2://Literal CODIGO
                                bool success2 = Int32.TryParse(dato.ToString(), out Int32 x2);
                                if (success2 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: CODIGO INTERNO, dato: {dato.ToString()} NO válido o Vacío, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 3://Literal CODIGO BARRA
                                bool success3 = Int32.TryParse(dato.ToString(), out Int32 x3);
                                if (success3 )
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: CODIGO BARRA, dato: {dato.ToString()} NO válido o Vacío, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 4://literal Nombre
                                bool success4 = Int32.TryParse(dato.ToString(), out Int32 x4);
                                if (success4 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: NOMBRE, dato: {dato.ToString()}  NO válido o vacío, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 5://literal Grupo
                                bool success5 = Int32.TryParse(dato.ToString(), out Int32 x5);
                                if (success5 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: GRUPO, dato: {dato.ToString()} NO válido0 o vacío, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 6://literal Tipo
                                bool success6 = Int32.TryParse(dato.ToString(), out Int32 xs6);
                                if (success6 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: TIPO, dato: {dato.ToString()} NO válido o vacío, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 7://literal subtipo
                                bool success7 = Int32.TryParse(dato.ToString(), out Int32 x7);
                                if (success7 )
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: SUBTIPO, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 8://literal marca
                                bool success8 = Int32.TryParse(dato.ToString(), out Int32 x8);
                                if (success8 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: MARCA, dato: {dato.ToString()} NO válido o vacío, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 9://literal unidad
                                bool success9 = Int32.TryParse(dato.ToString(), out Int32 x9);
                                if (success9 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: UNIDAD, dato: {dato.ToString()} NO válido o vacío, en [ {fila - 1} - {columna} ]");
                                }
                                break;

                            case 10://literal caracteristicas
                                bool success10 = Int32.TryParse(dato.ToString(), out Int32 x10);
                                if (success10)
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: CARACTERISTICAS, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 11://literal PRODUCTO CONTROL
                                bool success11 = Int32.TryParse(dato.ToString(), out Int32 x11);
                                if (success11 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: PRODUCTO CONTROL, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 12://numero idLote
                                bool success12 = Int32.TryParse(dato.ToString(), out Int32 x12);
                                if (!success12)
                                {
                                    if (dato.ToString() != "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: IDLOTE, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                }
                                break;

                            case 13://literal codlote
                                bool success13 = Int32.TryParse(dato.ToString(), out Int32 x13);
                                if (success13)//    asi->    !success11   para que acepte Entero y    (success11) acepte solo Literal
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: CODIGOlOTE, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                }
                                break;

                            case 14://literal nombre lote
                                bool success14 = Int32.TryParse(dato.ToString(), out Int32 x14);
                                if (success14)
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: NOMBRELOTE, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                }
                                break;

                            case 15://fecha fechaVencimiento
                                bool success15 = DateTime.TryParse(dato.ToString(), out DateTime x15);
                                if (!success15 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: FECHA, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                }

                                break;
                            case 16://Decimal  CostoBolUnitario
                                bool success16 = Double.TryParse(dato.ToString(), out Double x16);
                                if (!success16 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: COSTOBOLUNITARIO, dato: {dato.ToString()} NO válido o vacío,  en [ {fila - 1} - {columna} ]");
                                }
                                break;

                            case 17://Decimal cantStock
                                bool success17 = Double.TryParse(dato.ToString(), out Double x17);
                                if (!success17 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: CANTIDAD STOCK, dato: {dato.ToString()} NO válido o vacio, en [ {fila - 1} - {columna} ]");
                                }
                                break;

                            case 18://Decimal PrecioVenta
                                bool success18 = Double.TryParse(dato.ToString(), out Double x18);
                                if (!success18 || dato.ToString() == "")
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: PRECIO VENTA, dato: {dato.ToString()} NO válido  vacio, en [ {fila - 1} - {columna} ]");
                                }
                                break;

                            default:
                                this.listValidacion.Add($"Error, indice de Columna no existe");
                                //MessageBox.Show("no existe indice");
                                break;
                        }
                    }
                    columna++;
                }
                fila++;
            }
            return sw;

        }

        
        //MODULO GENERAL
        public bool validarDatosClientes(DataTable dtCliente)
        {
            listValidacion.Clear();

            bool sw = true;

            var longitudFila = dtCliente.Rows.Count;
            var longitudCol = dtCliente.Columns.Count;

            arrayHeader = new string[longitudCol];

            int fila = 1;
            foreach (DataRow row in dtCliente.Rows)
            {
                int columna = 1;
                foreach (DataColumn column in dtCliente.Columns)
                {
                    string headerTipoDato = dtCliente.Columns[columna - 1].ColumnName;
                    string cad = headerTipoDato.Substring(headerTipoDato.Length - 1, 1);
                   

                    var dato = row[column];

                    if (fila == 1)
                    {
                        arrayHeader[columna - 1] = dato.ToString();
                    }
                    else
                    {             

                        switch (columna)
                        {
                            case 1:  //Numero
                                bool success = Int32.TryParse(dato.ToString(), out Int32 x);
                                if (!success)
                                {
                                    if (dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: ID, dato: {dato.ToString()} válido, en [ {fila - 1} - {columna} ], no es Numero o Celda vacìo");
                                    }
                                }
                                break;
                            case 2://numero
                                bool success2 = Double.TryParse(dato.ToString(), out Double x2);
                                if (!success2)
                                {
                                    if (dato.ToString() != "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: NIT, dato: {dato.ToString()} no es Número, en [ {fila - 1} - {columna} ]");
                                    }
                                }
                                break;
                            case 3://Literal
                                bool success3 = Int32.TryParse(dato.ToString(), out Int32 x3);
                                if (success3)
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: NOMBRE, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 4://literal
                                bool success4 = Int32.TryParse(dato.ToString(), out Int32 x4);
                                if (success4)
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: CORREO, dato: {dato.ToString()}  NO válido, en [ {fila - 1} - {columna} ]");
                                }

                                break;
                            case 5://literal
                                bool success5 = Int32.TryParse(dato.ToString(), out Int32 x5);
                                if (success5)
                                {
                                    sw = false;
                                    this.listValidacion.Add($"Error en Columna: TIENE CREDITO, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                }
                                break;
                            case 6://Decimal PrecioVenta
                                bool success6 = Double.TryParse(dato.ToString(), out Double x6);
                                if (!success6 )
                                {
                                    if (dato.ToString() != "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: LIMITE CREDITO, dato: {dato.ToString()} NO válido o vacío,  en [ {fila - 1} - {columna} ]");
                                    }                                    
                                }
                                break;
                            case 7://numero
                                bool success7 = Int32.TryParse(dato.ToString(), out Int32 x7);
                                if (!success7)
                                {
                                    if (dato.ToString() != "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: TELEFONO, dato: {dato.ToString()} válido, en [ {fila - 1} - {columna} ]");
                                    }
                                }
                                break;

                            default:
                                this.listValidacion.Add($"Error, indice de Columna no existe");
                                break;
                        }
                    }
                    columna++;
                }
                fila++;
            }
            return sw;

        }

        public bool validarDatosEmpleados(DataTable dtCliente)
        {

            listValidacion.Clear();

            bool sw = true;

            var longitudFila = dtCliente.Rows.Count;
            var longitudCol = dtCliente.Columns.Count;

            arrayHeader = new string[longitudCol];

            int fila = 1;
            foreach (DataRow row in dtCliente.Rows)
            {
                //DataRow row2 = dtCliente.Rows[fila];
                bool sw2 = isRowNull(row);
                if (!sw2)//si casillas no vacias en excel
                {
                    int columna = 1;
                    foreach (DataColumn column in dtCliente.Columns)
                    {

                        var dato = row[column];

                        if (fila == 1)
                        {
                            arrayHeader[columna - 1] = dato.ToString();
                        }
                        else
                        {
                            switch (columna)
                            {
                                case 1:  //Numero
                                    bool success = Int32.TryParse(dato.ToString(), out Int32 x);
                                    if (!success || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: ID EMPLEADO, dato: {dato.ToString()} válido, en [ {fila - 1} - {columna} ], no es Numero o Celda vacìo");
                                    }
                                    break;
                                case 2://numero CI
                                    bool success2 = Int32.TryParse(dato.ToString(), out Int32 x2);
                                    if (!success2)
                                    {
                                        if (dato.ToString() != "")
                                        {
                                            sw = false;
                                            this.listValidacion.Add($"Error en Columna: NIT, dato: {dato.ToString()} no es Número, en [ {fila - 1} - {columna} ]");
                                        }
                                    }
                                    break;
                                case 3://Literal
                                    bool success3 = Int32.TryParse(dato.ToString(), out Int32 x3);
                                    if (success3 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: APELLIDO PATERNO, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 4://literal
                                    bool success4 = Int32.TryParse(dato.ToString(), out Int32 x4);
                                    if (success4)
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: APELLIDO MATERNO, dato: {dato.ToString()}  NO válido, en [ {fila - 1} - {columna} ]");
                                    }

                                    break;
                                case 5://literal
                                    bool success5 = Int32.TryParse(dato.ToString(), out Int32 x5);
                                    if (success5 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna:   NOMBRE, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 6://LITERAL
                                    bool success6 = Int32.TryParse(dato.ToString(), out Int32 x6);
                                    if (success6 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna:   NOMBRE, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 7://MUMERO
                                    bool success7 = Int32.TryParse(dato.ToString(), out Int32 x7);
                                    if (!success7 )
                                    {
                                        if (dato.ToString() != "")
                                        {
                                            sw = false;
                                            this.listValidacion.Add($"Error en Columna: TELEFONO, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                        }
                                    }
                                    break;                                    
                                case 8://fecha
                                    bool success8 = DateTime.TryParse(dato.ToString(), out DateTime x8);
                                    if (!success8 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: FECHA DE INGRESO, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                default:
                                    this.listValidacion.Add($"Error, indice de Columna no existe");
                                    break;
                            }


                        }
                        columna++;
                    }
                }

                fila++;
            }
            return sw;

        }

        public bool validarDatosProveedores(DataTable dtCliente)
        {

            listValidacion.Clear();

            bool sw = true;

            var longitudFila = dtCliente.Rows.Count;
            var longitudCol = dtCliente.Columns.Count;

            arrayHeader = new string[longitudCol];

            int fila = 1;
            foreach (DataRow row in dtCliente.Rows)
            {
                //DataRow row2 = dtCliente.Rows[fila];
                bool sw2 = isRowNull(row);
                if (!sw2)//si casillas no vacias en excel
                {
                    int columna = 1;
                    foreach (DataColumn column in dtCliente.Columns)
                    {

                        var dato = row[column];

                        if (fila == 1)
                        {
                            arrayHeader[columna - 1] = dato.ToString();
                        }
                        else
                        {
                            switch (columna)
                            {
                                case 1:  //Numero
                                    bool success = Int32.TryParse(dato.ToString(), out Int32 x);
                                    if (!success || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: ID PROVEEDOR, dato: {dato.ToString()} válido, en [ {fila - 1} - {columna} ], no es Numero o Celda vacìo");
                                    }
                                    break;

                                case 2://numero CI
                                    bool success2 = Int32.TryParse(dato.ToString(), out Int32 x2);
                                    if (!success2)
                                    {
                                        if (dato.ToString() != "")
                                        {
                                            sw = false;
                                            this.listValidacion.Add($"Error en Columna: NIT, dato: {dato.ToString()} no es Número, en [ {fila - 1} - {columna} ]");
                                        }
                                    }
                                    break;
                                case 3://Literal nombre empresa
                                    bool success3 = Int32.TryParse(dato.ToString(), out Int32 x3);
                                    if (success3 )
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: NOMBRE EMPRESA, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 4://literal
                                    bool success4 = Int32.TryParse(dato.ToString(), out Int32 x4);
                                    if (success4 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: APELLIDO PATERNO, dato: {dato.ToString()}  NO válido, en [ {fila - 1} - {columna} ]");
                                    }

                                    break;
                                case 5://literal
                                    bool success5 = Int32.TryParse(dato.ToString(), out Int32 x5);
                                    if (success5)
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna:   APELLIDO MATERNO, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 6://LITERAL
                                    bool success6 = Int32.TryParse(dato.ToString(), out Int32 x6);
                                    if (success6 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna:   NOMBRE, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 7://LITERAL
                                    bool success7 = Int32.TryParse(dato.ToString(), out Int32 x7);
                                    if (success7)
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna:   CORREO, dato: {dato.ToString()} NO válido, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;

                                case 8://MUMERO
                                    bool success8 = Int32.TryParse(dato.ToString(), out Int32 x8);
                                    if (!success8 || dato.ToString() == "")
                                    {
                                        if (dato.ToString() != "")
                                        {
                                            sw = false;
                                            this.listValidacion.Add($"Error en Columna: TELEFONO, dato: {dato.ToString()} válido, en [ {fila - 1} - {columna} ]");
                                        }
                                    }
                                    break;

                                default:
                                    this.listValidacion.Add($"Error, indice de Columna no existe");
                                    break;
                            }


                        }
                        columna++;
                    }
                }

                fila++;
            }
            return sw;

        }

        
        //MODULO CONTABILIDAD
        public bool validarDatosCxCobrar( DataTable dtCliente) {
            listValidacion.Clear();
            DataTable dt = new DataTable();
            ArrayList listCli = new ArrayList();
            dt = _excel.listaClientes();
            listCli = this.obtColumnIdCliente(dt, "num_sec");


            bool sw = true;

            var longitudFila = dtCliente.Rows.Count;
            var longitudCol = dtCliente.Columns.Count;

            arrayHeader = new string[longitudCol];

            int fila = 1;
            foreach (DataRow row in dtCliente.Rows)
            {
                bool sw2 = isRowNull(row);
                if (!sw2)//si casillas no vacias en excel
                {
                    int columna = 1;
                    foreach (DataColumn column in dtCliente.Columns)
                    {

                        var dato = row[column];

                        if (fila == 1)
                        {
                            arrayHeader[columna - 1] = dato.ToString();
                        }
                        else
                        {
                            
                            switch (columna)
                            {
                                case 1:  //Numero
                                    bool success1 = Int32.TryParse(dato.ToString(), out Int32 x1);
                                    if (!success1 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: ID CLIENTE, dato: {dato.ToString()} no es Número o es Vacío, en [ {fila - 1} - {columna} ]");
                                    }
                                    else
                                    {
                                        if (!existeId(listCli,Convert.ToInt32(dato))) {
                                            this.listValidacion.Add($"Error en Columna: ID CLIENTE, : {dato.ToString()}  no Existe en La Base Datos [ {fila - 1} - {columna} ]");
                                        }
                                    }
                                    break;
                                case 2://Fecha  
                                    bool success2 = DateTime.TryParse(dato.ToString(), out DateTime x2);
                                    if (!success2 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: FECHA DEUDA, dato: {dato.ToString()} no válido o Vacio, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 3://Fecha
                                    bool success3 = DateTime.TryParse(dato.ToString(), out DateTime x3);
                                    if (!success3 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: FECHA DE VENCIMIENTO, dato: {dato.ToString()} no válido o Vacio, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 4://Numero                                   
                                    bool success4 = Int32.TryParse(dato.ToString(), out Int32 x4);
                                    if (!success4 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: NUMERO DE FACTURA, dato: {dato.ToString()} no válido o Vacio,  en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 5://Numero
                                    bool success5 = Double.TryParse(dato.ToString(), out Double x5);
                                    if (!success5 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: MONTO TOTAL DE DEUDA, dato: {dato.ToString()} no válido o Vacio, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 6://Numero                                 
                                    bool success6 = Double.TryParse(dato.ToString(), out Double x6);
                                    if (!success6 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: MONTO CANCELADO, dato: {dato.ToString()}  no válido o Vacio, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;

                                case 7://Numero
                                    bool success7 = Double.TryParse(dato.ToString(), out Double x7);
                                    if (!success7 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: SALDO, dato: {dato.ToString()} no válido o Vacio en [ {fila - 1} - {columna} ]");
                                    }
                                    break;

                                default:
                                    this.listValidacion.Add($"Error, indice de Columna no existe");
                                    break;
                            }

                        }
                        columna++;
                    }
                }

                fila++;
            }
            return sw;

        }
        public bool validarDatosCxPagar( DataTable dtCliente )
        {
            listValidacion.Clear();
            DataTable dt = new DataTable();
            ArrayList listCli = new ArrayList();
            dt = _excel.listaClientes();
            listCli = this.obtColumnIdCliente(dt, "num_sec");


            bool sw = true;

            var longitudFila = dtCliente.Rows.Count;
            var longitudCol = dtCliente.Columns.Count;

            arrayHeader = new string[longitudCol];

            int fila = 1;
            foreach (DataRow row in dtCliente.Rows)
            {
                bool sw2 = isRowNull(row);
                if (!sw2)//si casillas no vacias en excel
                {
                    int columna = 1;
                    foreach (DataColumn column in dtCliente.Columns)
                    {

                        var dato = row[column];

                        if (fila == 1)
                        {
                            arrayHeader[columna - 1] = dato.ToString();
                        }
                        else
                        {

                            switch (columna)
                            {
                                case 1:  //Numero
                                    bool success1 = Int32.TryParse(dato.ToString(), out Int32 x1);
                                    if (!success1 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: ID CLIENTE, dato: {dato.ToString()} no es Número o es Vacío, en [ {fila - 1} - {columna} ]");
                                    }
                                    else
                                    {
                                        if (!existeId(listCli, Convert.ToInt32(dato)))
                                        {
                                            this.listValidacion.Add($"Error en Columna: ID CLIENTE, : {dato.ToString()}  no Existe en La Base Datos [ {fila - 1} - {columna} ]");
                                        }
                                    }
                                    break;
                                case 2://Fecha  
                                    bool success2 = DateTime.TryParse(dato.ToString(), out DateTime x2);
                                    if (!success2 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: FECHA DEUDA, dato: {dato.ToString()} no válido o Vacio, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 3://Fecha
                                    bool success3 = DateTime.TryParse(dato.ToString(), out DateTime x3);
                                    if (!success3 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: FECHA DE VENCIMIENTO, dato: {dato.ToString()} no válido o Vacio, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 4://Numero                                   
                                    bool success4 = Int32.TryParse(dato.ToString(), out Int32 x4);
                                    if (!success4 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: NUMERO DE FACTURA, dato: {dato.ToString()} no válido o Vacio,  en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 5://Numero
                                    bool success5 = Double.TryParse(dato.ToString(), out Double x5);
                                    if (!success5 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: MONTO TOTAL DE DEUDA, dato: {dato.ToString()} no válido o Vacio, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;
                                case 6://Numero                                 
                                    bool success6 = Double.TryParse(dato.ToString(), out Double x6);
                                    if (!success6 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: MONTO CANCELADO, dato: {dato.ToString()}  no válido o Vacio, en [ {fila - 1} - {columna} ]");
                                    }
                                    break;

                                case 7://Numero
                                    bool success7 = Double.TryParse(dato.ToString(), out Double x7);
                                    if (!success7 || dato.ToString() == "")
                                    {
                                        sw = false;
                                        this.listValidacion.Add($"Error en Columna: SALDO, dato: {dato.ToString()} no válido o Vacio en [ {fila - 1} - {columna} ]");
                                    }
                                    break;

                                default:
                                    this.listValidacion.Add($"Error, indice de Columna no existe");
                                    break;
                            }

                        }
                        columna++;
                    }
                }

                fila++;
            }
            return sw;
        }
        

        public bool isRowNull(DataRow row)
        {
            foreach (DataColumn column in row.Table.Columns)
                if (!row.IsNull(column))
                    return false;

            return true;
        }
        public bool esEntero(string cad)
        {
            bool success = Int32.TryParse(cad, out int x);    // o use `int.TryParse()`
            if (success)
            {
                return success;
            }
            else
            {
                return success;
            }
        }

        private ArrayList obtColumnIdCliente(DataTable dt, string nombreCol) {
            ArrayList listCol = new ArrayList();

            dt = _excel.listaClientes();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                listCol.Add( Convert.ToInt32( dt.Rows[j][nombreCol].ToString()));
            }
            return listCol;
        }
        public bool existeId(ArrayList Al, int id)
        { bool sw = false;
            int ns = -1;
            for (int i = 0; i < Al.Count; i++) {
                if (Al[i].Equals(id)) {
                    sw = true;
                    return sw;
                }
            }
            return sw;
        }


    }
}
