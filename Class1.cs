using System.Diagnostics;
using System.IO;
using Xunit;

namespace SearchAndSortAlerts
{
    public class ExtractStringFromFile
    {
        [Fact]
        public void ExtractTestCases()
        {
            try
            {
                var lines = File.ReadAllLines(@"C:\Users\.txt"); // change source
                var alert = "Knab.";
                var env = ":ciam: ";
                foreach (string line in lines)
                {
                    if (line.ToString().Contains(alert))
                    {
                        var aFrom = line.IndexOf(alert) + alert.Length;
                        var aTo = line.LastIndexOf("[FAIL]");
                        var aresults = line.Substring(aFrom, aTo - aFrom);

                        File.AppendAllText(@"C:\Users\WriteText.txt", aresults + '\n'); // change dest
                        Debug.WriteLine(aresults);

                    }
                    if (line.ToString().Contains(env))
                    {
                        var eFrom = line.IndexOf(env) + env.Length;
                        var eTo = line.LastIndexOf("BUILD State: FAILED");
                        var eresults = line.Substring(eFrom, eTo - eFrom);

                        File.AppendAllText(@"C:\Users\WriteText.txt", eresults + '\n');
                        Debug.WriteLine(eresults);
                    }
                }
            }
            catch (IOException ex)
            {
                System.Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
