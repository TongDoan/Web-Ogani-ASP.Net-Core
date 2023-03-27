using BTH1.Models;

namespace BTH1.Repository
{
    public interface IloaiSpRpt
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(string maloai);
        TLoaiSp GetLoai(string maloai);
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
