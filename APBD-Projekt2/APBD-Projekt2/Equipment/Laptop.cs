namespace APBD_Projekt2.Equipment;

public class Laptop : Equipment
{
    public string WindowslubMac{get;}
    public string Procesor { get; }
    public Laptop(string nazwa, string windowslubMac, string procesor) : base(nazwa)
    {
        WindowslubMac = windowslubMac;
        Procesor = procesor;
    }
}