using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
namespace GUI_QLBanHang
{
    public partial class frmMain : Form
    {
        BUS_NhanVien busNV = new BUS_NhanVien();
        public string email;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            menuHuongDan.Cursor = Cursors.Hand;
            menuTaiKhoan.Cursor = Cursors.Hand;

        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            QL_NhanVien fnhanvien = new QL_NhanVien();
            fnhanvien.Dock = DockStyle.Fill;
            panelControl.Controls.Add(fnhanvien);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();

            QL_KhachHang fkhachhang = new QL_KhachHang(email);
            fkhachhang.Dock = DockStyle.Fill;
            panelControl.Controls.Add(fkhachhang);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            QL_Hang fhang = new QL_Hang(email);
            fhang.Dock = DockStyle.Fill;
            panelControl.Controls.Add(fhang);
        }


        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            this.menuHuongDan.Show(pnMenu, new Point(206,456));
        }

        private void btnHuongDan_MouseHover(object sender, EventArgs e)
        {
           this.menuHuongDan.Show(pnMenu, new Point(206, 456));
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            menuTaiKhoan.Show(pnMenu, new Point(206, 405));
        }

        private void btnTaiKhoan_MouseHover(object sender, EventArgs e)
        {
            menuTaiKhoan.Show(pnMenu, new Point(206, 405));
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Đăng nhập")
            {
                using (frmDangNhap flogin = new frmDangNhap())
                {
                    flogin.ShowDialog();
                    if (flogin.getSuccess)
                    {
                        // đã đăng nhập thành công

                        email = flogin.getEmail;
                        resetValue();
                        btnLogin.Text = "Đăng xuất";
                        btnLogin.CustomImages.Image = Properties.Resources.logout;
                    }//đăng nhập không thành công thì không làm gì
                }
            }
            else
            {
                panelControl.Controls.Clear();
                resetValue(false);
                lblEmail.Text = "Đăng nhập để sử dụng";
                btnLogin.Text = "Đăng nhập";
                btnLogin.CustomImages.Image = Properties.Resources.login_64px;

            }
        }

        private void resetValue(bool isVisible = true)
        {
            lblEmail.Text = "Chào nhân viên \n" + email;
            btnNhanVien.Visible = isVisible;
            btnKhachHang.Visible = isVisible;
            btnSanPham.Visible = isVisible;
            btnThongKe.Visible = isVisible;
            btnTaiKhoan.Visible = isVisible;
            // kiểm tra vai tro | true = quản trị , false = nhân viên thường 
            if (!busNV.LayVaiTro(email))
            {
                btnNhanVien.Visible = false;
                btnThongKe.Visible = false;
            }
        }

        private void itemDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmDoiMatKhau fquenmk = new frmDoiMatKhau(email))
            {
                fquenmk.ShowDialog();
                if (fquenmk.getSuccess)
                {
                    resetValue(isVisible:false);
                    btnLogin.Text = "Đăng nhập";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Save();
                    btnLogin.PerformClick();
                }
            }

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            QL_ThongKe thongke = new QL_ThongKe();
            thongke.Dock = DockStyle.Fill;
            panelControl.Controls.Add(thongke);
        }

        private void itemThongTinNV_Click(object sender, EventArgs e)
        {
            frmThongTinNV frmThongTin = new frmThongTinNV(email);
            frmThongTin.ShowDialog();
        }

        private void itemHuongDan_Click(object sender, EventArgs e)
        {
            Process.Start("Huongdan.txt");
        }

        private void itemGioiThieu_Click(object sender, EventArgs e)
        {
            Process.Start("Gioithieu.txt");

        }
    }
}
