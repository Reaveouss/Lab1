using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class BinarySearch
    {
        public static int Perform(double searchValue, List<double> listToSearch)
        {
            int left = 0;
            int right = listToSearch.Count - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (listToSearch[mid] == searchValue)
                {
                    return mid;
                }
                else if (listToSearch[mid] < searchValue)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
