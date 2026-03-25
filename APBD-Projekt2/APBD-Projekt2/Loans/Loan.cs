using APBD_Projekt2.Users;

namespace APBD_Projekt2.Loans;

public class Loan
{
    public int Id { get; }
    public User Uzytkownik { get; }
    public Equipment.Equipment Sprzet { get; }
    public DateTime DataWypozyczenia { get; }
    public DateTime TerminZwrotu { get; }
    
    public DateTime ? DataOddania { get; private set; }
    
    public bool czyOddane => DataOddania != null;

    public Loan(int id, User uzytkownik, Equipment.Equipment sprzet, DateTime dataWypozyczenia, DateTime terminZwrotu)
    {
        Id = id;
        Uzytkownik = uzytkownik;
        Sprzet = sprzet;
        DataWypozyczenia = dataWypozyczenia;
        TerminZwrotu = terminZwrotu;
    }

    public void Zwrot(DateTime dataOddania)
    {
        DataOddania = dataOddania;
    }
}