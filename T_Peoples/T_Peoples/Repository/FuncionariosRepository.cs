using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using T_Peoples.Domains;

namespace T_Peoples.Repository
{
    public class FuncionariosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFuncionario,Nome,Sobrenome FROM Funcionarios";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = sdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
        public FuncionariosDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdFuncionario,Nome,Sobrenome FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionariosDomain funcionarios = new FuncionariosDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionarios;
                        }
                    }
                    return null;
                }
            }
        }
        public void Deletar (int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(FuncionariosDomain funcionarios)
        {
            string Query = "INSERT INTO Funcionarios (Nome,Sobrenome) Values (@Nome,@Sobrenome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Atualizar (FuncionariosDomain funcionarios)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome , Sobrenome = @Sobrenome WHERE IdFuncionario = @IdFuncionario ";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);
                    cmd.Parameters.AddWithValue("@IdFuncionario", funcionarios.IdFuncionario);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}