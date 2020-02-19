using Microsoft.AspNetCore.Mvc;
using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using senai.filmes.webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();

        }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmeRepository.Deletar(id);

            return Ok("Gênero deletado");
        }
       


    }
}
