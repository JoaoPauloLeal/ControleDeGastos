using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using PexeiraConnectionClassLibrary;

namespace ControleDeGastos.Models
{
    public class DespesasRepositorio
    {
        RepositorioDB conn = new RepositorioDB();
        private List<Despesas> despesas = new List<Despesas>();

        public IEnumerable<Despesas> getAll()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT d.IdDespesas, d.Local, d.Data, d.Valor, d.TipoPK, t.Nome ");
            sql.Append("FROM despesas d ");
            sql.Append("INNER JOIN tipogasto t ");
            sql.Append("ON d.TipoPK = t.IdTipo ");
            sql.Append("ORDER BY d.Data DESC");
            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = conn.executarConsulta(cmm);
            while (dr.Read())
            {
                Despesas desp = new Despesas
                {

                    Id = (int)dr["IdDespesas"],
                    Data = (DateTime)dr["Data"],
                    Valor = (decimal)dr["Valor"],
                    Local = (string)dr["Local"],
                    gastos = new Gastos
                    {
                        IdTipo = (int)dr["TipoPK"],
                        Nome = (string)dr["Nome"]
                    }
                };
                despesas.Add(desp);
            }
            dr.Dispose();
            return despesas;
        }
        public StringBuilder ConverterData(DateTime pData)
        {
            int dataY = pData.Year;
            int dataM = pData.Month;
            int dataD = pData.Day;
            StringBuilder datac = new StringBuilder();
            datac.Append(dataY.ToString());
            datac.Append("/");
            datac.Append(dataM.ToString());
            datac.Append("/");
            datac.Append(dataD.ToString());

            return datac;
        }
        public IEnumerable<Despesas> Consulta(DateTime pData)
        {
            StringBuilder datac = ConverterData(pData);
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from despesas d ");
            sql.Append("inner join tipogasto t ");
            sql.Append("on t.IdTipo = d.TipoPK  ");
            sql.Append("where Data=@d_date");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@d_date", datac);
            MySqlDataReader dr = conn.executarConsulta(cmm);
            
            while (dr.Read())
            {
                Despesas desp = new Despesas
                {

                    Id = (int)dr["IdDespesas"],
                    Data = (DateTime)dr["Data"],
                    Valor = (decimal)dr["Valor"],
                    Local = (string)dr["Local"],
                    gastos = new Gastos
                    {
                        IdTipo = (int)dr["IdTipo"],
                        Nome = (string)dr["Nome"]
                    }
            };
                despesas.Add(desp);
            }
            dr.Dispose();
            return despesas;
        }
        public IEnumerable<Despesas> getSete()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT d.IdDespesas, d.Local, d.Data, d.Valor, d.TipoPK, t.Nome ");
            sql.Append("FROM despesas d ");
            sql.Append("INNER JOIN tipogasto t ");
            sql.Append("ON d.TipoPK = t.IdTipo");
            sql.Append(" ORDER BY d.Data DESC");
            sql.Append(" LIMIT 7;");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = conn.executarConsulta(cmm);
            
            while (dr.Read())
            {
                Despesas desp = new Despesas
                {
                    Id = (int)dr["IdDespesas"],
                    Local = (string)dr["Local"],
                    Data = (DateTime)dr["Data"],
                    Valor = (decimal)dr["Valor"],
                    gastos = new Gastos
                    {
                        IdTipo = (int)dr["TipoPK"],
                        Nome = (string)dr["Nome"]
                        
                    }
                };
                despesas.Add(desp);
            }
            dr.Dispose();
            return despesas;
        }
        public Despesas GetOne(int id)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("select * ");
            sql.Append("from despesas d ");
            sql.Append("INNER JOIN tipogasto t ");
            sql.Append("ON d.TipoPK = t.IdTipo ");
            sql.Append("where IdDespesas = @id_despesa");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_despesa", id);
            MySqlDataReader dr = conn.executarConsulta(cmm);

            dr.Read();

            Despesas desp = new Despesas
            {

                Id = (int)dr["IdDespesas"],
                Data = (DateTime)dr["Data"],
                Valor = (decimal)dr["Valor"],
                Local = (string)dr["Local"],
                gastos = new Gastos
                {
                    IdTipo = (int)dr["TipoPK"],
                    Nome = (string)dr["Nome"]
                }
            };
            dr.Dispose();
            return desp;
        }
        public void Create(Despesas pDespesas)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder datac = ConverterData(pDespesas.Data);

            StringBuilder sql = new StringBuilder();
            sql.Append("insert into despesas (Data,Valor,TipoPK,Local) ");
            sql.Append("values (@c_data,@c_valor,@c_tipo,@c_local)");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@c_data", datac);
            cmm.Parameters.AddWithValue("@c_valor", pDespesas.Valor);
            cmm.Parameters.AddWithValue("@c_tipo", pDespesas.gastos.IdTipo);
            cmm.Parameters.AddWithValue("@c_local", pDespesas.Local);
            
            conn.executarComando(cmm);
        }
        public void Delete(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from despesas where IdDespesas = @id_del");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_del", pId);

            conn.executarComando(cmm);

        }
        public void Update(Despesas despesa)
        {
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder cData = ConverterData(despesa.Data);
            StringBuilder sql = new StringBuilder();

            sql.Append("update despesas ");
            sql.Append("set Data=@data, Valor=@valor, TipoPK=@tipo, Local=@local ");
            sql.Append("where IdDespesas=@id");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@data", cData);
            cmm.Parameters.AddWithValue("@valor", despesa.Valor);
            cmm.Parameters.AddWithValue("@tipo", despesa.gastos.IdTipo);
            cmm.Parameters.AddWithValue("@local", despesa.Local);
            cmm.Parameters.AddWithValue("@id", despesa.Id);

            conn.executarComando(cmm);

        }
    }
}