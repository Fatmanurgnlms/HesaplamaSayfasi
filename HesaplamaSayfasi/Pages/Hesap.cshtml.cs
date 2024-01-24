using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesaplamaSayfasi.Pages
{
    public class HesapModel : PageModel
    {
        [BindProperty]
        public int Vize { get; set; }

        [BindProperty]
        public int Final { get; set; }

        public bool ShowResult { get; set; }

        public IActionResult OnPost()
        {
            ShowResult = true;
            return Page();
        }

        public double CalculateAverage()
        {
            // Vize ve finalin aðýrlýklý ortalamasýný hesapla (Vize: 0.4, Final: 0.6)
            return (Vize * 0.4) + (Final * 0.6);
        }
    }
}