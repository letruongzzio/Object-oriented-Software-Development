using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    
    public class NHOMHANGHOA
    {
        Entities db;
        public NHOMHANGHOA()
        {
            db = Entities.CreateEntities();
        }

        public tb_NHOMHH getItem(int idnhom)
        {
            return db.tb_NHOMHH.FirstOrDefault(x => x.IDNHOM == idnhom);
        }
        public List<tb_NHOMHH> getAll()
        {
            return db.tb_NHOMHH.ToList();
        }

        public void add(tb_NHOMHH nhh)
        {
            try
            {
                db.tb_NHOMHH.Add(nhh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu " + ex.Message);
            }
        }

        public void update(tb_NHOMHH nhh)
        {
            tb_NHOMHH _nhh = db.tb_NHOMHH.FirstOrDefault(x => x.IDNHOM == nhh.IDNHOM);
            _nhh.TENNHOM = nhh.TENNHOM;
            _nhh.DISABLED = nhh.DISABLED;
            _nhh.GHICHU = nhh.GHICHU;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu " + ex.Message);
            }

        }
        public void delete(int idnhom)
        {
            tb_NHOMHH nhh = db.tb_NHOMHH.FirstOrDefault(x => x.IDNHOM == idnhom);
            nhh.DISABLED = true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu " + ex.Message);
            }
        }
    }
}
