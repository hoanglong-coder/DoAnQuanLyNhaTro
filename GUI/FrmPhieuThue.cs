using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using BLL_DAL;
namespace GUI
{
    public partial class FrmPhieuThue : Form
    {
        Xuly xl = new Xuly();
        public FrmPhieuThue()
        {
            InitializeComponent();
        }

        private void FrmPhieuThue_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            dataGridView3.DataSource = xl.LoadPhieuThuePhieuThuv2DangThue();
            //Thông tin phiếu thuê

            textBox1.ReadOnly = true;
            textEdit2.ReadOnly = true;
            textEdit1.ReadOnly = true;
            textEdit4.ReadOnly = true;
            textEdit3.ReadOnly = true;
            textEdit5.ReadOnly = true;

            comboBox2.DataSource = xl.LoadKT();
            comboBox2.DisplayMember = "HOTEN";
            comboBox2.ValueMember = "MAKT";
            comboBox1.DataSource = xl.LoadPTNew();
            comboBox1.DisplayMember = "TENPHONG";
            comboBox1.ValueMember = "MAPT";

            //Thông tin khách hàng
            comboBox4.DataSource = xl.LoadKT();
            comboBox4.DisplayMember = "HOTEN";
            comboBox4.ValueMember = "MAKT";
            comboBox5.DataSource = xl.LoadKT();
            comboBox5.DisplayMember = "CMND";
            comboBox5.ValueMember = "MAKT";
            comboBox6.DataSource = xl.LoadKT();
            comboBox6.DisplayMember = "GIOITINH";
            comboBox6.ValueMember = "MAKT";
            comboBox7.DataSource = xl.LoadKT();
            comboBox7.DisplayMember = "NGHENGHIEP";
            comboBox7.ValueMember = "MAKT";
            comboBox8.DataSource = xl.LoadKT();
            comboBox8.DisplayMember = "DIACHI";
            comboBox8.ValueMember = "MAKT";
            comboBox9.DataSource = xl.LoadKT();
            comboBox9.ValueMember = "MAKT";
            comboBox9.DisplayMember = "SDT";
            comboBox10.DataSource = xl.LoadKT();
            comboBox10.DisplayMember = "NGAYSINH";
            comboBox10.ValueMember = "MAKT";

            //Thông tin phòng

        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.CurrentRow != null)
                {
                    comboBox2.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    comboBox4.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    comboBox1.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                    textEdit2.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                    textBox1.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
                    comboBox5.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    comboBox6.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    comboBox7.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    comboBox8.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    comboBox9.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    comboBox10.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    textEdit1.Text = xl.TenLoaiPhong(int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()));
                    textEdit3.Text = xl.TenPhong(int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()));
                    textEdit4.Text = xl.Soluongtoida(int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()));
                    textEdit5.Text = xl.Soluonghientai(int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()));
                    dataGridView1.DataSource = xl.LoadCTTBPHONG(int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()));
                    //string mathu = xl.getMaThu(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                    //string mathutien = xl.getmathutien(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    dataGridView2.DataSource = xl.loadDvphieuthuev2(int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString()));

                    //MessageBox.Show("Mã phiếu thu" + xl.getMaThu(dataGridView3.CurrentRow.Cells[0].Value.ToString()));

                }
            }
            catch (Exception)
            {


            }
            
            
            
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                dataGridView3.DataSource = xl.LoadPhieuThuePhieuThuv2DangThue();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                dataGridView3.DataSource = xl.LoadPhieuThuePhieuThuv2NgungThue();
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            //XtraReport1 report = new XtraReport1();
            //report.DataSource = xl.loadcttphieuthu2(18);
            //report.ShowPreviewDialog();
            XtraReport2 report = new XtraReport2();
            report.DataSource = xl.InPhieuThue(int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString()));
            report.ShowPreviewDialog();
        }
    }
}
