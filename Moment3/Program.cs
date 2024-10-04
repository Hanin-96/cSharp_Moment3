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

            bool isTrue = true;
            //Skapar ny instans guestbook
            GuestBook guestBook = new GuestBook();

            while (isTrue)
            {
                //Ladda default gränssnittet på konsollen
                DefaultInterface(guestBook);
                //Ifall errormeddelande finns, ska den skrivas ut
                if (errorMessage != "" && errorMessage != null)
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
            //Skriver ut konsoll gränssnittet
            Console.WriteLine($"{guestBookAdmin.ToUpper()} \n");
            Console.WriteLine("Tryck på följande alternativ: \n");
            Console.WriteLine("1 : Skriv i gästboken");
            Console.WriteLine("2 : Ta bort inlägg från gästboken \n");
            Console.WriteLine("X : Avsluta \n");

            //Hämtar och visar tillgängliga inlägg
            ShowAvailableGuestBook(guestBook);
        }

        //method för att visa tillgängliga inlägg i gästboken
        private static void ShowAvailableGuestBook(GuestBook guestBook)
        {
            Console.WriteLine("Följande inlägg är lagrade: \n");

            //For-loop för att hämta varje gästinlägg 
            for (int i = 0; i < guestBook.GetGuests().Count; i++)
            {
                Guest guestAvailableNow = guestBook.GetGuests()[i];
                Console.WriteLine($"[{i}] {guestAvailableNow.GuestName} : {guestAvailableNow.GuestMessage}");
            }
            //Räknar ut antal lagrade inlägg
            int totalCountGuests = guestBook.CountGuests();
            Console.WriteLine($"\nTotala antal lagrade inlägg: {totalCountGuests}\n");



        }

        private static void UserInput(int inputValue, GuestBook guestBook)
        {
            switch (inputValue)
            {
                //Ifall användare trycker 1 och skapar nytt inlägg
                case '1':
                    errorMessage = "";
                    bool isRunning = true;

                    //Felhantering ifal tomma fält skickas in
                    //Strängarna får ej vara tomma
                    while (isRunning)
                    {
                        Console.Write("Ange namn: ");
                        string? userGuestName = Console.ReadLine();

                        Console.Write("Ange inlägg: ");
                        string? userGuestMessage = Console.ReadLine();

                        //Om namn eller 
                        if (string.IsNullOrEmpty(userGuestName) && string.IsNullOrEmpty(userGuestMessage))
                        {
                            isRunning = false;
                            errorMessage = "Du måste ange både namn och inlägg!";

                        } else if(string.IsNullOrEmpty(userGuestName) || string.IsNullOrEmpty(userGuestMessage))
                        {
                            isRunning = false;
                            errorMessage ="Du måste ange både namn och inlägg!";
                        }
                        else
                        {
                            //Om inputs inte är tomma, kör addGuest Method och skicka in namn och inlägg
                            isRunning = false;
                            guestBook.AddGuest(userGuestName, userGuestMessage);
                        }
                    }
                    break;

                //Ifall användare trycker 2 vid radering av inlägg
                case '2':
                    errorMessage = "";
                    Console.Write("Ange Index att radera: ");
                    string? userIndex = Console.ReadLine();
                    if(!string.IsNullOrEmpty(userIndex))
                        try
                        {
                            guestBook.DeleteGuest(Convert.ToInt32(userIndex));
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Fel index");
                            Console.ReadKey();
                        }
                    break;
                    //Lämna och stänga ner
                case 88:
                    Environment.Exit(0);
                    break;

                default:
                    errorMessage = "Fel input, vänligen tryck rätt alternativ \n";
                    break;
            }
        }
    }
}
