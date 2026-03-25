using APBD_Projekt2.Enums;
using APBD_Projekt2.Loans;
using APBD_Projekt2.Users;
using System.Linq;

namespace APBD_Projekt2.Services;

public class LoanService : ILoanService
{
    private readonly List<Loan> _wypozyczenia = new();
    private int _nastpId = 1;

    public Loan WypozyczSprzet(User uzytkownik, Equipment.Equipment sprzet, int dni)
    {
        if (sprzet.Dostepnosc != EquipmentStatus.Dostepny)
            throw new Exception("Sprzęt niedostępny.");

        var aktualneWypozyczenia = _wypozyczenia.Count(w => w.Uzytkownik == uzytkownik && !w.czyOddane);

        if (aktualneWypozyczenia >= uzytkownik.maxLoan)
            throw new Exception("Przekroczono limit wypożyczeń.");

        var wypozyczenie = new Loan(
            _nastpId++,
            uzytkownik,
            sprzet,
            DateTime.Now,
            DateTime.Now.AddDays(dni)
        );
        
        _wypozyczenia.Add(wypozyczenie);
        
        sprzet.UstawJakoWypozyczone();
        return wypozyczenie;
    }

    public void ZwrocSprzet(Loan wypozyczone)
    {
        wypozyczone.Zwrot(DateTime.Now);
        wypozyczone.Sprzet.UstawJakoDostepne();
    }

    public List<Loan> GetAktualneWypozyczenia(User uzytkownik)
    {
        return _wypozyczenia.Where(w => w.Uzytkownik == uzytkownik && !w.czyOddane).ToList();
    }

    public List<Loan> GetOpoznioneWypozyczenia()
    {
        return _wypozyczenia.Where(w=>!w.czyOddane && w.TerminZwrotu<DateTime.Now).ToList();
    }
    
    //NALICZANIE KARY
    public decimal NaliczanieKary(Loan wypozyczenie)
    {
        if (wypozyczenie.TerminZwrotu < DateTime.Now)
        {
            var dni = (DateTime.Now - wypozyczenie.TerminZwrotu).Days;
            return dni * 5; //łatwa do zmiany wartość
        }

        return 0;
    }

    public void GenerujRaport(List<Equipment.Equipment> sprzet)
    {
        var calySprzet = sprzet.Count;
        var dostepny =  sprzet.Count(e=>e.Dostepnosc == EquipmentStatus.Dostepny);
        var niedostepny = calySprzet - dostepny;
        
        var aktualneWypozyczenia = _wypozyczenia.Count(w=>!w.czyOddane);
        var spoznioneWypozyczenia = _wypozyczenia.Count(w=>!w.czyOddane &&  w.TerminZwrotu < DateTime.Now);
        
        Console.WriteLine("\n ----------RAPORT---------");
        Console.WriteLine($"Liczba sprzętu: {calySprzet}");
        Console.WriteLine($"Dostepne: {dostepny}");
        Console.WriteLine($"Niedostepne: {niedostepny}");
        Console.WriteLine($"Aktywne wypożyczenia: {aktualneWypozyczenia}");
        Console.WriteLine($"Przeterminowane:  {spoznioneWypozyczenia}");
        Console.WriteLine("----------------------------");
    }
}