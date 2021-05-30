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
    public partial class FrmXoaKT : Form
    {
        Xuly xl = new Xuly();
        public FrmXoaKT()
        {
            InitializeComponent();
        }

        private void FrmXoaKT_Load(object sender, EventArgs e)
        {
            EnableTextbox();
            dataGridView1.DataSource = xl.LoadKT();
        }
        public void EnableTextbox()
        {
            textBox1.ReadOnly = true;
            textEdit2.ReadOnly = true;
            textEdit3.ReadOnly = true;
            textEdit4.ReadOnly = true;
            textEdit5.ReadOnly = true;
            textEdit6.ReadOnly = true;
            textEdit7.ReadOnly = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Selected == true)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textEdit2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textEdit3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textEdit4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textEdit5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textEdit6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textEdit7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }
        //Xóa khách trọ
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(!xl.XoaKhachTroCoKiemtr(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())))
            {
                MessageBox.Show("Không thể xóa khách trọ do đang có trong phiếu thuê");
                return;
            }
            xl.XoaKT(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.DataSource = xl.LoadKT();       
                           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
