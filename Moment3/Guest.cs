using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moment3
{
    internal class Guest
    {
        //Inmatning ska bestå av två fält
        private string? guestName;
        private string? guestMessage;

        //Constructor
        public Guest(string aGuestName, string aGuestMessage)
        {
            guestName = aGuestName;
            guestMessage = aGuestMessage;
            GuestUser = $"{guestName}: {guestMessage}";
        }


        //Get/setter
        public string? GuestUser
        {
            get;
            set;
        }
    }
}
