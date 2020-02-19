using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using senai.filmes.webapi.Repositories;

namespace senai.filmes.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }

        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            return _generoRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            _generoRepository.Cadastrar(generoDomain);
            return Ok();
            //return BadRequest(); //Status code 400
            //return NotFound(); //Status code 404
            //return StatusCode(203); //Status code 203
            //return StatusCode(201); //Status code 201
        }

        [HttpPut]
        public IActionResult Atualizar(GeneroDomain generoDomain)
        {
            _generoRepository.Atualizar(generoDomain);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            _generoRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.GetById(id);

            if (generoBuscado == null)
            {
                return StatusCode(404);
            }

            return StatusCode(200, generoBuscado);
        }
    }
}