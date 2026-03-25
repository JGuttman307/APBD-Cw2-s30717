namespace APBD_Projekt2.Users;

public class Student : User
{
    public Student( string imie, string nazwisko) : base( imie, nazwisko){}
    
    public override int maxLoan => 2;
    
    
}