namespace APBD_Projekt2.Users;

public abstract class User
{
    public int ID { get; }
    public string Imie { get; }
    public string Nazwisko { get; }

    public User(int id, string imie, string nazwisko)
    {
        ID = id;
        Imie = imie;
        Nazwisko = nazwisko;
    }
    public abstract int maxLoan { get; }
}