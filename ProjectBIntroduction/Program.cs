using ProjectBIntroduction.FrontEnd;
using ProjectBIntroduction.Server;

namespace ProjectBIntroduction
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            new Client(new Api()).Run();
        }
    }
}