using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class DONVI
    {
        Entities db;

        public DONVI()
        {
            db = Entities.CreateEntities();
        }

        public tb_DONVI getItem(string madvi)
        {
            return db.tb_DONVI.FirstOrDefault(x => x.MADVI == madvi);
        }

        public List<tb_DONVI> getAll(string macty)
        {
            return db.tb_DONVI.Where(x => x.MACTY == macty).ToList();
        }

        public void add(tb_DONVI dvi)
        {
            try
            {
                db.tb_DONVI.Add(dvi);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu " + ex.Message);
            }
        }
        public void update(tb_DONVI dvi)
        {
            tb_DONVI _dvi = db.tb_DONVI.FirstOrDefault(x => x.MADVI == dvi.MADVI);
            _dvi.MACTY = dvi.MACTY;
            _dvi.TENDVI = dvi.TENDVI;
            _dvi.DIENTHOAI = dvi.DIENTHOAI;
            _dvi.FAX = dvi.FAX;
            _dvi.EMAIL = dvi.EMAIL;
            _dvi.DIACHI = dvi.DIACHI;
            _dvi.DISABLED = dvi.DISABLED;
            _dvi.KHO = dvi.KHO;
            _dvi.KYHIEU = dvi.KYHIEU;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void delete(string madvi)
        {
            tb_DONVI _dvi = db.tb_DONVI.FirstOrDefault(x => x.MADVI == madvi);
            _dvi.DISABLED = true;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
