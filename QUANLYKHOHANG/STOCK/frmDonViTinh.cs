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
    public partial class frmDonViTinh : DevExpress.XtraEditors.XtraForm
    {
        public frmDonViTinh()
        {
            InitializeComponent();
        }

        DONVITINH _donvitinh;
        bool _them;
        int _id;

        void loadData()
        {
            gcDanhSach.DataSource = _donvitinh.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }

        void _enabled(bool t)
        {
            txtTen.Enabled = t;
        }

        void _reset()
        {
            txtTen.Text = "";
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_DVT dvt = new tb_DVT();
                dvt.TEN = txtTen.Text;
                _donvitinh.add(dvt);
            }
            else
            {
                tb_DVT dvt = _donvitinh.getItem(_id);
                dvt.TEN = txtTen.Text;
                _donvitinh.update(dvt);
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

        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            _donvitinh = new DONVITINH();
            loadData();
            showHideControl(true);
            _enabled(false);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = gvDanhSach.GetFocusedRowCellValue("ID").GetHashCode();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TEN").ToString();
            }
        }
    }
}