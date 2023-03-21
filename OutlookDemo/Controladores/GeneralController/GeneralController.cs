using OutlookDemo.Datos.General;
using OutlookDemo.Datos.Inventario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.HtmlRenderer.Adapters.RGraphicsPath;

namespace OutlookDemo.Controladores.GeneralController
{
    public class GeneralController
    {


        private General _general;

        public ArrayList ErrorListCompare { get; set; }
        public ArrayList ErrorListMigrate { get; set; }
        public GeneralController(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {
            _general = new General(nombreSer, usuarioSer, passSer, bdSer);
            ErrorListCompare = new ArrayList();
            ErrorListMigrate = new ArrayList();
        }

        public void migrarTablaCliente(DataTable dt)
        {
            string nombre;
            ArrayList AlDatos;
            ArrayList AlDatoTelf;
            ArrayList AlDatosCl;
            int ns = -1;
            bool bExiste = false;


            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row = dt.Rows[j];
                bool sw = isRowNull(row);
                if (!sw)
                {

                    nombre = dt.Rows[j][1].ToString();
                    string email = dt.Rows[j][2].ToString();
                    string cred = dt.Rows[j][3].ToString();
                    string limCred = dt.Rows[j][4].ToString();
                    string telef = dt.Rows[j][5].ToString();


                    #region // Directorio
                    AlDatos = new ArrayList();
                    AlDatos.Add(-1); //@n_s
                    AlDatos.Add(nombre);
                    AlDatos.Add("");//nit
                    AlDatos.Add("");//direc
                    AlDatos.Add(email);
                    AlDatos.Add("");//obs
                    AlDatos.Add(1);//ns_TipoDirectorio --usua  --suc    
                    ns = _general.RegistrarDirectorio(AlDatos);
                    AlDatos.Clear();
                    #endregion

                    #region // Telefono
                    if (telef != null || telef != "")
                    {
                        AlDatoTelf = new ArrayList();
                        AlDatoTelf.Add(Convert.ToInt32(telef));
                        AlDatoTelf.Add("Tel");
                        AlDatoTelf.Add("");
                        AlDatoTelf.Add(Convert.ToInt32(ns));
                        _general.registrarTelefono(AlDatoTelf);
                        AlDatoTelf.Clear();

                    }
                    #endregion

                    #region //Cliente
                    AlDatosCl = new ArrayList();
                    AlDatosCl.Add(ns); //@n_s
                    AlDatosCl.Add(DateTime.Now);//fingre
                    AlDatosCl.Add(1);//EstadoCliente 
                    if (cred == "SI") { AlDatosCl.Add(1); } else { AlDatosCl.Add(0); }//conCredito 
                    AlDatosCl.Add(1);//ns_TipoCliente
                    AlDatosCl.Add(limCred);//limiteCredito 
                    AlDatosCl.Add("BOL");//cod_Moneda
                    AlDatosCl.Add(24);//ns_cuenta 

                    AlDatosCl.Add(120);//ns_cuentaAnticipo 
                    AlDatosCl.Add("");//NombreAFacturar 
                    AlDatosCl.Add("");//NitAFacturar 
                    AlDatosCl.Add(null);//ns_Empleado 
                    AlDatosCl.Add(0.00);//descped 

                    AlDatosCl.Add(null);//nsSucursal 
                    AlDatosCl.Add(0);//DiasCredito 
                    AlDatosCl.Add(null);//ns_segmento 
                    AlDatosCl.Add(DateTime.Now);//FechaLimCredito
                    AlDatosCl.Add("");//cod_TipoLimiteTiempoCredito 

                    AlDatosCl.Add("");//NombreComercial
                    AlDatosCl.Add(0);//DiaLimFactura 
                    AlDatosCl.Add(0);//DiasLimiteMora 
                    _general.RegistrarCliente(AlDatosCl);
                    AlDatosCl.Clear();
                    #endregion

                }

            }

        }

        public void migrarTablaCliente2(DataTable dt)
        {
            ErrorListMigrate.Clear();

            DataTable dtDirectorio = _general.ListDirectorio2column();
            DataTable dtDato = new DataTable();
            dtDato.Columns.Add("indice");
            dtDato.Columns.Add("nombre");
            dtDato.Columns.Add("ns");

            string nombre;
            string nit;
            ArrayList AlDatos;
            int ns = -1;
            bool bExiste = false;

            #region Directorio
            for (int j = 0; j < dtDirectorio.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtDirectorio.Rows[j]["nit"].ToString(), dtDirectorio.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nit              = dt.Rows[j][1].ToString();
                string nombreCli = dt.Rows[j][2].ToString();
                string email     = dt.Rows[j][3].ToString();
                string cred      = dt.Rows[j][4].ToString();
                string limCred   = dt.Rows[j][5].ToString();
                string telef     = dt.Rows[j][6].ToString();

                nombre = nit;
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");
                foreach (DataRow row in rslt)
                {
                    if (row["nombre"].ToString() == "")
                    {
                        bExiste = false;
                        break;
                    }
                    else {
                        dt.Rows[j][0] = -1; //row["ns"];
                        bExiste = true;
                        this.ErrorListMigrate.Add($"ERROR no se Insertó... número de NIT: {nit} ya Existe, Directorio: {nombreCli},de  Fila {j} ");
                    }
                    
                }
                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(dtDato.Rows.Count + 1, nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1); //@n_s
                    AlDatos.Add(nombreCli);
                    if (nit == "")
                    { AlDatos.Add("");//nit
                    }
                    else {
                       AlDatos.Add(Convert.ToInt32(nit));//nit
                    }                        
                    AlDatos.Add("");//direc
                    AlDatos.Add(email);
                    AlDatos.Add("");//obs
                    AlDatos.Add(1);//ns_TipoDirectorio --usua  --suc    
                    ns = _general.RegistrarDirectorio(AlDatos);

                    dt.Rows[j][0] = ns.ToString();
                    AlDatos.Clear();

                    rslt = dtDato.Select("indice = '" + dtDato.Rows.Count + "'");
                    foreach (DataRow row in rslt)
                    {
                        row["ns"] = ns;
                    }
                    ns = -1;
                }
                bExiste = false;
            }
            dtDato.Clear();
            #endregion

            #region Telefono
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][6].ToString(); //Telef
             
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");
                foreach (DataRow row in rslt)
                {
                    dt.Rows[j][6] = row["ns"];
                    bExiste = true;
                }
                if (!bExiste)//No existe
                {
                    if (!dt.Rows[j][0].ToString().Equals("-1")) {
                        dtDato.Rows.Add(j.ToString(), nombre, ns);
                        if (nombre != null && nombre != "")
                        {
                            AlDatos = new ArrayList();
                            AlDatos.Add(Convert.ToInt32(nombre));//Telef
                            AlDatos.Add("Tel");
                            AlDatos.Add("");
                            AlDatos.Add(Convert.ToInt32(dt.Rows[j][0]));//nsDirectorio
                            bool sw = _general.registrarTelefono2(AlDatos);
                            if (sw)
                            {
                                ns = Convert.ToInt32(dt.Rows[j][0]);
                            }
                            AlDatos.Clear();
                        }
                    }                        
                    dt.Rows[j][6] = ns.ToString();

                    rslt = dtDato.Select("indice = '" + j.ToString() + "'");
                    foreach (DataRow row in rslt)
                    {
                        row["ns"] = ns;
                    }
                    ns = -1;
                }
                bExiste = false;
            }
            dtDato.Clear();
            #endregion

            #region Cliente
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                string cred = dt.Rows[j][4].ToString();
                nombre = dt.Rows[j][5].ToString(); //limite de credito

                if (!dt.Rows[j][0].ToString().Equals("-1"))
                {
                    AlDatos = new ArrayList();
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][0])); //@n_s
                    AlDatos.Add(DateTime.Now);//fingre
                    AlDatos.Add(1);//EstadoCliente 
                    if (cred == "SI") { AlDatos.Add(1); } else { AlDatos.Add(0); }//conCredito 
                    AlDatos.Add(1);//ns_TipoCliente
                    if (nombre.ToString().Equals(""))
                    {
                        AlDatos.Add(Convert.ToDouble("0"));//limiteCredito 
                    }
                    else
                    {
                        string auxLimC;
                        if (dt.Rows[j][5].ToString().Contains("."))
                        {
                            auxLimC = dt.Rows[j][5].ToString().Replace(".", ",");
                        }
                        else {
                            auxLimC = dt.Rows[j][5].ToString();
                        }                        
                        double LimC = 0;
                        Double.TryParse(auxLimC, out LimC);                        
                        AlDatos.Add(Convert.ToDouble(LimC));//limiteCredito 
                    }
                    AlDatos.Add("BOL");//cod_Moneda
                    AlDatos.Add(24);//ns_cuenta 

                    AlDatos.Add(120);//ns_cuentaAnticipo 
                    AlDatos.Add(dt.Rows[j][2].ToString());//NombreAFacturar 
                    _ = (dt.Rows[j][1].ToString() == "") ? AlDatos.Add("") : AlDatos.Add(Convert.ToUInt32(dt.Rows[j][1]));//NitAFacturar  
                    //if (dt.Rows[j][1].ToString() == "")
                    //{
                    //    AlDatos.Add("");//NitAFacturar 
                    //}
                    //else
                    //{
                    //    AlDatos.Add(Convert.ToUInt32(dt.Rows[j][1]));//NitAFacturar 
                    //}
                    AlDatos.Add(null);//ns_Empleado 
                    AlDatos.Add(0.00);//descped 
                    AlDatos.Add(null);//nsSucursal 
                    AlDatos.Add(0);//DiasCredito 
                    AlDatos.Add(null);//ns_segmento 
                    AlDatos.Add(DateTime.Now);//FechaLimCredito
                    AlDatos.Add("");//cod_TipoLimiteTiempoCredito 
                    AlDatos.Add("");//NombreComercial
                    AlDatos.Add(0);//DiaLimFactura 
                    AlDatos.Add(0);//DiasLimiteMora 
                    bool sw = _general.RegistrarCliente2(AlDatos);
                    if (sw)
                    {
                        ns = Convert.ToInt32(dt.Rows[j][0]);
                    }
                    AlDatos.Clear();
                }

                dt.Rows[j][5] = ns.ToString();
                bExiste = false;
            }
            dtDato.Clear();
            #endregion


        }

        /// POR CORREGUIR   ERROR AL COMPARAR  EXCEL CLIENTE Y LA BASE DE DATOS
        public bool compararExcel_TablaCliente(DataTable dt1)
        {
            bool sw = true;
            DataTable dt2 = _general.listarClientes();

            DataTable dtDirectorio = _general.listarDirectorios();
            DataTable dtTelefono = _general.listarTelefonos();


            for (int j = 1; j < dt1.Rows.Count; j++)
            {
                DataRow row = dt1.Rows[j];
                bool sw2 = isRowNull(row);
                if (!sw2)//si casillas no vacias en excel
                {
                    //Directorio
                    string n = dt1.Rows[j][1].ToString();//nombre excel
                    string email = dt1.Rows[j][2].ToString();//email excel
                    string iddirect = obtenerCampo_DTable(dtDirectorio, "nombre", n, "num_sec");
                    string nombreDir = "";
                    string emailDir = "";
                    if (iddirect != "")
                    {
                        nombreDir = obtenerCampo_DTable(dtDirectorio, "num_sec", iddirect, "nombre");//nombre DB Directorio
                        emailDir = obtenerCampo_DTable(dtDirectorio, "num_sec", iddirect, "email");//email DB Directorio
                    }
                    if (!n.Equals(nombreDir))
                    {
                        sw = false;
                        this.ErrorListCompare.Add($"Error, dato: {n}  y  {nombreDir} NO son iguales, en [ {j} - 1 ] en la Base de Datos");
                    }
                    if (!email.Equals(emailDir))
                    {
                        sw = false;
                        this.ErrorListCompare.Add($"Error, dato: {email}  y  {emailDir} NO son iguales, en [ {j} - 2 ] en la Base de Datos");
                    }

                    //telefono
                    string telef = dt1.Rows[j][5].ToString();//telef excel
                    string idTelefono = obtenerCampo_DTable(dtTelefono, "numero", telef, "num_sec");
                    string numTelefono = "";
                    if (idTelefono != "")
                    {
                        numTelefono = obtenerCampo_DTable(dtTelefono, "num_sec", idTelefono, "numero");//telef DB Telefono
                    }
                    if (!telef.Equals(numTelefono))
                    {
                        sw = false;
                        this.ErrorListCompare.Add($"Error, dato: {telef}  y  {numTelefono} NO son iguales, en [ {j} - 5 ] en la Base de Datos");
                    }

                    //cliente
                    string LimitCred = dt1.Rows[j][4].ToString();//limiCred excel
                    string conCred = dt1.Rows[j][3].ToString();//conCred excel
                    string limCredCliente = "";
                    string conCredCliente = "";

                    if (LimitCred == "") { LimitCred = "0.00"; }
                    if (conCred == "SI") { conCred = "1"; } else { conCred = "0"; }

                    if (iddirect != "")
                    {
                        limCredCliente = obtenerCampo_DTable(dt2, "num_sec", iddirect, "limiteCredito");
                        conCredCliente = obtenerCampo_DTable(dt2, "num_sec", iddirect, "conCredito");
                    }
                    if (limCredCliente == "") { limCredCliente = "0.00"; }
                    if (conCredCliente == "") { conCredCliente = "0"; }
                    if (!Convert.ToDouble(LimitCred).Equals(Convert.ToDouble((limCredCliente))))
                    {
                        sw = false;
                        this.ErrorListCompare.Add($"Error, dato: {LimitCred}  y  {limCredCliente} NO son iguales, en [ {j} - 4 ] en la Base de Datos");
                    }
                    if (!Convert.ToInt32(conCred).Equals(Convert.ToInt32(conCredCliente)))
                    {
                        sw = false;
                        this.ErrorListCompare.Add($"Error, dato: {conCred}  y  {conCredCliente} NO son iguales, en [ {j} - 4 ] en la Base de Datos");
                    }

                }

            }
            return sw;
        }
        //
        public void migrarTablaEmpleado(DataTable dt)
        {

            ArrayList AlDatos;
            ArrayList AlDatoEmpl;
            ArrayList AlDatoTelf;
            ArrayList AlDatoPerson;
            int ns = -1;
            bool bExiste = false;

            string apeMat = "";
            string correo = "";

            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row = dt.Rows[j];
                bool sw = isRowNull(row);
                if (!sw)// si row no es vacia
                {

                    string apePat = dt.Rows[j][1].ToString();
                    apeMat = dt.Rows[j][2].ToString();
                    string nombre = dt.Rows[j][3].ToString();
                    correo = dt.Rows[j][4].ToString();
                    string telef = dt.Rows[j][5].ToString();
                    string fingreso = dt.Rows[j][6].ToString();


                    #region //Directorio
                    AlDatos = new ArrayList();
                    AlDatos.Add(-1); //@n_s
                    AlDatos.Add(apePat + " " + apeMat + " " + nombre);
                    AlDatos.Add("");//nit
                    AlDatos.Add("");//direc
                    AlDatos.Add(correo);
                    AlDatos.Add("");//obs
                    AlDatos.Add(1);//ns_TipoDirectorio --usua  --suc    
                    ns = _general.RegistrarDirectorio(AlDatos);
                    AlDatos.Clear();
                    #endregion

                    #region //Telefono
                    if (telef != null || telef != "")
                    {
                        AlDatoTelf = new ArrayList();
                        AlDatoTelf.Add(Convert.ToInt32(telef));
                        AlDatoTelf.Add("Tel");
                        AlDatoTelf.Add("");
                        AlDatoTelf.Add(Convert.ToInt32(ns));
                        _general.registrarTelefono(AlDatoTelf);
                        AlDatoTelf.Clear();

                    }
                    #endregion

                    //persona
                    AlDatoPerson = new ArrayList();
                    AlDatoPerson.Add("1");// tipo varchar,
                    AlDatoPerson.Add(Convert.ToInt32(ns));//n_s integer,
                    AlDatoPerson.Add("");//ci varchar(15),
                    AlDatoPerson.Add("SC");//proced varchar(2),
                    AlDatoPerson.Add(apePat);//appaterno varchar(40),
                    AlDatoPerson.Add(apeMat);//appMaterno varchar(20),
                    AlDatoPerson.Add(nombre);//nombre varchar(20),
                    AlDatoPerson.Add(DateTime.Now);//fnac datetime,
                    AlDatoPerson.Add("sc");//lugarNac varchar(40),
                    AlDatoPerson.Add(null);//foto image,
                    AlDatoPerson.Add("F");//cod_Genero varchar,
                    AlDatoPerson.Add("SOL");//cod_EstadoCivil varchar(3),
                    AlDatoPerson.Add(null);//nrocompci varchar(10),
                    AlDatoPerson.Add(null);//apcasada varchar(20)
                    _general.RegistrarPersona(AlDatoPerson);


                    ////Empleado
                    AlDatoEmpl = new ArrayList();
                    AlDatoEmpl.Add("1"); //tipo varchar,
                    AlDatoEmpl.Add(Convert.ToInt32(ns));// @n_s integer,
                    AlDatoEmpl.Add("AEG");//susuario varchar(30),
                    AlDatoEmpl.Add(Convert.ToDateTime(fingreso));//fingreso datetime,
                    AlDatoEmpl.Add("");//nroCuenta varchar(20),	
                    AlDatoEmpl.Add(0);//annoExterno tinyint,
                    AlDatoEmpl.Add(0);//mesExterno tinyint,
                    AlDatoEmpl.Add(0);//diaExterno tinyint,
                    AlDatoEmpl.Add(0);//PreparaHuella bit,
                    AlDatoEmpl.Add(0);//conCodigo bit,
                    AlDatoEmpl.Add(null);//ns_Grupo integer,
                    AlDatoEmpl.Add("FU");//cod_Afiliacion char(2),
                    AlDatoEmpl.Add(null);//ns_Area integer,
                    AlDatoEmpl.Add("");//nua varchar(10),
                    AlDatoEmpl.Add("");//libmil varchar(15),
                    AlDatoEmpl.Add(1);//ns_sucursal int,
                    AlDatoEmpl.Add("");//email_pwd varchar(30),
                    AlDatoEmpl.Add("");//codrc_iva varchar(20),
                    AlDatoEmpl.Add("");//nroSeguro varchar(50)
                    _general.RegistrarEmpleado(AlDatoEmpl);


                }
            }
        }

        public void migrarTablaEmpleado2(DataTable dt)
        {
            this.ErrorListMigrate.Clear();

            DataTable dtDirectorio = _general.listarDirectorios();
            DataTable dtDato = new DataTable();
            dtDato.Columns.Add("indice");
            dtDato.Columns.Add("nombre");
            dtDato.Columns.Add("ns");

            ArrayList AlDatos;
            int ns = -1;
            bool bExiste = false;
            string nombre;
            string nombrecompleto = "";
            string apeMat = "";
            string correo = "";

            #region Directorio        
            for (int j = 0; j < dtDirectorio.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtDirectorio.Rows[j]["nombre"].ToString(), dtDirectorio.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row1 = dt.Rows[j];
                bool sw = isRowNull(row1);
                if (!sw)// si row no es vacia
                {
                    string ci     = dt.Rows[j][1].ToString();
                    string apePat = dt.Rows[j][2].ToString();
                    apeMat = dt.Rows[j][3].ToString();
                    nombre = dt.Rows[j][4].ToString();
                    correo = dt.Rows[j][5].ToString();
                    string telef    = dt.Rows[j][6].ToString();
                    string fingreso = dt.Rows[j][7].ToString();

                    nombrecompleto = apePat + " " + apeMat + " " + nombre;
                    DataRow[] rslt = dtDato.Select("nombre = '" + nombrecompleto + "'");

                    foreach (DataRow row in rslt)
                    {
                        //dt.Rows[j][5] = row["ns"];
                        dt.Rows[j][5] = -1;
                        bExiste = true;
                        this.ErrorListMigrate.Add($"ERROR no se Insertò...Directorio con Nombre: {nombre} ya Existe, en Fila {j} ");
                    }
                    if (!bExiste)//No existe
                    {
                        dtDato.Rows.Add(dtDato.Rows.Count + 1, nombrecompleto, ns);

                        AlDatos = new ArrayList();
                        AlDatos.Add(-1); //@n_s
                        AlDatos.Add(apePat + " " + apeMat + " " + nombre);
                        AlDatos.Add("");//nit
                        AlDatos.Add("");//direc
                        AlDatos.Add(correo);
                        AlDatos.Add("");//obs
                        AlDatos.Add(1);//ns_TipoDirectorio   
                        ns = _general.RegistrarDirectorio(AlDatos);
                        AlDatos.Clear();

                        dt.Rows[j][5] = ns.ToString();

                        rslt = dtDato.Select("indice = '" + dtDato.Rows.Count + "'");
                        foreach (DataRow row in rslt)
                        {
                            row["ns"] = ns;
                        }
                        ns = -1;
                    }
                    bExiste = false;
                }
                else {
                    break;
                }                
            }
            dtDato.Clear();
            #endregion

            #region Telefono
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row1 = dt.Rows[j];
                bool sw1 = isRowNull(row1);
                if (!sw1)// si row no es vacia
                {
                    nombre = dt.Rows[j][6].ToString();
                    DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                    foreach (DataRow row in rslt)
                    {
                        dt.Rows[j][6] = row["ns"];
                        bExiste = true;
                    }
                    if (!bExiste)//No existe
                    {
                        if (!dt.Rows[j][5].ToString().Equals("-1")) // si (-1) no inserto directorio
                        {
                            dtDato.Rows.Add(j.ToString(), nombre, ns);
                            if (nombre != null && nombre != "")
                            {
                                AlDatos = new ArrayList();   
                                AlDatos.Add(Convert.ToInt32(nombre));//Telef
                                AlDatos.Add("Tel");
                                AlDatos.Add("");
                                AlDatos.Add(Convert.ToInt32(dt.Rows[j][5]));//nsDirectorio
                                bool sw = _general.registrarTelefono2(AlDatos);
                                if (sw)
                                {
                                    ns = Convert.ToInt32(dt.Rows[j][5]);
                                }
                                AlDatos.Clear();
                            }
                        }                        
                        dt.Rows[j][6] = ns.ToString();

                        rslt = dtDato.Select("indice = '" + j.ToString() + "'");
                        foreach (DataRow row in rslt)
                        {
                            row["ns"] = ns;
                        }
                        ns = -1;
                    }
                    bExiste = false;
                }
                else { break; }
            }
            dtDato.Clear();
            #endregion

            #region Persona            
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row1 = dt.Rows[j];
                bool sw1 = isRowNull(row1);
                if (!sw1)// si row no es vacia
                {                   
                    string ci     = dt.Rows[j][1].ToString();
                    string apePat = dt.Rows[j][2].ToString();
                    apeMat = dt.Rows[j][3].ToString();
                    nombre = dt.Rows[j][4].ToString();
                    correo = dt.Rows[j][5].ToString();

                    if (!dt.Rows[j][5].ToString().Equals("-1")) // si (-1) no inserto directorio
                    {
                        AlDatos = new ArrayList();
                        AlDatos.Add("1");// tipo
                        AlDatos.Add(Convert.ToInt32(dt.Rows[j][5]));//n_s integer,
                        _ = (ci == "") ? AlDatos.Add("") : AlDatos.Add(Convert.ToInt32(ci));//nit                  
                        AlDatos.Add("SC");//proced
                        AlDatos.Add(apePat);//appaterno
                        AlDatos.Add(apeMat);//appMaterno
                        AlDatos.Add(nombre);//nombre
                        AlDatos.Add(DateTime.Now);//fnac
                        AlDatos.Add("sc");//lugarNac
                        AlDatos.Add(null);//foto
                        AlDatos.Add("F");//cod_Genero
                        AlDatos.Add("SOL");//cod_EstadoCivil
                        AlDatos.Add(null);//nrocompci
                        AlDatos.Add(null);//apcasada
                        bool sw = _general.RegistrarPersona2(AlDatos);

                        if (sw)
                        {
                            ns = Convert.ToInt32(dt.Rows[j][5]);
                        }
                        AlDatos.Clear();
                    }
                    dt.Rows[j][1] = ns.ToString();                    
                    ns = -1;
                    bExiste = false;
                }
                else{   break;  }
            }
            #endregion


            #region Empleado         
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row1 = dt.Rows[j];
                bool sw1 = isRowNull(row1);
                if (!sw1)// si row no es vacia
                {   
                    string fingreso = dt.Rows[j][7].ToString();

                    if (!dt.Rows[j][5].ToString().Equals("-1")) // si (-1) no inserto directorio
                    {                    
                        AlDatos = new ArrayList();
                        AlDatos.Add("1"); //tipo
                        AlDatos.Add(Convert.ToInt32(dt.Rows[j][5]));// @n_s
                        AlDatos.Add("AEG");//susuario
                        AlDatos.Add(Convert.ToDateTime(fingreso));//fingreso
                        AlDatos.Add("");//nroCuenta 
                        AlDatos.Add(0);//annoExterno
                        AlDatos.Add(0);//mesExterno
                        AlDatos.Add(0);//diaExterno
                        AlDatos.Add(0);//PreparaHuella
                        AlDatos.Add(0);//conCodigo
                        AlDatos.Add(null);//ns_Grupo
                        AlDatos.Add("FU");//cod_Afiliacion
                        AlDatos.Add(null);//ns_Area
                        AlDatos.Add("");//nua
                        AlDatos.Add("");//libmil
                        AlDatos.Add(1);//ns_sucursal
                        AlDatos.Add("");//email_pwd
                        AlDatos.Add("");//codrc_iva
                        AlDatos.Add("");//nroSeguro
                        bool sw = _general.RegistrarEmpleado2(AlDatos);
                        if (sw)
                        {
                            ns = Convert.ToInt32(dt.Rows[j][5]);
                        }
                        AlDatos.Clear();
                    }
                    dt.Rows[j][4] = ns.ToString();
                    ns = -1;
                    bExiste = false;
                }
                else
                {  break;   }
            }
            #endregion

        }
        public void migrarTablaProveedores( DataTable dt) {
            ArrayList AlDatosDirect;
            ArrayList AlDatoTelf;
            ArrayList AlDatoPerson;
            ArrayList AlDatoProvee;
            int ns = -1;                  

            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row = dt.Rows[j];
                bool sw = isRowNull(row);
                if (!sw)// si row no es vacia
                {
                    string nombreEmpre = dt.Rows[j][1].ToString();
                    string apePat = dt.Rows[j][2].ToString();
                    string apeMat = dt.Rows[j][3].ToString();
                    string nombre = dt.Rows[j][4].ToString();
                    string correo = dt.Rows[j][5].ToString();
                    string telef  = dt.Rows[j][6].ToString();

                    #region //Directorio
                    AlDatosDirect = new ArrayList();
                    AlDatosDirect.Add(-1); //@n_s                    
                    if ( nombreEmpre != "" ) { 
                        AlDatosDirect.Add(apePat + " " + apeMat + " " + nombre + $" - {nombreEmpre} "); 
                    }
                    else {
                        AlDatosDirect.Add( apePat + " " + apeMat + " " + nombre ); 
                    }
                    AlDatosDirect.Add("");//nit
                    AlDatosDirect.Add("");//direc
                    AlDatosDirect.Add(correo);
                    AlDatosDirect.Add("");//obs
                    if (nombreEmpre != "") { AlDatosDirect.Add(1); } else { AlDatosDirect.Add(2); }//ns_TipoDirectorio                        
                    ns = _general.RegistrarDirectorio(AlDatosDirect);
                    AlDatosDirect.Clear();
                    #endregion

                    #region //Telefono
                    if (telef != null || telef != "")
                    {
                        AlDatoTelf = new ArrayList();
                        AlDatoTelf.Add(Convert.ToInt32(telef));
                        AlDatoTelf.Add("Tel");
                        AlDatoTelf.Add("");
                        AlDatoTelf.Add(Convert.ToInt32(ns));
                        _general.registrarTelefono(AlDatoTelf);
                        AlDatoTelf.Clear();

                    }
                    #endregion
                    #region
                    //persona
                    AlDatoPerson = new ArrayList();
                    AlDatoPerson.Add("1");// tipo varchar,
                    AlDatoPerson.Add(Convert.ToInt32(ns));//n_s integer,
                    AlDatoPerson.Add("");//ci varchar(15),
                    AlDatoPerson.Add("SC");//proced varchar(2),
                    AlDatoPerson.Add(apePat);//appaterno varchar(40),
                    AlDatoPerson.Add(apeMat);//appMaterno varchar(20),
                    AlDatoPerson.Add(nombre);//nombre varchar(20),
                    AlDatoPerson.Add(DateTime.Now);//fnac datetime,
                    AlDatoPerson.Add("sc");//lugarNac varchar(40),
                    AlDatoPerson.Add(null);//foto image,
                    AlDatoPerson.Add("F");//cod_Genero varchar,
                    AlDatoPerson.Add("SOL");//cod_EstadoCivil varchar(3),
                    AlDatoPerson.Add(null);//nrocompci varchar(10),
                    AlDatoPerson.Add(null);//apcasada varchar(20)
                    _general.RegistrarPersona(AlDatoPerson);
                    #endregion 


                    AlDatoProvee = new ArrayList();
                    AlDatoProvee.Add("1"); // @Tipo = 1,
                    AlDatoProvee.Add(Convert.ToInt32(ns)); // @n_s = 1964,
                    AlDatoProvee.Add(null); // @ns_cuenta = 2096,
                    AlDatoProvee.Add(null); // @ns_cuentaAnticipo = 716,
                    AlDatoProvee.Add(null); // @ns_cuentaGarantia = null
                    _general.registrarProveedor(AlDatoProvee);



                }
            }
        }
        public void migrarTablaProveedores2(DataTable dt)
        {
            this.ErrorListMigrate.Clear();
            DataTable dtDirectorio = _general.listarDirectorios();
            DataTable dtDato = new DataTable();
            dtDato.Columns.Add("indice");
            dtDato.Columns.Add("nombre");
            dtDato.Columns.Add("ns");

            string nombre;
            ArrayList AlDatos;
            int ns = -1;
            bool bExiste = false;

            #region Directorio
            for (int j = 0; j < dtDirectorio.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtDirectorio.Rows[j]["nit"].ToString(), dtDirectorio.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                string nit         = dt.Rows[j][1].ToString();
                string nombreEmpre = dt.Rows[j][2].ToString();
                string apePat = dt.Rows[j][3].ToString();
                string apeMat = dt.Rows[j][4].ToString();
                nombre = dt.Rows[j][5].ToString();
                string correo = dt.Rows[j][6].ToString();

                DataRow[] rslt = dtDato.Select("nombre = '" + nit + "'");
                foreach (DataRow row in rslt)
                {
                    if (row["nombre"].ToString() == "")
                    {
                        bExiste = false;
                        break;
                    }
                    else
                    {
                        dt.Rows[j][6] = -1; //row["ns"]; // en pos de correo
                        bExiste = true;
                        this.ErrorListMigrate.Add($"ERROR no se Insertó... número de NIT: {nit} ya Existe, Directorio: {nombre},de  Fila {j} ");
                    }
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(dtDato.Rows.Count + 1, nit, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1); //@n_s                    
                    if (nombreEmpre != "")
                    {
                        AlDatos.Add(apePat + " " + apeMat + " " + nombre + $" - {nombreEmpre} ");
                    }
                    else
                    {
                        AlDatos.Add(apePat + " " + apeMat + " " + nombre);
                    }
                    if (nit == "")
                    {
                        AlDatos.Add("");//nit
                    }
                    else
                    {
                        AlDatos.Add(Convert.ToInt32(nit));//nit
                    }
                    AlDatos.Add("");//direc
                    AlDatos.Add(correo);
                    AlDatos.Add("");//obs
                    if (nombreEmpre != "") { AlDatos.Add(1); } else { AlDatos.Add(2); }//ns_TipoDirectorio                                            
                    ns = _general.RegistrarDirectorio(AlDatos);

                    dt.Rows[j][6] = ns.ToString();
                    AlDatos.Clear();

                    rslt = dtDato.Select("indice = '" + dtDato.Rows.Count + "'");
                    foreach (DataRow row in rslt)
                    {
                        row["ns"] = ns;
                    }
                    ns = -1;
                }
                bExiste = false;
            }
            dtDato.Clear();
            #endregion

            #region Telefono
            for (int j = 1; j < dt.Rows.Count; j++)
            {                
                nombre = dt.Rows[j][7].ToString();
                string email = dt.Rows[j][3].ToString();
                
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    dt.Rows[j][7] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    if (!dt.Rows[j][6].ToString().Equals("-1"))
                    {
                        dtDato.Rows.Add(j.ToString(), nombre, ns);
                        if (nombre != null && nombre != "")
                        {
                            //AlDatos = new ArrayList();

                            AlDatos = new ArrayList();
                            AlDatos.Add(Convert.ToInt32(nombre));
                            AlDatos.Add("Tel");
                            AlDatos.Add("");
                            AlDatos.Add(Convert.ToInt32(dt.Rows[j][6])); //ns_Directorio
                            bool sw = _general.registrarTelefono2(AlDatos);
                            if (sw)
                            {
                                ns = Convert.ToInt32(dt.Rows[j][6]);
                            }
                            AlDatos.Clear();
                        }
                    }                    
                    dt.Rows[j][7] = ns.ToString();

                    rslt = dtDato.Select("indice = '" + j.ToString() + "'");
                    foreach (DataRow row in rslt)
                    {
                        row["ns"] = ns;
                    }
                    ns = -1;
                }
                bExiste = false;
            }
            dtDato.Clear();
            #endregion


            #region Persona            
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row1 = dt.Rows[j];
                bool sw1 = isRowNull(row1);
                if (!sw1)// si row no es vacia
                {
                    string apePat = dt.Rows[j][3].ToString();
                    string apeMat = dt.Rows[j][4].ToString();
                    nombre = dt.Rows[j][5].ToString();

                    if (!dt.Rows[j][6].ToString().Equals("-1"))
                    {
                        //persona
                        AlDatos = new ArrayList();
                        AlDatos.Add("1");// tipo varchar,
                        AlDatos.Add(Convert.ToInt32(dt.Rows[j][6]));//n_s integer,
                        AlDatos.Add("");//ci varchar(15),
                        AlDatos.Add("SC");//proced varchar(2),
                        AlDatos.Add(apePat);//appaterno varchar(40),
                        AlDatos.Add(apeMat);//appMaterno varchar(20),
                        AlDatos.Add(nombre);//nombre varchar(20),
                        AlDatos.Add(DateTime.Now);//fnac datetime,
                        AlDatos.Add("sc");//lugarNac varchar(40),
                        AlDatos.Add(null);//foto image,
                        AlDatos.Add("F");//cod_Genero varchar,
                        AlDatos.Add("SOL");//cod_EstadoCivil varchar(3),
                        AlDatos.Add(null);//nrocompci varchar(10),
                        AlDatos.Add(null);//apcasada varchar(20)                    
                        bool sw = _general.RegistrarPersona2(AlDatos);

                        if (sw)
                        {
                            ns = Convert.ToInt32(dt.Rows[j][6]);
                        }
                        AlDatos.Clear();
                    }                    
                    dt.Rows[j][2] = ns.ToString();
                    ns = -1;
                    bExiste = false;
                }
                else
                {
                    break;
                }


            }
            #endregion


            #region Proveedor
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                if (!dt.Rows[j][6].ToString().Equals("-1"))
                {
                    AlDatos = new ArrayList();
                    AlDatos.Add("1"); // @Tipo = 1,
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][6])); // @n_s = 1964,
                    AlDatos.Add(null); // @ns_cuenta = 2096,
                    AlDatos.Add(null); // @ns_cuentaAnticipo = 716,
                    AlDatos.Add(null); // @ns_cuentaGarantia = null

                    bool sw = _general.registrarProveedor2(AlDatos);
                    if (sw)
                    {
                        ns = Convert.ToInt32(dt.Rows[j][6]);
                    }
                    AlDatos.Clear();
                }
                dt.Rows[j][5] = ns.ToString();
                bExiste = false;
            }
            dtDato.Clear();
            #endregion


        }

        public string obtenerCampo_DTable(DataTable dt, string porCampo, string campoComparar, string campoReturn)
        {
            string Result = "";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string campo = dt.Rows[j][porCampo].ToString();
                string campoRet = dt.Rows[j][campoReturn].ToString();
                if (campo == campoComparar)
                {
                    return campoRet;
                }
            }
            return Result;
        }

        public bool isRowNull(DataRow row)
        {
            foreach (DataColumn column in row.Table.Columns)
                if (!row.IsNull(column))
                    return false;

            return true;
        }

    }
}
