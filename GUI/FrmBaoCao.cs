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
    public partial class FrmBaoCao : Form
    {
        Xuly xl = new Xuly();
        public FrmBaoCao()
        {
            InitializeComponent();
        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            textEdit1.ReadOnly = true;
            textEdit2.ReadOnly = true;
            textEdit3.ReadOnly = true;
            textEdit1.Text = xl.Tongkhachtrodangthue().ToString();
            textEdit2.Text = xl.Sophongdaduocthue().ToString();
            textEdit3.Text = xl.Sophongcontrong().ToString();
            dataGridView1.DataSource = xl.LoadDanhSachHoaDonChuaThuTien();
            dataGridView3.DataSource = xl.LoadDanhSachKhachtrodangthue();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1();
            report.DataSource = xl.loadcttphieuthu2(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            report.ShowPreviewDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            rptDanhsachkhachtro report = new rptDanhsachkhachtro();
            report.DataSource = xl.LoadKT();
            report.ShowPreviewDialog();
        }
    }
}
