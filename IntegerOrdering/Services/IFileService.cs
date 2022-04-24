namespace IntegerOrdering.Services
{
    public interface IFileService
    {
        string GetLatestResults();
        bool WriteFile(int[] data);
    }
}