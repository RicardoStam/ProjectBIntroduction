using System.Text.Json;

namespace Api.Mvc.Context
{
    internal abstract class AbsDataContext<T>
    {
        internal List<T> Data { get; set; }
        private readonly string path;

        internal AbsDataContext(string fileName)
        {
            if (!fileName.EndsWith(".json")) fileName += ".json";
            path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"Api\DataSources\"+fileName);
            Data = ReadFile();
        }

        private List<T> ReadFile()
        {
            try
            {
                string data = File.ReadAllText(path);
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
            File.WriteAllText(path, data);
        }
    }
}
