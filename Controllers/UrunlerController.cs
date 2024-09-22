using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NisanWebAPI.Models;

namespace NisanWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrunlerController : ControllerBase
    {
        private readonly UyeContext _context;
        public UrunlerController(UyeContext context)
        {
            _context = context;
        }
        //*GET : api/<UrunlerController>
        [HttpGet]
        public IEnumerable<Urun>Get() //* bu metot ürün listesi döner
        {
            return _context.Urunler.ToList();
        }
//*Get api/Urunler
        [HttpGet("{id}")]
        public Urun Get(int id) //* id li get geriye 1 tane ürün döner
        {
            // return  _context.Urunler.Find(id); // find ile 1 ürün dönme
            return  _context.Urunler.FirstOrDefault(x=>x.Id == id); //* bir başka metot find kullanılır genelde. metodunda lambda exğression kullanarak kayır bulma.
        }

        //post api urunler Controller
        [HttpPost]
        public int Post( [FromBody] Urun value)
        {
        _context.Urunler.Add(value);
        int sonuc =_context.SaveChanges();
        return sonuc;
        }
        [HttpPut("{id}")]
        public int Put (int id, [FromBody] Urun value)
        {
        _context.Urunler.Update(value);
        int sonuc =_context.SaveChanges();
        return sonuc;
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {

        var kayit = _context.Urunler.Find(id);
        if (kayit != null)
        {
        _context.Remove(kayit);
        }
        int sonuc =_context.SaveChanges();
        return sonuc;
        }
    }
}