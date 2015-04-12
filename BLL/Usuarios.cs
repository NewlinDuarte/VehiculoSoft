using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public string Contra { get; set; }
        public string Email { get; set; }

        public Usuarios()
        {
            IdUsuario = 0;
            NombreUsuario = null;
            Nombres = null;
            Contra = null;
            Email = null;
        }

        public Usuarios(string NombreUsuario, string Nombres, string Contra, string Email)
        {
            this.NombreUsuario = NombreUsuario;
            this.Nombres = Nombres;
            this.Contra = Contra;
            this.Email = Email;
        }

        public bool Insert()
        {
            
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            this.IdUsuario = Convert.ToInt32(conexion.ObtenerValorDb("Insert into Usuarios (Fecha, NombreUsuario, Nombres, Contra, Email) values (GETDATE(),'"+this.NombreUsuario+"','"+this.Nombres+"','"+this.Contra+"','"+this.Email+"')Select @@Identity"));
            if (this.IdUsuario > 0)
                return true;
            else
                return false;
        }

        public bool Buscar(int IdBuscado) 
        {
            DataTable dt = new DataTable();
            dt = Usuarios.Listar("*", "IdUsuario = " + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr;
                dr = dt.Select("IdUsuario = " + IdBuscado);
                this.IdUsuario = IdBuscado;
                this.NombreUsuario = (string)dr[0]["NombreUsuario"];
                this.Nombres = (string)dr[0]["Nombres"];
                this.Contra = (string)dr[0]["Contra"];
                this.Email = (string)dr[0]["Email"];
                return true;
            }
            else
                return false;
        }


        public bool Autenticar(string NombreUsuario, string Contra) 
        {
            DataTable dt = new DataTable();
            dt = Usuarios.Listar();

            foreach(DataRow dr in dt.Rows)
            {
                if ((string)dr["NombreUsuario"] == NombreUsuario && (string)dr["Contra"] == Contra) 
                {
                    this.Buscar((int)dr["IdUsuario"]);
                    return true;
                }
            }
            return false;
        }

        public bool Eliminar(int IdBuscado) 
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Delete from Usuarios where IdUsuario = " + IdBuscado);
        }

        public Boolean Modificar(string NombreUsuario, string Nombre, string Contra, string Email)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Update Usuarios set NombreUsuario = '" + NombreUsuario + "',  Nombres ='" + Nombres + "',Contra ='" + Contra + "' , Email ='" + Email + "' Where IdUsuario = " + this.IdUsuario + ";");

        }

        public static DataTable Listar(string campos = "*", string filtro = "1=1") 
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            return conexion.BuscarDb("Select " + campos + " from Usuarios where " + filtro);
        }
    }
}
