using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using System;
using System.Collections.Generic;
using Dapper;

using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataLayer.Dados.Repositories
{
    public class ConvenioRepository : IConvenioRepository
    {
        private readonly string strConn;

        public ConvenioRepository(string strConn)
        {
            this.strConn = strConn;
        }
        public void Insert(Convenio obj)
        {
            var query = "insert into Convenio(NomeConvenio) " + "values (@NomeConvenio)";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }

        public void Update(Convenio obj)
        {
            var query = "update Convenio set NomeConvenio= @NomeConvenio where IdConvenio = @IdConvenio";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, obj);
            }
        }

        public void Delete(int Id)
        {
            var query = "delete from Convenio where IdConvenio = @IdConvenio";
            using (var conn = new SqlConnection(strConn))
            {
                conn.Execute(query, new { IdConvenio = Id });
            }
        }

        public List<Convenio> GetAll()
        {
            var query = "select * from Convenio";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Convenio>(query).ToList();
            }
        }

        public Convenio GetById(int Id)
        {
            var query = "select * from Convenio where IdConvenio= @IdConvenio";
            using (var conn = new SqlConnection(strConn))
            {
                return conn.Query<Convenio>(query, new { IdConvenio = Id }).SingleOrDefault();
            }
        }

       

        
    }
}
