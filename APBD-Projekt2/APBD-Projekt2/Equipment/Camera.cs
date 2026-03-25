namespace APBD_Projekt2.Equipment;

public class Camera : Equipment
{
    public int KatWidzenia;
    public string Model;
    public Camera(string nazwa, int katwidzenia, string model) : base(nazwa)
    {
        KatWidzenia = katwidzenia;
        Model = model;

    }
}