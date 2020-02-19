using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source=DEV5\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=sa@132";

        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme (Titulo, IdGenero) VALUES (@Titulo, @IdGenero)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT F.IdFilme, F.Titulo, F.IdGenero, G.Nome AS TituloGenero FROM Filme F INNER JOIN Genero G ON F.IdGenero = G.IdGenero;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = rdr["TituloGenero"].ToString()
                            }
                        };

                        filmes.Add(filme); 
                        
                    }
                }
            }
            return filmes;


        }
    }
}
