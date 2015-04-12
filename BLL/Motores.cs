using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Motores
    {
        public int IdMotor { get; set; }
        public string Fabricante  { get; set; }
        public string Modelo { get; set; }
        public int IdColor { get; set; }
        public string NumeroChasis  { get; set; }
        public int AProduccion { get; set; }
        public float Precio { get; set; }

        public Motores() 
        {
            IdMotor = 0;
            Fabricante = string.Empty;
            Modelo = string.Empty;
            IdColor = 0;
            NumeroChasis = string.Empty;
            AProduccion = 0;
            Precio = 0;
        }

        public Motores(string Fabricante, string Modelo, int IdColor, string NumeroChasis, int AProduccion, float Precio) 
        {
            this.Fabricante = Fabricante;
            this.Modelo = Modelo;
            this.IdColor = IdColor;
            this.NumeroChasis = NumeroChasis;
            this.AProduccion = AProduccion;
            this.Precio = Precio;
        }


        public bool Insert()
        {

            DAL.ConexionDb conexion = new DAL.ConexionDb();
            this.IdMotor = Convert.ToInt32(conexion.ObtenerValorDb("Insert into Motores (Fabricante, Modelo, IdColor, NumeroChasis, AProduccion, Precio) values ('" + this.Fabricante + "','" + this.Modelo + "','" + this.IdColor + "','" + this.NumeroChasis +  "','" + this.AProduccion +  "','" + this.Precio + "')Select @@Identity"));
            if (this.IdMotor > 0)
                return true;
            else
                return false;
        }

        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            dt = Motores.Listar("*", "IdMotor = " + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr;
                dr = dt.Select("IdMotor = " + IdBuscado);
                this.IdMotor = IdBuscado;
                this.Fabricante = (string)dr[0]["Fabricante"];
                this.Modelo = (string)dr[0]["Modelo"];
                this.IdColor = (int)dr[0]["IdColor"];
                this.NumeroChasis = (string)dr[0]["NumeroChasis"];
                this.AProduccion = (int)dr[0]["AProduccion"];
                this.Precio = Convert.ToSingle(dr[0]["Precio"]);
                return true;
            }
            else
                return false;
        }

        public bool Eliminar(int IdBuscado)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Delete from Motores where IdUsuario = " + IdBuscado);
        }

        public Boolean Modificar(string Fabricante, string Modelo, int IdColor, string NumeroChasis, int AProduccion, float Precio)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Update Motores set Fabricante ='" + Fabricante + "', Modelo ='" + Modelo + "', IdColor =" + IdColor + ", NumeroChasis ='" + NumeroChasis + "', AProduccion = " + AProduccion + ", Precio = " + Precio + " Where IdMotor = " + this.IdMotor + ";");

        }

        public static DataTable Listar(string campos = "*", string filtro = "1=1")
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            return conexion.BuscarDb("Select " + campos + " from Motores where " + filtro);
        }

    }
}
