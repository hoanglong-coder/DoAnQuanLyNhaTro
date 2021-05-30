using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
namespace GUI
{
    public partial class FrmThemKT : Form
    {
        Xuly xl = new Xuly();
        public FrmThemKT()
        {
            InitializeComponent();
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename;
                filename = dlg.FileName;
                buttonEdit1.Text = filename;
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
                try
                {
                    xl.ThemKTV2(dateTimePicker1.Value, textEdit1.Text, textEdit2.Text, comboBox1.Text, textEdit3.Text, textEdit4.Text, textEdit5.Text, false, buttonEdit1.Text);
                    MessageBox.Show("Thêm thành công");
                    XoaText();
                }
                catch (Exception)
                {

                    MessageBox.Show("Thêm thất bại");
                }                 

        }

        //Không cho nhập chữ số vào họ tên
        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == 8) || Char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true;
        }
        //Không cho nhập chữ vào CMND/CCCD
        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;             
            }
        }
        //Không cho nhập chữ vào số điện thoại
        private void textEdit5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Làm mới lại textbox khi thêm thành công;
        public void XoaText()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            comboBox1.SelectedItem = -1;
            buttonEdit1.Text = "";
        }

        private void FrmThemKT_Load(object sender, EventArgs e)
        {

        }


       
    }
}
