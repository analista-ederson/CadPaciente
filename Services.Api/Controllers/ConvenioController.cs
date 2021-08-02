using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Api.ViewModels.Convenio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastro(ConvenioCadastroModel model, [FromServices] IConvenioRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   Convenio convenio = new Convenio();
                    convenio.NomeConvenio = model.NomeConvenio;
                   

                    rep.Insert(convenio);

                    return Ok("Convênio cadastrado com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest("Ocorreram erros de validação");
            }
        }

        [HttpPut]
        public IActionResult Put(ConvenioConsultaModel model, [FromServices] IConvenioRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Convenio convenio = new Convenio();
                    convenio.IdConvenio = model.IdConvenio;
                    convenio.NomeConvenio = model.NomeConvenio;
                   

                    rep.Update(convenio);

                    return Ok("Convênio atualizado com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest("Ocorreram erros de validação");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IConvenioRepository rep)
        {
            try
            {
                rep.Delete(id);
                return Ok("Exclusão realizada com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public IActionResult ConsultarTodos([FromServices] IConvenioRepository rep)
        {
            try
            {
                var list = new List<Convenio>();
                list = rep.GetAll();

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id, [FromServices] IConvenioRepository rep)
        {
            try
            {
                var cliente = rep.GetById(id);

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

    }
}
