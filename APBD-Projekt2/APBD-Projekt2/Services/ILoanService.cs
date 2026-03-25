using APBD_Projekt2.Users;
using APBD_Projekt2.Equipment;
using APBD_Projekt2.Loans;

namespace APBD_Projekt2.Services;

public interface ILoanService
{
    public Loan WypozyczSprzet(User uzytkownik, Equipment.Equipment sprzet, int dni);
    public void ZwrocSprzet(Loan wypozyczone);
    
    List<Loan> GetAktualneWypozyczenia(User uzytkownik);
    List<Loan> GetOpoznioneWypozyczenia();
}