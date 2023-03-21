using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo.Datos
{
    public class Conexion
    {
        ModGn.Osiris.TAcceso Acc;
        ModGn.Osiris.TAcceso AccAlterno;
        Double TCOficial;

        public string nombreServ { get; set; }
        public string UsuarioServ { get; set; }
        public string passServ { get; set; }
        public string BDconexion { get; set; }


        public Conexion(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {

            String nombreservidor = nombreSer;
            String UsServidor = usuarioSer;
            String PasServidor = passSer;
            string BD = bdSer;

            string aux = "SQL" + nombreservidor + UsServidor + PasServidor + "RamSes";

            AccAlterno = new ModGn.Osiris.TAcceso("SQL", nombreservidor, UsServidor, PasServidor, "RamSes");
            Acc = new ModGn.Osiris.TAcceso("SQL", nombreservidor, UsServidor, PasServidor, BD);


            AccAlterno.pIDSucursal = 1;
            AccAlterno.AbreConexion();
            Acc.pIDSucursal = 3;
            Acc.AbreConexion();

            //inventario
            Acc.PreparaProcAlm("inpMarca");
            Acc.PreparaProcAlm("inpUnidad");
            Acc.PreparaProcAlm("inpTipoProd");
            Acc.PreparaProcAlm("inpSubTipo");

            Acc.PreparaProcAlm("inpGrupo");
            Acc.PreparaProcAlm("inpProducto");
            Acc.PreparaProcAlm("inpLote");
            Acc.PreparaProcAlm("inpStock");
            Acc.PreparaProcAlm("inpPrecio");
            
            //general
            Acc.PreparaProcAlm("gnpDirectorio");
            Acc.PreparaProcAlm("gnpCliente");
            Acc.PreparaProcAlm("GnpTelefono");
            Acc.PreparaProcAlm("gnpPersona");
            Acc.PreparaProcAlm("gnpEmpleado");
            Acc.PreparaProcAlm("gnpProveedor");
            
            //contabilidad
            Acc.PreparaProcAlm("ccpTxn");
            Acc.PreparaProcAlm("ccpDetalleTxn");
            Acc.PreparaProcAlm("cppTxn");
            Acc.PreparaProcAlm("cppDetalleTxn");



            TCOficial = ObtieneUltimoTC();
        }
        public Double ObtieneUltimoTC()
        {
            return AccAlterno.DevuelveDatoDO("select top 1 ValorD from gntTipoCambio order by fecha desc");
        }


        public ModGn.Osiris.TAcceso AccAlternativo()
        {
            return AccAlterno;
        }
        public ModGn.Osiris.TAcceso AccCnx()
        {
            return Acc;
        }

        public void preparaProc(string proc)
        {
            Acc.PreparaProcAlm(proc);
        }

    }
}
