using Arvato.PortalCandadato.Shared.DTO;
using Arvato.PortalCandidato.Model;
using Arvato.PortalCandidato.Service.Repository.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvato.PortalCandidato.Service.Service
{
    public class CandidateService
    {


        IUnitOfWork _unitOfWork;
        public CandidateService()
        {
            _unitOfWork = new UnitOfWork(new PortalCandidatoContext());

        }


        public IEnumerable<CandidateDTO> Get()
        {
            return Mapper.Map<IEnumerable<CandidateDTO>>(_unitOfWork.Candidates.Get());
        }

        public CandidateDTO Get(int id)
        {
            return  Mapper.Map<IEnumerable<CandidateDTO>>(_unitOfWork.Candidates.Get(x => x.Id == id)).FirstOrDefault();
        }

        public void Insert(CandidateDTO candidate)
        {
             var nuevaCan = Mapper.Map<Candidate>(candidate);
            //Candidate nuevaCan = new Candidate()
            //{
            //    Email = candidate.Email,
            //    Name = candidate.Name,
            //    PathCV = candidate.PathCV,
            //    RegionId = candidate.RegionId,
            //    Surname = candidate.Surname,
            //    RGPD = candidate.RGPD,
            //    User = candidate.User,
            //    Telephone = candidate.Telephone
            //};

            _unitOfWork.Candidates.Insert(nuevaCan);
            _unitOfWork.Complete();
        }


        public void Delete(int id)
        {
            _unitOfWork.Candidates.Delete(id);
            _unitOfWork.Complete();
        }

        public void Update(CandidateDTO candidate)
        {
            //var regions = _unitOfWork.Regiones.Get(x => x.Id == region.Id).FirstOrDefault();
            //regions.Email = region.Email;
            _unitOfWork.Candidates.Update(Mapper.Map<Candidate>(candidate));
            _unitOfWork.Complete();
        }




    }
}
