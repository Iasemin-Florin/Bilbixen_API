using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilbixen_API.EF;
using Bilbixen_API.Models;

namespace Bilbixen_API.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukterController : ControllerBase
    {
        private BilbixenContext _db;

        public ProdukterController(BilbixenContext db)
        {
            _db = db;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var produkter = _db.Produkter.ToList();

            return Ok(produkter);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public IActionResult GetOneProdukt(int id)
        {
            var produkter = _db.Produkter.Find(id);

            if (produkter is null)
            {
                return BadRequest("No data was found");
            }
            return Ok(produkter);
        }

        [Route("Create")]
        [HttpPost]

        public IActionResult Create(ProduktModel model)
        {
            if (string.IsNullOrEmpty(model.ProduktNavn))
            {
                return BadRequest("No Produkt Specified");
            }

            else if (string.IsNullOrEmpty(model.pris.ToString()))
            {
                return BadRequest("No Pris Specified");
            }

            Produkter produkt = new Produkter();
            produkt.ProduktNavn = model.ProduktNavn;
            produkt.Pris = model.pris;
            

            _db.Produkter.Add(produkt);
            _db.SaveChanges();

            return Ok(produkt);
        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Update(ProduktModel model)
        {
            if (string.IsNullOrEmpty(model.ProduktNavn))
            {
                return BadRequest("need to insert Prdukt navn");
            }
            else if (string.IsNullOrEmpty(model.pris.ToString()))
            {
                return BadRequest("need to insert Pris");
            }

            var produkter = _db.Produkter.Find(model.produktID);

            if (produkter is null)
                return BadRequest("Incorrect Produkt ID");

            produkter.ProduktNavn = model.ProduktNavn;
            produkter.Pris = model.pris;
            

            _db.Produkter.Attach(produkter);
            _db.SaveChanges();

            return Ok(produkter);

        }

        [Route("Delete/{id}")]
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var produkter = _db.Produkter.Find(id);
            if (produkter is null)
                return BadRequest("User not found");

            _db.Produkter.Remove(produkter);
            _db.SaveChanges();

            return Ok($"{produkter.ProduktNavn} got deleted");
        }
    }
}
