using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moment3
{
    internal class Guest
    {
        //Endast kod inom klass har åtkomst till strängarna
        private string? guestName;
        private string? guestMessage;

        //Constructor utan parameter för deserialisering
        public Guest() { }

        //Constructor för instansiering
        public Guest(string aGuestName, string aGuestMessage)
        {
            GuestName = aGuestName;
            GuestMessage = aGuestMessage;
        }

        //Getter/Setter för gästanvändare(guestName) och inlägg(guestMessage)
        public string? GuestName
        {
            get { return guestName; }
            set { guestName = value; }
        }

        public string? GuestMessage
        {
            get { return guestMessage; }
            set { guestMessage = value; }
        }

    }
}
