namespace APBD_Projekt2.Equipment;

public class Laptop : Equipment
{
    public bool WindowslubMac{get;}
    public string Procesor { get; }
    public Laptop(string nazwa, bool windowslubMac, string procesor) : base(nazwa)
    {
        WindowslubMac = windowslubMac;
        Procesor = procesor;
    }
}