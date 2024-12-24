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
using DevExpress.Export.Xl;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;

namespace STOCK
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        SYS_FUNC _func;
        private void MainForm_Load(object sender, EventArgs e)
        {
            _func = new SYS_FUNC();
            leftMenu();
        }
        void leftMenu()
        {
            int i = 0;
            var _lsParent = _func.getParent();
            foreach (var _pr in _lsParent)
            {
                NavBarGroup navGroup = new NavBarGroup(_pr.DESCRIPTION);
                navGroup.Tag = _pr.FUNC_CODE;
                navGroup.Name = _pr.FUNC_CODE;
                navGroup.ImageOptions.LargeImageIndex = i;
                i++;
                navMain.Groups.Add(navGroup);

                var _lsChild = _func.getChild(_pr.FUNC_CODE);
                foreach (var _ch in _lsChild)
                {
                    NavBarItem navItem = new NavBarItem(_ch.DESCRIPTION);
                    navItem.Tag = _ch.FUNC_CODE;
                    navItem.Name = _ch.FUNC_CODE;
                    navItem.ImageOptions.SmallImageIndex = 0;
                    navGroup.ItemLinks.Add(navItem);
                }

                navMain.Groups[navGroup.Name].Expanded = true;
            }
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();

            // var _group = _sysGroup.getGroupByMember(_user.IDUSER);
            // var _uRight = _sysRight.getRight(_user.IDUSER, func_code);

            // if (_group != null)
            // {
            //     var _groupRight = _sysRight.getRight(_group.GROUP, func_code);
            //     if (_uRight.USER_RIGHT < _groupRight.USER_RIGHT)
            //         _uRight.USER_RIGHT = _groupRight.USER_RIGHT;
            // }

            // if (_uRight.USER_RIGHT == 0)
            // {
            //     MessageBox.Show("Không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // }
            // else
            // {
            switch (func_code)
            {
                case "CONGTY":
                    {
                        frmCongTy frm = new frmCongTy();
                        frm.ShowDialog();
                        break;
                    }
                case "DONVI":
                    {
                        frmDonVi frm = new frmDonVi();
                        frm.ShowDialog();
                        break;
                    }
                case "NHACUNGCAP":
                    {
                        frmNhaCungCap frm = new frmNhaCungCap();
                        frm.ShowDialog();
                        break;
                    }
                case "DONVITINH":
                    {
                        frmDonViTinh frm = new frmDonViTinh();
                        frm.ShowDialog();
                        break;
                    }
                case "NHOMHANGHOA":
                    {
                        frmNhomHangHoa frm = new frmNhomHangHoa();
                        frm.ShowDialog();
                        break;
                    }
                    // case "TANG":
                    // {
                    //     frmTang frm = new frmTang();
                    //     frm.ShowDialog();
                    //     break;
                    // }
                    // case "SANPHAM":
                    // {
                    //     frmSanPham frm = new frmSanPham();
                    //     frm.ShowDialog();
                    //     break;
                    // }
                    // case "LOAIPHONG":
                    // {
                    //     frmLoaiPhong frm = new frmLoaiPhong();
                    //     frm.ShowDialog();
                    //     break;
                    // }
                    // case "PHONG":
                    // {
                    //     frmPhong frm = new frmPhong();
                    //     frm.ShowDialog();
                    //     break;
                    // }
                    // case "KHACHHANG":
                    // {
                    //     frmKhachHang frm = new frmKhachHang();
                    //     frm.ShowDialog();
                    //     break;
                    // }
            }
            // }
        }
    }
}