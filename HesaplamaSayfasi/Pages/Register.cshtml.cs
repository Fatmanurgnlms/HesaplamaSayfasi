using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.OleDb;

namespace HesaplamaSayfasi.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Ad { get; set; }

        [BindProperty]
        public string Sifre { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            // Access veritabaný baðlantý dizgisi
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fatma\\Documents\\veriler.accdb";
            // Var olan kullanýcýnýn kontrolü
            if (IsUserRegistered(Ad))
            {
                ErrorMessage = "Bu kullanýcý zaten kayýtlý!";
                return Page();
            }

            // SQL sorgusu
            string sql = "INSERT INTO veriler (Ad, Sifre) VALUES (?, ?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    // Parametrelerin eklenmesi
                    command.Parameters.AddWithValue("ad", Ad);
                    command.Parameters.AddWithValue("sifre", Sifre);
                    // Baðlantý açýlýr ve sorgu çalýþtýrýlýr
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Ürün eklendikten sonra baþka bir sayfaya yönlendirme yapabilirsiniz
            return RedirectToPage("/Hesap");
        }

        private bool IsUserRegistered(string ad)
        {
            // Kullanýcýnýn veritabanýnda kayýtlý olup olmadýðýný kontrol etmek için kullanýlacak sorgu
            // Bu sorguyu, kullanýlan veritabaný þemasýna ve yapýlandýrmasýna uygun þekilde güncellemeniz gerekebilir
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fatma\\Documents\\veriler.accdb";
            string sql = "SELECT COUNT(*) FROM veriler WHERE ad = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("ad", Ad);
                    connection.Open();

                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
            }
        }
    }
}





