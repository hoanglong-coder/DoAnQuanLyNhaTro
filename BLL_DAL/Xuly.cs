using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace BLL_DAL
{
    public class Xuly
    {
        dbQuanLyNhaTroDataContext qlnt = new dbQuanLyNhaTroDataContext();

        public Xuly()
        { }

        //Xử lý Khách Trọ
        public IQueryable LoadKT()
        {
            return qlnt.KHACHTROs.Select(t => t);
        }
        public void ThemKTV2(DateTime ngaysinh, string Hoten, string cmnd, string gt, string nghenghiep, string diachi, string sdt, bool chuho, string hinh)
        {
            KHACHTRO khachtro = new KHACHTRO();
            khachtro.HOTEN = Hoten;
            khachtro.NGAYSINH = ngaysinh;
            khachtro.CMND = cmnd;
            khachtro.GIOITINH = gt;
            khachtro.NGHENGHIEP = nghenghiep;
            khachtro.DIACHI = diachi;
            khachtro.SDT = sdt;
            khachtro.CHUHO = chuho;
            khachtro.HINH = hinh;
            qlnt.KHACHTROs.InsertOnSubmit(khachtro);
            qlnt.SubmitChanges();
        }
        public bool XoaKhachTroCoKiemtr(int makt)
        {
            var kt = qlnt.PHIEUTHUEPHONGs.Where(t => t.MAKT == makt);
            if (kt.Count() != 0)
            {
                return false;
            }
            return true;
        }
        public void XoaKT(int MaKT)
        {
            var khachtro = qlnt.KHACHTROs.Where(t => t.MAKT == MaKT);
            qlnt.KHACHTROs.DeleteAllOnSubmit(khachtro);
            qlnt.SubmitChanges();

        }
        public void SuaKT(int MaKT, DateTime ngaysinh, string Hoten, string cmnd, string gt, string nghenghiep, string diachi, string sdt, string hinh)
        {
            KHACHTRO khachtro = qlnt.KHACHTROs.Single(t => t.MAKT == MaKT);
            khachtro.HOTEN = Hoten;
            khachtro.NGAYSINH = ngaysinh;
            khachtro.CMND = cmnd;
            khachtro.GIOITINH = gt;
            khachtro.NGHENGHIEP = nghenghiep;
            khachtro.DIACHI = diachi;
            khachtro.SDT = sdt;
            khachtro.HINH = hinh;
            qlnt.SubmitChanges();
        }
        public IQueryable Timkiemkhactro(string search)
        {
            var kq = qlnt.KHACHTROs.Where(t => t.HOTEN.Contains(search) || t.SDT.Contains(search) || t.CMND.Contains(search)||t.NGHENGHIEP.Contains(search)||t.DIACHI.Contains(search));
            return kq;
        }
        //Xử lý Thiết bị - Phòng
        public IQueryable LoadLP()
        {
            return qlnt.LOAIPHONGs.Select(t => t);
        }
        public void ThemLP(string TenLp, int Dongia)
        {
            LOAIPHONG loaiphong = new LOAIPHONG();
            loaiphong.TENLOAIPHONG = TenLp;
            loaiphong.DONGIA = Dongia;
            qlnt.LOAIPHONGs.InsertOnSubmit(loaiphong);
            qlnt.SubmitChanges();
        }
        public void XoaLP(int Malp)
        {
            var loaiphong = qlnt.LOAIPHONGs.Where(t => t.MALP == Malp);
            qlnt.LOAIPHONGs.DeleteAllOnSubmit(loaiphong);
            qlnt.SubmitChanges();
        }
        public void SuaLP(int Malp, string TenLp, int Dongia)
        {
            LOAIPHONG loaiphong = qlnt.LOAIPHONGs.Single(t => t.MALP == Malp);
            loaiphong.TENLOAIPHONG = TenLp;
            loaiphong.DONGIA = Dongia;
            qlnt.SubmitChanges();
        }
        public IQueryable LoadTB()
        {
            return qlnt.THIETBIs.Select(t => t);
        }
        public bool KTTRUNGTB(string tentb, string nhanhieu, int gia)
        {
            var thietbi = qlnt.THIETBIs.Where(t => t.TENTB == tentb && t.NHANHIEU == nhanhieu && t.GIA == gia);
            if (thietbi.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public void ThemTB(string tenthietbi, string nhanhieu, int gia)
        {
            THIETBI thietbi = new THIETBI();
            thietbi.TENTB = tenthietbi;
            thietbi.NHANHIEU = nhanhieu;
            thietbi.GIA = gia;
            qlnt.THIETBIs.InsertOnSubmit(thietbi);
            qlnt.SubmitChanges();
        }
        public void XoaTB(int mathietbi)
        {
            var thietbi = qlnt.THIETBIs.Where(t => t.MATB == mathietbi);
            qlnt.THIETBIs.DeleteAllOnSubmit(thietbi);
            qlnt.SubmitChanges();
        }
        public void SuaTB(int mathietbi, string tenthietbi, string nhanhieu, int gia)
        {
            THIETBI thietbi = qlnt.THIETBIs.Single(t => t.MATB == mathietbi);
            thietbi.TENTB = tenthietbi;
            thietbi.NHANHIEU = nhanhieu;
            thietbi.GIA = gia;
            qlnt.SubmitChanges();
        }
        public IQueryable LoadPTNew()
        {
            var kq = from t in qlnt.PHONGTROs
                     select new {MAPT=t.MAPT,MALP=t.MALP,TRANGTHAI=t.TRANGTHAI,TENPHONG=t.TENPHONG,SLTOIDA=t.SLTOIDA,SONGUOIHIENTAI=t.SONGUOIHIENTAI };


            return kq;
        }
        public void ThemPhong(int malp, string tenphong, int sltd)
        {
            PHONGTRO phongtro = new PHONGTRO();
            phongtro.MALP = malp;
            phongtro.TENPHONG = tenphong;
            phongtro.SLTOIDA = sltd;
            phongtro.SONGUOIHIENTAI = 0;
            phongtro.TRANGTHAI = "Chưa cho thuê";
            qlnt.PHONGTROs.InsertOnSubmit(phongtro);
            qlnt.SubmitChanges();
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

        }
        public int CountPhong()
        {
            return qlnt.PHONGTROs.Count();
        }
        public List<PHONGTRO> LoadPT()
        {
            return qlnt.PHONGTROs.Select(t => t).ToList();
        }
        public List<KHACHTRO> TreeKt()
        {
            var data = qlnt.KHACHTROs.Where(t => t.CHUHO == true).ToList();
            return data;
        }

        public string TenLoai(int MaLoai)
        {
            var tenloai = qlnt.LOAIPHONGs.Single(t => t.MALP == MaLoai).TENLOAIPHONG;
            return tenloai.ToString();
        }
        public void SuaPhong(int maphong, int malp, string tenphong, int sltd)
        {
            PHONGTRO phong = qlnt.PHONGTROs.Single(t => t.MAPT == maphong && t.MALP == malp);
            phong.TENPHONG = tenphong;
            phong.SLTOIDA = sltd;
            qlnt.SubmitChanges();
        }
        public IQueryable LoadPTNew(int malp)
        {
            var phong = from u in qlnt.PHONGTROs
                        where u.MALP == malp
                        select new { MAPT = u.MAPT, MALP = u.MALP, TENPHONG = u.TENPHONG, SLTOIDA = u.SLTOIDA, TRANGTHAI = u.TRANGTHAI, SONGUOIHIENTAI = u.SONGUOIHIENTAI };

            return phong;
        }
        public IQueryable LoadCTTB(int mapt)
        {
            var cctb = from u in qlnt.CTTHIETBIs
                       from t in qlnt.THIETBIs
                       where u.MATB == t.MATB && u.MAPT == mapt
                       select new { MATB = u.MATB, TENTB = t.TENTB, SOLUONG = u.SOLUONG, TINHTRANG = u.TINHTRANG };
            return cctb;
        }
        public bool KTTB(int mapt, int matb)
        {
            var thietbi = qlnt.CTTHIETBIs.Where(t => t.MAPT == mapt && t.MATB == matb);
            if (thietbi.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public void ThemThietBiVaoPhong(int mapt, int matb, int soluong, string tinhtrang)
        {
            if (!KTTB(mapt, matb))
            {
                MessageBox.Show("Thiết bị đã có trong phòng!");
                return;
            }
            CTTHIETBI cttb = new CTTHIETBI();
            cttb.MAPT = mapt;
            cttb.MATB = matb;
            cttb.SOLUONG = soluong;
            cttb.TINHTRANG = tinhtrang;
            qlnt.CTTHIETBIs.InsertOnSubmit(cttb);
            qlnt.SubmitChanges();
        }
        public void XoaThietBiTrongPhong(int mapt, int matb)
        {
            var thietbi = qlnt.CTTHIETBIs.Where(t => t.MAPT == mapt && t.MATB == matb);
            qlnt.CTTHIETBIs.DeleteAllOnSubmit(thietbi);
            qlnt.SubmitChanges();

        }
        public void SuaThietBiTrongPhong(int mapt, int matb, int soluong, string tinhtrang)
        {
            CTTHIETBI cctb = qlnt.CTTHIETBIs.Single(t => t.MAPT == mapt && t.MATB == matb);
            cctb.MATB = matb;
            cctb.SOLUONG = soluong;
            cctb.TINHTRANG = tinhtrang;
            qlnt.SubmitChanges();
        }


        //Xử lý Dịch vụ
        public IQueryable LoadDV()
        {
            var dichvu = from u in qlnt.DICHVUs
                         select new { MADV = u.MADV, TENDV = u.TENDV, DONGIA = u.DONGIA, DONVITINH = u.DONVITINH, TRANGTHAI = u.TRANGTHAI };
            return dichvu;
        }
        public bool KTDV(string ten)
        {
            var tendv = from u in qlnt.DICHVUs
                        where u.TENDV == ten
                        select u;

            if (tendv.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public void ThemDV(string tendv, int dg, string dvt)
        {
            if (!KTDV(tendv))
            {
                MessageBox.Show("Dịch vụ này đã có!");
                return;
            }
            DICHVU dv = new DICHVU();
            dv.TENDV = tendv;
            dv.DONGIA = dg;
            dv.DONVITINH = dvt;
            dv.TRANGTHAI = "False";
            qlnt.DICHVUs.InsertOnSubmit(dv);
            qlnt.SubmitChanges();
        }
        public bool KTMADV(int madv)
        {
            var dv = from u in qlnt.CTPHIEUTHUs
                     where u.MADV == madv
                     select u;

            if (dv.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public bool KTDVDIENNUOC(int madv)
        {
            var dv = from u in qlnt.DICHVUs
                     where u.MADV == madv && u.TRANGTHAI == "True"
                     select u;

            if (dv.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public void XoaDV(int madv)
        {
            if (!KTDVDIENNUOC(madv))
            {
                MessageBox.Show("Điện và nước không thể xóa!!");
                return;
            }
            if (!KTMADV(madv))
            {
                MessageBox.Show("Không thể xóa dịch vụ này!!");
                return;
            }
            var dv = qlnt.DICHVUs.Where(t => t.MADV == madv);
            qlnt.DICHVUs.DeleteAllOnSubmit(dv);
            qlnt.SubmitChanges();
        }
        public void SuaDV(int madv, int dg, string dvt)
        {
            DICHVU dv = qlnt.DICHVUs.Single(t => t.MADV == madv);
            dv.DONGIA = dg;
            dv.DONVITINH = dvt;
            qlnt.SubmitChanges();
        }

        //Xử lý Thuê trọ
        public int CountDV()
        {
            return qlnt.DICHVUs.Count();
        }
        public List<DICHVU> LoadCheckdv()
        {
            return qlnt.DICHVUs.Where(t => t.TRANGTHAI == "False").ToList();
        }
        public IQueryable loadkt()
        {
            var kt = (from u in qlnt.PHIEUTHUEPHONGs select u.MAKT).ToList();
            var rs = from c in qlnt.KHACHTROs where !kt.Contains(c.MAKT) select c;
            return rs;
        }
        public KHACHTRO khachtro(int makt)
        {
            KHACHTRO kt = new KHACHTRO();
            kt.HOTEN = qlnt.KHACHTROs.Single(t => t.MAKT == makt).HOTEN;
            kt.CMND = qlnt.KHACHTROs.Single(t => t.MAKT == makt).CMND;
            kt.NGAYSINH = qlnt.KHACHTROs.Single(t => t.MAKT == makt).NGAYSINH;
            kt.GIOITINH = qlnt.KHACHTROs.Single(t => t.MAKT == makt).GIOITINH;
            kt.NGHENGHIEP = qlnt.KHACHTROs.Single(t => t.MAKT == makt).NGHENGHIEP;
            kt.DIACHI = qlnt.KHACHTROs.Single(t => t.MAKT == makt).DIACHI;
            kt.SDT = qlnt.KHACHTROs.Single(t => t.MAKT == makt).SDT;
            kt.HINH = qlnt.KHACHTROs.Single(t => t.MAKT == makt).HINH;
            return kt;
        }
        public IQueryable LoadMutilPT2(int malp)
        {
            var pt = from u in qlnt.LOAIPHONGs
                     from t in qlnt.PHONGTROs
                     where u.MALP == t.MALP && t.MALP == malp && t.TRANGTHAI == "Chưa cho thuê"
                     select new
                     {
                         MAPT = t.MAPT,
                         TENPT = t.TENPHONG,
                         SLTD = t.SLTOIDA,
                         SLHT = t.SONGUOIHIENTAI,
                         DONGIA = u.DONGIA,
                         TRANGTHAI = t.TRANGTHAI
                     };
            return pt;
        }
        public IQueryable LoadMutilPT1(int malp)
        {
            var pt = from u in qlnt.LOAIPHONGs
                     from t in qlnt.PHONGTROs
                     where u.MALP == t.MALP && t.MALP == malp && t.TRANGTHAI == "Đã cho thuê"
                     select new
                     {
                         MAPT = t.MAPT,
                         TENPT = t.TENPHONG,
                         SLTD = t.SLTOIDA,
                         SLHT = t.SONGUOIHIENTAI,
                         DONGIA = u.DONGIA,
                         TRANGTHAI = t.TRANGTHAI
                     };
            return pt;
        }
        public IQueryable LoadMutilPTTB(int maphongtro)
        {
            var tb = from t in qlnt.CTTHIETBIs
                     from u in qlnt.THIETBIs
                     where t.MATB == u.MATB && t.MAPT == maphongtro
                     select new { MATB = t.MATB, TENTB = u.TENTB, SL = t.SOLUONG, TT = t.TINHTRANG };
            return tb;
        }
        public bool KiemTraDichVuChinh(int Madv)
        {
            //var dv = qlnt.DICHVUs.Where(t => t.MADV == Madv && t.TRANGTHAI == "False");
            var dv = qlnt.DICHVUs.Where(t => t.MADV == Madv && t.TRANGTHAI == "False");
            if (dv.Count() != 0)
            {
                return true;
            }
            return false;
        }
        public int getMadv(string ten)
        {
            return qlnt.DICHVUs.Single(t=>t.TENDV==ten).MADV;
        }
        public void ThemDichVuDienNuoc(string tendv)
        {
            CTPHIEUTHU ccpt = new CTPHIEUTHU();
            ccpt.MATHU = qlnt.PHIEUTHUTIENs.Select(t => t).OrderByDescending(e => e.MATHU).FirstOrDefault().MATHU;
            ccpt.MADV = getMadv(tendv);
            if (KiemTraDichVuChinh(getMadv(tendv)))
            {
                ccpt.THANHTIEN = qlnt.DICHVUs.Where(t => t.MADV == getMadv(tendv)).Single().DONGIA;
            }
            qlnt.CTPHIEUTHUs.InsertOnSubmit(ccpt);
            qlnt.SubmitChanges();
            
        }
        public void ThemCTPHIEUTHU(int madv)
        {
            CTPHIEUTHU ccpt = new CTPHIEUTHU();
            ccpt.MATHU = qlnt.PHIEUTHUTIENs.Select(t => t).OrderByDescending(e => e.MAPHIEUTHUE).FirstOrDefault().MATHU;
            ccpt.MADV = madv;
            if (KiemTraDichVuChinh(madv))
            {
                ccpt.THANHTIEN = qlnt.DICHVUs.Where(t => t.MADV == madv).Single().DONGIA;
            }
            qlnt.CTPHIEUTHUs.InsertOnSubmit(ccpt);
            qlnt.SubmitChanges();
        }
        public bool KTSOLUONGTOIDAVASOLUONGHIENTAI(int maphongtro)
        {
            int sltd = int.Parse(qlnt.PHONGTROs.Single(t => t.MAPT == maphongtro).SLTOIDA.ToString());
            int slht = int.Parse(qlnt.PHONGTROs.Single(t => t.MAPT == maphongtro).SONGUOIHIENTAI.ToString());
            if (slht == sltd)
            {
                return false;
            }
            return true;
        }
        public void CapNhatSauKhiLapPhieuThue(int maphong, int makt, bool ch)
        {
            PHONGTRO pt = qlnt.PHONGTROs.Single(t => t.MAPT == maphong);
            pt.TRANGTHAI = "Đã cho thuê";
            KHACHTRO KT = qlnt.KHACHTROs.Single(t => t.MAKT == makt);
            KT.CHUHO = ch;
            qlnt.SubmitChanges();
        }
        public void LapPhieuThue(int makt, int maphongtro, DateTime ngaythue, bool ch)
        {
            PHIEUTHUEPHONG ptt = new PHIEUTHUEPHONG();
            ptt.MAKT = makt;
            ptt.MAPT = maphongtro;
            ptt.NGAYTHUE = ngaythue;
            ptt.TRANGTHAI = "Đang thuê";
            qlnt.PHIEUTHUEPHONGs.InsertOnSubmit(ptt);
            CapNhatSauKhiLapPhieuThue(maphongtro, makt, ch);
            qlnt.SubmitChanges();
        }
        public void LapPhieuThu(DateTime ngaybatdau)
        {
            PHIEUTHUTIEN ptt = new PHIEUTHUTIEN();
            ptt.MAPHIEUTHUE = qlnt.PHIEUTHUEPHONGs.Select(t => t).OrderByDescending(e => e.MAPHIEUTHUE).FirstOrDefault().MAPHIEUTHUE;
            ptt.NGAYBATDAU = ngaybatdau;
            ptt.DATTHANHTOAN = 0;
            qlnt.PHIEUTHUTIENs.InsertOnSubmit(ptt);
            qlnt.SubmitChanges();
        }
        public void CapNhatSoLuongnguoi(int maphongtro)
        {
            PHONGTRO pt = qlnt.PHONGTROs.Single(t => t.MAPT == maphongtro);
            pt.SONGUOIHIENTAI = countdemslkt(maphongtro);
            qlnt.SubmitChanges();
            if (countdemslkt(maphongtro) == 0)
            {
                PHONGTRO phongtro = qlnt.PHONGTROs.Single(t => t.MAPT == maphongtro);
                phongtro.TRANGTHAI = "Chưa cho thuê";
                qlnt.SubmitChanges();
            }
        }
        public int countdemslkt(int maphongtro)
        {
            return qlnt.PHIEUTHUEPHONGs.Count(t => t.MAPT == maphongtro && t.TRANGTHAI == "Đang thuê");
        }
        public int GetLastRecordKhachTro()
        {
            var kq = qlnt.KHACHTROs.Select(t => t).OrderByDescending(e => e.MAKT).FirstOrDefault().MAKT;
            return kq;
        }
        public IQueryable LoadPhieuThuePhieuThuv2()
        {
            var kq = (from t in qlnt.PHIEUTHUTIENs
                      from u in qlnt.PHIEUTHUEPHONGs
                      from e in qlnt.KHACHTROs
                      where t.MAPHIEUTHUE == u.MAPHIEUTHUE && u.MAKT == e.MAKT && e.CHUHO == true
                      select new { MAPHIEUTHUE = u.MAPHIEUTHUE, MAKT = u.MAKT, MAPT = u.MAPT, NGAYTHUE = u.NGAYTHUE, NGAYTRA = u.NGAYTRA, TRANGTHAI = u.TRANGTHAI }).Distinct();

            return kq;
        }
        public string TenLoaiPhong(int Maphong)
        {
            int maloai;
            maloai = int.Parse(qlnt.PHONGTROs.Single(t => t.MAPT == Maphong).MALP.ToString());
            return TenLoai(maloai);
        }
        public string TenPhong(int maphong)
        {
            return qlnt.PHONGTROs.Single(t => t.MAPT == maphong).TENPHONG;
        }
        public string Soluongtoida(int maphong)
        {
            return qlnt.PHONGTROs.Single(t => t.MAPT == maphong).SLTOIDA.ToString();
        }
        public string Soluonghientai(int maphong)
        {
            return qlnt.PHONGTROs.Single(t => t.MAPT == maphong).SONGUOIHIENTAI.ToString();
        }
        public IQueryable LoadCTTBPHONG(int maphongtro)
        {
            var thietbi = from u in qlnt.CTTHIETBIs
                          from t in qlnt.THIETBIs
                          where u.MATB == t.MATB && u.MAPT == maphongtro
                          select new
                          {
                              TTB = t.TENTB,
                              Sl = u.SOLUONG,
                              TT = u.TINHTRANG
                          };
            return thietbi;
        }
        public IQueryable LoadDVPHIEUTHUEv2(int maphieuthue)
        {
            //var kq = from u in qlnt.CTPHIEUTHUs
            //         from e in qlnt.DICHVUs
            //         where u.MADV == e.MADV && u.MATHU == mapt && e.TRANGTHAI == "False"
            //         select new { MADV = e.MADV, TENDV = e.TENDV, DVT = e.DONVITINH, DONGIA = e.DONGIA };
            //return kq;
            ////var kq = from u in qlnt.CTPHIEUTHUs
            ////         select u; 
            ////return kq;
            var kq = qlnt.PHIEUTHUTIENs.Where(t => t.MAPHIEUTHUE == maphieuthue).OrderByDescending(e => e.MATHU).FirstOrDefault().MATHU;

            var phieuthuechitiet = from u in qlnt.CTPHIEUTHUs
                                   from e in qlnt.DICHVUs
                                   where u.MADV == e.MADV && u.MATHU == kq && e.TRANGTHAI == "False"
                                   select new { MADV = e.MADV, TENDV = e.TENDV, DVT = e.DONVITINH, DONGIA = e.DONGIA };
            return phieuthuechitiet;

        }
        public IQueryable loadDvphieuthuev2(int maphieuthue)
        {
            var kq = qlnt.PHIEUTHUTIENs.Where(t => t.MAPHIEUTHUE == maphieuthue).OrderByDescending(e => e.MATHU).FirstOrDefault().MATHU;

            var phieuthuechitiet = from u in qlnt.CTPHIEUTHUs
                                   from e in qlnt.DICHVUs
                                   where u.MADV == e.MADV && u.MATHU == kq && e.TRANGTHAI == "False"
                                   select new { MADV = e.MADV, TENDV = e.TENDV, DVT = e.DONVITINH, DONGIA = e.DONGIA };
            return phieuthuechitiet;

        }
        public IQueryable lOADROIPHONGFalse()
        {
            var kq = from t in qlnt.PHIEUTHUEPHONGs
                     from e in qlnt.KHACHTROs
                     where t.MAKT == e.MAKT && e.CHUHO == false
                     select new { MAPHIEUTHUE = t.MAPHIEUTHUE, MAKT = t.MAKT, MAPT = t.MAPT, NGAYTHUE = t.NGAYTHUE, NGAYTRA = t.NGAYTRA, TRANGTHAI = t.TRANGTHAI };
            return kq;
        }
        public IQueryable lOADROIPHONGTrue()
        {
            var kq = from t in qlnt.PHIEUTHUEPHONGs
                     from e in qlnt.KHACHTROs
                     where t.MAKT == e.MAKT && e.CHUHO == true
                     select new { MAPHIEUTHUE = t.MAPHIEUTHUE, MAKT = t.MAKT, MAPT = t.MAPT, NGAYTHUE = t.NGAYTHUE, NGAYTRA = t.NGAYTRA, TRANGTHAI = t.TRANGTHAI };
            return kq;
        }
        public void RoiPhong(int maphieuthue)
        {
            PHIEUTHUEPHONG phieuthue = qlnt.PHIEUTHUEPHONGs.Single(t => t.MAPHIEUTHUE == maphieuthue);
            phieuthue.TRANGTHAI = "Ngừng thuê";
            phieuthue.NGAYTRA = DateTime.Now;
            qlnt.SubmitChanges();
        }
        public bool KIEMTRATHANHTOANHET(int maphieuthue)
        {
            var phieuthu = qlnt.PHIEUTHUTIENs.Where(t => t.MAPHIEUTHUE == maphieuthue && t.DATTHANHTOAN == 0);
            if (phieuthu.Count() != 0)
            {
                return false;//không cho thanh toán
            }
            return true;//cho thanh toán
        }
        public void TRAPHONG(int maphieuthue, int maphong)
        {
            PHIEUTHUEPHONG ptt = qlnt.PHIEUTHUEPHONGs.Single(t => t.MAPHIEUTHUE == maphieuthue);
            ptt.TRANGTHAI = "Ngừng thuê";
            ptt.NGAYTRA = DateTime.Now;
            (from p in qlnt.PHIEUTHUEPHONGs where p.MAPT == maphong select p).ToList().ForEach(x => x.TRANGTHAI = "Ngừng thuê");
            qlnt.SubmitChanges();
        }
        public IQueryable LoadDVKHONGDIENNUOC()
        {
            return qlnt.DICHVUs.Where(t => t.TRANGTHAI == "False");
        }
        public IQueryable LoadPhieuThuePhieuThuv3()
        {
            var kq = (from t in qlnt.PHIEUTHUTIENs
                      from u in qlnt.PHIEUTHUEPHONGs
                      from e in qlnt.KHACHTROs
                      where t.MAPHIEUTHUE == u.MAPHIEUTHUE && u.MAKT == e.MAKT && e.CHUHO == true && u.TRANGTHAI == "Đang thuê"
                      select new { MAPHIEUTHUE = u.MAPHIEUTHUE, MAKT = u.MAKT, MAPT = u.MAPT, NGAYTHUE = u.NGAYTHUE, NGAYTRA = u.NGAYTRA, TRANGTHAI = u.TRANGTHAI }).Distinct();

            return kq;
            //var kq = (from u in qlnt.PHIEUTHUEPHONGs
            //          select new { MAPHIEUTHUE = u.MAPHIEUTHUE, MAKT = u.MAKT, MAPT = u.MAPT, NGAYTHUE = u.NGAYTHUE, NGAYTRA = u.NGAYTRA, TRANGTHAI = u.TRANGTHAI });

            //return kq;


        }
        public bool KTDVCOTRONGHETHONG(int maphieuthu, int madv)
        {
            var kq = qlnt.CTPHIEUTHUs.Where(t => t.MATHU == maphieuthu && t.MADV == madv);
            if (kq.Count() != 0)
            {
                //có giá trị            
                return false;
            }
            return true;
        }
        public void XoaDichVuv2(int maphieuthue, int madichvu)
        {
            //var dv = qlnt.CTPHIEUTHUs.Single(t => t.MATHU == getmaphieuthu(maphieuthue) && t.MADV == madichvu);
            //qlnt.CTPHIEUTHUs.DeleteOnSubmit(dv);
            //qlnt.SubmitChanges();

            var kq = qlnt.PHIEUTHUTIENs.Where(t => t.MAPHIEUTHUE == maphieuthue).OrderByDescending(e => e.MATHU).FirstOrDefault().MATHU;
            var dv = qlnt.CTPHIEUTHUs.Single(t => t.MATHU == kq && t.MADV == madichvu);
            qlnt.CTPHIEUTHUs.DeleteOnSubmit(dv);
            qlnt.SubmitChanges();

        }
        public void ThemDichVuv2(int maphieuthue, int madichvu)
        {
            var kq = qlnt.PHIEUTHUTIENs.Where(t => t.MAPHIEUTHUE == maphieuthue).OrderByDescending(e => e.MATHU).FirstOrDefault().MATHU;
            if (!KTDVCOTRONGHETHONG(kq, madichvu))
            {
                MessageBox.Show("Dịch vụ này đã có");
                return;
            }
            CTPHIEUTHU ctpt = new CTPHIEUTHU();
            ctpt.MATHU = kq;
            ctpt.MADV = madichvu;
            if (KiemTraDichVuChinh(madichvu))
            {
                ctpt.THANHTIEN = qlnt.DICHVUs.Where(t => t.MADV == madichvu).Single().DONGIA;
            }
            qlnt.CTPHIEUTHUs.InsertOnSubmit(ctpt);
            qlnt.SubmitChanges();

        }
        public IQueryable LoadPhieuThuePhieuThu()
        {
            var kq = (from t in qlnt.PHIEUTHUTIENs
                      from u in qlnt.PHIEUTHUEPHONGs
                      where t.MAPHIEUTHUE == u.MAPHIEUTHUE && u.TRANGTHAI == "Đang thuê"
                      select new { MAPHIEUTHUE = u.MAPHIEUTHUE, MAKT = u.MAKT, MAPT = u.MAPT, NGAYTHUE = u.NGAYTHUE, NGAYTRA = u.NGAYTRA, TRANGTHAI = u.TRANGTHAI }).Distinct();

            return kq;
        }
        public IQueryable loadphieuthuv2(int maphieuthue)
        {
            var pt = from t in qlnt.PHIEUTHUTIENs
                     from e in qlnt.PHIEUTHUEPHONGs
                     from a in qlnt.KHACHTROs
                     where e.MAPHIEUTHUE == t.MAPHIEUTHUE && a.MAKT == e.MAKT && t.MAPHIEUTHUE == maphieuthue && a.CHUHO == true
                     select new { MATHU = t.MATHU, MAPHIEUTHUE = t.MAPHIEUTHUE, NGAYBATDAU = t.NGAYBATDAU, NGAYKETHUC = t.NGAYKETTHUC, TONGTIEN = t.TONGTIEN, DATHANHTOAN = t.DATTHANHTOAN };
            return pt;
        }
        public IQueryable loadcttphieuthu(int maphieuthu)
        {
            var ctpt = from t in qlnt.CTPHIEUTHUs
                       from e in qlnt.DICHVUs
                       where t.MADV == e.MADV && t.MATHU == maphieuthu && e.TRANGTHAI == "False"
                       select new { MATHU = t.MATHU, MADV = t.MADV, TENDV = e.TENDV, THANHTIEN = t.THANHTIEN };
            return ctpt;
        }
        public string TinhTienDien(int socu, int somoi)
        {
            //tính tiền điện
            int tb = somoi - socu;
            int giatiendien = int.Parse(qlnt.DICHVUs.Where(t => t.MADV == 1).Single().DONGIA.ToString());
            int result = tb * giatiendien;
            return result.ToString();

        }
        public string TinhTienNuoc(int socu, int somoi)
        {

            int tb = somoi - socu;
            int giatiennuoc = int.Parse(qlnt.DICHVUs.Where(t => t.MADV == 2).Single().DONGIA.ToString());
            int result = tb * giatiennuoc;
            return result.ToString();
        }
        public void CapNhattienDienNuocvaochitietphieuthu(int maphieuthu, int madv, int csc, int csm, int thanhtien)
        {
            CTPHIEUTHU ctpt = qlnt.CTPHIEUTHUs.Single(t => t.MATHU == maphieuthu && t.MADV == madv);
            ctpt.CHISOCU = csc;
            ctpt.CHISOMOI = csm;
            ctpt.THANHTIEN = thanhtien;
            qlnt.SubmitChanges();
        }
        public void CapNhatTongTien(int maphieuthu, int maphongtro)
        {
            int giaphongtro = int.Parse((from t in qlnt.LOAIPHONGs
                               from e in qlnt.PHONGTROs
                               where t.MALP == e.MALP && e.MAPT == maphongtro
                               select t).Single().DONGIA.ToString());
            var data = qlnt.CTPHIEUTHUs.Where(t => t.MATHU == maphieuthu);
            int tongtien = int.Parse(data.Sum(t => t.THANHTIEN).ToString());
            PHIEUTHUTIEN ptt = qlnt.PHIEUTHUTIENs.Single(t => t.MATHU == maphieuthu);
            ptt.TONGTIEN = tongtien + giaphongtro;
            qlnt.SubmitChanges();
        }
        public bool KIEMTRATHANHTOAN(int maphieuthu)
        {
            var tiendien = qlnt.CTPHIEUTHUs.Where(t => t.MADV == 1 && t.MATHU == maphieuthu && t.THANHTIEN.Equals(null));
            var tiennuoc = qlnt.CTPHIEUTHUs.Where(t => t.MADV == 2 && t.MATHU == maphieuthu && t.THANHTIEN.Equals(null));
            if (tiendien.Count() != 0 || tiennuoc.Count() != 0)
            {
                return false;
            }
            return true;
        }
        public void ThanhToan(int maphieuthu)
        {
            PHIEUTHUTIEN ptt = qlnt.PHIEUTHUTIENs.Single(t => t.MATHU == maphieuthu);
            ptt.DATTHANHTOAN = 1;
            ptt.NGAYKETTHUC = DateTime.Now;
            qlnt.SubmitChanges();
        }
        public void Otrotieptuc(int maphieuthue)
        {
            PHIEUTHUTIEN phieuthutien = new PHIEUTHUTIEN();
            phieuthutien.MAPHIEUTHUE = maphieuthue;
            phieuthutien.NGAYBATDAU = DateTime.Now;
            phieuthutien.DATTHANHTOAN = 0;
            qlnt.PHIEUTHUTIENs.InsertOnSubmit(phieuthutien);
            qlnt.SubmitChanges();
        }
        public void TaoCTTPTHU(int madv)
        {
            CTPHIEUTHU ctpt = new CTPHIEUTHU();
            ctpt.MATHU = qlnt.PHIEUTHUTIENs.Select(t => t).OrderByDescending(e => e.MATHU).FirstOrDefault().MATHU;
            ctpt.MADV = madv;
            if (KiemTraDichVuChinh(madv))
            {
                ctpt.THANHTIEN = qlnt.DICHVUs.Where(t => t.MADV == madv).Single().DONGIA;
            }
            qlnt.CTPHIEUTHUs.InsertOnSubmit(ctpt);
            qlnt.SubmitChanges();          

        }
        public IQueryable loadphieuthu(int maphieuthue)
        {

            var pt = from t in qlnt.PHIEUTHUTIENs
                     where t.MAPHIEUTHUE == maphieuthue
                     select new { MATHU = t.MATHU, MAPHIEUTHUE = t.MAPHIEUTHUE, NGAYBATDAU = t.NGAYBATDAU, NGAYKETHUC = t.NGAYKETTHUC, TONGTIEN = t.TONGTIEN, DATHANHTOAN = t.DATTHANHTOAN };
            return pt;
        }
        public string gettongtien(int maphieuthu)
        {
            return qlnt.PHIEUTHUTIENs.Single(t => t.MATHU == maphieuthu).TONGTIEN.ToString();
        }
        public IQueryable LoadPhieuThuePhieuThuv2DangThue()
        {
            var kq = (from t in qlnt.PHIEUTHUTIENs
                      from u in qlnt.PHIEUTHUEPHONGs
                      from e in qlnt.KHACHTROs
                      where t.MAPHIEUTHUE == u.MAPHIEUTHUE && u.MAKT == e.MAKT && e.CHUHO == true && u.TRANGTHAI == "Đang thuê"
                      select new { MAPHIEUTHUE = u.MAPHIEUTHUE, MAKT = u.MAKT, MAPT = u.MAPT, NGAYTHUE = u.NGAYTHUE, NGAYTRA = u.NGAYTRA, TRANGTHAI = u.TRANGTHAI }).Distinct();

            return kq;
        }
        public IQueryable LoadPhieuThuePhieuThuv2NgungThue()
        {
            var kq = (from t in qlnt.PHIEUTHUTIENs
                      from u in qlnt.PHIEUTHUEPHONGs
                      from e in qlnt.KHACHTROs
                      where t.MAPHIEUTHUE == u.MAPHIEUTHUE && u.MAKT == e.MAKT && e.CHUHO == true && u.TRANGTHAI == "Ngừng thuê"
                      select new { MAPHIEUTHUE = u.MAPHIEUTHUE, MAKT = u.MAKT, MAPT = u.MAPT, NGAYTHUE = u.NGAYTHUE, NGAYTRA = u.NGAYTRA, TRANGTHAI = u.TRANGTHAI }).Distinct();

            return kq;
        }
        public IQueryable loadphieuthuv2ChuaThanhToan(int maphieuthue)
        {
            var pt = from t in qlnt.PHIEUTHUTIENs
                     from e in qlnt.PHIEUTHUEPHONGs
                     from a in qlnt.KHACHTROs
                     where e.MAPHIEUTHUE == t.MAPHIEUTHUE && a.MAKT == e.MAKT && t.MAPHIEUTHUE == maphieuthue && a.CHUHO == true&&t.DATTHANHTOAN==0
                     select new { MATHU = t.MATHU, MAPHIEUTHUE = t.MAPHIEUTHUE, NGAYBATDAU = t.NGAYBATDAU, NGAYKETHUC = t.NGAYKETTHUC, TONGTIEN = t.TONGTIEN, DATHANHTOAN = t.DATTHANHTOAN };
            return pt;
        }
        public IQueryable loadphieuthuv2DaThanhToan(int maphieuthue)
        {
            var pt = from t in qlnt.PHIEUTHUTIENs
                     from e in qlnt.PHIEUTHUEPHONGs
                     from a in qlnt.KHACHTROs
                     where e.MAPHIEUTHUE == t.MAPHIEUTHUE && a.MAKT == e.MAKT && t.MAPHIEUTHUE == maphieuthue && a.CHUHO == true && t.DATTHANHTOAN == 1
                     select new { MATHU = t.MATHU, MAPHIEUTHUE = t.MAPHIEUTHUE, NGAYBATDAU = t.NGAYBATDAU, NGAYKETHUC = t.NGAYKETTHUC, TONGTIEN = t.TONGTIEN, DATHANHTOAN = t.DATTHANHTOAN };
            return pt;
        }


        //Thống kê doan thu
        public IQueryable LoadDanhThuThang(int nam)
        {
            var data = qlnt.PHIEUTHUTIENs.Where(t=>t.NGAYBATDAU.Value.Year==nam).Select(k => new {k.NGAYBATDAU, k.TONGTIEN }).GroupBy(x => new { x.NGAYBATDAU }, (key, group) => new
            {
                mtn = DateTime.Parse(key.NGAYBATDAU.ToString()).Month,
                tongtien = group.Sum(k => k.TONGTIEN)
            });
            return data;

        }
        public IQueryable LoadDoanhThuTungNam()
        {
            var data = qlnt.PHIEUTHUTIENs.Select(k => new { k.NGAYBATDAU, k.TONGTIEN }).GroupBy(x => new { x.NGAYBATDAU }, (key, group) => new
            {
                mtn = DateTime.Parse(key.NGAYBATDAU.ToString()).Year,
                tongtien = group.Sum(k => k.TONGTIEN)
            });
            return data;
        }

        //Báo cáo
        public int Tongkhachtrodangthue()
        {
            return qlnt.PHIEUTHUEPHONGs.Count(t => t.TRANGTHAI == "Đang thuê");
        }
        public int Sophongdaduocthue()
        {
            return qlnt.PHONGTROs.Count(t => t.TRANGTHAI == "Đã cho thuê");
        }
        public int Sophongcontrong()
        {
            return qlnt.PHONGTROs.Count(t => t.TRANGTHAI == "Chưa cho thuê");
        }

        public int Doanhthucuathanghientai(int nam,int thang)
        {
            var data = qlnt.PHIEUTHUTIENs.Where(t => t.NGAYBATDAU.Value.Month == nam&&t.NGAYBATDAU.Value.Month==thang).Select(k => new { k.NGAYBATDAU, k.TONGTIEN }).GroupBy(x => new { x.NGAYBATDAU }, (key, group) => new
            {
                tongtien = group.Sum(k => k.TONGTIEN)
            });
            return data.Single().tongtien;

        }
        //Report
        //public IQueryable InPhieuThue(int maphieuthue)
        //{
        //    var data = from t in qlnt.PHIEUTHUEPHONGs
        //               from e in qlnt.KHACHTROs
        //               from i in qlnt.PHONGTROs
        //               from c in qlnt.PHIEUTHUTIENs
        //               from f in qlnt.CTPHIEUTHUs
        //               from j in qlnt.DICHVUs
        //               where t.MAPT == i.MAPT && t.MAKT == e.MAKT && t.MAPHIEUTHUE == c.MAPHIEUTHUE && c.MATHU == f.MATHU &&f.MADV==j.MADV&& t.MAPHIEUTHUE == maphieuthue
        //               select new {MAPPT=t.MAPHIEUTHUE,HOTEN = e.HOTEN,MADV=j.MADV,TENDV=j.TENDV,DONGIA=j.DONGIA };

        //    return data;
        //}

        public IQueryable pt(int maphieuthue)
        {
            return qlnt.PHIEUTHUEPHONGs.Select(t => t.MAPHIEUTHUE == maphieuthue);
        }
        public IQueryable loadcttphieuthu2(int maphieuthu)
        {
            //var ctpt = from t in qlnt.CTPHIEUTHUs
            //           from e in qlnt.DICHVUs
            //           where t.MADV == e.MADV && t.MATHU == maphieuthu
            //           select new { MATHU = t.MATHU, MADV = t.MADV, TENDV = e.TENDV, THANHTIEN = t.THANHTIEN };
            //return ctpt;
            return qlnt.CTPHIEUTHUs.Where(t => t.MATHU == maphieuthu);

        }
        public IQueryable InPhieuThue(int maphieuthue)
        {
            return qlnt.PHIEUTHUEPHONGs.Where(t => t.MAPHIEUTHUE == maphieuthue);
        }
        public IQueryable LoadDanhSachHoaDonChuaThuTien()
        {
            var data = from t in qlnt.PHIEUTHUEPHONGs
                       from c in qlnt.PHIEUTHUTIENs
                       from e in qlnt.KHACHTROs
                       where t.MAKT == e.MAKT && c.MAPHIEUTHUE == t.MAPHIEUTHUE && c.DATTHANHTOAN == 0
                       select new {MAHD=c.MATHU,TENKT=e.HOTEN,NGAYBATDAU=c.NGAYBATDAU,Tongtien=c.TONGTIEN };

            return data;
        }
        public IQueryable LoadDanhSachKhachtrodangthue()
        {
            var data = from t in qlnt.KHACHTROs
                       from i in qlnt.PHIEUTHUEPHONGs
                       from q in qlnt.PHONGTROs
                       where t.MAKT == i.MAKT && i.MAPT == q.MAPT && i.TRANGTHAI == "Đang thuê"
                       select new {TENKT=t.HOTEN,TP=q.TENPHONG,NGAYTHUE=i.NGAYTHUE};
            return data;
        }

       

    }
    
}
