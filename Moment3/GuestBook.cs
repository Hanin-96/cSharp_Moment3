using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Moment3
{
    internal class GuestBook
    {
        private string fileJson = @"guestbook.json";

        //Skapar lista som kan nås med index
        private List<Guest> guests = new List<Guest>();

        //Constructor
        public GuestBook()
        {
            //Om JSON filen för GuestBook finns
            if (File.Exists(fileJson) == true)
            {
                //Läs ut data från filen
                string jsonString = File.ReadAllText(fileJson);

                guests = JsonSerializer.Deserialize<List<Guest>>(jsonString)!;
            }   
        }

        //Method för att lägga till nya guests
        public Guest AddGuest(string guestPerson, string guestMessage)
        {
            Guest newObject = new Guest(guestPerson, guestMessage);
            newObject.GuestName = guestPerson;
            newObject.GuestMessage = guestMessage;
            guests.Add(newObject);

            Marshal();
            return newObject;

        }

        //method för att skriva ut existerande guests list
        public List<Guest> GetGuests()
        {
            return guests;
        }

        //Method för att hämta totala antal lagrade inlägg
        public int CountGuests()
        {
            List<Guest> guestsTotal = GetGuests();
            //Räknar ut antal
            return guestsTotal.Count;
        }

        private void Marshal()
        {
            var jsonString = JsonSerializer.Serialize(guests);
            File.WriteAllText(fileJson, jsonString);
        }
    }
}
