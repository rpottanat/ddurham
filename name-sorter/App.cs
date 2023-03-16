using name_sorter_library.Service;

namespace name_sorter
{
    public class App
    {
        private const string OutPutFileName = $"Document\\sorted-names-list.txt";
        private readonly IFileService _fileService;

        public App(IFileService fileService)
        {
            _fileService = fileService;
        }

        internal async Task Run(string[] args)
        {
            string filePath = args[0];

            filePath = $"Document\\{filePath}";

            //read the input file and sort it
            var names = await _fileService.ReadFromFile(filePath);

            //write the result to outputfile
            _ = await _fileService.WriteToFile(OutPutFileName, names);

            //read the output file 
            var sortedNames = await _fileService.ReadFromFile(OutPutFileName);

            foreach (var name in sortedNames)
            {
                Console.WriteLine(name.ToString());
            }
        }
    }
}
