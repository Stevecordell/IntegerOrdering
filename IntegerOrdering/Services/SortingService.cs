using IntegerOrdering.Sorters;
using System;
using System.Diagnostics;
using System.Text;

namespace IntegerOrdering.Services
{
    public class SortingService : ISortingService
    {
        private IFileService _fileService;
        private IBubbleSort _bubbleSorter;
        private IInsertionSort _insertionSorter;
        private Stopwatch _stopwatch = new Stopwatch();
        private double _elapsed;
        private string _performance;
 

        public SortingService(IFileService fileService, IBubbleSort bubbleSorter, IInsertionSort insertionSorter)
        {
            _bubbleSorter = bubbleSorter;
            _insertionSorter = insertionSorter;
            _fileService = fileService;
        }

        /// <summary>
        /// called from sortArray endpoint
        /// </summary>
        /// <param name="data">the data to be sorted</param>
        /// <returns></returns>
        public string SortIntArray(int[] data)
        {
            try
            {
                _performance = string.Empty;

                //Make a copy of the original data for second call to SortData
                int[] copy = new int[data.Length];
                Array.Copy(data, copy, data.Length);

                DoSort(_insertionSorter, ref data, out _elapsed);
                _performance = $"time for insertion sort = {_elapsed} milliseconds, ";

                DoSort(_bubbleSorter, ref copy, out _elapsed);
                _fileService.WriteFile(data);

                _performance += $" - time for bubble sort = {_elapsed} milliseconds";
                return _performance;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Called from sortstring endpoint. The string is first parsed to an int array before passing to the sort method
        /// </summary>
        /// <param name="data">The string representing data to be sorted</param>
        /// <returns></returns>
        public string SortStringData(string data)
        {
            try
            {
                _performance = string.Empty;
                string[] original = data.Split(' ');
                int[] input = new int[original.Length];
                for (int i = 0; i < original.Length; i++)
                {
                    input[i] = int.Parse(original[i]);
                }
                int[] copy = new int[original.Length];
                Array.Copy(input, copy, input.Length); 

                DoSort(_insertionSorter, ref input, out _elapsed);
                _performance = $"time for insertion sort = {_elapsed} milliseconds, ";
                DoSort(_bubbleSorter, ref copy, out _elapsed);
                _performance += $" - time for bubble sort = {_elapsed} milliseconds";

                _fileService.WriteFile(input);

                return _performance;
            }
            catch (FormatException)
            {
                throw;
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Do the data sort depending on the type of sorter passed in
        /// </summary>
        /// <param name="sorter">The sorting algorithm to use for the sort</param>
        /// <param name="data">the data to be sorted</param>
        /// <param name="elapsed">measure of elapsed time to do the sort</param>
        /// <returns></returns>
        private bool DoSort(IIntegerSorter sorter, ref int[] data, out double elapsed)
        {
            try
            {
                _stopwatch.Restart();
                sorter.Sort(ref data);
                _stopwatch.Stop();
                elapsed = _stopwatch.Elapsed.TotalMilliseconds;
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
