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
    public class CandidateController : ApiController
    {


        CandidateService _service;
        public CandidateController()
        {
            _service = new CandidateService();       
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            IEnumerable<CandidateDTO> candidatos;
            try {
                 candidatos= _service.Get();
                if (candidatos.Count() > 0)
                {
                    return Ok(candidatos);
                }
                else
                {
                    return BadRequest("No existen candaditos en la base de datos");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error al recuperar los datos");

            }
           

        }

        public IHttpActionResult Get(int id)
        {
            CandidateDTO candidato;
            try
            {
                candidato = _service.Get(id);
                if (candidato!=null)
                {
                    return Ok(candidato);
                }
                else
                {
                    return BadRequest("No existe el candidato");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error al recuperar los datos");

            }


        }


        [HttpPost]
        public IHttpActionResult Insert(CandidateDTO candidato)
        {
            try
            {

                _service.Insert(candidato);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error al recuperar los datos");
            }
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            CandidateDTO candidato;
            try
            {
                candidato = _service.Get(id);
                if (candidato != null)
                {
                    _service.Delete(id);
                    return Ok();
                }
                else
                {
                    return BadRequest("No existe el candidato");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error al recuperar los datos");

            }
        }

        [HttpPut]
        public IHttpActionResult Update(CandidateDTO candidato)
        {

            try
            {
                _service.Update(candidato);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error al recuperar los datos");

            }
        }

    }
}
