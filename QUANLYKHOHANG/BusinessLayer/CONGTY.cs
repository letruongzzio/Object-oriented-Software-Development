using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class CONGTY
    {
        Entities db;

        public CONGTY()
        {
            db = Entities.CreateEntities();
        }

        public tb_CONGTY getItem(string macty)
        {
            return db.tb_CONGTY.FirstOrDefault(x => x.MACTY == macty);
        }
        public List<tb_CONGTY> getAll()
        {
            return db.tb_CONGTY.ToList();
        }

        public void add(tb_CONGTY ct)
        {
            try
            {
                db.tb_CONGTY.Add(ct);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu " + ex.Message);
            }
        }

        public void update(tb_CONGTY ct)
        {
            tb_CONGTY _ct = db.tb_CONGTY.FirstOrDefault(x => x.MACTY == ct.MACTY);
            _ct.TENCTY = ct.TENCTY;
            _ct.DIENTHOAI = ct.DIENTHOAI;
            _ct.FAX = ct.FAX;
            _ct.EMAIL = ct.EMAIL;
            _ct.DIACHI = ct.DIACHI;
            _ct.DISABLED = ct.DISABLED;
             //_ct.KHO = ct.KHO;
             //_ct.KYHIEU = ct.KYHIEU;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu " + ex.Message);
            }

        }
        public void delete(string macty)
        {
            tb_CONGTY ct = db.tb_CONGTY.FirstOrDefault(x => x.MACTY == macty);
            ct.DISABLED = true;
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
