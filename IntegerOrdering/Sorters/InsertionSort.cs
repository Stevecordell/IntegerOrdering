namespace IntegerOrdering.Sorters
{
    public class InsertionSort : IInsertionSort
    {
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
