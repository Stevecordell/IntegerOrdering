using System;

namespace IntegerOrdering.Sorters
{
    public class BubbleSort : IBubbleSort
    { 
        /// <summary>
        /// Sorting algorithm. BubbleSort
        /// </summary>
        /// <param name="data">the data to be sorted</param>
        /// <returns></returns>
        public bool Sort(ref int[] data)
        {
            try
            {
                var itemMoved = false;
                do
                {
                    itemMoved = false;
                    for(int i=0; i< data.Length -1; i++)
                    {
                        if(data[i] > data[i +1])
                        {
                            (data[i], data[i + 1]) = (data[i + 1], data[i]);
                            itemMoved = true;
                        }
                    }
                } while (itemMoved);
                return true;
            }
            catch 
            {
                throw;
            }
        }
    }
}
