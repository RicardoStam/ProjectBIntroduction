using Api;
using ProjectBIntroduction.FrontEnd;

namespace ProjectBIntroduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Client(new Api.Api()).Run();
        }
    }
}