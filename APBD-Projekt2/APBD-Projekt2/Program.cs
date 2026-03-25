
using APBD_Projekt2.Equipment;
using APBD_Projekt2.Services;
using APBD_Projekt2.Users;

//DANE
var uzytkownik1 = new Student("Jan", "Kowalski"); 
var uzytkownik2 = new Student("Wiktoria", "Cereniewicz");

var laptop = new Laptop("DELL", "Windows", "Core i5");
var projektor = new Projector("CO-FH01", 4000, "Epson");
var kamera = new Camera("Nikon", 120, "W181");
var kamera2 = new Camera("Canon", 110, "5D");


//SERWISY
var sprzetLista = new List<Equipment>();
var wypozyczenieSerwis = new LoanService();

//DODAJE DO LISTY
sprzetLista.Add(laptop);
sprzetLista.Add(projektor);
sprzetLista.Add(kamera);
sprzetLista.Add(kamera2);


//WYPOŻYCZANIE
try
{
    Console.Write("\n[Wypożyczenie sprzętu]:");

    var wypozyczenie = wypozyczenieSerwis.WypozyczSprzet(uzytkownik1, laptop, 3);
    Console.WriteLine($"Wypożyczono: {wypozyczenie.Sprzet.Nazwa}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//OBSŁUGA BŁĘDNYCH OPERACJI
//próba wypożyczenia niedostępnego sprzętu
try
{
    wypozyczenieSerwis.WypozyczSprzet(uzytkownik2, laptop, 2);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//przekroczenie limitu wypożyczeń użytkownika
try
{
    wypozyczenieSerwis.WypozyczSprzet(uzytkownik2, kamera, 2);
    wypozyczenieSerwis.WypozyczSprzet(uzytkownik2, projektor, 2);
    wypozyczenieSerwis.WypozyczSprzet(uzytkownik2, kamera2, 2);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

//ZWROT I KARA
var Wypozyczenie = wypozyczenieSerwis.GetAktualneWypozyczenia(uzytkownik1).First();

wypozyczenieSerwis.ZwrocSprzet(Wypozyczenie);

var kara = wypozyczenieSerwis.NaliczanieKary(Wypozyczenie);
Console.WriteLine($"Kara: {kara}");

//LISTY
Console.WriteLine("\nAktywne wypożyczenia:");
foreach (var w in wypozyczenieSerwis.GetAktualneWypozyczenia(uzytkownik1))
{
    Console.WriteLine(w.Sprzet.Nazwa);
}

//RAPORT
wypozyczenieSerwis.GenerujRaport(sprzetLista);