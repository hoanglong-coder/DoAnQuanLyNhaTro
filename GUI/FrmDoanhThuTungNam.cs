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
    public partial class FrmDoanhThuTungNam : Form
    {
        Xuly xl = new Xuly();
        public FrmDoanhThuTungNam()
        {
            InitializeComponent();
        }

        private void FrmDoanhThuTungNam_Load(object sender, EventArgs e)
        {
            chart1.DataSource = xl.LoadDoanhThuTungNam();
            if (chart1.DataSource != null)
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Tổng tiền";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Năm";

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
