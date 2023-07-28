using Microsoft.AspNetCore.Mvc;
using MusicLibraryWebAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicLibrariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MusicLibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<MusicLibrariesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MusicLibrariesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicLibrariesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MusicLibrariesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicLibrariesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
