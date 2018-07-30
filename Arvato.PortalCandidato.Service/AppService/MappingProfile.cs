using Arvato.PortalCandadato.Shared.DTO;
using Arvato.PortalCandidato.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvato.PortalCandidato.Service.AppService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Region, RegionDTO>();
            CreateMap<RegionDTO, Region>();
            CreateMap<Candidate, CandidateDTO>();
            CreateMap<CandidateDTO, Candidate>();

            //.ForMember(dest => dest.DESTINO, opts => opts.MapFrom(src => src.LECTURA));
        }

        public void Iniciar()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<MappingProfile>();
            });
        }
    }
}
