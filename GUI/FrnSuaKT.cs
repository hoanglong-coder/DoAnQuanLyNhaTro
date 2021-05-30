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
    public partial class FrmSuaKT : Form
    {
        Xuly xl = new Xuly();
        public FrmSuaKT()
        {
            InitializeComponent();
        }

        private void FrmXoaKT_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadKT();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Selected == true)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textEdit2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString());
                    comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textEdit5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textEdit6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textEdit7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                 
                    buttonEdit1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }
        //Xóa khách trọ
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xl.SuaKT(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dateTimePicker1.Value, textBox1.Text, textEdit2.Text, comboBox2.Text, textEdit5.Text, textEdit6.Text, textEdit7.Text, buttonEdit1.Text);
            dataGridView1.DataSource = xl.LoadKT();
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
