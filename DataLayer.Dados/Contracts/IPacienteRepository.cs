using DataLayer.Dados.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dados.Contracts
{
   public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Paciente GetByCPF(string cpf);
    }
}
