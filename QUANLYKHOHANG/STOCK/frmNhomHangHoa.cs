using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;

namespace STOCK
{
    public partial class frmNhomHangHoa : DevExpress.XtraEditors.XtraForm
    {
        public frmNhomHangHoa()
        {
            InitializeComponent();
        }

        NHOMHANGHOA _nhomhh;
        bool _them;
        int _idnhom;

        void loadData()
        {
            gcDanhSach.DataSource = _nhomhh.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }

        void _enabled(bool t)
        {
            txtTen.Enabled = t;
            chkDisabled.Enabled = t;
            txtGhiChu.Enabled = t;
        }

        void _reset()
        {
            txtTen.Text = "";
            txtGhiChu.Text = "";
            chkDisabled.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nhomhh.delete(_idnhom);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_NHOMHH nhomhh = new tb_NHOMHH();
                nhomhh.TENNHOM = txtTen.Text;
                nhomhh.GHICHU = txtGhiChu.Text;
                nhomhh.DISABLED = chkDisabled.Checked;
                _nhomhh.add(nhomhh);
            }
            else
            {
                tb_NHOMHH nhomhh = _nhomhh.getItem(_idnhom);
                nhomhh.TENNHOM = txtTen.Text;
                nhomhh.GHICHU = txtGhiChu.Text;
                nhomhh.DISABLED = chkDisabled.Checked;
                _nhomhh.add(nhomhh);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idnhom = gvDanhSach.GetFocusedRowCellValue("IDNHOM").GetHashCode();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENNHOM").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GHICHU").ToString();
                chkDisabled.Checked = Convert.ToBoolean(gvDanhSach.GetFocusedRowCellValue("DISABLED"));
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.del_icon_x;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }

        private void frmNhomHangHoa_Load(object sender, EventArgs e)
        {
            _nhomhh = new NHOMHANGHOA();
            loadData();
            showHideControl(true);
            _enabled(false);
        }
    }
}