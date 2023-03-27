using BTH1.Models;

namespace BTH1.ViewModels
{
    public class HomeProductDetialViewModel 
    {
        private TDanhMucSp sp;
        private List<TAnhSp> anhsp;
        public HomeProductDetialViewModel(TDanhMucSp sp, List<TAnhSp> anhsp)
        {
            this.Sp = sp;
            this.Anhsp = anhsp;
        }

        public List<TAnhSp> Anhsp { get => anhsp; set => anhsp = value; }
        public TDanhMucSp Sp { get => sp; set => sp = value; }
    }
}
