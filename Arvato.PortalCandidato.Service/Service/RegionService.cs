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
    public class RegionService
    {
        IUnitOfWork _unitOfWork;
        public RegionService()
        {
            _unitOfWork = new UnitOfWork(new PortalCandidatoContext());

        }


        public IEnumerable<RegionDTO> Get()
        {
            return Mapper.Map<IEnumerable<RegionDTO>>(_unitOfWork.Regiones.Get());
        }

        public RegionDTO Get(int id)
        {
            return Mapper.Map<IEnumerable<RegionDTO>>(_unitOfWork.Regiones.Get(x => x.Id == id)).FirstOrDefault();
        }

        public void Update(RegionDTO region)
        {
            //var regions = _unitOfWork.Regiones.Get(x => x.Id == region.Id).FirstOrDefault();
            //regions.Email = region.Email;
            _unitOfWork.Regiones.Update(Mapper.Map<Region>(region));
            _unitOfWork.Complete();
        }


    }
}
