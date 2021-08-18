using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinaBilder.Data;
using MinaBilder.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinaBilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly MinaBilderContext _context;

        public AlbumsController(MinaBilderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return await _context.Album.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Album.FindAsync(id);
            if(album == null)
            {
                return NotFound();
            }
            return album;
        }
    }
}
