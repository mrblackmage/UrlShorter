using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace urlshorterTest
{
    public class UrlShorter
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private Random random = new Random();
        private Dictionary<string, string> storage = new Dictionary<string, string>();
        public string Shorten(string longUrl)
        {
            string shortCode;

            do
            {
                char[] chars = new char[7];
                for (int i = 0; i < chars.Length; i++)
                {
                    int index = random.Next(Alphabet.Length);
                    chars[i] = Alphabet[index];
                }
                shortCode = new string(chars);

            } while (storage.ContainsKey(shortCode));

            storage.Add(shortCode, longUrl);

            return shortCode;
        }

    }

    internal class Program
    {

        static void Main(string[] args)
        {
            var shortener = new UrlShorter();
            string code = shortener.Shorten("https://youtube.com");
            Console.WriteLine($"Сокращённый код: {code}");

            //string original = shortener.Expand(code);
            //Console.WriteLine($"Оригинальная ссылка: {original}");

            //string notFound = shortener.Expand("несуществующий");
            //Console.WriteLine($"Несуществующая: {notFound ?? "не найдена"}");


        } 
    }
}
