using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T_Peoples.Domains;
using T_Peoples.Repository;

namespace T_Peoples.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionariosRepository funcionarios = new FuncionariosRepository();

        [HttpGet]
        public IEnumerable<FuncionariosDomain> ListarTudo()
        {
            return funcionarios.Listar();
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionariosDomain funcionariosDomain = funcionarios.BuscarPorId(id);
            if (funcionariosDomain == null)
                return NotFound();
            return Ok(funcionariosDomain);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            funcionarios.Deletar(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Inserir (FuncionariosDomain funcionariosDomain)
        {
            funcionarios.Inserir(funcionariosDomain);
            return Ok(funcionariosDomain);
        }
        [HttpPost]
        public IActionResult Atualizar(FuncionariosDomain funcionariosDomain)
        {
            funcionarios.Atualizar(funcionariosDomain);
            return Ok(funcionariosDomain);
        }
    }
}