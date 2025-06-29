using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace LiczbyPierwsze16_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rangeTo = 0;

            FindPrimeNumbers(rangeTo);


        }

        static void CheckTrivialPrimes(int n)
        {
            // podstawowe sprawdzenie
            if (n < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                throw new Exception("Błąd podane \"n\" mniejsze niż 1");
            }
            if (n == 1)
            {
                Console.WriteLine($"Podany zakres {n}");
                Console.WriteLine($"Liczyb pierwsze to 1");
                return;
            }
            if (n == 2)
            {
                Console.WriteLine($"Podany zakres {n}");
                Console.WriteLine($"Liczyb pierwsze to 1 i 2");
                return;
            }
            if (n == 3)
            {
                Console.WriteLine($"Podany zakres {n}");
                Console.WriteLine($"Liczyb pierwsze to 1, 2 i 3");
                return;
            }
        }

        static void FindPrimeNumbers15(int n)
        {
            int numberOfDigits = n.ToString().Length+2;
            if(n <= 3)
            {
                CheckTrivialPrimes(n);
                return;
            }   

            // wypisanie podstawowych liczb pierwszych
            Console.WriteLine($"Podany zakres {n}");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(1 + new string(' ',numberOfDigits-1) + "|");
            Console.WriteLine(2 + new string(' ', numberOfDigits-1) + "|");
            Console.WriteLine(3 + new string(' ', numberOfDigits-1) + "|");
            Console.ResetColor();

            // pętla dla reszty
            for (int i = 4; i <= n; i++)
            {
                // jeżeli jest parzysta to sprawdzamy kolejną
                if (i % 2 != 0)
                {
                    int maxRangeDividers = (int)Math.Ceiling(Math.Sqrt(i)); // skrócenie szukania dzielników
                    bool isPrime = true;

                    // sprawdzanie jednego przypadku
                    for (int j = 2; j < maxRangeDividers; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                        }
                    }
                    if (isPrime)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(i + new string(' ', numberOfDigits - i.ToString().Length) + "|");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(i + new string(' ', numberOfDigits - i.ToString().Length) + "|");
                    }
                }
            }
        }

        static void FindPrimeNumbers(int n)
        {
            // przepisaie zmiennej
            Queue<int> primeNumbers = new Queue<int>();
            if (n <= 3)
            {
                CheckTrivialPrimes(n);
                return;
            }

            // wypisanie podstawowych liczb pierwszych
            Console.WriteLine($"Podany zakres {n}");
            primeNumbers.Enqueue(1);
            primeNumbers.Enqueue(2);

            // pętla dla reszty
            for (int i=4; i <= n; i++)
            {
                // jeżeli jest parzysta to sprawdzamy kolejną
                if (i % 2 != 0)
                {
                    int maxRangeDividers = (int)Math.Ceiling(Math.Sqrt(i)); // skrócenie szukania dzielników
                    bool isPrime = true;

                    // sprawdzanie jednego przypadku
                    for (int j = 2; j < maxRangeDividers; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                        }
                    }
                    if (isPrime) primeNumbers.Enqueue(i);
                }
            }

            int queueCounter = primeNumbers.Count;
            Console.WriteLine($"Podany zakres to od 1 do {n}");
            Console.WriteLine($"Znajduję się w nim {queueCounter} liczb pierwszych, są to:");
            while(queueCounter > 0)
            {
                queueCounter--;
                Console.WriteLine("Wartość: "+primeNumbers.Dequeue());
            }
   

        }

    }
}
