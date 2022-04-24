namespace IntegerOrdering.Sorters
{
    public class InsertionSort : IInsertionSort
    {
        /// <summary>
        /// Data sorting algorithm. InsertionSort
        /// </summary>
        /// <param name="data">the data to be sorted</param>
        /// <returns></returns>
        public bool Sort(ref int[] data)
        {
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    var item = data[i];
                    var currentIndex = i;
                    while (currentIndex > 0 && data[currentIndex - 1] > item)
                    {
                        data[currentIndex] = data[currentIndex - 1];
                        currentIndex--;
                    }
                    data[currentIndex] = item;
                }
                return true;
            }
            catch
            {
                throw;
            }

        }
    }
}
