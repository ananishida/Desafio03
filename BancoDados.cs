using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio03
{
    class BandoDados
    {
        private string stringConexao = "Data Source=localhost; Initial Catalog=Dados; User ID=acesso; password=senha;language=Portuguese";

        private SqlConnection cn;


        private void conexao()
        {
            cn = new SqlConnection(stringConexao);
        }

        public SqlConnection abrirConexao()
        {
            try
            {

                conexao();
                cn.Open();

                return cn;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public void fecharConexao()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public DataTable executarConsultaGenerica(string sql)
        {
            try
            {
                abrirConexao();

                SqlCommand command = new SqlCommand(sql, cn);
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                fecharConexao();
            }
        }

        public int Executar(SqlCommand command)
        {
            int Id = 0;

            try
            {
                abrirConexao();
                command.Connection = cn;
                object ggggg = command.ExecuteScalar();
                return int.Parse(ggggg.ToString());
            }

            finally
            {
                fecharConexao();
            }
        }


        public DataTable Consulta(SqlCommand command)
        {
            try
            {
                abrirConexao();
                command.Connection = cn;

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                fecharConexao();
            }
        }
    }
}
