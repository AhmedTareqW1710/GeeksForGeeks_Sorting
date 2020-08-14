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


        private static int[]  MergeSort(int[] a, int leftIndex, int rightIndex)
        {

            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;

                MergeSort(a, leftIndex, middleIndex);

                MergeSort(a, middleIndex + 1, rightIndex);


                Merge(a, leftIndex, middleIndex, rightIndex);

            }

            return a;
        }

        private static int[] Merge(int[] arr, int left, int middle, int right)
        {
            // Get length of the two new subarrays
            int n1 = (middle - left) + 1;
            int n2 = right - middle;

            // Create two new arrays with the length calculated
            int[] L = new int[n1];
            int[] R = new int[n2];

            // Copy data to the new arrays 
            for (int i = 0; i < n1; ++i)
                L[i] = arr[left + i];
            for (int j = 0; j < n2; ++j)
                R[j] = arr[middle + 1 + j];

            // merge the two temp arrays

            // Initial indexes of first and second subarrays 
            int m = 0;
            int n = 0;

            // Initial index of merged subarry array 
            int k = left;
            while (m < n1 && n < n2)
            {
                if (L[m] <= R[n])
                {
                    arr[k] = L[m];
                    m++;
                }
                else
                {
                    arr[k] = R[n];
                    n++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (m < n1)
            {
                arr[k] = L[m];
                m++;
                k++;
            }

            /* Copy remaining elements of R[] if any */
            while (n < n2)
            {
                arr[k] = R[n];
                n++;
                k++;
            }

            return arr;
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

                int[] sortedArr = MergeSort(A, 0,n -1);

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
