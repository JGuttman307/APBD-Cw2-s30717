namespace APBD_Projekt2.Users;

public class Employee : User
{
    public Employee( string imie, string nazwisko) : base( imie, nazwisko){}
    
    public override int maxLoan => 5;
}