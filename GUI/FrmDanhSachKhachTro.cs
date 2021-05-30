using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress;
using BLL_DAL;
namespace GUI
{
    public partial class FrmDanhSachKhachTro : Form
    {
        Xuly xl = new Xuly();
        public FrmDanhSachKhachTro()
        {
            InitializeComponent();
        }

        private void FrmDanhSachKhachTro_Load(object sender, EventArgs e)
        {
            ReadOnLy();
            dataGridView1.DataSource = xl.LoadKT();
            foreach (KHACHTRO item in xl.TreeKt())
            {
                TreeNode node = new TreeNode(item.HOTEN);
                treeView1.Nodes.Add(node);
            }



        }
        public void ReadOnLy()
        {
            textEdit1.ReadOnly = true;
            textEdit7.ReadOnly = true;
            textEdit8.ReadOnly = true;
            comboBoxEdit1.ReadOnly = true;
            textEdit3.ReadOnly = true;
            textEdit4.ReadOnly = true;
            textEdit5.ReadOnly = true;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Selected == true)
                {
                    textEdit1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textEdit7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboBoxEdit1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textEdit8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textEdit3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textEdit4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textEdit5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    pictureBox1.Image = new Bitmap(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadKT();
        }

        private void textEdit6_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.DataSource = xl.Timkiemkhactro(textEdit6.Text);
        }

       
    }
}
