using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL_DAL;
namespace GUI
{
    public partial class FrmDoanThuThang : Form
    {
        Xuly xl = new Xuly();
        public FrmDoanThuThang()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void FrmDoanThuThang_Load(object sender, EventArgs e)
        {
            chart1.DataSource = xl.LoadDanhThuThang(DateTime.Now.Year);
            if (chart1.DataSource != null)
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Tổng tiền";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";

                chart1.Series["Series1"].XValueMember = "mtn";
                chart1.Series["Series1"].YValueMembers = "tongtien";
            }
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            chart1.DataSource = xl.LoadDanhThuThang(int.Parse(dateTimePicker1.Value.Year.ToString()));
            if (chart1.DataSource != null)
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Tổng tiền";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";

                chart1.Series["Series1"].XValueMember = "mtn";
                chart1.Series["Series1"].YValueMembers = "tongtien";
            }
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }
    }
}
