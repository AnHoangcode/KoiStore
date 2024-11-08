using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace YourNamespace.Pages
{
    public class UploadFileModel : PageModel
    {
        public bool UploadSuccess { get; set; }

        // X? l� upload file
        public async Task OnPostAsync(IFormFile fileUpload)
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                // ???ng d?n l?u t?p trong th? m?c wwwroot/images
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileUpload.FileName);

                // L?u t?p v�o th? m?c wwwroot/images
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                // ?�nh d?u upload th�nh c�ng
                UploadSuccess = true;
            }
            else
            {
                // N?u kh�ng c� t?p ho?c t?p kh�ng h?p l?
                UploadSuccess = false;
            }
        }
    }
}
