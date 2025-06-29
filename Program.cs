using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LiczbyPierwsze16_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rangeTo = 10000;
            int columns = 60;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // funkcja
            FindPrimeNumbersInColumns(rangeTo, columns);

            stopwatch.Stop();
            Console.WriteLine($"Czas wykonania: {stopwatch.ElapsedMilliseconds} ms");

            //FindPrimeNumbers(rangeTo);


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

        static void FindPrimeNumbersInColumns(int n, int columns)
        {
            int numberOfDigits = n.ToString().Length+2;
            int counterColumns = columns;
            ConsoleColor primeColor = ConsoleColor.Green;
            if (n <= 3)
            {
                CheckTrivialPrimes(n);
                return;
            }   

            // wypisanie podstawowych liczb pierwszych
            Console.WriteLine($"Podany zakres {n}");

            // 1
            Console.BackgroundColor = primeColor;
            Console.Write(1 + new string(' ', numberOfDigits - 1));
            Console.ResetColor();
            Console.Write("|");

            // 2
            Console.BackgroundColor = primeColor;
            Console.Write(2 + new string(' ', numberOfDigits - 1));
            Console.ResetColor();
            Console.Write("|");

            // 3
            Console.BackgroundColor = primeColor;
            Console.Write(3 + new string(' ', numberOfDigits - 1));
            Console.ResetColor();
            Console.Write("|");

            counterColumns -= 3;

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


                        Console.BackgroundColor = primeColor;
                        Console.Write(i + new string(' ', numberOfDigits - i.ToString().Length));
                        Console.ResetColor();
                        Console.Write("|");
                        counterColumns--;
                    }
                    else
                    {
                        Console.Write(i + new string(' ', numberOfDigits - i.ToString().Length) + "|");
                        counterColumns--;
                    }
                }
                else
                {
                    Console.Write(i + new string(' ', numberOfDigits - i.ToString().Length) + "|");
                    counterColumns--;
                }

                if (counterColumns <= 0)
                {
                    Console.WriteLine();
                    counterColumns = columns;
                }
            }
            Console.WriteLine();
            Console.WriteLine("To wszystko, pozdrawiam");
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
