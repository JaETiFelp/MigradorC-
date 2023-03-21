using Borland.Delphi;
using OutlookDemo.Datos.Inventario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OutlookDemo.Controladores.InventarioController
{
    public class InventarioController
    {
        private Inventario _inventario;

        public ArrayList ErrorListCompare { get; set; }
        public ArrayList ErrorListMigrate { get; set; }
        public InventarioController(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {
            _inventario = new Inventario(nombreSer, usuarioSer, passSer, bdSer);
            ErrorListCompare = new ArrayList();
            ErrorListMigrate = new ArrayList();
        }


        public void migrarTablaProducto(DataTable dt)
        {
            this.ErrorListMigrate.Clear();

            DataTable dtGrupo   = _inventario.ListGrupo2column();
            DataTable dtTipo    = _inventario.ListTipo2column();
            DataTable dtSubTipo = _inventario.ListSubTipo2column();
            DataTable dtMarca   = _inventario.ListMarca2column();
            DataTable dtUnidad  = _inventario.ListUnidad2column();
            DataTable dtProduco = _inventario.ListProducto2column();
            DataTable dtProducto = _inventario.listaProductos();
            DataTable dtLote    = _inventario.ListLote2column();
            DataTable dtLoteAll = _inventario.listaLote();
            //DataTable dtStock   = _inventario.ListStock2column();
            DataTable dtDato    = new DataTable();
            dtDato.Columns.Add("indice");
            dtDato.Columns.Add("nombre");
            dtDato.Columns.Add("ns");

            string nombre;
            ArrayList AlDatos;
            int ns = -1;
            bool bExiste = false;

            #region Grupo
            for (int j = 0; j < dtGrupo.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtGrupo.Rows[j]["nombre"].ToString(), dtGrupo.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][4].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    dt.Rows[j][4] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(dtDato.Rows.Count+1, nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);
                    AlDatos.Add("");
                    AlDatos.Add(null);
                    AlDatos.Add("");
                    AlDatos.Add(0);

                    ns = _inventario.RegistrarGrupo(AlDatos);
                    dt.Rows[j][4] = ns.ToString();

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


            #region Tipo
            for (int j = 0; j < dtTipo.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtTipo.Rows[j]["Descripcion"].ToString(), dtTipo.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][5].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][4] = row["ns"];
                    dt.Rows[j][5] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(dtDato.Rows.Count + 1, nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);
                    AlDatos.Add("");

                    ns = _inventario.RegistrarTipo(AlDatos);
                    dt.Rows[j][5] = ns.ToString();

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

            #region SubTipo

            for (int j = 0; j < dtSubTipo.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtSubTipo.Rows[j]["Nombre"].ToString(), dtSubTipo.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
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
                    dtDato.Rows.Add(dtDato.Rows.Count + 1, nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);

                    ns = _inventario.RegistrarSubTipoProd(AlDatos);
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

            #region Marca
            for (int j = 0; j < dtMarca.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtMarca.Rows[j]["Nombre"].ToString(), dtMarca.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][7].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][6] = row["ns"];
                    dt.Rows[j][7] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(dtDato.Rows.Count + 1, nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);
                    AlDatos.Add(0);
                    AlDatos.Add("");

                    ns = _inventario.RegistrarMarca(AlDatos);
                    dt.Rows[j][7] = ns.ToString();

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

            #region Unidad
            for (int j = 0; j < dtUnidad.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtUnidad.Rows[j]["nombre"].ToString(), dtUnidad.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                //nombre = dt.Rows[j][7].ToString();
                nombre = dt.Rows[j][8].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    dt.Rows[j][8] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(dtDato.Rows.Count + 1, nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);
                    AlDatos.Add("");
                    AlDatos.Add(0);

                    ns = _inventario.RegistrarUnidad(AlDatos);
                    dt.Rows[j][8] = ns.ToString();

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



            #region Producto
            for (int j = 0; j < dtProduco.Rows.Count; j++)
            {
                dtDato.Rows.Add((j + 1).ToString(), dtProduco.Rows[j]["codigo"].ToString(), dtProduco.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][1].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");
                foreach (DataRow row1 in rslt)
                {
                    DataRow[] prodRow = dtProducto.Select("codigo = '" + nombre + "'");
                    foreach (DataRow row in prodRow)
                    {
                        string controlado = "";
                        if (dt.Rows[j][10].ToString() == "SI") { controlado = "1"; } else { controlado = "0"; }//controlado bit,

                        if (!nombre.Equals(row["codigo"].ToString()) //codigo
                               || !dt.Rows[j][2].ToString().Equals(row["codAlterno"].ToString()) //codBarra
                               || !dt.Rows[j][3].ToString().Equals(row["nombre"].ToString()) //nombre
                               || !dt.Rows[j][4].ToString().Equals(row["ns_Grupo"].ToString()) //grupo
                               || !dt.Rows[j][5].ToString().Equals(row["ns_TipoProd"].ToString()) //tipo
                               || !dt.Rows[j][6].ToString().Equals(row["ns_SubTipo"].ToString()) //subtipo
                               || !dt.Rows[j][7].ToString().Equals(row["ns_Marca"].ToString()) //marca
                               || !dt.Rows[j][8].ToString().Equals(row["ns_Unidad"].ToString()) //unidad
                               || !controlado.ToString().Equals(row["controlado"].ToString()) //controlado
                            )
                        {                           
                            this.ErrorListMigrate.Add($"ERROR{j}... Producto REPETIDO con Código: {dt.Rows[j][1].ToString()} ya Existe en BD, pero alguna COLUMNA de Excel varia en Fila {j} ");
                            //bExiste = false;
                            dt.Rows[j][1] = row1["ns"];
                            dt.Rows[j][0] = -1;
                            bExiste = true;
                        }
                        else
                        {
                            dt.Rows[j][1] = row1["ns"];
                            dt.Rows[j][0] = -1;
                            bExiste = true;
                        }
                    }
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(dtDato.Rows.Count + 1, nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);//ns
                    if (dt.Rows[j][1].ToString() == "" || dt.Rows[j][1].ToString() == null)
                    {
                        AlDatos.Add(dt.Rows[j][2].ToString());//codigo  == codBarra
                    }
                    else
                    {
                        AlDatos.Add(dt.Rows[j][1].ToString());//codigo
                    }

                    if (dt.Rows[j][2].ToString().Length > 0)////codigoAlterno
                    {
                        AlDatos.Add((dt.Rows[j][2].ToString()));
                    }
                    else
                    {
                        AlDatos.Add("");
                    }
                    AlDatos.Add("");//serie
                    AlDatos.Add(dt.Rows[j][3].ToString());//nombre
                    AlDatos.Add(null);//imagen
                    AlDatos.Add("");//medida
                    AlDatos.Add("");//color
                    AlDatos.Add("");//modelo
                    AlDatos.Add("");//composicion
                    AlDatos.Add("");//linea
                    AlDatos.Add("");//categoria   al migrar poner siempre vacio
                    AlDatos.Add(0);//peso
                    AlDatos.Add(dt.Rows[j][9].ToString());//caracteristicas
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][5]));//ns_TipoProd
                    AlDatos.Add("PROD");//cod_ClaseProd
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][8]));//ns_Unidad
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][4]));//ns_Grupo
                    AlDatos.Add(null);//ns_NomGenerico
                    AlDatos.Add(false);//compuesto
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][7]));//ns_Marca
                    AlDatos.Add(true);//habilitado
                    AlDatos.Add("");//codigoUbicacion
                    AlDatos.Add("1");//presentacion
                    AlDatos.Add(null);//ns_Proveedor
                    AlDatos.Add(1);//habilitaalerta
                    AlDatos.Add(1);//stockminimo
                    AlDatos.Add(1);//habilitaCompra
                    AlDatos.Add(0);//EsActivoFijo
                    AlDatos.Add(0);//EsEquipoGarantia
                    AlDatos.Add(0);//EsIEHD
                    AlDatos.Add(dt.Rows[j][6]);//ns_SubTipo
                    AlDatos.Add(1000000);//stockMaximo
                    AlDatos.Add(dt.Rows[j][8]);//ns_UnidadContenido
                    AlDatos.Add(0);//empaque
                    AlDatos.Add(null);//ns_prodRemp
                    AlDatos.Add(null);//cod_Clasificacion
                    AlDatos.Add(null);//cod_Clasificacionprov
                    AlDatos.Add(0);//tieneGA
                    AlDatos.Add(0);//EsIEHDCompra
                    AlDatos.Add(null);//ns_nandina

                    AlDatos.Add(null);//ns_productoImpuestos integer,
                    AlDatos.Add(null);//patrocinado integer,
                    if (dt.Rows[j][10].ToString() == "SI") { AlDatos.Add(1); } else { AlDatos.Add(0); }//controlado bit,
                    //AlDatos.Add(null);//controlado bit,

                    ns = _inventario.RegistrarProducto(AlDatos);
                    if (ns.ToString().Equals("-1"))
                    {
                        this.ErrorListMigrate.Add($"ERROR NO MIGRADO,... El PRODUCTO con  código: {nombre}, Fila {j} de Excel  NO se migró");
                    }
                    dt.Rows[j][1] = ns.ToString();
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


            #region Lote
            for (int j = 0; j < dtLote.Rows.Count; j++)
            {                
                dtDato.Rows.Add((j + 1).ToString(), dtLote.Rows[j]["codigo"].ToString(), dtLote.Rows[j]["num_sec"].ToString());
            }
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][12].ToString();//Codigo Lote
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    // si existe lote y es nuevo producto   error no se puede insertar Lote ya existe lote para otro producto
                    if (!dt.Rows[j][0].ToString().Equals("-1")) //nuevo producto insertado
                    {
                        bool sw = false;
                        DataRow[] algunProd = dtLoteAll.Select("codigo = '" + row["nombre"].ToString() + "'");
                        foreach (DataRow r  in algunProd) {                            
                            this.ErrorListMigrate.Add($" ........... ERROR FATAL...  LOTE:   {nombre} ya fué asignado a un PRODUCTO.  Excel: Fila {j} ");
                            sw = true;
                            break;
                        }
                        if (sw) {
                            dt.Rows[j][12] = -1;
                            bExiste = true;
                        }
                        else
                        {
                            bExiste = false;
                        }   
                        break;
                    }
                    else {
                        //dt.Rows[j][12] = row["ns"];
                        dt.Rows[j][12] = -1;
                        bExiste = true;
                        this.ErrorListMigrate.Add($"ERROR...LOTE  con Código: {nombre} ya Existe, no se insertó en BD.   Excel: Fila {j} ");
                        break;
                    }

                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(dtDato.Rows.Count + 1, nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);//ns
                    AlDatos.Add(nombre);//Codigo
                    AlDatos.Add(dt.Rows[j][13].ToString());// Descripcion
                    AlDatos.Add("");//Observacion
                    //TipoCambio
                    double tc = _inventario.DevuelveTipoCambio();
                    //End TipoCambio
                    string auxCostoBol = dt.Rows[j][15].ToString().Replace(".", ",");
                    double CostBol = 0;
                    Double.TryParse(auxCostoBol, out CostBol);
                    AlDatos.Add(CostBol / tc);//CostoDOL
                    AlDatos.Add(CostBol);//CostoBOL

                    string auxPrecioBol = dt.Rows[j][17].ToString().Replace(".", ",");
                    double preBol = 0;
                    Double.TryParse(auxPrecioBol, out preBol);
                    AlDatos.Add(preBol / tc);//PrecioDOL
                    AlDatos.Add(preBol);//PrecioBOL

                    AlDatos.Add(DateTime.Now);//Fecha Ingreso
                    AlDatos.Add(DateTime.Now);//Fecha Fabricacion
                    AlDatos.Add(Convert.ToDateTime(dt.Rows[j][14]));//Fecha Caducidad
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][1]));//ns_producto
                    AlDatos.Add("BOL");//cod_moneda
                    AlDatos.Add("");//caracteristicas

                    ns = _inventario.RegistrarLote(AlDatos);
                   
                    dt.Rows[j][12] = ns.ToString();

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

            

            #region stock
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][16].ToString();
                if (!dt.Rows[j][12].ToString().Equals("-1"))
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);//ns
                    AlDatos.Add(Convert.ToDouble(nombre));//cantidad  nombre
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][12]));//ns_lote
                    AlDatos.Add(1);//ns_almacen

                    ns = _inventario.RegistrarStock(AlDatos);
                    AlDatos.Clear();

                }
                dt.Rows[j][16] = ns.ToString();
                ns = -1;                
                bExiste = false;
            }
            dtDato.Clear();
            #endregion

            #region Precio
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][17].ToString();//Precio               
                if (!dt.Rows[j][12].ToString().Equals("-1"))
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);//ns

                    string auxPrecioBol = dt.Rows[j][17].ToString().Replace(".", ",");
                    double preBol = 0;
                    Double.TryParse(auxPrecioBol, out preBol);
                    AlDatos.Add(decimal.Round(Convert.ToDecimal(preBol), 3));//monto float,
                    //AlDatos.Add(preBol);//monto float,

                    AlDatos.Add(DateTime.Now.AddYears(1));//FIVigencia datetime,
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][1]));//ns_Producto integer,
                    AlDatos.Add("BOL");//cod_Moneda varchar(3),
                    AlDatos.Add(1);//ns_TipoPrecio integer,
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][8]));//ns_unidad integer,
                    AlDatos.Add(null);//cobertura money,
                    ns = _inventario.RegistrarPrecio(AlDatos);  
                    AlDatos.Clear();
                }
                dt.Rows[j][17] = ns.ToString();
                ns = -1;
                bExiste = false;
            }
            dtDato.Clear();
            #endregion

        }

        public void migrarTablaProducto2(DataTable dt)
        {


            DataTable dtDato = new DataTable();
            dtDato.Columns.Add("indice");
            dtDato.Columns.Add("nombre");
            dtDato.Columns.Add("ns");

            string nombre;
            ArrayList AlDatos;
            int ns = -1;
            bool bExiste = false;


           
             #region Grupo
            for (int j = 1; j < dt.Rows.Count; j++)
            {    
                nombre = dt.Rows[j][4].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][3] = row["ns"];
                    dt.Rows[j][4] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);
                    AlDatos.Add("");
                    AlDatos.Add(null);
                    AlDatos.Add("");
                    AlDatos.Add(0);

                    ns = _inventario.RegistrarGrupo(AlDatos);
                    dt.Rows[j][4] = ns.ToString();

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

            #region Tipo
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][5].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][4] = row["ns"];
                    dt.Rows[j][5] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);
                    AlDatos.Add("");

                    ns = _inventario.RegistrarTipo(AlDatos);
                    dt.Rows[j][5] = ns.ToString();

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

            #region SubTipo
            for (int j = 1; j < dt.Rows.Count; j++)
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
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);

                    ns = _inventario.RegistrarSubTipoProd(AlDatos);
                    dt.Rows[j][6] = ns.ToString();
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

            #region Marca
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][7].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][6] = row["ns"];
                    dt.Rows[j][7] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);
                    AlDatos.Add(0);
                    AlDatos.Add("");

                    ns = _inventario.RegistrarMarca(AlDatos);
                    dt.Rows[j][7] = ns.ToString();

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

            #region Unidad
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                //nombre = dt.Rows[j][7].ToString();
                nombre = dt.Rows[j][8].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    dt.Rows[j][8] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);
                    AlDatos.Add(nombre);
                    AlDatos.Add("");
                    AlDatos.Add(0);

                    ns = _inventario.RegistrarUnidad(AlDatos);
                    dt.Rows[j][8] = ns.ToString();

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

            #region Producto
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][1].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    dt.Rows[j][1] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);//ns
                    if (dt.Rows[j][1].ToString()=="" || dt.Rows[j][1].ToString()== null ) {
                        AlDatos.Add(dt.Rows[j][2].ToString());//codigo  == codBarra
                    }
                    else{
                        AlDatos.Add(dt.Rows[j][1].ToString());//codigo
                    }

                    if (dt.Rows[j][2].ToString().Length > 0 )////codigoAlterno
                    {
                        AlDatos.Add((dt.Rows[j][2].ToString()));
                    }
                    else {
                        AlDatos.Add("");
                    }
                    AlDatos.Add("");//serie
                    AlDatos.Add(dt.Rows[j][3].ToString());//nombre
                    AlDatos.Add(null);//imagen
                    AlDatos.Add("");//medida
                    AlDatos.Add("");//color
                    AlDatos.Add("");//modelo
                    AlDatos.Add("");//composicion
                    AlDatos.Add("");//linea
                    AlDatos.Add("");//categoria   al migrar poner siempre vacio
                    AlDatos.Add(0);//peso
                    AlDatos.Add(dt.Rows[j][9].ToString());//caracteristicas
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][5]));//ns_TipoProd
                    AlDatos.Add("PROD");//cod_ClaseProd
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][8]));//ns_Unidad
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][4]));//ns_Grupo
                    AlDatos.Add(null);//ns_NomGenerico
                    AlDatos.Add(false);//compuesto
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][7]));//ns_Marca
                    AlDatos.Add(true);//habilitado
                    AlDatos.Add("");//codigoUbicacion
                    AlDatos.Add("1");//presentacion
                    AlDatos.Add(null);//ns_Proveedor
                    AlDatos.Add(1);//habilitaalerta
                    AlDatos.Add(1);//stockminimo
                    AlDatos.Add(1);//habilitaCompra
                    AlDatos.Add(0);//EsActivoFijo
                    AlDatos.Add(0);//EsEquipoGarantia
                    AlDatos.Add(0);//EsIEHD
                    AlDatos.Add(dt.Rows[j][6]);//ns_SubTipo
                    AlDatos.Add(1000000);//stockMaximo
                    AlDatos.Add(dt.Rows[j][8]);//ns_UnidadContenido
                    AlDatos.Add(0);//empaque
                    AlDatos.Add(null);//ns_prodRemp
                    AlDatos.Add(null);//cod_Clasificacion
                    AlDatos.Add(null);//cod_Clasificacionprov
                    AlDatos.Add(0);//tieneGA
                    AlDatos.Add(0);//EsIEHDCompra
                    AlDatos.Add(null);//ns_nandina

                    AlDatos.Add(null);//ns_productoImpuestos integer,
                    AlDatos.Add(null);//patrocinado integer,
                    if (dt.Rows[j][10].ToString() == "SI") { AlDatos.Add(1); } else { AlDatos.Add(0); }//controlado bit,
                    //AlDatos.Add(null);//controlado bit,

                    ns = _inventario.RegistrarProducto(AlDatos);
                    dt.Rows[j][1] = ns.ToString();

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

            #region Lote
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][12].ToString();//Codigo Lote
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][10] = row["ns"];
                    dt.Rows[j][12] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);//ns
                    AlDatos.Add(nombre);//Codigo
                    AlDatos.Add(dt.Rows[j][13].ToString());// Descripcion
                    AlDatos.Add("");//Observacion
                    //TipoCambio
                    double tc = _inventario.DevuelveTipoCambio();
                    //End TipoCambio
                    string auxCostoBol = dt.Rows[j][15].ToString().Replace(".", ",");
                    double CostBol = 0;
                    Double.TryParse(auxCostoBol, out CostBol);
                    AlDatos.Add(CostBol/tc);//CostoDOL
                    AlDatos.Add(CostBol);//CostoBOL
                    
                    string auxPrecioBol = dt.Rows[j][17].ToString().Replace(".", ",");
                    double preBol = 0;
                    Double.TryParse(auxPrecioBol, out preBol);
                    AlDatos.Add(preBol/tc);//PrecioDOL
                    AlDatos.Add(preBol);//PrecioBOL

                    AlDatos.Add(DateTime.Now);//Fecha Ingreso
                    AlDatos.Add(DateTime.Now);//Fecha Fabricacion
                    AlDatos.Add(Convert.ToDateTime(dt.Rows[j][14]));//Fecha Caducidad
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][1]));//ns_producto
                    AlDatos.Add("BOL");//cod_moneda
                    AlDatos.Add("");//caracteristicas

                    ns = _inventario.RegistrarLote(AlDatos);
                    dt.Rows[j][12] = ns.ToString();

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

            #region Stock
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                nombre = dt.Rows[j][16].ToString();
                DataRow[] rslt = dtDato.Select("nombre = '" + nombre + "'");

                foreach (DataRow row in rslt)
                {
                    //dt.Rows[j][14] = row["ns"];
                    dt.Rows[j][16] = row["ns"];
                    bExiste = true;
                }

                if (!bExiste)//No existe
                {
                    dtDato.Rows.Add(j.ToString(), nombre, ns);

                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);//ns
                    AlDatos.Add(Convert.ToDouble(nombre));//cantidad  nombre
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][12]));//ns_lote
                    AlDatos.Add(1);//ns_almacen

                    ns = _inventario.RegistrarStock(AlDatos);
                    dt.Rows[j][16] = ns.ToString();

                    AlDatos.Clear();

                    rslt = dtDato.Select("indice = '" + j.ToString() + "'");
                    foreach (DataRow row in rslt)
                    {
                        row["ns"] = ns;
                    }
                    ns = -1;
                }
                else {
                    AlDatos = new ArrayList();
                    AlDatos.Add(-1);//ns
                    AlDatos.Add(Convert.ToDouble(nombre));//cantidad  nombre
                    AlDatos.Add(Convert.ToInt32(dt.Rows[j][12]));//ns_lote
                    AlDatos.Add(1);//ns_almacen

                    ns = _inventario.RegistrarStock(AlDatos);
                    dt.Rows[j][16] = ns.ToString();

                    AlDatos.Clear();
                }
                bExiste = false;
            }
            dtDato.Clear();
            #endregion
        }

        public bool compararExcel_TablaProducto(DataTable dt1)
        {
            bool sw = true;
            DataTable dt2 = new DataTable();
            dt2 = _inventario.listaProductos();
            
            DataTable dtGrupo = _inventario.listaGrupo();
            DataTable dtTipo = _inventario.listaTipo();
            DataTable dtSubTipo = _inventario.listaSubTipo();
            DataTable dtMarca = _inventario.listaMarca();
            DataTable dtUnidad = _inventario.listaUnidad();
            DataTable dtLote = _inventario.listaLote();
            DataTable dtStock = _inventario.listaStock();

            this.ErrorListCompare.Clear();

            for (int j = 1; j < dt1.Rows.Count; j++)
            {
                //Producto
                string cod = dt1.Rows[j][1].ToString(); //codigo
                string codProdDB = dt2.Rows[j - 1][6].ToString();
                if (!cod.Equals(codProdDB))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error CODIGO, dato: {cod} y {codProdDB} NO son iguales, en Fila {j} ");
                }

                string codBarra = dt1.Rows[j][2].ToString(); //codigoBarra
                string codBarraDB = dt2.Rows[j - 1][7].ToString();
                if (!codBarra.Equals(codBarraDB))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo CODIGO BARRA, dato: {codBarra} y {codBarraDB} NO son iguales, en Fila {j} ");
                }

                string nombreProd = dt1.Rows[j][3].ToString(); //NombreProd
                string nombreProdDB = dt2.Rows[j - 1][9].ToString();
                if (!nombreProd.Equals(nombreProdDB))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo NOMBRE, dato: {nombreProd} y {nombreProdDB} NO son iguales, en Fila {j} ");
                }

                string caractProd = dt1.Rows[j][9].ToString(); //Caracteristicas
                string caractProdDB = dt2.Rows[j - 1][19].ToString();
                if (!caractProd.Equals(caractProdDB))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo CARACTERISTICAS, dato: {caractProd} y {caractProdDB} NO son iguales, en Fila {j} ");
                }

                string controlProd = dt1.Rows[j][10].ToString(); //Controlado
                string controlProdDB = dt2.Rows[j-1][48].ToString();
                if (controlProdDB == "1") {controlProdDB = "SI"; } else { controlProdDB="NO"; }
                if (!controlProd.Equals(controlProdDB))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo CONTROLADO, dato: {controlProd} y {controlProdDB} NO son iguales, en Fila {j} ");
                }


                //Grupo
                string g = dt1.Rows[j][4].ToString();
                string nombreGrupo = dt2.Rows[j - 1][23].ToString();
                nombreGrupo = obtenerCampoPorID(dtGrupo, nombreGrupo, "nombre");
                if (!g.Equals(nombreGrupo))
                {//no iguales
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo GRUPO, dato: {g} y {nombreGrupo} NO son iguales, en [ {j} - 23 ] en la Base de Datos");
                }

                //Tipo
                string t = dt1.Rows[j][5].ToString();
                string idTipo = dt2.Rows[j - 1][20].ToString();
                idTipo = obtenerCampoPorID(dtTipo, idTipo, "Descripcion");
                if (!t.Equals(idTipo))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo TIPO, dato: {t} y {idTipo} NO son iguales, en [ {j} - 20 ] en la Base de Datos");
                }

                //SubTipo
                string st = dt1.Rows[j][6].ToString();
                string idsubTipo = dt2.Rows[j - 1][36].ToString();
                idsubTipo = obtenerCampoPorID(dtSubTipo, idsubTipo, "Nombre");
                if (!st.Equals(idsubTipo))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo SUBTIPO, dato: {st} y {idsubTipo} NO son iguales, en [ {j} - 36 ] en la Base de Datos");
                }

                //Marca
                string m = dt1.Rows[j][7].ToString();
                string idMarca = dt2.Rows[j - 1][25].ToString();
                idMarca = obtenerCampoPorID(dtMarca, idMarca, "Nombre");
                if (!m.Equals(idMarca))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo MARCA, dato: {m} y {idMarca} NO son iguales, en [ {j} - 25 ] en la Base de Datos");
                }

                //Unidad
                string u = dt1.Rows[j][8].ToString();
                string idunidad = dt2.Rows[j - 1][22].ToString();
                idunidad = obtenerCampoPorID(dtUnidad, idunidad, "Nombre");
                if (!u.Equals(idunidad))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo UNIDAD, dato: {u} y {idunidad} NO son iguales, en [ {j} - 22 ] en la Base de Datos");
                }

                
                //Lote
                string l = dt1.Rows[j][12].ToString(); //codigoLote
                string idProducto = dt2.Rows[j - 1][0].ToString();
                string idlote = obtenerCampoIDLote(dtLote, idProducto, "num_sec");

                string codigolote = obtenerCampoPorID(dtLote, idlote, "codigo");
                if (!l.Equals(codigolote))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo CODIGO LOTE, dato: {l} y {codigolote} NO son iguales, en Fila {j} ");
                }

                string fvenc = dt1.Rows[j][14].ToString(); //fecha vencimiento
                string fcaducidad = obtenerCampoPorID(dtLote, idlote, "FCaducidad");
                if (!fvenc.Equals(fcaducidad))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo FECHA CADUCIDAD, dato: {fvenc} y {fcaducidad} NO son iguales, en Fila {j} ");
                }

                string costUnitBol = dt1.Rows[j][15].ToString().Replace(".", ","); //costoBolUnitario                
                string cos = obtenerCampoPorID(dtLote, idlote, "costoBol");
                string costUnitBolDB = Decimal.Round(Convert.ToDecimal(cos),2).ToString();
                if (!costUnitBol.Equals(costUnitBolDB.ToString()))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo COSTO BOL, dato: {costUnitBol} y {costUnitBolDB} NO son iguales, en Fila {j} ");
                }

                string precioBol = dt1.Rows[j][17].ToString().Replace(".", ","); //precioVentaBol
                string pre = obtenerCampoPorID(dtLote, idlote, "precioBol");
                string precioBolDB  = Decimal.Round(Convert.ToDecimal(pre), 2).ToString();
                if (!precioBol.Equals(precioBolDB))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo PRECIO BOL, dato: {precioBol} y {precioBolDB} NO son iguales, en Fila {j} ");
                }


                // verifica Stock  -- obtengo num_Sec de tabla producto, con id prod obtengo idlote, con idlote verifico el stock  de excel
                string stk = dt1.Rows[j][16].ToString(); //Stock de excel                
                string stock_Prod_Lote = obtenerCampoCantStock(dtStock, idlote, "cantFisica");//stock BD
                if (!stk.Equals(stock_Prod_Lote))
                {
                    sw = false;
                    this.ErrorListCompare.Add($"Error en campo STOCK, dato: {stk} y {stock_Prod_Lote} NO son iguales, en Fila {j} de BD ");
                }


            }
            //}
            //else {
            //    sw = false;
            //}          
            return sw;

        }




        public string obtenerCampoPorID(DataTable dt, string idGrupo, string campoReturn)
        {
            string Result = "";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string num_sec = dt.Rows[j]["num_Sec"].ToString();
                string nombre = dt.Rows[j][campoReturn].ToString();

                if (num_sec == idGrupo)
                {
                    return nombre;
                }
            }
            return Result;
        }
        public string obtenerCampoIDLote(DataTable dt, string id, string campoReturn)
        {
            string Result = "";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string num_sec = dt.Rows[j]["ns_Producto"].ToString();
                string nombre = dt.Rows[j][campoReturn].ToString();
                if (num_sec == id)
                {
                    return nombre;
                }
            }
            return Result;
        }
        public string obtenerCampoCantStock(DataTable dt, string id, string campoReturn)
        {
            string Result = "";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string num_sec = dt.Rows[j]["ns_Lote"].ToString();
                string nombre = dt.Rows[j][campoReturn].ToString();

                if (num_sec == id)
                {
                    return nombre;
                }
            }
            return Result;
        }


        public Int32 RegistrarMarca(ArrayList Al)
        {
            return _inventario.RegistrarMarca(Al);
        }
        private ArrayList obtColumnId_Tabla(DataTable dt, string nombreCol)
        {
            ArrayList listCol = new ArrayList();

            dt = _inventario.listaLote();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                listCol.Add(Convert.ToInt32(dt.Rows[j][nombreCol].ToString()));
            }
            return listCol;
        }
        public bool existeId(ArrayList Al, int id)
        {
            bool sw = false;
            int ns = -1;
            for (int i = 0; i < Al.Count; i++)
            {
                if (Al[i].Equals(id))
                {
                    sw = true;
                    return sw;
                }
            }
            return sw;
        }
        public int obtenerID(DataTable dt, int id)
        {
            int ns = -1;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string nombre = dt.Rows[j]["num_sec"].ToString();
                if (nombre.Equals(id.ToString()))
                {
                    ns = Convert.ToInt32(dt.Rows[j]["ns_Producto"]);
                    return ns;
                }
            }
            return -1;
        }
        public ArrayList obtenerListaIDs(DataTable dt, int id)
        {
            ArrayList al = new ArrayList();            
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string nombre = dt.Rows[j]["num_sec"].ToString();
                if (nombre.Equals(id.ToString()))
                {
                    al.Add(Convert.ToInt32(dt.Rows[j]["ns_Producto"]));                    
                }
            }
            return al;
        }


    }
}
