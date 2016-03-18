using System.ComponentModel.DataAnnotations;

namespace MVCWork.Models
{
    public class 客戶聯絡人批次更新ViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int 客戶Id { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [手機格式驗證(ErrorMessage = "手機格式驗證錯誤，應為09xx-xxxxxx")]
        public string 手機 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Phone(ErrorMessage = "電話格式錯誤")]
        public string 電話 { get; set; }

    }
}