namespace Banking_Renamer
{
    public interface IFileFinder
    {
        string SearchPattern { get; set; }
        string SearchRegex { get; set; }
    }
}
