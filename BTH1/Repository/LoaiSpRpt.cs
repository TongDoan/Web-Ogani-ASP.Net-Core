using BTH1.Models;

namespace BTH1.Repository
{
    public class LoaiSpRpt : IloaiSpRpt
    {
        private readonly QlbanVaLiContext _context;

        public LoaiSpRpt(QlbanVaLiContext context)
        {
            _context = context;
        }

        
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            throw new NotImplementedException();
        }

        public TLoaiSp Delete(string maloai)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoai(string maloai)
        {
            throw new NotImplementedException();
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            throw new NotImplementedException();
        }

        
    }
}
