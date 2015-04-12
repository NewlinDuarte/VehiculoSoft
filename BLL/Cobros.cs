using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cobros
    {
        public int IdCobro { get; set; }
        public DateTime Fecha { get; set; }
        public float Balance { get; set; }
        public float Abono { get; set; }
        public int IdFinanciamiento { get; set; }

        public Cobros() 
        {
            IdCobro = 0;
            Fecha = DateTime.Now;
            Balance = 0;
            Abono = 0;
        }

        public Cobros(float Balance, float Abono,int IdFinanciamiento) 
        {
            this.Balance = Balance;
            this.Abono = Abono;
            this.IdFinanciamiento = IdFinanciamiento;
        }

        public bool Insert()
        {

            DAL.ConexionDb conexion = new DAL.ConexionDb();
            this.IdCobro = Convert.ToInt32(conexion.ObtenerValorDb("Insert into Cobros (Fecha, Balance, Abono, IdFinanciamiento) values (GETDATE(),'" + this.Balance + "','" + this.Abono + "', " + this.IdFinanciamiento + ")Select @@Identity"));
            if (this.IdCobro > 0)
                return true;
            else
                return false;
        }

        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            dt = Cobros.Listar("*", "IdCobro = " + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr;
                dr = dt.Select("IdCobro = " + IdBuscado);
                this.IdCobro = IdBuscado;
                this.Fecha = (DateTime)dr[0]["Fecha"];
                this.Balance = (float)dr[0]["Balance"];
                this.Abono = (float)dr[0]["Abono"];
                return true;
            }
            else
                return false;
        }



        public Boolean Modificar(float Balance, float Abono)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Update Cobros set Balance = " + Balance + ",  Abono =" + Abono + " Where IdCobro = " + this.IdCobro + ";");

        }

        public bool Eliminar(int IdBuscado)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Delete from Cobros where IdCobro = " + IdBuscado);
        }



        public static DataTable Listar(string campos = "*", string filtro = "1=1")
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            return conexion.BuscarDb("Select " + campos + " from Cobros where " + filtro);
        }

    }
}
