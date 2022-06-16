using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB5_TH.Models
{
    public class Giohang
    {
        dbRubikStoreDataContext data = new dbRubikStoreDataContext();
        public int id { get; set; }
        [Display(Name = "Tên")]
        public String ten { get; set; }
        [Display(Name = "Ảnh bìa")]
        public String hinh { get; set; }
        [Display(Name = "Giá bán")]
        public Double gia { get; set; }
        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }
        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return iSoluong * gia; }
        }
        public Giohang(int id)
        {
            this.id = id;
            Rubik rubik = data.Rubiks.Single(n => n.id == id);
            ten = rubik.ten;
            hinh = rubik.hinh;
            gia = double.Parse(rubik.gia.ToString());
            iSoluong = 1;
        }
    
    }
}