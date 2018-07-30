using Arvato.PortalCandadato.Shared.DTO;
using Arvato.PortalCandidato.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Arvato.PortalCandidato.Api.Controllers
{
    public class RegionController : ApiController
    {

        RegionService _service;
        public RegionController()
        {
            _service = new RegionService();
        }

        public IHttpActionResult Get()
        {
            IEnumerable<RegionDTO> region;
            try
            {
                region = _service.Get();
                if (region.Count() > 0)
                {
                    return Ok(region);
                }
                else
                {
                    return BadRequest("No existen regiones en la base de datos");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error al recuperar los datos");

            }


        }

        public IHttpActionResult Get(int id)
        {
           RegionDTO region;
            try
            {
                region = _service.Get(id);
                if (region!=null)
                {
                    return Ok(region);
                }
                else
                {
                    return BadRequest("No existen regiones en la base de datos");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error al recuperar los datos");

            }


        }



        [HttpPut]
        public IHttpActionResult Update(RegionDTO region)
        {

            try
            {
                _service.Update(region);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error al recuperar los datos");

            }
        }
    }
}
