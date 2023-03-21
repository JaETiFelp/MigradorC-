using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo.Datos.Inventario
{
    public class Inventario
    {

        Conexion cnx;
        ModGn.Osiris.TAcceso Acc;
        ModGn.Osiris.TAcceso AccAlterno;
        public Inventario(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {
            cnx = new Conexion(nombreSer, usuarioSer, passSer, bdSer);
            AccAlterno = cnx.AccAlternativo();
            Acc = cnx.AccCnx();
        }
        public Int32 RegistrarMarca(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "inpMarca", out num_sec, 1);
            return num_sec;
        }
        public Int32 RegistrarUnidad(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "inpUnidad", out num_sec, 1);
            return num_sec;
        }
        public Int32 RegistrarTipo(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "inpTipoProd", out num_sec, 1);
            return num_sec;
        }
        public Int32 RegistrarSubTipoProd(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "inpSubTipo", out num_sec, 1);
            return num_sec;
        }
        public Int32 RegistrarGrupo(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "inpGrupo", out num_sec, 1);
            return num_sec;
        }
        public Int32 RegistrarLote(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "inpLote", out num_sec, 1);
            return num_sec;
        }

        public Int32 RegistrarProducto(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "inpProducto", out num_sec, 1);
            return num_sec;
        }
        public Int32 RegistrarStock(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Acc.Guardar(Al, null, "inpStock", out num_sec, 1);
            return num_sec;
        }

        public Int32 RegistrarPrecio(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "inpPrecio", out num_sec, 1);
            return num_sec;
        }

        
        // consultas query
        public Double DevuelveTipoCambio()
        {
            return AccAlterno.DevuelveDatoDO("select top 1 valorD from gntTipoCambio order by fecha desc");
        }

        public DataTable listaProductos()
        {
            String Query = "select * from intProducto ";
            return Acc.DevuelveDatoDT(Query);
        }

        public DataTable listaGrupo()
        {
            String Query = "select * from intGrupo ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable listaTipo()
        {
            String Query = "select * from intTipoProd ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable listaSubTipo()
        {
            String Query = "select * from intSubTipo ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable listaMarca()
        {
            String Query = "select * from intMarca ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable listaUnidad()
        {
            String Query = "select * from intUnidad ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable listaLote()
        {
            String Query = "select * from intLote ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable listaStock()
        {
            String Query = "select * from intStock ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable ListGrupo2column()
        {
            String Query = "select num_sec, nombre from intGrupo ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable ListTipo2column()
        {
            String Query = "select num_sec, Descripcion from intTipoProd ";
            return Acc.DevuelveDatoDT(Query);
        }

        public DataTable ListSubTipo2column()
        {
            String Query = "select num_sec, Nombre from intSubTipo ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable ListMarca2column()
        {
            String Query = "select num_sec, Nombre from intMarca ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable ListUnidad2column()
        {
            String Query = "select num_sec, nombre from intUnidad ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable ListProducto2column()
        {
            String Query = "select num_sec, codigo from intProducto ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable ListLote2column()
        {
            String Query = "select num_sec, codigo from intLote ";
            return Acc.DevuelveDatoDT(Query);
        }
        



    }
}