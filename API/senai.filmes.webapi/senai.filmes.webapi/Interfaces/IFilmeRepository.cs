using senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> Listar();

        void Cadastrar(FilmeDomain filme);

        void Deletar(int id);


    }
}
