using DataAccess.Interfaces;
using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.Controllers
{
    public class DemoController : ApiController
    {
        private IDemoRepository _repo { get; set; }

        public DemoController(IDemoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<DemoEntity> entities = _repo.GetAll();
            return Ok(entities);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            DemoEntity entity = _repo.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public IHttpActionResult Post(DemoModel model)
        {
            if(ModelState.IsValid)
            {
                DemoEntity entity = model.ToEntity();
                _repo.Add(entity);
                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put(int? id, [FromBody] DemoModel model)
        {
            if (!id.HasValue) return BadRequest();
            if (ModelState.IsValid)
            {
                _repo.Modify(id.Value, model.ToEntity());
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _repo.Remove(id);
            return Ok();
        }



    }
}
