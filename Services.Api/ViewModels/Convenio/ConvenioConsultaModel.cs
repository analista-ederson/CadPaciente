using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Api.ViewModels.Convenio
{
    public class ConvenioConsultaModel
    {
        [Required(ErrorMessage = "O ID do advogado deverá ser informado")]
        public int IdConvenio { get; set; }

        [Required(ErrorMessage = "O nome deverá ser preenchido")]
        [MaxLength(150, ErrorMessage = "O campo só recebe até 150 caracteres")]
        public string NomeConvenio { get; set; }
    }
}
