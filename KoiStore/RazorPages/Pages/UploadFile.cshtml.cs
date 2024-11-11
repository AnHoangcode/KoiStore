using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace YourNamespace.Pages
{
    public class UploadFileModel : PageModel
    {
        public bool UploadSuccess { get; set; }

        // Xử lý upload file
        public async Task OnPostAsync(IFormFile fileUpload)
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                // Đường dẫn lưu tệp trong thư mục wwwroot/images
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileUpload.FileName);

                // Lưu tệp vào thư mục wwwroot/images
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                // Đánh dấu upload thành công
                UploadSuccess = true;
            }
            else
            {
                // Néu không có tệp hoặc tệp không hợp lệ
                UploadSuccess = false;
            }
        }
    }
}
