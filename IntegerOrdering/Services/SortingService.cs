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

        public string SortIntArray(int[] data)
        {
            try
            {
                _performance = string.Empty;
                var copy = data;

                DoSort(_insertionSorter, ref copy, out _elapsed);
                _performance = $"time for insertion sort = {_elapsed} milliseconds, ";
                DoSort(_bubbleSorter, ref data, out _elapsed);
                _fileService.WriteFile(data);
                _performance += $" - time for bubble sort = {_elapsed} milliseconds";
                return _performance;
            }
            catch (Exception)
            {
                throw;
            }




        }

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
                var copy = input;
                DoSort(_insertionSorter, ref copy, out _elapsed);
                _performance = $"time for insertion sort = {_elapsed} milliseconds, ";
                DoSort(_bubbleSorter, ref input, out _elapsed);
                _performance += $" - time for bubble sort = {_elapsed} milliseconds";

                _fileService.WriteFile(input);

                return _performance;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private bool DoSort(IIntegerSorter sorter, ref int[] data, out double elapsed)
        {
            try
            {
                _stopwatch.Start();
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
