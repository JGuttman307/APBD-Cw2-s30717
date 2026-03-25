namespace APBD_Projekt2.Equipment;

public class Projector : Equipment
{
    public double Rozdzielczosc { get; }
    public string Marka { get; }
    public Projector(string nazwa, double rozdzielczosc, string marka) : base(nazwa)
    {
        Rozdzielczosc = rozdzielczosc;
        Marka = marka;
    }
}