using System;
using System.Globalization;

namespace MiejscaZerowe
{
    public class Program
    {
        public static void Main(string[] args)
        {
           

            if (args.Length == 0)
            {
                Console.Write("Podaj wartość współczynnika: a = ");
                string a = Console.ReadLine();

                Console.Write("Podaj wartość współczynnika: b = ");
                string b = Console.ReadLine();

                Console.Write("Podaj wartość współczynnika: c = ");
                string c = Console.ReadLine();

                Console.WriteLine(Calculate(new string[] { a, b, c }));
            }
            else
            {
                Console.WriteLine(Calculate(args));
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }

        public static string Calculate(string[] args)
        {

            // ilość współczynników

            int liczbaWspoczynnikow = args.Length;
            if (liczbaWspoczynnikow == 3)
            {
                double a = Double.Parse(args[0], CultureInfo.InvariantCulture.NumberFormat);
                double b = Double.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
                double c = Double.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);
                double x1, x2;
                if (a == 0 & b!=0 & c!=0)
                {
                    x1 = -c/ b;
                    return "Jedno miejsce zerowe: x0 = " + x1;

                }
                else if(a != 0 & b == 0 & c != 0)
                {
                    double delta =- (4 * a * c);
                    x1 = (- Math.Sqrt(delta)) / (2 * a);
                    x2 = (Math.Sqrt(delta)) / (2 * a);
                   
                    return "Dwa miejsca zerowe: x1 = " + Math.Round(x1, 2) + ", x2 = " + Math.Round(x2, 2);

                }
                else if(a != 0 & b != 0 & c == 0)
                {
                    x1 = (-b -b ) / (2 * a);
                    x2 = (-b + b) / (2 * a);

                    return "Dwa miejsca zerowe: x1 = " + Math.Round(x1, 2) + ", x2 = " + Math.Round(x2, 2);
                }
                else if(a == 0 & b == 0 & c != 0)
                  {
                    return "Brak miejsc zerowych.";
                }
                else if (a == 0 & b == 0 & c == 0)
                {
                    return "Nieskończenie wiele miejsc zerowych.";
                }
                else if (a == 0 & b != 0 & c == 0)
                {
                    return "Jedno miejsce zerowe: x0 = 0";
                }
                else { 
                    double delta = (b * b) - (4 * a * c);

                if (delta > 0)

                {

                    x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b + Math.Sqrt(delta)) / (2 * a);

                    return "Dwa miejsca zerowe: x1 = " + x1 + ", x2 = " + x2;
                }

                else if (delta == 0)

                {
                    x1 = -b / (2 * a);

                    return "Jedno miejsce zerowe: x0 = " + x1;
                }

                else

                    return "Brak miejsc zerowych.";

            }
        }
            else
            {
                if(liczbaWspoczynnikow == 0)
                {
                    return "Nie podano żadnych współczynników.";
                }
                else if(liczbaWspoczynnikow == 1)
                {
                    return "Podano 1 zamiast 3 współczynników.";
                }
                else if(liczbaWspoczynnikow == 2)
                {
                    return "Podano 2 zamiast 3 współczynników.";
                }
                else if(liczbaWspoczynnikow > 3)
                {
                    return "Podano więcej niż 3 współczynniki.";
                }
            }
            // wykluczenie liter ze wspolczynnikow

            // poprawny format wprowadzonych danych

            // calculate
            throw new NotImplementedException();

            // metoda oblicz()
            //
            //
            // Napisz implementację metody 'Calculate' obliczającej miejsca zerowe funkcji kwadratowej
            // o podanych współczynnikach a, b oraz c.
            //
            // Metoda ta przyjmuje jako argumenty jednowymiarowy string array 'args'
            // gdzie poszczególne elementy tego string array 'args' to współczynnyki a, b oraz c funkcji kwadratowej.
            //
            // Metoda ma zwracć informację o wyliczonych miejscach zerowych jako string, przy czym:
            // - pierwszy element string array 'args' to współczynnik a, drugi to współczynnik b, trzeci to współczynnik c
            // - wymagane jest podanie dokładnie trzech współczynników a. b oraz c
            // - jeśli string array 'args' zawiera mniej lub więcej niż trzy elementy, metoda zwrócić ma informację o błędzie
            // - jeśli wartość któregoś ze współczynników (elementy string array 'args') nie może zostać zapisana jako zmienna
            //   typu double, metoda zwrócić ma informację o błędnej wartości współczynnika
            // - dokładność wyliczenia miejsc zerowych to dwa miejsca po przecinku
            // - wartości ułamkowe współczynników mogą być podane wyłącznie z kropką jako separatorem części dziesiętnych,
            //   np. 1.3 lub 7.985 (wartość 1,3 lub 7,985 powinny być uznane za błędne)
            // - wartości ujemne współczynników oznaczane są poprzez - przed liczbą, np. -1.7 (wartość - 1.7 będzie zatem błędna)
            //
            // Aby ułatwić wykonanie tego zadania, w ramach solution dodany został drugi projekt 'TestMejscZerowych',
            // w którym zdefiniowane zostały testy sprawdzające poprawnośc implementacji metody 'Calculate'. Aby wykonać te testy,
            // otwóz Test Explorer (wybierz menu 'Test' -> 'Windows' -> 'Test Explorer') i kliknij 'Run All'.
            //
            // Metoda 'Main' pozwala na uruchomienie aplikacji 'MejscaZerowe' i zweryfikowania (manualnego) jakie rezultaty zwraca
            // metoda 'Calculate' (na początku próba dokonania obliczeń skończy się wyjątkiem, ponieważ metoda 'Calculate' nie
            // jest jeszcze zaimplementowana. Aby uruchomić 'MiejscaZerowe' po prostu klikniej 'Start' na pasku narzędzi.
            //
            // Zalecamy nie zmieniać implementacji metody 'Main', ponieważ nie to jest celem tego zadania.
            //
            // Wykonanie zadania NIE WYMAGA żadnych modyfikacji projektu 'TestMejscZerowych'.
            //
            // Aby możliwe było wykonanie testów, metoda 'Calculate' musi być metodą publiczną (to pozwala na dostęp do niej
            // z poziomu projektu TestMiejscZerowych.
        }
    }
}
