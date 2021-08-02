using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Api.ViewModels.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Adicionar(PacienteCadastroModel model, [FromServices] IPacienteRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var busca = rep.GetByCPF(model.CPF);
                    if (busca == null)
                    {
                        
                        Paciente paciente = new Paciente();
                        paciente.Prontuario = model.Prontuario;
                        paciente.Nome = model.Nome;
                        paciente.Sobrenome = model.Sobrenome;
                        paciente.Genero = model.Genero;
                        paciente.CPF = model.CPF;
                        paciente.UfRg = model.UfRg;
                        paciente.DataNascimento = model.DataNascimento;
                        paciente.RG = model.RG;
                        paciente.Email = model.Email;
                        paciente.Celular = model.Celular;
                        paciente.Telefone = model.Telefone;
                        paciente.Convenio = model.Convenio;
                        paciente.NumConvenio = model.NumConvenio;
                        paciente.ValidadeConvenio = model.ValidadeConvenio;

                        rep.Insert(paciente);
                        
                        return Ok("Paciente cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Este CPF já está cadastrado em nossa base");
                    }
                }
                catch(Exception e)
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
        public IActionResult Atualizar(PacienteConsultaModel model, [FromServices] IPacienteRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    Paciente paciente = new Paciente();
                    paciente.Prontuario = model.Prontuario;
                    paciente.Nome = model.Nome;
                    paciente.Sobrenome = model.Sobrenome;
                    paciente.Genero = model.Genero;
                    paciente.CPF = model.CPF;
                    paciente.UfRg = model.UfRg;
                    paciente.DataNascimento = model.DataNascimento;
                    paciente.RG = model.RG;
                    paciente.Email = model.Email;
                    paciente.Celular = model.Celular;
                    paciente.Telefone = model.Telefone;
                    paciente.Convenio = model.Convenio;
                    paciente.NumConvenio = model.NumConvenio;
                    paciente.ValidadeConvenio = model.ValidadeConvenio;

                    rep.Update(paciente);
                    return Ok("Paciente atualizado com sucesso");
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

        [HttpGet]
        public IActionResult ConsultarTodos([FromServices] IPacienteRepository rep)
        {
            try
            {
                var list = new List<Paciente>();
                list = rep.GetAll();

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
       /*
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id, [FromServices] IPacienteRepository rep)
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
       */
        
        [HttpGet("{cpf}")]
        public IActionResult ConsultarPorCPF(string cpf, [FromServices] IPacienteRepository rep)
        {
            try
            {
                var cliente = rep.GetByCPF(cpf);
                if(cliente != null)
                {
                    return Ok(cliente);
                }
                else
                {
                    return BadRequest("CPF não encontrado em nossa base!");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        

    }
}
