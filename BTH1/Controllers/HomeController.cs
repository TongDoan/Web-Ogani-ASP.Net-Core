using BTH1.Models;
using BTH1.Models.Authentication;
using BTH1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;
using X.PagedList;

namespace BTH1.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       // [Authenication]
        public IActionResult Index(int? page)
        {
            int pageNumber = page == null || page <=0 ? 1 :page.Value;
            int pageSize = 8;
            var lstsp = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsp, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult SanPhamTheoLoai(string maloai, int? page )
        {
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            int pageSize = 8;
            var lst = db.TDanhMucSps.Where(x => x.MaLoai == maloai).AsNoTracking();
            PagedList<TDanhMucSp> lstsp = new PagedList<TDanhMucSp>(lst, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lstsp);
        }
        //Dùng ViewBag
        public IActionResult ChiTietSanPham(string masp)
        {
            TDanhMucSp sp = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
            var lstanh = db.TAnhSps.Where(x => x.MaSp == masp).ToList();
            ViewBag.lstAnhSP = lstanh;
            return View(sp);
        }
        //Dùng ViewComponent
        public IActionResult ProductDetail(string masp)
        {
            var sp = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
            var anh = db.TAnhSps.Where((x) => x.MaSp == masp).AsNoTracking().ToList();
            var sps = new HomeProductDetialViewModel(sp, anh);
            if (sp == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(sps);
            }

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}