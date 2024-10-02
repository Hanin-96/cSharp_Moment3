/*
DT071G Programmering i c#.NET
Hanin Farhan
Moment 3 Objektorienterad c# 
Uppgift - Skapa en gästbok:
- Skapa en konsolapplikation
- Inmatning av data
- Skapa klasser
- Felhantering och validering, inga tomma fält
- Inmatning i form av två fält ska serialiseras/deserialiseras
- Data ska lagras i json fil
- Lägga till och ta bort data(inlägg) via konsolinmatning
- Menyval skrivs om med console.Clear för varje förändring i gästboken
*/


namespace Moment3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Guest userFirst = new Guest("Hanin", "Hej mitt namn är Hanin");
            //Console.WriteLine(userFirst.GuestUser);
            //Console.ReadLine();

            bool isTrue = true;
            string guestBookAdmin = "H a n i n s  G ä s t b o k";

            while (isTrue)
            {
                //Rensar konsollen
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"{guestBookAdmin.ToUpper()} \n");
                Console.WriteLine("Tryck på följande alternativ: \n");
                Console.WriteLine("1 : Skriv i gästboken");
                Console.WriteLine("2 : Ta bort inlägg från gästboken \n");
                Console.WriteLine("X : Avsluta \n");

                ShowAvailableGuestBook();
            }
        }

        private static void ShowAvailableGuestBook()
        {
            //Skapar ny instans guestbook
            GuestBook guestBook = new GuestBook();
            Console.WriteLine("Följande inlägg är lagrade: \n");

            for (int i = 0; i < guestBook.GetGuests().Count; i++)
            {
                Guest guestAvailableNow = guestBook.GetGuests()[i];
                Console.WriteLine($"[{i}] {guestAvailableNow.GuestName} : {guestAvailableNow.GuestMessage}");
            }
            int totalCountGuests = guestBook.CountGuests();
            Console.WriteLine($"\nTotala antal lagrade inlägg: {totalCountGuests}\n");

            int userInputValue = (int)Console.ReadKey(true).Key;
            UserInput(userInputValue, guestBook);
            
        }

        private static void UserInput(int inputValue, GuestBook guestBook)
        {

            switch (inputValue)
            {
                case '1':
                    Console.CursorVisible = true;
                    Console.Write("Ange namn: ");
                    string? userGuestName = Console.ReadLine();
                    Console.Write("Ange meddelande: ");
                    string? userGuestMessage = Console.ReadLine();
                    guestBook.AddGuest(userGuestName, userGuestMessage);

                    break;
                default:
                    Console.WriteLine("Du har skrivit fel");
                    break;
            }


        }
    }
}
