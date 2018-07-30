using Arvato.PortalCandidato.Model;
using Arvato.PortalCandidato.Service.Repository.Core;
using Arvato.PortalCandidato.Service.Repository.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvato.PortalCandidato.Service.Repository.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        //Modificar por el contexto correspondientes
        private PortalCandidatoContext _db;
        //Ejemplo
         public IRepository<Candidate> Candidates { get; private set; }
        public IRepository<Region> Regiones { get; private set; }


        public UnitOfWork(PortalCandidatoContext db)
        {
            _db = db;
            //Ejemplo
            Candidates = new Repository<Candidate>(_db);
            Regiones = new Repository<Region>(_db);

        }

        public void Complete()
        {
            _db.SaveChanges();
        }
    }
}
