using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
namespace GUI_QLBanHang
{
    public partial class frmDoiMatKhau : Form
    {


        public frmDoiMatKhau(string email)
        {
            InitializeComponent();
            txtEmail.Text = email;
        }

        private bool isSuccess = false;

        public bool getSuccess
        {
            get { return isSuccess; }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text != "")
            {
                if (txtMatKhauMoi.Text == txtMatKhauMoi2.Text)
                {
                    BUS_NhanVien nv = new BUS_NhanVien();
                    if (nv.QuenMatKhau(txtEmail.Text, txtMatKhauCu.Text, txtMatKhauMoi.Text))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isSuccess = true;
                        Close();
                    }
                    else MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
