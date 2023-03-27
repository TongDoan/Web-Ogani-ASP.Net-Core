using BTH1.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BTH1.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private IloaiSpRpt _iloaiSpRpt;

        public LoaiSpMenuViewComponent(IloaiSpRpt iloaiSpRpt)
        {
            _iloaiSpRpt = iloaiSpRpt;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _iloaiSpRpt.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
