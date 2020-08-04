using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Person.API.DTO;
using Person.API.Models;

namespace Person.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class KisilerController : ControllerBase
    {
        private readonly KisiContext _context;

        public KisilerController(KisiContext context)
        {
            _context = context;
        }

        // GET: api/Kisiler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kisi>>> GetKisiler()
        {
            return await _context.Kisiler.Include( s => s.PersonelBilgi).ToListAsync();
        }

    


        // GET: api/Kisiler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonelDTO>> GetKisi(int id)
        {

            PersonelDTO kisi = await _context.Kisiler
                       .Select(x => new PersonelDTO() { Id = x.Id, Ad = x.Ad, Soyad = x.Soyad, GirisTarihi = x.PersonelBilgi.GirisTarihi, CikisTarihi = x.PersonelBilgi.CikisTarihi })
                       .SingleOrDefaultAsync(x => x.Id == id);

            if (kisi == null)
                return NotFound("İstenilen personel bulunamadı");
            return Ok(kisi);
        }

        // PUT: api/Kisiler/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKisi(int id, Kisi kisi)
        {
            if (id != kisi.Id)
            {
                return BadRequest();
            }

            _context.Entry(kisi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KisiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Kisiler
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kisi>> PostKisi(Kisi kisi)
        {
            _context.Kisiler.Add(kisi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKisi", new { id = kisi.Id }, kisi);
        }

        // DELETE: api/Kisiler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kisi>> DeleteKisi(int id)
        {
            var kisi = await _context.Kisiler.FindAsync(id);
            if (kisi == null)
            {
                return NotFound();
            }

            _context.Kisiler.Remove(kisi);
            await _context.SaveChangesAsync();

            return kisi;
        }

        private bool KisiExists(int id)
        {
            return _context.Kisiler.Any(e => e.Id == id);
        }
    }
}
