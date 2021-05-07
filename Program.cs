using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica
{
    public class ThreadWork
    {
        public static void Dots()
        {
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('.');
                    System.Threading.Thread.Sleep(1000);
                    if (i == 2)
                    {
                        Console.Write("\r   \r");
                        i = -1;
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenidos a mi prueba tecnica, muchas gracias por darme esta oportunidad!\n");
            Console.WriteLine("A continuación luego de presionar 'Enter' para continuar");
            Console.WriteLine("Ingrese la fraccion a ser simplificada en el siguiente formato de ejemplo: 4/6");

            Thread thread1 = new Thread(ThreadWork.Dots);
            thread1.Start();
            Console.ReadLine();
            thread1.Abort();
            Console.WriteLine("Bienvenido a .NetSimplifier de Adolfo Moyano.\n");

            string command = Console.ReadLine();
            string[] fractionString = command.Split('/');
            int numerator = int.Parse(fractionString[0]);
            int denominator = int.Parse(fractionString[1]);
            float num;
            float denom;
            bool simple = false;
            while (simple == false)
            {
                denom = denominator;
                num = numerator;
                if ((numerator / 2 == num / 2) && (denominator / 2 == denom / 2))
                {
                    numerator /= 2;
                    denominator /= 2;
                }
                else if ((numerator / 3 == num / 3) && (denominator / 3 == denom / 3))
                {
                    numerator /= 3;
                    denominator /= 3;
                }
                else
                {
                    if ((numerator > denominator) && ((numerator / denominator) == (num / denominator)))
                    {
                        numerator /= denominator;
                        denominator /= denominator;
                    }

                    else if ((numerator <= denominator) && ((denominator / numerator) == (denom / numerator)))
                    {
                        denominator /= numerator;
                        numerator /= numerator;
                    }
                    Console.WriteLine(numerator + "/" + denominator);
                    simple = true;
                }
            }
        }
    }
}
