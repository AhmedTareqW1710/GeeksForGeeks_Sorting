using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks_Sorting
{
    class Program
    {


        private static int[] SelectionSort(int[] a, int n)
        {
            int minIndex = 0;
            int startindex = 0;
            int i = 0;

            // the array is sorted when startindex is equal to the array length
            while (startindex < n)
            {
                // Get the min Index
                if (a[i] < a[minIndex])
                    minIndex = i;

                // Swap the min value with first value  
                if (i == n - 1)
                {
                    int temp = a[startindex];
                    a[startindex] = a[minIndex];
                    a[minIndex] = temp;
                    startindex++;
                    minIndex = startindex;
                    i = startindex;
                }
                else
                    i++;
            }

            return a;
        }



        static void Main(string[] args)
        {
            // Get Number of test cases
            int numberOfTestCases = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfTestCases; i++)
            {
                // Get Input array length
                int n = Convert.ToInt32(Console.ReadLine());

                // get Input array elemnts
                string[] arrStr = Console.ReadLine().Split(' ');

                int[] A = new int[n];

                for (int j = 0; j < n; j++)
                {
                    A[j] = Convert.ToInt32(arrStr[j].ToString());
                }

                int[] sortedArr = SelectionSort(A, n);

                string output = string.Empty;

                foreach (var item in sortedArr)
                {
                    output += " " + item.ToString();
                }

                Console.WriteLine(output.Trim());
                Console.ReadLine();
            }
        }
    }
}
