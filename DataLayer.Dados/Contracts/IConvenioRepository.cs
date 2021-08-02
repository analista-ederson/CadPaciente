using DataLayer.Dados.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dados.Contracts
{
   public interface IConvenioRepository : IBaseRepository<Convenio>
    {
        void Delete(int Id);
    }
}
