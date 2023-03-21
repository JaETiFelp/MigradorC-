using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo.Datos.General
{
    public class General
    {
        Conexion cnx;
        ModGn.Osiris.TAcceso Acc;
        ModGn.Osiris.TAcceso AccAlterno;
        public General(string nombreSer, string usuarioSer, string passSer, string bdSer)
        {
            cnx = new Conexion(nombreSer, usuarioSer, passSer, bdSer);
            AccAlterno = cnx.AccAlternativo();
            Acc = cnx.AccCnx();
        }

        public Int32 RegistrarDirectorio(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Acc.Guardar(Al, null, "gnpDirectorio", out num_sec, 1);
            return num_sec;
        }
        public void RegistrarCliente(ArrayList Al)
        {
            Int32 num_sec = 0;
            Al.Insert(0, "1");
            Al.Add("AEG");
            Al.Add(1);
            //Acc.Guardar(Al, null, "gnpCliente", out num_sec, 1);

            string sentencia = "exec gnpCliente '" + Al[0].ToString() + "','" + Al[1] + "','" + Al[2] + "','"
                             + Al[3] + "','" + Al[4] + "','" + Al[5] + "','" + Al[6] + "','"
                             + Al[7] + "','" + Al[8] + "','" + Al[9] + "','" + Al[10] + "','"
                             + Al[11] + "','" + Al[12] + "','" + Al[13] + "','" + Al[14] + "','"
                             + Al[15] + "','" + Al[16] + "','" + Al[17] + "','" + Al[18] + "','"
                             + Al[19] + "','" + Al[20] + "','" + Al[21] + "','" + Al[22] + "','" + Al[23].ToString() + "'";

            Acc.EjecutaSentencia(sentencia);

        }
        public bool RegistrarCliente2(ArrayList Al)
        {
            bool sw = false;
            Al.Insert(0, "1");
            Al.Add("AEG");
            sw = Acc.Guardar(Al, null, "gnpCliente");
            return sw;

        }
        public Int32 registrarTelefono(ArrayList Al)
        {
            Int32 num_sec = 0;
            Acc.Guardar(Al, null, "GnpTelefono");
            return num_sec;//mo devuelve nada
        }
        public bool registrarTelefono2(ArrayList Al)
        {
            bool sw = Acc.Guardar(Al, null, "GnpTelefono");
            return sw;//mo devuelve nada
        }

        public void RegistrarPersona(ArrayList Al)
        {
            Acc.Guardar(Al, null, "gnpPersona");
        }
        public bool RegistrarPersona2(ArrayList Al)
        {
            bool sw = Acc.Guardar(Al, null, "gnpPersona");
            return sw;
        }
        public void RegistrarEmpleado(ArrayList Al)
        {
            Acc.Guardar(Al, null, "gnpEmpleado");
        }
        public bool RegistrarEmpleado2(ArrayList Al)
        {
            bool sw = Acc.Guardar(Al, null, "gnpEmpleado");
            return sw;
        }

        public void registrarProveedor(ArrayList Al) {
            Acc.Guardar(Al, null, "gnpProveedor");
        }
        public bool registrarProveedor2(ArrayList Al)
        {
           bool sw = Acc.Guardar(Al, null, "gnpProveedor");
            return sw;
        }



        public DataTable listarDirectorios()
        {
            String Query = "select * from gntDirectorio ";
            return Acc.DevuelveDatoDT(Query);
        }

        public DataTable listarTelefonos()
        {
            String Query = "select * from gntTelefono ";
            return Acc.DevuelveDatoDT(Query);
        }
        public DataTable listarClientes()
        {
            String Query = "select * from gntCliente ";
            return Acc.DevuelveDatoDT(Query);

        }
        public DataTable listarPersonas()
        {
            String Query = "select * from gntPersona ";
            return Acc.DevuelveDatoDT(Query);
        }


        public DataTable ListDirectorio2column()
        {
            String Query = "select num_sec, nit from gntDirectorio ";
            return Acc.DevuelveDatoDT(Query);
        }



    }
}
