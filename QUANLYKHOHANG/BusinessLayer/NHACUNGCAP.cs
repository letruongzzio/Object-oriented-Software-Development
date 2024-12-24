using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class NHACUNGCAP
    {
        Entities db;

        public NHACUNGCAP()
        {
            db = Entities.CreateEntities();
        }

        public tb_NHACUNGCAP getItem(int mancc)
        {
            return db.tb_NHACUNGCAP.FirstOrDefault(x => x.MANCC == mancc);
        }

        public List<tb_NHACUNGCAP> getAll()
        {
            return db.tb_NHACUNGCAP.ToList();
        }

        public void add(tb_NHACUNGCAP ncc)
        {
            try
            {
                db.tb_NHACUNGCAP.Add(ncc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu " + ex.Message);
            }
        }

        public void update(tb_NHACUNGCAP ncc)
        {
            tb_NHACUNGCAP _ncc = db.tb_NHACUNGCAP.FirstOrDefault(x => x.MANCC == ncc.MANCC);
            _ncc.TENNCC = ncc.TENNCC;
            _ncc.DIENTHOAI = ncc.DIENTHOAI;
            _ncc.FAX = ncc.FAX;
            _ncc.EMAIL = ncc.EMAIL;
            _ncc.DIACHI = ncc.DIACHI;
            _ncc.CREATE_DATE = ncc.CREATE_DATE;
            _ncc.DISABLED = ncc.DISABLED;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void delete(int mancc)
        {
            tb_NHACUNGCAP _ncc = db.tb_NHACUNGCAP.FirstOrDefault(x => x.MANCC == mancc);
            _ncc.DISABLED = true;

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
