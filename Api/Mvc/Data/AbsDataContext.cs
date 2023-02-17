using System.Text.Json;

namespace Api.Mvc.Data
{
    internal abstract class AbsDataContext<T>
    {
        public List<T> Data { get; set; }
        private string Path;

        public AbsDataContext(string fileName)
        {
            if (!fileName.EndsWith(".json")) fileName += ".json";
            Path = System.IO.Path.GetFullPath("C:\\hro\\Apiduction\\Apiduction\\Server\\Data\\Sources\\" + fileName);
            Data = ReadFile();
        }

        private List<T> ReadFile()
        {
            try
            {
                string data = File.ReadAllText(Path);
                return JsonSerializer.Deserialize<List<T>>(data);
            }
            catch (Exception)
            {
                throw new Exception("Unable to read the data file.");
            }
        }

        protected void SaveChanges()
        {            
            string data = JsonSerializer.Serialize(Data);
            File.WriteAllText(Path, data);
        }
    }
}
