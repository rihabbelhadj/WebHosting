using System.Text;

namespace WEBHostingbackend.Helpers
{
    public class EncDscPassword
    {
        public static string secretKey = "@123secretkeydontshare";
        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            else
            {
                password = password + secretKey;
                var passwordinBytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(passwordinBytes);
            }
        }
        public static string DecryptPassword(string encryptedpassword)
        {
            if (string.IsNullOrEmpty(encryptedpassword))
            {
                return "";
            }
            else
            {
                var encodeBytes = Convert.FromBase64String(encryptedpassword);
                var actualPassword = Encoding.UTF8.GetString(encodeBytes);
                actualPassword = actualPassword.Substring(0, actualPassword.Length - secretKey.Length);
                return actualPassword;
            }
        }
    }
}
