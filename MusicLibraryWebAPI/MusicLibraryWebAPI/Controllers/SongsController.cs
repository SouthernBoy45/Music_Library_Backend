﻿using Microsoft.AspNetCore.Mvc;
using MusicLibraryWebAPI.Data;
using MusicLibraryWebAPI.Models;

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
        // GET: api/<MusicLibraries>
        [HttpGet]
        public IActionResult Get()
        {
            var songs = _context.MusicLibraries.ToList();
            return Ok(songs);
        }

        // GET api/<MusicLibraries>/5
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

        // POST api/<MusicLibrariesController>
        [HttpPost]
        public IActionResult Post([FromBody] Song musicLibrary)
        {
            _context.MusicLibraries.Add(musicLibrary);
            _context.SaveChanges();
            return StatusCode(201, musicLibrary);
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