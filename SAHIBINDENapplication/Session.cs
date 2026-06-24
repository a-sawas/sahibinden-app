using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAHIBINDENapplication.Models;


namespace SAHIBINDENapplication
{
    public static class Session
    {
        public static User CurrentUser { get; set; }
        public static bool IsGuest { get; set; } = true;

        public static bool IsLoggedIn => CurrentUser != null && !IsGuest;
        public static bool IsAdmin => CurrentUser?.Role == "admin";

        public static void LoginAsGuest()
        {
            CurrentUser = null;
            IsGuest = true;
        }

        public static void Logout()
        {
            CurrentUser = null;
            IsGuest = true;
        }
    }
}
