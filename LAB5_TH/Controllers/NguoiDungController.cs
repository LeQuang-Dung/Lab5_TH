using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAB5_TH.Models;

namespace LAB5_TH.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }

        dbRubikStoreDataContext data = new dbRubikStoreDataContext();
        // GET: NguoiDung


        public ActionResult DangKy()
        {
            return View();
        }

        //post: ham dang ky(post) nhap du lieu tu trang dangky
        //va thuc hien viec tao moi du lieu
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống*";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập*";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu*";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu*";
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được bỏ trống*";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Phải nhập số điện thoại*";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (KH)
                kh.hoten = hoten;
                kh.tendangnhap = tendn;
                kh.matkhau = matkhau;
                kh.email = email;
                kh.diachi = diachi;
                kh.dienthoai = dienthoai;
                kh.ngaysinh = DateTime.Parse(ngaysinh);
                data.KhachHangs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.DangKy();
        }

        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }

        public ActionResult Dangnhap(FormCollection collection)
        {
            //Gan cac gia tri nguoi dung nhap lieu cho cac bien
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đang nhập*";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu*";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (KH)
                KhachHang kh = data.KhachHangs.SingleOrDefault(n => n.tendangnhap == tendn && n.matkhau == matkhau);
                if (kh != null)
                {
                    //ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    return RedirectToAction("Index", "Rubik");
                }
                else
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }
    }
}

       
