using APBD_Projekt2.Enums;

namespace APBD_Projekt2.Equipment;

public abstract class Equipment
{
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public string Nazwa { get; }
    //private aby nie można było zmieniać
    public EquipmentStatus Dostepnosc { get; private set; } = EquipmentStatus.Dostepny;

    public Equipment(string nazwa)
    {
        Nazwa = nazwa;
    }
    
    public void UstawJakoWypozyczone()
    {
        Dostepnosc = EquipmentStatus.Wypozyczony;
    }
    public void UstawJakoDostepne()
    {
        Dostepnosc = EquipmentStatus.Dostepny;
    }
    public void UstawJakoNiedostepne()
    {
        Dostepnosc = EquipmentStatus.Niedostepny;
    }
}