using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NisanWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace NisanWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KullanicilarController : ControllerBase
    {
        private readonly UyeContext _context;

        public KullanicilarController(UyeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uye>>> Get()
        {
            return await _context.Uyeler.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public Uye Get(int id) //* id li get geriye 1 tane ürün döner
        {
            // return  _context.Uyeler.Find(id); // find ile 1 kayıt dönme
            return  _context.Uyeler.FirstOrDefault(x=>x.Id == id); //* bir başka metot find kullanılır genelde. metodunda lambda exğression kullanarak kayır bulma.
        }
         [HttpPost]
        public Uye Post( [FromBody] Uye value)
        {
        _context.Uyeler.Add(value);
        int sonuc =_context.SaveChanges();
        // return sonuc; Geriye int dönmek istersek
        return value;
        }
        // [HttpPut("{id}")]
        [HttpPut]
        public Uye Put (int id, [FromBody] Uye value)
        {
        _context.Uyeler.Update(value);
        int sonuc =_context.SaveChanges();
        return value;
        }
         [HttpDelete("{id}")]
        public Uye Delete(int id)
        {

        var kayit = _context.Uyeler.Find(id);
        if (kayit != null)
        {
        _context.Uyeler.Remove(kayit);
        }
        int sonuc =_context.SaveChanges();
        return kayit;
        }
    }
}
