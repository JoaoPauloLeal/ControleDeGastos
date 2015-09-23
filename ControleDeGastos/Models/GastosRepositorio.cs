using MySql.Data.MySqlClient;
using PexeiraConnectionClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeGastos.Models
{
    public class GastosRepositorio
    {
        RepositorioDB conn = new RepositorioDB();
        private List<Gastos> gastos = new List<Gastos>();

        public IEnumerable<Gastos> getAll()
        {
            string sql = "select * from tipogasto";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                gastos.Add(new Gastos((int)dr["IdTipo"], (string)dr["Nome"]));

            }
            return gastos;
        }
        public void Create(Gastos pGastos)
        {
            string sql = "insert into tipogasto (Nome) values('";
            sql += pGastos.Nome + "')";

            conn.executarComando(sql);
        }
        public void Delete(int pId)
        {
            string sql = "delete from tipogasto where IdTipo=" + pId;
            conn.executarComando(sql);
        }
        public Gastos GetOne(int pId)
        {
            string sql = "select * from tipogasto where IdTipo=" + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);
            dr.Read();
            Gastos gastos = new Gastos((int)dr["IdTipo"], (string)dr["Nome"]);
            return gastos;
        }
        public void Update(Gastos pgastos)
        {
            string sql = "update tipogasto set Nome='" + pgastos.Nome + "' where IdTipo=" + pgastos.IdTipo;
            conn.executarComando(sql);
        }
    }
}