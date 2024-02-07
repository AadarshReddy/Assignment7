using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCRUD.Models;

namespace WebAppCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        static List<Movie> list = new List<Movie>()
       {
           new Movie{id=1,MName="Pokiri",StarCast="Mahesh Babu",Director="Puri",ReleaseDate= new DateTime(day:23,month:12,year:2012) },
           new Movie{id=2,MName="Kaleja",StarCast="Mahesh Babu",Director="Trivikram",ReleaseDate= new DateTime(day:23,month:12,year:2024) }
       };
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            Movie mov = list.SingleOrDefault(x => x.id == id);
            if (mov == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mov);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Movie> Delete(int id)
        {
            Movie mov = list.SingleOrDefault(x => x.id == id);
            if (mov == null)
            {
                return NotFound();
            }
            else
            {
                list.Remove(mov);
                return NoContent();
            }
        }
        [HttpPost]
        public ActionResult<Movie> Post(Movie newMov)
        {
            list.Add(newMov);
            return CreatedAtAction(nameof(Get), newMov);
        }
        [HttpPut("{id}")]
        public ActionResult<Movie> Put(int id, Movie UpMov)
        {
            Movie extMov = list.SingleOrDefault(x => x.id == id);
            if (extMov == null)
            {
                return NotFound();
            }
            else
            {
               

                extMov.MName = UpMov.MName;
                extMov.StarCast = UpMov.StarCast;
                extMov.Director = UpMov.Director;
                extMov.ReleaseDate = UpMov.ReleaseDate;

                return NoContent();
            }
        }
    }
}
