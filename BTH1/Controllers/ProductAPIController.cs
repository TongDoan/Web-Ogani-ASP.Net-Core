using BTH1.Models;
using BTH1.Models.APIModels;
using Microsoft.AspNetCore.Mvc;

namespace BTH1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
       
      QlbanVaLiContext db = new QlbanVaLiContext();
        public IEnumerable<Product> GetAllSP()
        {
            var sanPham = (from p in db.TDanhMucSps
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;

        }
        [HttpGet("{maloai}")]

         public IEnumerable<Product> showProductByCategor(string maloai)
        {
            var sanPham = (from p in db.TDanhMucSps where p.MaLoai == maloai 
                           select new Product
                           {
                               MaSp=p.MaSp,
                               TenSp=p.TenSp,
                               MaLoai=p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
        }        
        
    }
}
