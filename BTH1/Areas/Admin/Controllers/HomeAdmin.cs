using BTH1.Models;
using BTH1.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using X.PagedList;

namespace BTH1.Areas.Admin.Controllers
{

    [Area("admin")]


    [Route("admin/homeadmin")]
    public class HomeAdmin : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();

        [Route("")]
        [Route("index")]


        public IActionResult Index()
        {
            return View();
        }
        [Route("danhsachsanpham")]
        public IActionResult DanhSachSanPham(int? page)
        {
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            int pageSize = 8;
            var lstsp = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsp, pageNumber, pageSize);
            return View(lst);
            
        }
        [Route("themsanpham")]

        public IActionResult ThemSanPham()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            return View();
        }
        [ValidateAntiForgeryToken]
        [Route("themsanpham")]
        [HttpPost]
        public IActionResult ThemSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham");
            }
            return View(sanPham);
        }
        [Route("suasanpham")]

        public IActionResult SuaSanPham(string masp)
        {
            var spedit = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");
            return View(spedit);
        }

        [Route("suasanpham")]
        [HttpPost]
        public IActionResult SuaSanPham(TDanhMucSp sanPham)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham");
            }
            return View(sanPham);
        }


        [Route("XoaSanPham")]
        public IActionResult XoaSanPham(string masp)
        {
            var listChiTiet = db.TChiTietSanPhams.Where(x => x.MaSp == masp);
            foreach (var item in listChiTiet)
            {
                if (db.TChiTietHdbs.Where(x => x.MaChiTietSp == item.MaChiTietSp) != null)
                {
                    return RedirectToAction("DanhSachSanPham");
                }
            }
            var listAnh = db.TAnhSps.Where(x => x.MaSp == masp);
            if (listAnh != null) db.RemoveRange(listAnh);
            if (listChiTiet != null) db.RemoveRange(listChiTiet);
            db.Remove(db.TDanhMucSps.Find(masp));
            db.SaveChanges();
            return RedirectToAction("DanhSachSanPham");
        }
        [Route("danhsachloaisanpham")]
        public IActionResult DanhSachLoaiSanPham()
        {

            var lstsp = db.TLoaiSps.AsNoTracking().OrderBy(x => x.MaLoai).ToList();
            
            return View(lstsp);

        }
        [Route("themloaisanpham")]

        public IActionResult ThemLoaiSanPham()
        {
            
            return View();
        }
        [ValidateAntiForgeryToken]
        [Route("themloaisanpham")]
        [HttpPost]
        public IActionResult ThemLoaiSanPham(TLoaiSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TLoaiSps.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhSachLoaiSanPham");
            }
            return View(sanPham);
        }
        [Route("sualoaisanpham")]

        public IActionResult SuaLoaiSanPham(string maloai)
        {
            var spedit = db.TLoaiSps.SingleOrDefault(x => x.MaLoai == maloai);
            return View(spedit);
        }

        [Route("sualoaisanpham")]
        [HttpPost]
        public IActionResult SuaLoaiSanPham(TLoaiSp sanPham)
        {

            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachLoaiSanPham");
            }
            return View(sanPham);
        }

    }
}
