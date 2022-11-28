using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDEPENDENT_WORK_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func, n);

            Action<Task<int[]>> action = new Action<Task<int[]>>(PrintSumm_Max);
            Task task2 = task1.ContinueWith(action);

            task1.Start();

            Console.ReadKey();
        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            Console.WriteLine("Сформированный массив:");
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 50);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            return array;
        }

        static void PrintSumm_Max(Task<int[]> task)
        {
            int[] array = task.Result;
            int sum = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array[i];
            }
            Console.WriteLine("Сумма чисел в массиве равна {0}", sum);

            int max = array[0];
            foreach (int a in array)
            {
                if (a > max)
                    max = a;
            }
            Console.WriteLine("Максимальное число в массиве {0}", max);
        }
    }
}
