using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
//using BLL_DAL;
namespace GUI
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //Xuly xl = new Xuly();
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(SkinsLink);

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(Themes, true, true);
        }
        public void ViewChildForm(Form _form)
        {
            if (!IsFormActive(_form))
            {
                _form.MdiParent = this;
                _form.Show();
            }
        }
        public bool IsFormActive(Form form)
        {
            bool Isopend = false;   
            if(MdiChildren.Count()>0)
            {
                foreach (var item in MdiChildren)
                {
                    if(form.Name == item.Name)
                    {
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        Isopend = true;
                    }
                    
                }
            }
            return Isopend;
        }
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmThemKT frm = new FrmThemKT();
            frm.ShowDialog();
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDanhSachKhachTro frm = new FrmDanhSachKhachTro();
            frm.Name = "Danh sách khách trọ";
            ViewChildForm(frm);
        }
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Lưu thành công!");
        }
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmXoaKT frm = new FrmXoaKT();
            frm.ShowDialog();
        }
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSuaKT frm = new FrmSuaKT();
            frm.ShowDialog();
        }
        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDanhSachPhong frm = new FrmDanhSachPhong();
            ViewChildForm(frm);
        }
        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLP frm = new FrmLP();
            frm.ShowDialog();
        }
        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmThemPhong frm = new FrmThemPhong();
            frm.ShowDialog();
        }
        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MessageBox.Show("Lưu ý khi muốn xóa phòng phải xóa hết tất cả thiết bị ở trong phòng mới được phép xóa phòng");
            //FrmXoaPhong frm = new FrmXoaPhong();
            //frm.ShowDialog();
        }
        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSuaPhong frm = new FrmSuaPhong();
            frm.ShowDialog();
        }
        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmThietBị frm = new FrmThietBị();
            frm.ShowDialog();
        }
        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPhongThietbi frm = new FrmPhongThietbi();
            ViewChildForm(frm);
        }
        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPhieuThue frm = new FrmPhieuThue();
            ViewChildForm(frm);
        }
        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDichVu frm = new FrmDichVu();
            frm.ShowDialog();
        }
        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmThueTro frm = new FrmThueTro();
            ViewChildForm(frm);
        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDangKyDichVu frm = new FrmDangKyDichVu();
            ViewChildForm(frm);
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm frm = new Frm();
            ViewChildForm(frm);
        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmThanhToan frm = new FrmThanhToan();
            ViewChildForm(frm);
        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem52_ItemClick(object sender, ItemClickEventArgs e)
        {
            
           
        }

        private void barButtonItem50_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            try
            {
                FrmDoanhThuTungNam frm = new FrmDoanhThuTungNam();
                frm.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi");
            }
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmDoanThuThang frm = new FrmDoanThuThang();
                frm.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi");
            }
        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBaoCao frm = new FrmBaoCao();
            frm.Show();
        }
    }
}