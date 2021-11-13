namespace DotNet6MinApi.Services
{
    public interface IZipService
    {
        IEnumerable<string> ZipResult(List<string> list1, List<string> list2, List<long?> list3);
    }
}
