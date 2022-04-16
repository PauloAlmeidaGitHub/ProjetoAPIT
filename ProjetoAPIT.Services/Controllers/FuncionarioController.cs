using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPIT.Repository.Entities;
using ProjetoAPIT.Repository.Interfaces;
using ProjetoAPIT.Services.Models;
using System.Collections.Generic;

namespace ProjetoAPIT.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        //========================================================================
        private readonly IFuncionarioRepository _service;
        public FuncionarioController(IFuncionarioRepository service)
        {
            _service = service;
        }
        //========================================================================


        //========================================================================
        [HttpPost]
        public IActionResult Post(FuncionarioCadastroModel model)
        {
            try
            {
                var obj = new Funcionario();
                obj.Nome = model.Nome;

                _service.Create(obj);

                return StatusCode(201, $"Funcionário {obj.Nome} cadastrado com sucesso!");
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //========================================================================
        [HttpGet]
        [Route("/All")]
        public IActionResult Get()
        {
            try
            {
                var funcionarios = _service.GetAll();
                return StatusCode(200,funcionarios);
                //return StatusCode(500, false);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //========================================================================
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var funcionario = _service.GetById(id);

                //retornar os dados do usuario
                return Ok(
                    new
                    {
                        FuncionarioId = funcionario.FuncionarioId,
                        Nome = funcionario.Nome
                    }
                    );
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        //========================================================================
    }
}
