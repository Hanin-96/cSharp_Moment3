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
        //Skapar global error msg
        static public string errorMessage = "";

        //Skapar global namn sträng
        static public string guestBookAdmin = "H a n i n s  G ä s t b o k";
        static void Main(string[] args)
        {

            //Guest userFirst = new Guest("Hanin", "Hej mitt namn är Hanin");
            //Console.WriteLine(userFirst.GuestUser);
            //Console.ReadLine();

            bool isTrue = true;
            //Skapar ny instans guestbook
            GuestBook guestBook = new GuestBook();

            while (isTrue)
            {
                DefaultInterface(guestBook);
                if(errorMessage!= "" && errorMessage != null)
                {
                    Console.WriteLine($"{errorMessage}");
                }
                int userInputValue = (int)Console.ReadKey(true).Key;
                UserInput(userInputValue, guestBook);
            }
        }

        private static void DefaultInterface(GuestBook guestBook)
        {
            //Rensar konsollen
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"{guestBookAdmin.ToUpper()} \n");
            Console.WriteLine("Tryck på följande alternativ: \n");
            Console.WriteLine("1 : Skriv i gästboken");
            Console.WriteLine("2 : Ta bort inlägg från gästboken \n");
            Console.WriteLine("X : Avsluta \n");

            ShowAvailableGuestBook(guestBook);
        }

        private static void ShowAvailableGuestBook(GuestBook guestBook)
        {
            Console.WriteLine("Följande inlägg är lagrade: \n");

            for (int i = 0; i < guestBook.GetGuests().Count; i++)
            {
                Guest guestAvailableNow = guestBook.GetGuests()[i];
                Console.WriteLine($"[{i}] {guestAvailableNow.GuestName} : {guestAvailableNow.GuestMessage}");
            }
            int totalCountGuests = guestBook.CountGuests();
            Console.WriteLine($"\nTotala antal lagrade inlägg: {totalCountGuests}\n");


            
        }

        private static void UserInput(int inputValue, GuestBook guestBook)
        {

            switch (inputValue)
            {
                case '1':
                    errorMessage = "";
                    Console.CursorVisible = true;
                    Console.Write("Ange namn: ");
                    string? userGuestName = Console.ReadLine();
                    Console.Write("Ange meddelande: ");
                    string? userGuestMessage = Console.ReadLine();
                    guestBook.AddGuest(userGuestName, userGuestMessage);

                    break;
                default:
                    errorMessage = "Fel input, vänligen tryck rätt alternativ \n";
                    break;
            }


        }
    }
}
