# APBD Projekt

System wypożyczania sprzętu uczelniowego

Krótki Opis projektu:

Aplikacja konsolowa, napisana w C#, która umożliwia wypożyczanie i zwrot sprzętu uczelniowego. System umożliwia dodawanie nowych użytkownika i nowego rodzaju sprzętu. Nalicza on również kary za opóźniony zwrot sprzętu i generuje raport o aktualnym stanie wypożyczalni.



Funkcjonalności:

\-Dodawanie nowych użytkowników

\-Dodawanie nowego rodzaju sprzętu

\-Wypożyczanie sprzętu

\-Zwrot sprzętu

\-Naliczanie kary za przekroczenie terminu wypożyczenia

\-Sprawdzanie dostępności sprzętu

\-Sprawdzanie aktywnych i przeterminowanych wypożyczeń

\-Generowanie raportu o stanie wypożyczalni 



Projekt podzieliłam na osobne warstwy. Modele znajdują się odpowiednio w folderach Equipment, Users i Loans. Equipment przechowuje klasę abstrakcyjną Equipment wraz z jej klasami pochodnymi (model sprzętu). Folder EquipmentStatus prechowuje osobno Enum o dostępności sprzętu. W Users znajduje się klasa abstrakcyjna User i jej klasy pochodne (model użytkownika). Loans przechowuje klasę Loan (model wypożyczeń). W folderze Services znajduje się logika biznesowa projektu.

Program.cs leży osobno i zajmuje się interakcją z użytkownikiem.



Starałam się utrzymać kohezję i każdej klasie odpowiednio dać po jednej odpowiedzialności (LoanService obsługuje logikę, Program interakcje z użytkownikiem). Między klasami nie ma dużych zależności, aby uniknąć za dużego sprzężenia.

Modele danych nie zawierają logiki biznesowej dla wygodnej modyfikacji i przejrzystości kodu.



Zastosowanie zasad SOLID w moim kodzie:

\-SRP (Single Responsobility Principle)-klasy mają odpowiednio podzielone odpowiedzialności

\-OCP (Open/Closed Principle)-możliwe jest dodanie nowych typów sprzętu lub użytkownika bez modyfikacji kodu

\-DIP (Dependency Inversion Principle)-zastosowałam interfejs ILoanService



Czemu taki podział klas, plików i warstw?(Decyzje projektowe)

Modele danych umieściłam zdala od logiki biznesowej, aby ułatwić dopisywanie nowych typów, zwiększyć kohezję i zmniejszyć sprzężenie między komponentami. Użyłam klas abstrakcyjnych, by móc te różne nowe typy przypisywać. Klasy pochodne mają wtedy ważne pola z klasy pierwotnej, jak i dodatkowo mogą przechowywać dodatkowe własne pola.

Status sprzętu został zaimplementowany jako Enum, aby ułatwić dalszą rozbudowę. Całą logikę wypożyczeń umieściłam w LoanService. Interakcja z użytkownikiem całkowicie znajuduje się wyłącznie w pliku Program.cs. Obsługa błędów realizowana jest za pomocą wyjątków (a nie Console.Write()), aby metody jasno mówiły, że jest błąd i hamowały program.

