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
    public partial class FrmSuaPhong : Form
    {
        Xuly xl = new Xuly();
        public FrmSuaPhong()
        {
            InitializeComponent();
        }

        private void FrmSuaPhong_Load(object sender, EventArgs e)
        {
            //comboBox1.Enabled = false;
            textEdit3.ReadOnly = true;
            textEdit4.ReadOnly = true;
            dataGridView1.DataSource = xl.LoadPTNew();
            comboBox1.DataSource = xl.LoadLP();
            comboBox1.DisplayMember = "TENLOAIPHONG";
            comboBox1.ValueMember = "MALP";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Selected == true)
                {
                    comboBox1.SelectedValue = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    textEdit1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textEdit4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textEdit3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
            }
            catch (Exception)
            {
              
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xl.SuaPhong(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()),int.Parse( comboBox1.SelectedValue.ToString()), textEdit1.Text, int.Parse(comboBox2.Text));
            dataGridView1.DataSource = xl.LoadPTNew();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
