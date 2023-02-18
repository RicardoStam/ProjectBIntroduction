using System.Text.Json;

namespace ProjectBIntroduction.Server.Data
{
    public abstract class AbsDataContext<T>
    {
        protected List<T> Data { get; set; }
        private string Path;

        public AbsDataContext(string fileName)
        {
            if (!fileName.EndsWith(".json")) fileName += ".json";
            string currentLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            
            Path = currentLocation + @"\Server\DataSources\" + fileName;
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
