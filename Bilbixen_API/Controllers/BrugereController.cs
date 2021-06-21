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
    public class BrugereController : Controller
    {
        private BilbixenContext _db;

        public BrugereController(BilbixenContext db)
        {
            _db = db;
        }

        [Route("GetAll")]
        [HttpGet]

        public IActionResult GetAll()
        {
            var brugere = _db.Brugere.ToList();
            return Ok(brugere);

        }

        [Route("Get/{id}")]
        [HttpGet]
        public IActionResult GetOneBruger(int id)
        {
            var bruger = _db.Brugere.Find(id);
            
            if(bruger is null)
            {
                return BadRequest("No data was found");
            }
            return Ok(bruger);
        }

        [Route("Create")]
        [HttpPost]

        public IActionResult Create(BrugerModel model)
        {
            if (string.IsNullOrEmpty(model.Fnavn))
            {
                return BadRequest("need to insert Førstenavn");
            }
            else if (string.IsNullOrEmpty(model.Enavn))
            {
                return BadRequest("need to insert Efternavn");
            }
            else if (string.IsNullOrEmpty(model.TlfNR))
            {
                return BadRequest("need to insert tlf nr");
            }
            else if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest("need to insert email");
            }
            else if (string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("need to insert password");
            }
            else if (string.IsNullOrEmpty(model.PostNR.ToString()))
            {
                return BadRequest("need to insert postNR");
            }
            else if (string.IsNullOrEmpty(model.Admin.ToString()))
            {
                return BadRequest("need to insert Admin");
            }
            Bruger bruger = new Bruger();

            bruger.FNavn = model.Fnavn;
            bruger.ENavn = model.Enavn;
            bruger.TlfNr = model.TlfNR;
            bruger.Email = model.Email;
            bruger.Password = model.Password;
            bruger.Adresse = model.Adresse;
            bruger.PostNr = model.PostNR;
            bruger.Admin = model.Admin;

            _db.Brugere.Add(bruger);
            _db.SaveChanges();

            return Ok(bruger);

        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Update(BrugerModel model)
        {
            if (string.IsNullOrEmpty(model.Fnavn))
            {
                return BadRequest("need to insert Førstenavn");
            }
            else if (string.IsNullOrEmpty(model.Enavn))
            {
                return BadRequest("need to insert Efternavn");
            }
            else if (string.IsNullOrEmpty(model.TlfNR))
            {
                return BadRequest("need to insert tlf nr");
            }
            else if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest("need to insert email");
            }
            else if (string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("need to insert password");
            }
            else if (string.IsNullOrEmpty(model.PostNR.ToString()))
            {
                return BadRequest("need to insert postNR");
            }
            else if (string.IsNullOrEmpty(model.Admin.ToString()))
            {
                return BadRequest("need to insert Admin");
            }

            var bruger = _db.Brugere.Find(model.BrugerID);

            if (bruger is null)
                return BadRequest("Incorrect Bruger ID");

            bruger.FNavn = model.Fnavn;
            bruger.ENavn = model.Enavn;
            bruger.TlfNr = model.TlfNR;
            bruger.Email = model.Email;
            bruger.Password = model.Password;
            bruger.Adresse = model.Adresse;
            bruger.PostNr = model.PostNR;
            bruger.Admin = model.Admin;

            _db.Brugere.Attach(bruger);
            _db.SaveChanges();

            return Ok(bruger);

        }

        [Route("Delete/{id}")]
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var bruger = _db.Brugere.Find(id);
            if (bruger is null)
                return BadRequest("User not found");

            _db.Brugere.Remove(bruger);
            _db.SaveChanges();

            return Ok($"{bruger.FNavn + " " + bruger.ENavn} got deleted");
        }

    }

}
