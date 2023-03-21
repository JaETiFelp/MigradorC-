using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo.Datos.Contabilidad
{
    public class Contabilidad
    {
        Conexion cnx;
        ModGn.Osiris.TAcceso Acc;
        ModGn.Osiris.TAcceso AccAlterno;
        public Contabilidad(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {
            cnx = new Conexion(nombreSer, usuarioSer, passSer, bdSer);
            AccAlterno = cnx.AccAlternativo();
            Acc = cnx.AccCnx();
        }
        public Int32 registrarCxCobrar(ArrayList Al)
        {
            Int32 num_sec = 0;
            Acc.Guardar(Al, null, "ccpTxn", out num_sec, 1);
            return num_sec;
        }
        public bool registrarCxCobrarDetalle(ArrayList Al)
        {
            bool sw = Acc.Guardar(Al, null, "ccpDetalleTxn");
            return sw;
        }

        public Int32 registrarCxPagar(ArrayList Al)
        {
            Int32 num_sec = 0;
            Acc.Guardar(Al, null, "cppTxn", out num_sec, 1);
            return num_sec;
        }
        public bool registrarCxPagarDetalle(ArrayList Al)
        {
            bool sw = Acc.Guardar(Al, null, "cppDetalleTxn");
            return sw;
        }



    }
}
