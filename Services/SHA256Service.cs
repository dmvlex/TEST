using System.Security.Cryptography;
using System.Text;

namespace TEST.Services
{
    public interface IHashingService
    {
        public string GenerateHash(string input);
    }
    public class SHA256Service : IHashingService
    {
        /// <summary>
        /// Возвращает хэш-код сгенерированный на основе строки.
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <returns>Хэш-строка</returns>
        public string GenerateHash(string input)
        {
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

    }
}
