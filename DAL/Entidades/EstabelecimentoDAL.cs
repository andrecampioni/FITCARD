using DAL.Mensagem;
using FITCARD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public static class EstabelecimentoDAL
    {
        //Url de conexão
        static string StrConexao = ConfigurationManager.ConnectionStrings["Banco"].ToString();

        #region Inserir Estabelecimento 
        public static Retorno Inserir(Estabelecimento cadastro)
        {
            Retorno p = new Retorno();

            using (var conn = new SqlConnection(StrConexao))
            {

                SqlCommand cmd = new SqlCommand("INSERT_ESTAB", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CNPJ", cadastro.CNPJ);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", cadastro.RazaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", cadastro.NomeFantasia);
                cmd.Parameters.AddWithValue("@EMAIL", cadastro.Email);
                cmd.Parameters.AddWithValue("@ENDERECO", cadastro.Endereco);
                cmd.Parameters.AddWithValue("@CIDADE", cadastro.Cidade);
                cmd.Parameters.AddWithValue("@ESTADO", cadastro.Estado);
                cmd.Parameters.AddWithValue("@TELEFONE", cadastro.Telefone);
                cmd.Parameters.AddWithValue("@CATEGORIA", cadastro.Categoria);
                cmd.Parameters.AddWithValue("@STATUS", cadastro.Status);
                cmd.Parameters.AddWithValue("@AGENCIA", cadastro.Agencia);
                cmd.Parameters.AddWithValue("@CONTA", cadastro.Conta);
                cmd.Parameters.AddWithValue("@DATACRIACAO", cadastro.DataCadastro);


                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p.IDRetorno = (int)reader["COD_ERRO"];
                            p.Mensagem = reader["RETORNO"].ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    p.IDRetorno = 1;
                    p.Mensagem = "Erro ao inserir o Estabelecimento. " + e.Message;
                }
                finally
                {
                    conn.Close();
                }
                return p;
            }
        }
        #endregion

        #region Atualizar Estabelecimento
        public static Retorno Atualizar(Estabelecimento cadastro)
        {
            using (var conn = new SqlConnection(StrConexao))
            {

                SqlCommand cmd = new SqlCommand("UPDATE_ESTAB", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("ID_ESTAB", cadastro.IDEstabelecimento);
                cmd.Parameters.AddWithValue("@CNPJ", cadastro.CNPJ);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", cadastro.RazaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", cadastro.NomeFantasia);
                cmd.Parameters.AddWithValue("@EMAIL", cadastro.Email);
                cmd.Parameters.AddWithValue("@ENDERECO", cadastro.Endereco);
                cmd.Parameters.AddWithValue("@CIDADE", cadastro.Cidade);
                cmd.Parameters.AddWithValue("@ESTADO", cadastro.Estado);
                cmd.Parameters.AddWithValue("@TELEFONE", cadastro.Telefone);
                cmd.Parameters.AddWithValue("@CATEGORIA", cadastro.Categoria);
                cmd.Parameters.AddWithValue("@STATUS", cadastro.Status);
                cmd.Parameters.AddWithValue("@AGENCIA", cadastro.Agencia);
                cmd.Parameters.AddWithValue("@CONTA", cadastro.Conta);

                Retorno p = new Retorno();

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p.IDRetorno = (int)reader["COD_ERRO"];
                            p.Mensagem = reader["RETORNO"].ToString();
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return p;
            }

        }
        #endregion

        #region Excluir Estabelecimento
        public static Retorno Excluir(int IDEstabelecimento)
        {
            using (var conn = new SqlConnection(StrConexao))
            {

                SqlCommand cmd = new SqlCommand("DELETE_ESTAB", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_ESTAB", IDEstabelecimento);
               
                Retorno p = new Retorno();

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p.IDRetorno = (int)reader["COD_ERRO"];
                            p.Mensagem = reader["RETORNO"].ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    p.IDRetorno = 1;
                    p.Mensagem = "Erro ao excluir o Estabelecimento. " + e.Message;
                }
                finally
                {
                    conn.Close();
                }
                return p;
            }
        }
        #endregion

        #region Obter Estabelecimento
        public static Estabelecimento Obter(int IDEstabelecimento)
        {
            using (var conn = new SqlConnection(StrConexao))
            {

                SqlCommand cmd = new SqlCommand("READ_ESTAB", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_ESTAB", IDEstabelecimento);

                Estabelecimento p = new Estabelecimento();

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p.IDEstabelecimento = (int)reader["IDEstabelecimento"];
                            p.CNPJ = reader["CNPJ"].ToString();
                            p.RazaoSocial = reader["RazaoSocial"].ToString();
                            p.NomeFantasia = reader["NomeFantasia"].ToString();
                            p.Email = reader["Email"].ToString();
                            p.Endereco = reader["Endereco"].ToString();
                            p.Cidade = reader["Cidade"].ToString();
                            p.Estado = reader["Estado"].ToString();
                            p.Telefone = reader["Telefone"].ToString();
                            p.DataCadastro = (DateTime)reader["DataCadastro"];
                            p.Categoria = reader["Categoria"].ToString();
                            p.Status = (int)reader["Status"];
                            p.Agencia = reader["Agencia"].ToString();
                            p.Conta = reader["Conta"].ToString();

                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return p;
            }
        }
        #endregion

        #region Lista Estabelecimento
        public static List<Estabelecimento> Lista()
        {
            using (var conn = new SqlConnection(StrConexao))
            {

                SqlCommand cmd = new SqlCommand("LIST_ESTAB", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<Estabelecimento> Lista = new List<Estabelecimento>();

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            Estabelecimento p = new Estabelecimento();
                            p.IDEstabelecimento = (int)reader["IDEstabelecimento"];
                            p.CNPJ = reader["CNPJ"].ToString();
                            p.RazaoSocial = reader["CNPJ"].ToString();
                            p.NomeFantasia = reader["RazaoSocial"].ToString();
                            p.Email = reader["Email"].ToString();
                            p.Endereco = reader["Endereco"].ToString();
                            p.Cidade = reader["Cidade"].ToString();
                            p.Estado = reader["Estado"].ToString();
                            p.Telefone = reader["Telefone"].ToString();
                            p.DataCadastro = (DateTime)reader["DataCadastro"];
                            p.Categoria = reader["Categoria"].ToString();
                            p.Status = (int)reader["Status"];
                            p.Agencia = reader["Agencia"].ToString();
                            p.Conta = reader["Conta"].ToString();
                            Lista.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao obter a relação de Estabelecimento. " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return Lista;
            }
        }
        #endregion
    }
}
