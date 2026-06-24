using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BCrypt.Net;


namespace SAHIBINDENapplication
{
    public static class PasswordHelper
    {
        // Call this when REGISTERING a user
        public static string Hash(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword, workFactor: 12);
        }

        // Call this when LOGGING IN
        public static bool Verify(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }

}
