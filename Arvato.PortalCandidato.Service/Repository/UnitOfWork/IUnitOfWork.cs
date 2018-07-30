using Arvato.PortalCandidato.Model;
using Arvato.PortalCandidato.Service.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvato.PortalCandidato.Service.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        //Ejemplo de una implementacion de repositoprio
        IRepository<Candidate> Candidates { get; }
        IRepository<Region> Regiones { get; }

        void Complete();
    }
}
