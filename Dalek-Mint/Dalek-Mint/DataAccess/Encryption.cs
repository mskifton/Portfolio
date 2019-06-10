using Dalek_Mint.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Dalek_Mint.DataAccess
{
    public static class Encryption
    {
        /// <summary>
        /// Create the encryption for the password.
        /// </summary>
        /// <param name="input">The password to encrypt.</param>
        /// <returns>Returns encrypted password.</returns>
        public static string Encrypt(string input)
        {
            // Create a salt to add to the password.
            byte[] salt = Salt();
            // Make a slow hash function.
            var pbkdf2 = new Rfc2898DeriveBytes(input, salt, 10000);
            // Place string in the byte array.
            byte[] hash = pbkdf2.GetBytes(20);
            // Make a new byte array to store the password and the salt.
            byte[] hashBytes = new byte[52];
            // Add the hash and salt into their places within the array.
            Array.Copy(salt, 0, hashBytes, 0, 32);
            Array.Copy(hash, 0, hashBytes, 32, 20);
            // Convert the aray to a string.
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Check to see if the password the user put in matches what is stored in the database.
        /// </summary>
        /// <param name="input">The inputted password.</param>
        /// <returns>Returns whether or not there was a match.</returns>
        public static bool CheckPassword(string email, string input)
        {
            bool success = false;
            if (input != null && input != "")
            {
                // Retrieve the stored password to compare to
                string savedPasswordHash = CheckIfPasswordFound(email);
                if (savedPasswordHash != null && savedPasswordHash != "")
                {
                    // Turn retrieved password into bytes.
                    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                    // Take the salt from the string.
                    byte[] salt = new byte[32];
                    Array.Copy(hashBytes, 0, salt, 0, 32);
                    // Hash the user's inputted password with the salt.
                    var pbkdf2 = new Rfc2898DeriveBytes(input, salt, 10000);
                    // Put the input into an array to compare to what is saved in DB byte-by-byte.
                    byte[] hash = pbkdf2.GetBytes(20);
                    // Check to see if the two passwords match.
                    success = ComparePasswords(hashBytes, hash);
                }
            }
            return success;
        }

        /// <summary>
        /// Compare the inputted password with the stored password.
        /// </summary>
        /// <param name="hashBytes">The inputted password.</param>
        /// <param name="hash">The stored password.</param>
        /// <returns>Returns whether the login was successful or not.</returns>
        private static bool ComparePasswords(byte[] hashBytes, byte[] hash)
        {
            bool ok = true;

            for (int i = 0; i < 20; i++)
            {
                // Starting from 16 in the array, check to see if the inputted password matches the stored.
                // 0 -15 in the array are salt values.
                if (hashBytes[i + 32] != hash[i])
                {
                    // Unsuccessful match.
                    ok = false;
                    break;
                }
            }

            return ok;
        }

        /// <summary>
        /// Make a database connection.
        /// </summary>
        /// <param name="input">The value of the returned password.</param>
        private static string CheckIfPasswordFound(string email)
        {
            User user = new User();
            string Procedure = "Find User";

            // Connect to database.
            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MintContext"].ConnectionString);
            SqlCommand Command = new SqlCommand(Procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@Email", email);

            using (Connection)
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    user.UserId = (int)reader["UserId"];
                    user.Email = reader["Email"].ToString();
                    user.Password = reader["Password"].ToString();
                }

                Connection.Close();
            }

            return user.Password;
        }

        /// <summary>
        /// Create a 16 byte salt to add on to the input before Encryption.
        /// </summary>
        /// <returns>Returns the salt.</returns>
        private static byte[] Salt()
        {
            byte[] salt;
            // Generate salt.
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[32]);
            return salt;
        }
    }
}