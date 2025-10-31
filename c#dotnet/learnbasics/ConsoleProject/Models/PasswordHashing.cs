using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ConsoleAppLearning.LearnConcepts
{
    internal class PasswordHashing
    {
        public void HashPasswordwithSalt(string password, out byte[] passwordSalt, out byte[] paswordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                // Send a sample text to hash.                
                passwordSalt = hmac.Key;
                paswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                Console.WriteLine(Convert.ToBase64String(paswordHash));

                //var hash = BitConverter.ToString(paswordHash).Replace("-", "").ToLower();

                // Print the string.   
                //Console.WriteLine($"passwordHash : {hash}");
            }

        }
        public void HashPassword(string password)
        {
            //byte[] kky = { 129, 236, 120, 4, 40, 100, 39, 194, 199, 190, 149, 81, 183, 165, 199, 181, 88, 247, 9, 135, 51, 27, 193, 35, 147, 131, 180, 149, 100, 158, 138, 149, 38, 133, 143, 60, 144, 185, 53, 201, 7, 181, 87, 255, 199, 4, 130, 83, 43, 249, 168, 125, 208, 34, 109, 142, 164, 79, 27, 109, 164, 22, 52, 36, 89, 112, 133, 10, 39, 95, 17, 44, 187, 153, 214, 5, 125, 224, 88, 57, 112, 84, 247, 29, 156, 144, 231, 140, 140, 39, 91, 176, 138, 49, 56, 120, 55, 0, 100, 42, 170, 157, 98, 169, 242, 222, 64, 25, 6, 161, 9, 215, 10, 43, 64, 203, 37, 5, 220, 12, 197, 106, 118, 113, 3, 194, 125, 19 };
            using (var hmac = new HMACSHA512())
            {
                // Send a sample text to hash.                
                var passwordSalt = hmac.Key;
                var paswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                var saltKey = Convert.ToBase64String(passwordSalt);
                var passwordKey = Convert.ToBase64String(paswordHash);

                //Console.WriteLine(Convert.ToBase64String(paswordHash));
                Console.WriteLine(saltKey);
                Console.WriteLine(passwordKey);

                //var convertBack = Convert.FromBase64String(saltKey);

                //foreach(var key in convertBack)
                //{
                // Console.WriteLine(key);
                //}

            }
        }

        public void ValidatePassword(string password)
        {
            var getExistingPassFromDb = "qC2KHcTbkIatKk9dQBHVPK+IcROO/bTSSt+O/g9YMSumtP0FUUJ0U4DSMn3F/keVKA2jKq4IfUIOSBT0t7b+rg==";

            var getSaltFromDB = "+UJ36GxjzAqth2521FOfKwv7NQb4J/WXPOGszU8vUUgaKhV9oFmE3kDEEdx98pBQ2SnIwBjuHb+xnApBNeMLMoFhrFKgkMDdEDgBZKcVlo1+Mpdn3TGvYI6eyZ7PTotaMhaj/KU7jd9uHw6LVN8Vn  a8+fM8E1gdvUqcVsmBFXBI=";
            var convertSaltBackToByte = Convert.FromBase64String(getSaltFromDB);

            using (var hmac = new HMACSHA512(convertSaltBackToByte))
            {
                // Send a sample text to hash.                                
                var computedPassToByte = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var computePassToHash = (Convert.ToBase64String(computedPassToByte));
                //Console.WriteLine(Convert.ToBase64String(paswordHash));
                Console.WriteLine(getExistingPassFromDb);
                Console.WriteLine(computePassToHash);

                if(!computePassToHash.SequenceEqual(getExistingPassFromDb))
                {
                    Console.WriteLine("Passwords Do Not Match");
                }
                else
                {
                    Console.WriteLine("Bingo! Passwords Match");
                }
            }

        }

    }

    public class User
    {
        public byte[] Salt { get; set; }
        public byte[] Pwd { get; set; }
    }
}
