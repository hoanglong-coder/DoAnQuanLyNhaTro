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
    public partial class FrmPhongThietbi : Form
    {
        Xuly xl = new Xuly();
        public FrmPhongThietbi()
        {
            InitializeComponent();
        }

        private void FrmPhongThietbi_Load(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            textEdit1.ReadOnly = true;
            textEdit2.ReadOnly = true;
            textEdit3.ReadOnly = true;
            textEdit4.ReadOnly = true;
            comboBox1.DataSource = xl.LoadLP();
            comboBox1.DisplayMember = "TENLOAIPHONG";
            comboBox1.ValueMember = "MALP";
            comboBox2.DataSource = xl.LoadTB();
            comboBox2.ValueMember = "MATB";
            comboBox2.DisplayMember = "TENTB";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = xl.LoadPTNew(int.Parse(comboBox1.SelectedValue.ToString()));
            }
            catch (Exception)
            {
                
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    textEdit1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textEdit2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textEdit3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textEdit4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                    string mapt = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    dataGridView2.DataSource = xl.LoadCTTB(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                }
            }
            catch (Exception)
            {

            }

           
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    comboBox2.SelectedValue = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    comboBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    comboBox4.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
             xl.ThemThietBiVaoPhong(int.Parse(textEdit2.Text),int.Parse( comboBox2.SelectedValue.ToString()), int.Parse(comboBox3.Text), comboBox4.Text);

             dataGridView2.DataSource = xl.LoadCTTB(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())); 
           
                       
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            xl.XoaThietBiTrongPhong(int.Parse(textEdit2.Text),int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()));
            dataGridView2.DataSource = xl.LoadCTTB(int.Parse(textEdit2.Text)); 
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //if (!xl.KTTB(textEdit2.Text, comboBox2.SelectedValue.ToString()))
            //{
            //    MessageBox.Show("Thiết bị sửa đã có trong phòng");
            //    return;
            //}
            xl.SuaThietBiTrongPhong(int.Parse(textEdit2.Text), int.Parse(comboBox2.SelectedValue.ToString()), int.Parse(comboBox3.Text), comboBox4.Text);
            dataGridView2.DataSource = xl.LoadCTTB(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
