using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Personas
    {
        public int IdPersona { get; set; }
        public int IsClient { get; set; } //solo 1 o 0
        public float Ingreso { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        

        public Personas() 
        {
            IdPersona = 0;
            IsClient = 0;
            Cedula = null;
            Ingreso = 0;
            Direccion = null;
            Telefono = null;
            
        }

        public Personas( int IsClient, string Cedula, float Ingreso, string Direccion, string Telefono, string Nombre, string Apellido) 
        {
            this.IsClient = IsClient;
            this.Cedula = Cedula;
            this.Ingreso = Ingreso;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            
        }

        public bool Insertar() 
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            this.IdPersona = Convert.ToInt32(conexion.ObtenerValorDb("Insert into Personas ( IsClient, Ingreso , Cedula, Telefono ,Direccion, Nombre, Apellido) values ('"  + this.IsClient + "','" + this.Ingreso + "','" + this.Cedula + "','" + this.Telefono + "','" + this.Direccion + "','" + this.Nombre + "','" + this.Apellido + "')Select @@Identity"));
            if (this.IdPersona > 0)
                return true;
            else
                return false;
        }

        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            dt = Personas.Listar("*", "IdPersona = " + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr;
                dr = dt.Select("IdPersona = " + IdBuscado);
                this.IdPersona = IdBuscado;
                this.IsClient = Convert.ToInt32(dr[0]["IsClient"]);
                this.Ingreso = Convert.ToSingle(dr[0]["Ingreso"]);
                this.Cedula = (string)dr[0]["Cedula"];
                this.Telefono = (string)dr[0]["Telefono"];
                this.Direccion = (string)dr[0]["Direccion"];
                this.Nombre = (string)dr[0]["Nombre"];
                this.Apellido = (string)dr[0]["Apellido"];
                
                return true;
            }
            else
                return false;
        }

        public bool Eliminar(int IdBuscado)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Delete from Personas where IdPersona = " + IdBuscado);
        }

        public Boolean Modificar(int IsClient, float Ingreso, string Cedula, string Telefono, string Direccion, string Nombre, string Apellido)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Update Personas set IsClient = " + IsClient + ",  Ingreso = " + Ingreso + ",  Cedula ='" + Cedula + "',Telefono ='" + Telefono + "' , Direccion ='" + Direccion + "' ,  Nombre = '" + Nombre + "',  Apellido = '" + Apellido + "' Where IdPersona = " + this.IdPersona + ";");

        }

        public static DataTable Listar(string campos = "*", string filtro = "1=1")
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            return conexion.BuscarDb("Select " + campos + " from Personas where " + filtro);
        }
    }

   
}
