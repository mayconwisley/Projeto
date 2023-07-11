using System.Security.Cryptography;
using System.Text;

namespace Projeto.API.Ultilitario;

public class SenhaHash
{
    public static string Gerar(string senha)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] senhaByte = Encoding.ASCII.GetBytes(senha);
            byte[] hashByte = sha256.ComputeHash(senhaByte);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashByte.Length; i++)
            {
                stringBuilder.Append(hashByte[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
