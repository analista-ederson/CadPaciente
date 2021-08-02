using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Api.ViewModels.Paciente
{
    public class PacienteCadastroModel
    {
       
        public string Prontuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string UfRg { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Convenio { get; set; }
        public string NumConvenio { get; set; }
        public string ValidadeConvenio { get; set; }
    }
}
