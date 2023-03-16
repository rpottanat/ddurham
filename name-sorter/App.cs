using name_sorter_library.Service;

namespace name_sorter
{
    public class App
    {
        private readonly IFileService _fileService;
        private const string OutPutFileName = $"Document\\sorted-names-list.txt";
        private const string filePath = $"Document\\unsorted-names-list.txt";

        public App(IFileService fileService )
        {
            _fileService = fileService;
        }

        internal async Task Run(string[] args)
        {
           // string filePath = args[0];           

          //  filePath = $"Document\\{filePath}";

            var names = await _fileService.ReadFromFile(filePath);

            _ = await _fileService.WriteToFile(OutPutFileName, names);

            names = await _fileService.ReadFromFile(OutPutFileName);

            foreach (var name in names)
            {
                Console.WriteLine(name.ToString());
            }
        }
    }
}
