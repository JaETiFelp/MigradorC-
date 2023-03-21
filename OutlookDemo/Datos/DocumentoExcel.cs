using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo.Datos
{
    public class DocumentoExcel
    {
        Conexion cnx;
        ModGn.Osiris.TAcceso Acc;
        ModGn.Osiris.TAcceso AccAlterno;
        public DocumentoExcel(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {
            cnx = new Conexion(nombreSer, usuarioSer, passSer, bdSer);
         
            AccAlterno = cnx.AccAlternativo();
            Acc = cnx.AccCnx();
        }
        public DataSet DevuelveExcel(string archivo, string pestaña)
        {
            return Acc.ImportarExcel(archivo, pestaña);
        }
        public DataTable listaClientes()
        {
            String Query = "select * from gntCliente ";
            return Acc.DevuelveDatoDT(Query);
        }
    }
}
