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
    public class OrdreLinjerController : ControllerBase
    {
        private BilbixenContext _db;

        public OrdreLinjerController(BilbixenContext db)
        {
            _db = db;
        }

        [Route("GetAll")]
        [HttpGet]

        public IActionResult GetAll()
        {
            var ordreLinjer = _db.OrdreLinjer.ToList();

            return Ok(ordreLinjer);
        }

        [Route("Get/{id}")]
        [HttpGet]

        public IActionResult Get(int id)
        {
            var ordreLinjer = _db.OrdreLinjer.Find(id);

            if (ordreLinjer is null)
                return BadRequest("Invalid Ordre linje ID");
            return Ok(ordreLinjer);
        }

        [Route("Create")]
        [HttpPost]

        public IActionResult Create(OrdreLinjeModel model)
        {
            if (string.IsNullOrEmpty(model.OrdreID.ToString()))
            {
                return BadRequest(" insert ordre id");
            }
            else if (string.IsNullOrEmpty(model.ProduktID.ToString()))
            {
                return BadRequest("insert produkt id");
            }
            else if (string.IsNullOrEmpty(model.Antal.ToString()))
            {
                return BadRequest("insert antal");
            }
            else if (string.IsNullOrEmpty(model.Pris.ToString()))
            {
                return BadRequest("insert pris");
            }

            OrdreLinje ordreLinje = new OrdreLinje();

            ordreLinje.OrdreId = model.OrdreID;
            ordreLinje.ProduktId = model.ProduktID;
            ordreLinje.Antal = model.Antal;
            ordreLinje.Pris = model.Pris;

            _db.OrdreLinjer.Add(ordreLinje);
            _db.SaveChanges();

            return Ok(ordreLinje);
        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Update(OrdreLinjeModel model)
        {
            if (string.IsNullOrEmpty(model.OrdreID.ToString()))
            {
                return BadRequest("insert ordre id");
            }
            else if (string.IsNullOrEmpty(model.ProduktID.ToString()))
            {
                return BadRequest("insert produkt id");
            }
            else if (string.IsNullOrEmpty(model.Antal.ToString()))
            {
                return BadRequest("insert antal");
            }
            else if (string.IsNullOrEmpty(model.Pris.ToString()))
            {
                return BadRequest("insert pris");
            }

            var ordreLinje = _db.OrdreLinjer.Find(model.OrdreLinjeID);

            if (ordreLinje is null)
            {
                return BadRequest("Ordrelinje doesn't exist with this id");
            }

            ordreLinje.OrdreId = model.OrdreID;
            ordreLinje.ProduktId = model.ProduktID;
            ordreLinje.Antal = model.Antal;
            ordreLinje.Pris = model.Pris;

            _db.OrdreLinjer.Attach(ordreLinje);
            _db.SaveChanges();
            return Ok(ordreLinje);
        }

        [Route("Delete/{id}")]
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var ordreLinje = _db.OrdreLinjer.Find(id);
            if (ordreLinje is null)
            {
                return BadRequest("an OrdreLinje doesnøt exist with this id");
            }

            _db.OrdreLinjer.Remove(ordreLinje);
            _db.SaveChanges();
            return Ok(ordreLinje + " was succesfully deleted");
        }
    }
}
