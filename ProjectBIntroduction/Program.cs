using ProjectBIntroduction.FrontEnd;
using ProjectBIntroduction.Server.Controller;
using ProjectBIntroduction.Server.Model;

namespace ProjectBIntroduction
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            new Client(new Server.Api()).Run();
        }
    }
}