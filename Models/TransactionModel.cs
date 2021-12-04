using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KT_System.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public Guid PhieuThuId { get; set; }
        [Display(Name = "Tên Dịch Vụ")]
        public string TenDichVu { get; set; }
        [Display(Name = "Mã Dịch Vụ")]
        public string MaDichVu { get; set; }
        [Display(Name = "Họ Tên Khách Hàng")]
        public string HoTenKhachHang { get; set; }
        [Display(Name = "Mã Khách Hàng")]
        public string MaKhachHang { get; set; }
        [Display(Name = "Số Tiền")]
        public decimal SoTien { get; set; }
        [Display(Name = "Người Nộp Tiền")]
        public string NguoiNopTien { get; set; }
        [Display(Name = "Phiếu Chi")]
        public bool IsPhieuChi { get; set; }
        [Display(Name = "Mã Cán Bộ Chỉ Định")]
        public string MaCanBoChiDinh { get; set; }
        [Display(Name = "Mã Khóa Chỉ Định")]
        public string MaKhoaChiDinh { get; set; }
        [Display(Name = "Mã Phòng Chỉ Định")]
        public string MaPhongChiDinh { get; set; }
        [Display(Name = "Mã Cán Bộ Xử Lý")]
        public string MaCanBoXuLy { get; set; }
        [Display(Name = "Mã Khóa Xử Lý")]
        public string MaKhoaXuLy { get; set; }
        [Display(Name = "Mã Phòng Xử Lý")]
        public string MaPhongXuLy { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        [Display(Name = "Ngày Tạo")]
        public DateTime NgayTao { get; set; }
    }
    internal class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
        }
    }

    public class EntryModel
    {

    }

    public class TransactionViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
