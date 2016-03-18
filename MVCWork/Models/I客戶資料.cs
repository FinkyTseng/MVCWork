namespace MVCWork.Models
{
    public interface I客戶資料
    {
        string Email { get; set; }
        int Id { get; set; }
        string 傳真 { get; set; }
        bool 刪除 { get; set; }
        string 地址 { get; set; }
        int 客戶分類 { get; set; }
        string 客戶名稱 { get; set; }
        string 帳號 { get; set; }
        string 統一編號 { get; set; }
        string 電話 { get; set; }
    }
}