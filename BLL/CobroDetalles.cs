using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CobroDetalles
    {
        public int IdCobroDetalle { get; set; }
        public int IdCobro { get; set; }
        public DateTime Fecha { get; set; }
        public float BalanceQuota { get; set; }
        public float Interes { get; set; }
        public float BalanceInteres { get; set; }
        public float Quotas { get; set; }

        public CobroDetalles() 
        {
            IdCobroDetalle = 0;
            IdCobro = 0;
            Fecha = DateTime.Now;
            BalanceQuota = 0;
            Interes = 0;
            BalanceInteres = 0;
            Quotas = 0;
        }

        public CobroDetalles( float BalanceQuota, float Interes, float BalanceInteres, float Quotas )
        {
            
            this.BalanceQuota = 0;
            this.Interes = 0;
            this.BalanceInteres = 0;
            this.Quotas = 0;
        }

        public bool Insert()
        {

            DAL.ConexionDb conexion = new DAL.ConexionDb();
            this.IdCobroDetalle = Convert.ToInt32(conexion.ObtenerValorDb("Insert into CobroDetalles (IdCobro, Fecha, BalanceQuota, Interes, BalanceInteres, Quotas) values ("+ this.IdCobro +", GETDATE(),'" + this.BalanceQuota + "','" + this.Interes + "','" + this.BalanceInteres + "','" + this.Quotas + "')Select @@Identity"));
            if (this.IdCobroDetalle > 0)
                return true;
            else
                return false;
        }

        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            dt = CobroDetalles.Listar("*", "IdCobroDetalle = " + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr;
                dr = dt.Select("IdCobroDetalle = " + IdBuscado);
                this.IdCobroDetalle = IdBuscado;
                this.IdCobro = (int)dr[0]["IdCobro"];
                this.Fecha = (DateTime)dr[0]["Fecha"];
                this.BalanceQuota = (float)dr[0]["BalanceQuota"];
                this.Interes = (float)dr[0]["Interes"];
                this.BalanceInteres = (float)dr[0]["BalanceInteres"];
                this.Quotas = (float)dr[0]["Quotas"];
                return true;
            }
            else
                return false;
        }


        public Boolean Modificar(float BalanceQuota, float Interes, float BalanceInteres, int Quotas)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Update CobroDetalles set BalanceQuota = " + BalanceQuota + ",  Interes =" + Interes + ", BalanceInteres = " + BalanceInteres + ", Quotas = " + Quotas + " Where IdCobroDetalle = " + this.IdCobroDetalle + ";");

        }


        public bool Eliminar(int IdBuscado)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Delete from CobroDetalles where IdCobroDetalle = " + IdBuscado);
        }

        public bool EliminarCompleto(int IdBuscado)
        {
            DAL.ConexionDb db = new DAL.ConexionDb();
            return db.EjecutarDB("Delete from CobroDetalles where IdCobro = " + IdBuscado);
        }

        public static DataTable Listar(string campos = "*", string filtro = "1=1")
        {
            DAL.ConexionDb conexion = new DAL.ConexionDb();
            return conexion.BuscarDb("Select " + campos + " from CobroDetalles where " + filtro);
        }
    }
}
