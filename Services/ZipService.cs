namespace DotNet6MinApi.Services
{
    public class ZipService : IZipService
    {
        public IEnumerable<string> ZipResult(List<string> list1, List<string> list2, List<long?> list3)
        {
            foreach ((string name, string role, long? action) in
            Enumerable.Zip(list1, list2, list3))
            {
                yield return $"{name} - {role} - {action}";
            }
        }
    }
}
