using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibraryWebAPI.Data;
using MusicLibraryWebAPI.Migrations;
using MusicLibraryWebAPI.Models;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET All api/<MusicLibraries>     #1
        [HttpGet]
        public IActionResult Get()
        {
            var songs = _context.MusicLibraries.ToList();
            return Ok(songs);
        }

        // GET api/<MusicLibraries>/5      #2
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _context.MusicLibraries.Find(id);

                if (song == null)
                {
                return NotFound();
                }
            return Ok(song);
        }

        // POST api/<MusicLibrariesController>       #3
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _context.MusicLibraries.Add(song);
            _context.SaveChanges();
            return StatusCode(201, song);
        }

        // PUT api/<MusicLibrariesController>/5        #4
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song song)
        {
            var updatedSong = _context.MusicLibraries.Find(id);

            if(updatedSong == null)
            {
                return NotFound();
            }
            updatedSong.Title = song.Title;
            updatedSong.Artist = song.Artist;
            updatedSong.Album = song.Album;
            updatedSong.ReleaseDate = song.ReleaseDate;
            updatedSong.Genre = song.Genre;

            _context.SaveChanges();
            return Ok(song); 
        }

        // DELETE api/<MusicLibrariesController>/5        #5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = _context.MusicLibraries.Find(id);
            if(song == null)
            {
                return NotFound();
            }
            _context.MusicLibraries.Remove(song);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
