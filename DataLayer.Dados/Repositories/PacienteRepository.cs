using Dapper;
using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Dados.Repositories
{
   public class PacienteRepository : IPacienteRepository
    {
        private readonly string strConn;

        public PacienteRepository(string strConn)
        {
            this.strConn = strConn;
        }

        public void Insert(Paciente obj)
        {

           
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute("SPInsert", obj, commandType: CommandType.StoredProcedure);
            }

        }
        public void Update(Paciente obj)
        {
           
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute("SPUpdate", obj, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Paciente> GetAll()
        {
           
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Paciente>("spSelectAll", commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public Paciente GetByCPF(string cpf)
        {
           
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query("spSelectByCPF", new { CPF = cpf }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }

        }

        public Paciente GetById(int Id)
        {
            var query = "select * from Paciente where IdPaciente = @IdPaciente";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Paciente>(query, new { IdPaciente = Id }).FirstOrDefault();
            }
        }

        
        
    }
}
