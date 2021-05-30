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
    public partial class FrmThemPhong : Form
    {
        Xuly xl = new Xuly();
        public FrmThemPhong()
        {
            InitializeComponent();
        }

        private void FrmThemPhong_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadPTNew();
            comboBox1.DataSource = xl.LoadLP();
            comboBox1.DisplayMember = "TENLOAIPHONG";
            comboBox1.ValueMember = "MALP";
            comboBox2.SelectedIndex = 1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text=="")
            {
                MessageBox.Show("Tên không được để trống");
                return;
            }
            xl.ThemPhong(int.Parse(comboBox1.SelectedValue.ToString()), textEdit1.Text, int.Parse(comboBox2.Text));
            dataGridView1.DataSource = xl.LoadPTNew();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
