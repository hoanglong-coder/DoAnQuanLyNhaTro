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
    public partial class FrmLP : Form
    {
        Xuly xl = new Xuly();
        public FrmLP()
        {
            InitializeComponent();
        }

        private void FrmLP_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadLP();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Selected == true)
                {
                    textEdit1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textEdit3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text==""||textEdit3.Text=="")
            {
                MessageBox.Show("Không được để trống");
                return;
            }
            xl.ThemLP(textEdit1.Text, int.Parse(textEdit3.Text));
            dataGridView1.DataSource = xl.LoadLP();
        }

        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                xl.XoaLP(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = xl.LoadLP();
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể xóa do có phòng có loại phòng đang xóa!");
                return;
            }
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            xl.SuaLP(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), textEdit1.Text, int.Parse(textEdit3.Text));
            dataGridView1.DataSource = xl.LoadLP();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
