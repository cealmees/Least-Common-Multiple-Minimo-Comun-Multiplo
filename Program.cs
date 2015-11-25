using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimo_común
{
    class Program
    {
        static void Main(string[] args)
        {
            int op1 = 0; 

            Console.WriteLine("Insert array lenght: ");
            op1 = Convert.ToInt32(Console.ReadLine());
            double[] array = new double[op1];
            for (int i = 0;i < op1; i++)
            {
                Console.WriteLine("Insert data ["+i+"]:  ");
                array[i] = Convert.ToDouble(Console.ReadLine());
            }

            int aux0 = op1 - 1;
            double[] num = new double[aux0];
            double[] den = new double[aux0];
            num[0] = numerador(1, 1, array[0], array[1]);
            den[0] = denominador(array[0], array[1]);

            int pom = op1 - 2;
            
            for (int a = 1; a < aux0; a++)
            {

                int aux = a + 1;
                int aux00 = a - 1;
                num[a] = numerador(num[aux00], den[aux00], 1, array[aux]);
                den[a] = denominador(den[aux00], array[aux]);

            }

            for (int i = 0; i < aux0; i++)
            {
                Console.WriteLine("Numerador [{0}]: " + num[i]+"      Denominador[{0}]: "+den[i], i,i);
            }

            Console.ReadLine();

            Console.WriteLine("Numerador: {0}", num[op1-2]);
            Console.WriteLine("Denominador: {0}", den[op1-2]);
            Console.WriteLine("Minimo divisor: {0}", mcd(num[op1-2], den[op1-2]));
            Console.WriteLine("Mínimo Común: {0}", (den[op1-2]/ mcd(num[op1-2],den[op1-2])));
            Console.ReadLine();
        }

        static double mcd(double numerador, double denominador)
        {
            double mcd = 0;
            double a = Math.Max(numerador, denominador);
            double b = Math.Min(numerador, denominador);
            do
            {
                mcd = b;
                b = a % b;
                a = mcd;
            } while (b != 0);
            return mcd;
        }



        static double numerador(double a, double b, double c, double d)
        {
            double numerador=0;
            numerador = a*d+b*c;
            return numerador;
        }
        static double denominador(double b, double d)
        {
            double denominador = 0;
            denominador = b * d;
            return denominador;
        }
    }
}
