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

            while(isTrue)
            {
                //Rensar konsollen
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"{guestBookAdmin.ToUpper()} \n");
                Console.WriteLine("Tryck på följande alternativ: \n");
                Console.WriteLine("1 : Skriv i gästboken");
                Console.WriteLine("2 : Ta bort inlägg från gästboken \n");
                Console.WriteLine("X : Avsluta");
                Console.ReadLine();
            }
        }
    }
}
