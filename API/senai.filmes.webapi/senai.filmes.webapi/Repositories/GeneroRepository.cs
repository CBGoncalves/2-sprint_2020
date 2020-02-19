using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source=DEV5\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=sa@132";

        public GeneroDomain GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscar = "SELECT IdGenero, Nome FROM Genero";
                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                   
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        GeneroDomain generoDomain = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        return generoDomain;
                    }
                    return null;

                }
            }
        }

        public void Atualizar(GeneroDomain generoDomain)
        {
            string query = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", generoDomain.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar(GeneroDomain generoDomain)
        {
            string queryInsert = "INSERT INTO Genero (Nome) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        public void Deletar(int id)
        {
            string query = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();

                }
            }
        

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdGenero, Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);
                    }
                }
            }

            return generos;
        }
    }
}
