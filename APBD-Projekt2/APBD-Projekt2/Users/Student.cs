namespace APBD_Projekt2.Users;

public class Student : User
{
    public Student(int id, string imie, string nazwisko) : base(id, imie, nazwisko){}
    
    public override int maxLoan => 2;
    
    
}