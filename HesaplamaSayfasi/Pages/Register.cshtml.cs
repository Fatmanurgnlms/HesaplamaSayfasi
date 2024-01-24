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
            // Access veritaban� ba�lant� dizgisi
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\fatma\\Documents\\veriler.accdb";
            // Var olan kullan�c�n�n kontrol�
            if (IsUserRegistered(Ad))
            {
                ErrorMessage = "Bu kullan�c� zaten kay�tl�!";
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
                    // Ba�lant� a��l�r ve sorgu �al��t�r�l�r
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // �r�n eklendikten sonra ba�ka bir sayfaya y�nlendirme yapabilirsiniz
            return RedirectToPage("/Hesap");
        }

        private bool IsUserRegistered(string ad)
        {
            // Kullan�c�n�n veritaban�nda kay�tl� olup olmad���n� kontrol etmek i�in kullan�lacak sorgu
            // Bu sorguyu, kullan�lan veritaban� �emas�na ve yap�land�rmas�na uygun �ekilde g�ncellemeniz gerekebilir
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





