using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PexeiraConnectionClassLibrary;

namespace ControleDeGastos.Models
{
    public class DespesasRepositorio
    {
        RepositorioDB conn = new RepositorioDB();
        private List<Despesas> despesas = new List<Despesas>();

        public IEnumerable<Despesas> getAll()
        {
            //List<Aluno> aluno = new List<Aluno>();

            string sql = "select * from despesas";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                despesas.Add(new Despesas((int)dr["IdDespesas"], Convert.ToString(dr["Data"]), (float)dr["Valor"], (int)dr["TipoPK"], (string)dr["Local"]));
            }
            return despesas;
        }
        public IEnumerable<Despesas> Consulta(string pData)
        {
            //List<Aluno> aluno = new List<Aluno>();

            string sql = "select * from despesas where Data='"+ pData+"'";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                despesas.Add(new Despesas((int)dr["IdDespesas"], Convert.ToString(dr["Data"]), (float)dr["Valor"], (int)dr["TipoPK"], (string)dr["Local"]));
            }
            return despesas;
        }
        public IEnumerable<Despesas> getSete()
        {
            //List<Aluno> aluno = new List<Aluno>();

            string sql = "select * from despesas order by Data desc limit 7";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                despesas.Add(new Despesas((int)dr["IdDespesas"], Convert.ToString(dr["Data"]), (float)dr["Valor"], (int)dr["TipoPK"], (string)dr["Local"]));
            }
            return despesas;
        }
        public Despesas GetOne(int pId)
        {
            string sql = "select * from despesas where IdDespesas=" + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);
            dr.Read();
            Despesas despesas = new Despesas((int)dr["IdDespesas"], Convert.ToString(dr["Data"]), (float)dr["Valor"], (int)dr["TipoPK"], (string)dr["Local"]);
            DateTime dt = DateTime.ParseExact(despesas.Data, "dd/mm/yyyy", null);
            despesas.Data = dt.ToString();
            return despesas;
        }
        public void Create(Despesas pDespesas)
        {
            /*string i = pDespesas.Valor.ToString();
            i.Replace(",", ".");
            pDespesas.Valor = Convert.ToInt64(i);*/
            string sql = "insert into despesas (Data,Valor,TipoPK,Local) values ('";
            sql += pDespesas.Data + "'," + pDespesas.Valor + "," + pDespesas.Tipo + ",'" + pDespesas.Local + "')";
            conn.executarComando(sql);
        }
        public void Delete(int pId)
        {
            string sql = "delete from despesas where IdDespesas = " + pId;
            conn.executarComando(sql);
        }
        public void Update(Despesas despesa)
        {
            string sql = "update despesas set Data='" + despesa.Data + "', Valor='" + despesa.Valor + "', TipoPK=" + despesa.Tipo + ", Local='" + despesa.Local + "' where IdDespesas=" + despesa.Id;
            conn.executarComando(sql);
        }
    }
}