using Hospital_BB.Models;
using Hospital_BB.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Hospital_BB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepo doc;

        public DoctorsController(IDoctorsRepo doc)
        {
            this.doc = doc;
        }

        [HttpGet]
        public IEnumerable<Doctors>? Get()
        {

            return doc.GetDoctor();
        }

        [HttpGet("{DoctorId}")]
        public Doctors? DoctorbyId(int doctorid)
        {

            return doc.DoctorById(doctorid);


        }
        [HttpPost]
        public async Task<ActionResult<Doctors>> Post([FromForm] Doctors doctor, IFormFile imageFile)
        {

            try
            {
                var createdCourse = await doc.CreateDoctor(doctor, imageFile);
                return CreatedAtAction("Get", new { id = createdCourse.Doctor_Id }, createdCourse);

            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{DoctorId}")]
        public async Task<ActionResult<Doctors>> Put(int doctorid, [FromForm] Doctors doctor, IFormFile imageFile)
        {
            try
            {
                var updatedCake = await doc.UpdateDoctor(doctorid, doctor, imageFile);
                if (updatedCake == null)
                {
                    return NotFound();
                }

                return Ok(updatedCake);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }


        [HttpDelete("{DoctorId}")]
        public Doctors? DeleteDoctor(int doctorid)
        {
            return doc.DeleteDoctor(doctorid);
        }

    }
}
