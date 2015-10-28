using ControleDeGastos.Core;
using ControleDeGastos.Repository.Contracts;
using MySql.Data.MySqlClient;
using PexeiraConnectionClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeGastos.Repository.Repositories
{
    public class GastosRepositorio : ITipoRepositorio
    {
        RepositorioDB conn = new RepositorioDB();
        private List<Gastos> gastos = new List<Gastos>();

        public IEnumerable<Gastos> getAll()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from tipogasto ");
            sql.Append("order by Nome asc");
            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = conn.executarConsulta(cmm);

            while (dr.Read())
            {
                gastos.Add
                (
                    new Gastos
                    {
                        IdTipo = (int)dr["IdTipo"],
                        Nome = (string)dr["Nome"]
                    }
                );
            }
            return gastos;
        }
        public void Create(Gastos pGastos)
        {
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into tipogasto (Nome) ");
            sql.Append("values(@nome)");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome", pGastos.Nome);

            conn.executarComando(cmm);
        }
        public int Delete(int pId)
        {
            int erro = 0;
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from tipogasto ");
            sql.Append("where IdTipo=@id");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id", pId);
            try
            {
                conn.executarComando(cmm);
            }
            catch (Exception)
            {
                erro = 1;
                return erro;
            }
            return erro;

        }
        public Gastos getOne(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from tipogasto ");
            sql.Append("where IdTipo=@id");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id", pId);
            MySqlDataReader dr = conn.executarConsulta(cmm);
            dr.Read();
            Gastos gastos = new Gastos
            {
                IdTipo = (int)dr["IdTipo"],
                Nome = (string)dr["Nome"]
            };

            return gastos;
        }
        public void Update(Gastos pgastos)
        {
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("update tipogasto ");
            sql.Append("set Nome=@nome ");
            sql.Append("where IdTipo=@tipo");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome", pgastos.Nome);
            cmm.Parameters.AddWithValue("@tipo", pgastos.IdTipo);
            conn.executarComando(cmm);
        }
    }
}