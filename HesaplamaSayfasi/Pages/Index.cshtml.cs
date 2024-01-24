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

        // Login iþlemleri
        public IActionResult OnPost()
        {
            // Giriþ yapma iþlemleri
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                // Kullanýcý adý ve þifreyi kontrol eden sorgu
                string sql = "SELECT COUNT(*) FROM veriler WHERE ad = ? AND sifre = ?";
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("ad", ad);
                    command.Parameters.AddWithValue("sifre", sifre);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        return RedirectToPage("/Hesap"); // Baþarýlý giriþ, yönlendirme
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
 