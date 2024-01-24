using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.OleDb;

namespace HesaplamaSayfasi.Pages
{
    public class IndexModel : PageModel
    {
        private const string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fatma\\Documents\\veriler.accdb";

        [BindProperty]
        public string ad { get; set; }

        [BindProperty]
        public string sifre { get; set; }

        public string ErrorMessage { get; set; }

        // Login i�lemleri
        public IActionResult OnPost()
        {
            // Giri� yapma i�lemleri
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                // Kullan�c� ad� ve �ifreyi kontrol eden sorgu
                string sql = "SELECT COUNT(*) FROM veriler WHERE ad = ? AND sifre = ?";
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("ad", ad);
                    command.Parameters.AddWithValue("sifre", sifre);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        return RedirectToPage("/Hesap"); // Ba�ar�l� giri�, y�nlendirme
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid username or password");
                        return Page();
                    }
                }
            }
        }
    }
}
 