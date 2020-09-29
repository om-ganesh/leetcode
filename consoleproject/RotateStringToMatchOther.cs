using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class RotateStringToMatchOther
    {
        List<Tuple<string, string>> data = new List<Tuple<string, string>>();

        public RotateStringToMatchOther()
        {
            data.Add(new Tuple<string, string>("ABC", "CAB"));
            data.Add(new Tuple<string, string>("ABCA", "ABC"));
            data.Add(new Tuple<string, string>("abcde", "cdeab"));
            data.Add(new Tuple<string, string>("abcde", "abced"));
        }

        public void Execute()
        {
            data.ForEach(t => {
                Console.WriteLine($"StringA: {t.Item1}, StringB: {t.Item2} can be same: {RotateString(t.Item1, t.Item2)}");
            });
        }

        private bool RotateString(string A, string B)
        {
            if(A.Length!=B.Length)
            {
                return false;
            }
            return (A + A).Contains(B);
        }
    }
}
