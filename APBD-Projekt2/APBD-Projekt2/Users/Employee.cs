namespace APBD_Projekt2.Users;

public class Employee : User
{
    public Employee(int id, string imie, string nazwisko) : base(id, imie, nazwisko){}
    
    public override int maxLoan => 5;
}