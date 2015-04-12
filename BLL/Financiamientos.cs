using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Financiamientos
    {
        public int IdFinanciamiento { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPersona { get; set; }
        public int IdGarante { get; set; }
        public int IdMotor { get; set; }
        public float Balance { get; set; }
        public int IntervaloPago { get; set; }
        public float Inicial { get; set; }

        public Financiamientos() 
        {
            Fecha = DateTime.Now;
            IdPersona = 0;
            IdGarante = 0;
            IdMotor = 0;
            Balance = 0;
            IntervaloPago = 0;
            Inicial = 0;
        }

        public Financiamientos(int IdPersona, int IdGarante, int IdMotor, float Balance, int Quotas, float Inicial) 
        {
            this.IdPersona = IdPersona;
            this.IdGarante = IdGarante;
            this.IdMotor = IdMotor;
            this.Balance = Balance;
            this.IntervaloPago = Quotas;
            this.Inicial = Inicial;
        }

        public bool Insert()
        {

            DAL.ConexionDb conexion = new DAL.ConexionDb();
            this.IdFinanciamiento = Convert.ToInt32(conexion.ObtenerValorDb("Insert into Financiamientos (Fecha, IdPersona, IdGarante, IdMotor, Balance, IntervaloPago, Inicial) values (GETDATE(),'" + this.IdPersona + "','" + this.IdGarante + "','" + this.IdMotor + "','" + this.Balance + "','" + this.IntervaloPago + "' , " + this.Inicial +")Select @@Identity"));
            if (this.IdFinanciamiento > 0)
                return true;
            else
                return false;
        }

        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            dt = Financiamientos.Listar("*", "IdFinanciamiento = " + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr;
                dr = dt.Select("IdFinanciamiento = " + IdBuscado);
                this.IdFinanciamiento = IdBuscado;
                this.Fecha = (DateTime)dr[0]["Fecha"];
                this.IdPersona = (int)dr[0]["IdPersona"];
                this.IdGarante = (int)dr[0]["IdGarante"];
                this.IdMotor = (int)dr[0]["IdMotor"];
                this.Balance = Convert.ToSingle(dr[0]["Balance"]);
                this.IntervaloPago = (int)dr[0]["IntervaloPago"];
                this.Inicial = Convert.ToSingle(dr[0]["Inicial"]);
                return true;
            }
            else
                return false;
        }


        public Boolean Modificar(int IdPersona, int IdGarante, int IdMotor, float Balance, int IntervaloPago, float Inicial)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Update Financiamientos set IdPersona = " + IdPersona + ",  IdGarante ='" + IdGarante + "',IdMotor ='" + IdMotor + "' , Balance ='" + Balance + "' ,  IntervaloPago = '" + IntervaloPago + "',  Inicial = '" + Inicial + "' Where IdFinanciamiento = " + this.IdFinanciamiento + ";");

        }

        public bool Eliminar(int IdBuscado)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Delete from Financiamientos where IdFinanciamiento = " + IdBuscado);
        }

        public static DataTable Listar(string campos = "*", string filtro = "1=1")
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            return conexion.BuscarDb("Select " + campos + " from Financiamientos where " + filtro);
        }
    }
}
