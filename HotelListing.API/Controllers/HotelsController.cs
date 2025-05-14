using HotelListing.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : Controller
{
    private static List<Hotel> hotels = new List<Hotel>
    {
        new Hotel { Id = 1, Name = "Odalys Hotel", Address = "123 Main St", Rating = 4.5 },
        new Hotel { Id = 2, Name = "Xerox Hotel", Address = "456 Beach Rd", Rating = 4.8 }
    };
    // GET: HotelsController
    [HttpGet]
    public ActionResult<IEnumerable<Hotel>> Get()
    {
        return Ok(hotels);
    }

    // GET: HotelsController/Details/5
    [HttpGet("{id}")]
    public ActionResult<Hotel> Details(int id)
    {
        var hotel = hotels.FirstOrDefault(h => h.Id == id);
        if (hotel == null)
        {
            return NotFound();
        }

        return Ok(hotel);
    }

    // POST: HotelsController/Create
    [HttpPost]
    public ActionResult<Hotel> Create([FromBody] Hotel newHotel)
    {
        if (hotels.Any(h =>  h.Id == newHotel.Id))
        {
            return BadRequest("Hotel with this Id already exists");
        }
        hotels.Add(newHotel);
        return CreatedAtAction(nameof(Get), new { id = newHotel.Id }, newHotel);
    }

    // PUT: HotelsController/Create
    [HttpPut("{id}")]
    public ActionResult Put([FromBody]Hotel updateHotel)
    {
        var existingHotel = hotels.FirstOrDefault(h => h.Id == updateHotel.Id);
        if (existingHotel == null)
        {
            return NotFound();
        }

        existingHotel.Address = updateHotel.Address;
        existingHotel.Name = updateHotel.Name;
        existingHotel.Rating = updateHotel.Rating;

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var hotel = hotels.FirstOrDefault(h =>h.Id == id);
        if(hotel == null)
        {
            return NotFound(new { message = "We no see am"});
        }
        hotels.Remove(hotel);
        return NoContent();

    }
}
