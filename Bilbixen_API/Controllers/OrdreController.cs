using Bilbixen_API.EF;
using Bilbixen_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilbixen_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdreController : ControllerBase
    {
        private BilbixenContext _db;

        public OrdreController(BilbixenContext db)
        {
            _db = db;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var ordre = _db.Ordrere.ToList();

            return Ok(ordre);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public IActionResult GetOneOrdre(int id)
        {
            var ordre = _db.Ordrere.Find(id);

            if (ordre is null)
            {
                return BadRequest("No data was found");
            }
            return Ok(ordre);
        }

        [Route("Create")]
        [HttpPost]

        public IActionResult Create(OrdreModel model)
        {
            if (string.IsNullOrEmpty(model.BrugerID.ToString()))
            {
                return BadRequest("No Bruger ID Specified");
            }

            else if (string.IsNullOrEmpty(model.OrdreDato.ToString()))
            {
                return BadRequest("No Date Specified");
            }

            else if (string.IsNullOrEmpty(model.TotalPris.ToString()))
            {
                return BadRequest("No total price specified");
            }

            Ordre ordre = new Ordre();
            ordre.BrugerId = model.BrugerID;
            ordre.OrdreDato = model.OrdreDato;
            ordre.TotalPris = model.TotalPris;


            _db.Ordrere.Add(ordre);
            _db.SaveChanges();

            return Ok(ordre);
        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Update(OrdreModel model)
        {
            if (string.IsNullOrEmpty(model.BrugerID.ToString()))
            {
                return BadRequest("need to insert brugerID ");
            }
            else if (string.IsNullOrEmpty(model.TotalPris.ToString()))
            {
                return BadRequest("need to insert totalpris");
            }

            var ordre = _db.Ordrere.Find(model.OrdreID);

            if (ordre is null)
                return BadRequest("Incorrect Produkt ID");

            ordre.BrugerId = model.BrugerID;
            ordre.TotalPris = model.TotalPris;


            _db.Ordrere.Attach(ordre);
            _db.SaveChanges();

            return Ok(ordre);

        }

        [Route("Delete/{id}")]
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var ordre = _db.Ordrere.Find(id);
            if (ordre is null)
                return BadRequest("User not found");

            _db.Ordrere.Remove(ordre);
            _db.SaveChanges();

            return Ok($"order with id: {ordre.OrdreId} got deleted");
        }
    }
}
