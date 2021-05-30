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
    public partial class FrmDanhSachPhong : Form
    {
        Xuly xl = new Xuly();
        public FrmDanhSachPhong()
        {
            InitializeComponent();
        }

        private void phong1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phong 1");
        }

        private void phong3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phong 2");
        }


        private void FrmDanhSachPhong_Load(object sender, EventArgs e)
        {
            textEdit1.ReadOnly = true;
            comboBoxEdit1.ReadOnly = true;
            textEdit2.ReadOnly = true;
            textEdit3.ReadOnly = true;
            comboBoxEdit2.ReadOnly = true;
            DynamicUserControls();
            foreach (PHONGTRO item in xl.LoadPT())
            {
                TreeNode node = new TreeNode(item.TENPHONG);
                treeView1.Nodes.Add(node);
            }
        }
        //Tải control từ sql lên gui
        private void DynamicUserControls()
        {
            flowLayoutPanel1.Controls.Clear();

            int soluong = xl.CountPhong();
            Phong[] phongs = new Phong[soluong];
            //List<PHONGTRO> phongtro = new List<PHONGTRO>();
            //phongtro = xl.LoadPT();


            //string[] tenphong = new string[20] { "Phòng 1", "Phòng 2 ", "Phòng 3", "Phòng 4", "Phòng 5", "Phòng 1", "Phòng 2 ", "Phòng 3", "Phòng 4", "Phòng 5", "Phòng 1", "Phòng 2 ", "Phòng 3", "Phòng 4", "Phòng 5", "Phòng 1", "Phòng 2 ", "Phòng 3", "Phòng 4", "Phòng 5" };
            for (int i = 0; i < phongs.Length; i++)
            {
                phongs[i] = new Phong();
                phongs[i].MaPhong = xl.LoadPT()[i].MAPT.ToString();
                phongs[i].MaLP = xl.LoadPT()[i].MALP.ToString();
                phongs[i].TenPhong = xl.LoadPT()[i].TENPHONG;
                phongs[i].SLHT = xl.LoadPT()[i].SONGUOIHIENTAI.ToString();
                phongs[i].SLTD = xl.LoadPT()[i].SLTOIDA.ToString();
                phongs[i].TrangThai = xl.LoadPT()[i].TRANGTHAI;
                flowLayoutPanel1.Controls.Add(phongs[i]);
                phongs[i].Click += new System.EventHandler(this.Phong_Click);
            }                   
        }
        private void Phong_Click(object sender, EventArgs e)
        {
            Phong obj = (Phong)sender;
            textEdit1.Text = obj.TenPhong;
            comboBoxEdit1.Text = xl.TenLoai(int.Parse(obj.MaLP));
            textEdit2.Text = obj.SLTD;
            textEdit3.Text = obj.SLHT;
            comboBoxEdit2.Text = obj.TrangThai;
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DynamicUserControls();
        }

        private void textEdit4_KeyPress(object sender, KeyPressEventArgs e)
        {
        }


    }
}
