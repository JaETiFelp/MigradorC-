using Borland.Delphi;
using OutlookDemo.Datos.Contabilidad;
using OutlookDemo.Datos.General;
using OutlookDemo.Datos.Inventario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.Native.WinApi;

namespace OutlookDemo.Controladores.ContabilidadController
{
    public class ContabilidadController
    {
        private Contabilidad _contabilidad;

        public ArrayList ErrorListCompare { get; set; }
        public ArrayList ErrorListMigrate { get; set; }

        public ContabilidadController(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {
            _contabilidad = new Contabilidad(nombreSer, usuarioSer, passSer, bdSer);
            ErrorListCompare = new ArrayList();
            ErrorListMigrate = new ArrayList();
        }


        public void migrarTablaCxCobrar(DataTable dt)
        {
            ArrayList AlDatosCxC;
            ArrayList AlDatoCxCdetalle;
            
            int ns = -1;

            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row = dt.Rows[j];
                bool sw = isRowNull(row);
                if (!sw)// si row no es vacia
                {
                    string idCLi            = dt.Rows[j][0].ToString();
                    string fchDeuda         = dt.Rows[j][1].ToString();
                    string fchVencimiento   = dt.Rows[j][2].ToString();
                    string numFact          = dt.Rows[j][3].ToString();
                    string monTotalDeuda    = dt.Rows[j][4].ToString();
                    string monTotalCancelado= dt.Rows[j][5].ToString();
                    string saldo            = dt.Rows[j][6].ToString();

                    #region // cctTxn
                    AlDatosCxC = new ArrayList();
                    AlDatosCxC.Add("1");//tipo varchar,
                    AlDatosCxC.Add(-1);//n_s integer output,
                    AlDatosCxC.Add(Convert.ToDateTime(fchDeuda));//Fecha datetime,             
                    AlDatosCxC.Add("vb");//Mod_Origen varchar(3),
                    AlDatosCxC.Add(6);//Origen varchar(10),
                    AlDatosCxC.Add(null);//MotivoDeuda varchar(200),
                    AlDatosCxC.Add(Convert.ToDouble(monTotalDeuda));//MontoDeuda money,--
                    AlDatosCxC.Add(Convert.ToDouble(monTotalCancelado));//MontoCancelado money,--
                    AlDatosCxC.Add("BOL");//cod_moneda varchar(3),
                    AlDatosCxC.Add("PEN");//cod_estado varchar(3),
                    AlDatosCxC.Add(Convert.ToInt32(idCLi));//ns_Deudor integer,
                    AlDatosCxC.Add(null);//interes money,
                    AlDatosCxC.Add(null);//ns_centroAnalisis integer,
                    AlDatosCxC.Add(DateTime.Now);//FechaUlt datetime,
                    AlDatosCxC.Add(null);//Fiscal bit,
                    AlDatosCxC.Add(null);//ns_TipoTxn integer,
                    AlDatosCxC.Add(null);//ns_TipoCa integer,
                    AlDatosCxC.Add("AEG");//usuario varchar(20),
                    //AlDatosCxC.Add(1);//Suc integer
                    ns = _contabilidad.registrarCxCobrar(AlDatosCxC);
                    AlDatosCxC.Clear();
                    #endregion


                    #region//cxCDetalle
                    AlDatoCxCdetalle = new ArrayList();
                    AlDatoCxCdetalle.Add("1");// @tipo varchar,
                    AlDatoCxCdetalle.Add(-1);//num_sec integer,
                    AlDatoCxCdetalle.Add(null);//descripcion varchar(200),
                    AlDatoCxCdetalle.Add(Convert.ToDouble(monTotalDeuda));//deuda real,
                    AlDatoCxCdetalle.Add(Convert.ToDouble(monTotalCancelado));//montoCancelado money,--
                    AlDatoCxCdetalle.Add(Convert.ToDateTime(fchVencimiento));//FVencimiento datetime,
                    AlDatoCxCdetalle.Add($"Fact: {numFact}");//observacion varchar(200),
                    AlDatoCxCdetalle.Add("PEN");//cod_estado varchar(3),
                    AlDatoCxCdetalle.Add(Convert.ToDouble(monTotalDeuda));//DeudaInicial money,
                    AlDatoCxCdetalle.Add(0.0);//Interesmora money,
                    AlDatoCxCdetalle.Add(Convert.ToInt32(ns));//ns_Txn integer,
                    //AlDatoCxCdetalle.Add(1);//Suc integer
                    _contabilidad.registrarCxCobrarDetalle(AlDatoCxCdetalle);
                    AlDatoCxCdetalle.Clear();
                    #endregion

                }
            }
        }
        public void migrarTablaCxPagar(DataTable dt)
        {
            ArrayList AlDatosCxP;
            ArrayList AlDatoCxPdetalle;

            int ns = -1;

            for (int j = 1; j < dt.Rows.Count; j++)
            {
                DataRow row = dt.Rows[j];
                bool sw = isRowNull(row);
                if (!sw)// si row no es vacia
                {
                    string idCLi = dt.Rows[j][0].ToString();
                    string fchDeuda = dt.Rows[j][1].ToString();
                    string fchVencimiento = dt.Rows[j][2].ToString();
                    string numFact = dt.Rows[j][3].ToString();
                    string monTotalDeuda = dt.Rows[j][4].ToString();
                    string monTotalCancelado = dt.Rows[j][5].ToString();
                    string saldo = dt.Rows[j][6].ToString();

                    #region // cctTxn
                    AlDatosCxP = new ArrayList();
                    AlDatosCxP.Add("1");//tipo varchar,
                    AlDatosCxP.Add(-1);//n_s integer output,
                    AlDatosCxP.Add(Convert.ToDateTime(fchDeuda));//Fecha datetime,             
                    AlDatosCxP.Add("vn");//Mod_Origen varchar(3),
                    AlDatosCxP.Add(null);//Origen varchar(10),
                    AlDatosCxP.Add(null);//MotivoDeuda varchar(200),
                    AlDatosCxP.Add(Convert.ToDouble(monTotalDeuda));//MontoDeuda money,--
                    AlDatosCxP.Add(Convert.ToDouble(monTotalCancelado));//MontoCancelado money,--
                    AlDatosCxP.Add("BOL");//cod_moneda varchar(3),
                    AlDatosCxP.Add("PEN");//cod_estado varchar(3),
                    AlDatosCxP.Add(Convert.ToInt32(idCLi));//ns_Deudor integer,
                    AlDatosCxP.Add(null);//ns_centroAnalisis integer,
                    AlDatosCxP.Add(null);//Fiscal bit,
                    AlDatosCxP.Add(null);//ns_TipoTxn integer,	
                    AlDatosCxP.Add(null);//ns_tipoCa integer,
                    AlDatosCxP.Add(null);//ns_rubro integer,
                    AlDatosCxP.Add("AEG");//usuario varchar(20),
                    //AlDatosCxP.Add();//Suc integer
                    ns = _contabilidad.registrarCxPagar(AlDatosCxP);
                    AlDatosCxP.Clear();
                    #endregion


                    #region//cxCDetalle
                    AlDatoCxPdetalle = new ArrayList();
                    AlDatoCxPdetalle.Add(null);//descripcion varchar(200),
                    AlDatoCxPdetalle.Add(Convert.ToDouble(monTotalDeuda));//deuda real,
                    AlDatoCxPdetalle.Add(Convert.ToDouble(monTotalCancelado));//montoCancelado money,--
                    AlDatoCxPdetalle.Add(Convert.ToDateTime(fchVencimiento));//FVencimiento datetime,
                    AlDatoCxPdetalle.Add($"Fact: {numFact}");//observacion varchar(200),
                    AlDatoCxPdetalle.Add("PEN");//cod_estado varchar(3),
                    AlDatoCxPdetalle.Add(Convert.ToInt32(ns));//ns_Txn integer,
                    //AlDatoCxPdetalle.Add();//Suc integer
                    _contabilidad.registrarCxPagarDetalle(AlDatoCxPdetalle);
                    AlDatoCxPdetalle.Clear();
                    #endregion

                }
            }
        }
        public void migrarTablaCxCobrar2(DataTable dt) {

            ErrorListMigrate.Clear();
            DataTable dtDato = new DataTable();
            dtDato.Columns.Add("indice");
            dtDato.Columns.Add("nombre");
            dtDato.Columns.Add("ns");

            string nombre;
            ArrayList AlDatos;
            int ns = -1;
            bool bExiste = false;



            #region cctTxn
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                string idCLi = dt.Rows[j][0].ToString();
                string fchDeuda = dt.Rows[j][1].ToString();
                string fchVencimiento = dt.Rows[j][2].ToString();
                string numFact = dt.Rows[j][3].ToString();
                string monTotalDeuda = dt.Rows[j][4].ToString();
                string monTotalCancelado = dt.Rows[j][5].ToString();
                string saldo = dt.Rows[j][6].ToString();

                nombre = idCLi;
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][3] = row["ns"];
                    dt.Rows[j][1] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    
                     // cctTxn
                    AlDatos = new ArrayList();
                    AlDatos.Add("1");//tipo varchar,
                    AlDatos.Add(-1);//n_s integer output,
                    AlDatos.Add(Convert.ToDateTime(fchDeuda));//Fecha datetime,             
                    AlDatos.Add("vb");//Mod_Origen varchar(3),
                    AlDatos.Add(6);//Origen varchar(10),
                    AlDatos.Add(null);//MotivoDeuda varchar(200),
                    AlDatos.Add(Convert.ToDouble(monTotalDeuda));//MontoDeuda money,
                    AlDatos.Add(Convert.ToDouble(monTotalCancelado));//MontoCancelado money,
                    AlDatos.Add("BOL");//cod_moneda varchar(3),
                    AlDatos.Add("PEN");//cod_estado varchar(3),
                    AlDatos.Add(Convert.ToInt32(idCLi));//ns_Deudor integer,
                    AlDatos.Add(null);//interes money,
                    AlDatos.Add(null);//ns_centroAnalisis integer,
                    AlDatos.Add(DateTime.Now);//FechaUlt datetime,
                    AlDatos.Add(null);//Fiscal bit,
                    AlDatos.Add(null);//ns_TipoTxn integer,
                    AlDatos.Add(null);//ns_TipoCa integer,
                    AlDatos.Add("AEG");//usuario varchar(20),
                    ns = _contabilidad.registrarCxCobrar(AlDatos);

                    dt.Rows[j][0] = ns.ToString();

                    AlDatos.Clear();

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

            #region cxCDetalle
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                string idCLi = dt.Rows[j][0].ToString();
                string fchDeuda = dt.Rows[j][1].ToString();
                string fchVencimiento = dt.Rows[j][2].ToString();
                string numFact = dt.Rows[j][3].ToString();
                string monTotalDeuda = dt.Rows[j][4].ToString();
                string monTotalCancelado = dt.Rows[j][5].ToString();
                string saldo = dt.Rows[j][6].ToString();

                nombre = numFact;
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][3] = row["ns"];
                    dt.Rows[j][3] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add("1");// @tipo varchar,
                    AlDatos.Add(-1);//num_sec integer,
                    AlDatos.Add(null);//descripcion varchar(200),
                    AlDatos.Add(Convert.ToDouble(monTotalDeuda));//deuda real,
                    AlDatos.Add(Convert.ToDouble(monTotalCancelado));//montoCancelado money,--
                    AlDatos.Add(Convert.ToDateTime(fchVencimiento));//FVencimiento datetime,
                    AlDatos.Add($"Fact: {numFact}");//observacion varchar(200),
                    AlDatos.Add("PEN");//cod_estado varchar(3),
                    AlDatos.Add(Convert.ToDouble(monTotalDeuda));//DeudaInicial money,
                    AlDatos.Add(0.0);//Interesmora money,
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][0]));//ns_Txn integer,
                    bool sw =_contabilidad.registrarCxCobrarDetalle(AlDatos);
                    if (sw)
                    {
                        ns = Convert.ToInt32(dt.Rows[j][0]);
                    }
                    //ns = _contabilidad.registrarCxCobrar(AlDatos);

                    dt.Rows[j][3] = ns.ToString();
                    AlDatos.Clear();

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

        }
        public void migrarTablaCxPagar2(DataTable  dt) {
            ErrorListMigrate.Clear();
            DataTable dtDato = new DataTable();
            dtDato.Columns.Add("indice");
            dtDato.Columns.Add("nombre");
            dtDato.Columns.Add("ns");

            string nombre;
            ArrayList AlDatos;
            int ns = -1;
            bool bExiste = false;


            #region CxP
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                string idCLi = dt.Rows[j][0].ToString();
                string fchDeuda = dt.Rows[j][1].ToString();
                string fchVencimiento = dt.Rows[j][2].ToString();
                string numFact = dt.Rows[j][3].ToString();
                string monTotalDeuda = dt.Rows[j][4].ToString();
                string monTotalCancelado = dt.Rows[j][5].ToString();
                string saldo = dt.Rows[j][6].ToString();


                nombre = dt.Rows[j][4].ToString();
                nombre = idCLi;
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][3] = row["ns"];
                    dt.Rows[j][0] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add("1");//tipo varchar,
                    AlDatos.Add(-1);//n_s integer output,
                    AlDatos.Add(Convert.ToDateTime(fchDeuda));//Fecha datetime,             
                    AlDatos.Add("vn");//Mod_Origen varchar(3),
                    AlDatos.Add(null);//Origen varchar(10),
                    AlDatos.Add(null);//MotivoDeuda varchar(200),
                    AlDatos.Add(Convert.ToDouble(monTotalDeuda));//MontoDeuda money,--
                    AlDatos.Add(Convert.ToDouble(monTotalCancelado));//MontoCancelado money,--
                    AlDatos.Add("BOL");//cod_moneda varchar(3),
                    AlDatos.Add("PEN");//cod_estado varchar(3),
                    AlDatos.Add(Convert.ToInt32(idCLi));//ns_Deudor integer,
                    AlDatos.Add(null);//ns_centroAnalisis integer,
                    AlDatos.Add(null);//Fiscal bit,
                    AlDatos.Add(null);//ns_TipoTxn integer,	
                    AlDatos.Add(null);//ns_tipoCa integer,
                    AlDatos.Add(null);//ns_rubro integer,
                    AlDatos.Add("AEG");//usuario varchar(20),
                    //AlDatosCxP.Add();//Suc integer
                    ns = _contabilidad.registrarCxPagar(AlDatos);                   

                    dt.Rows[j][0] = ns.ToString();

                    AlDatos.Clear();

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

            #region CxPDetalle
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                string idCLi = dt.Rows[j][0].ToString();
                string fchDeuda = dt.Rows[j][1].ToString();
                string fchVencimiento = dt.Rows[j][2].ToString();
                string numFact = dt.Rows[j][3].ToString();
                string monTotalDeuda = dt.Rows[j][4].ToString();
                string monTotalCancelado = dt.Rows[j][5].ToString();
                string saldo = dt.Rows[j][6].ToString();

                nombre = numFact;
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][3] = row["ns"];
                    dt.Rows[j][3] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(null);//descripcion varchar(200),
                    AlDatos.Add(Convert.ToDouble(monTotalDeuda));//deuda real,
                    AlDatos.Add(Convert.ToDouble(monTotalCancelado));//montoCancelado money,--
                    AlDatos.Add(Convert.ToDateTime(fchVencimiento));//FVencimiento datetime,
                    AlDatos.Add($"Fact: {numFact}");//observacion varchar(200),
                    AlDatos.Add("PEN");//cod_estado varchar(3),
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][0]));//ns_Txn integer,
                    //AlDatoCxPdetalle.Add();//Suc integer
                    bool sw = _contabilidad.registrarCxPagarDetalle(AlDatos);
                    if (sw)
                    {
                        ns = Convert.ToInt32(dt.Rows[j][0]);
                    }

                    dt.Rows[j][3] = ns.ToString();

                    AlDatos.Clear();

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
