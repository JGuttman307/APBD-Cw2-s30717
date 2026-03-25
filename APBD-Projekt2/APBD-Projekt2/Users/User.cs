namespace APBD_Projekt2.Users;

public abstract class User
{
    private static int _nextId = 1;

    public int ID { get; } = _nextId++;
    public string Imie { get; }
    public string Nazwisko { get; }

    public User( string imie, string nazwisko)
    {
        Imie = imie;
        Nazwisko = nazwisko;
    }
    public abstract int maxLoan { get; }
}