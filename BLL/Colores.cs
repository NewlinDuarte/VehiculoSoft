using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Colores
    {
        public int IdColor { get; set; }
        public string Color { get; set; }

        public Colores()
        {
            this.Color = string.Empty;
        }


        public Colores(string Color) 
        {
            this.Color = Color;
        }

        public bool Insert() 
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            this.IdColor = Convert.ToInt32(conexion.ObtenerValorDb("Insert into Colores (Color) values ('" + this.Color +"')Select @@Identity"));
            if (this.IdColor > 0)
                return true;
            else
                return false;
        }


        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            dt = Colores.Listar("*", "IdColor = " + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr;
                dr = dt.Select("IdColor = " + IdBuscado);
                this.IdColor = IdBuscado;
                this.Color = (string)dr[0]["Color"];
                return true;
            }
            else
                return false;
        }

        public static DataTable Listar(string campos = "*", string filtro = "1=1")
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            return conexion.BuscarDb("Select " + campos + " from Colores where " + filtro);
        }
    }
}
