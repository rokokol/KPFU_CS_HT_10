using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public class Bookcase
    {
        public readonly List<Book> Books;

        public void Sort(Sortings.Compare compare)
        {
            void Swap(int a, int b, IList<Book> array)
            {
                (array[a], array[b]) = (array[b], array[a]);
            }
            int Partition(IList<Book> array, int minIndex, int maxIndex)
            {
                var pivot = minIndex - 1;
                for (var i = minIndex; i < maxIndex; i++)
                {
                    if (compare(array[i], array[maxIndex]) <= 0) continue;
                    pivot++;
                    Swap(pivot, i, array);
                }

                pivot++;
                Swap(pivot, maxIndex, array);
                return pivot;
            }
            
            IList<Book> QuickSort(IList<Book> array, int minIndex, int maxIndex)
            {
                if (minIndex >= maxIndex)
                {
                    return array;
                }

                var pivotIndex = Partition(array, minIndex, maxIndex);
                QuickSort(array, minIndex, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, maxIndex);

                return array;
            }

            QuickSort(Books, 0, Books.Count - 1);
        }
        
        public Bookcase(params Book[] books)
        {
            Books = new List<Book>(books);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var VARIABLE in Books)
            {
                sb.Append(VARIABLE).Append(' ');
            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }
    }
}