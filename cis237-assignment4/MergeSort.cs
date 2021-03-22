// Skylar Peters
// CIS 237
// 3/22/2021

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class MergeSort
    {
        // Merge a[lo .. mid] with a[mid+1 .. hi] using aux[lo .. hi]
        private static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {
            // Copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // Merge back to a[]
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                { // Index past left subarray max index
                    a[k] = aux[j++];
                }
                else if (j > hi)
                { // index past right subarray max index
                    a[k] = aux[i++];
                }
                // If first element is null it wont compare
                else if (aux[j].CompareTo(aux[i]) < 0)
                {
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }

        // Main entry point to sort
        public static void Sort(IComparable[] a)
        {
            IComparable[] aux = new IComparable[a.Length];
            // Temporary fix for null values, not good when creating new droids
            sort(a, aux, 0, a.Length - 93);
        }

        // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
        private static void sort(
            IComparable[] a,
            IComparable[] aux,
            int lo,
            int hi
          )
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            sort(a, aux, lo, mid);
            sort(a, aux, mid + 1, hi);
            merge(a, aux, lo, mid, hi);
        }
    }
}
