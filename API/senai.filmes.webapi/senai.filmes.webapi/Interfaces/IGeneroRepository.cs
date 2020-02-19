using senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Interfaces
{
    interface IGeneroRepository
    {

        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns>Retorna uma lista de generos</returns>
        List<GeneroDomain> Listar();

        // Retorno NomeMetodo(Parâmetro)
        /// <summary>
        /// Cadastra novos generos 
        /// </summary>
        /// <param name="generoDomain"></param>
        void Cadastrar(GeneroDomain generoDomain);

        void Atualizar(GeneroDomain generoDomain);

        void Deletar(int id);

        GeneroDomain GetById(int id);
    }
}
