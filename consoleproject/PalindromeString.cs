using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class PalindromeString
    {
        List<string> data = new List<string>();
        public PalindromeString()
        {
            data.Add("A man, a plan, a canal: Panama");
            data.Add("race a car");
        }

        public void Execute()
        {
            data.ForEach(d =>
            {
                Console.WriteLine($"The given string is Palindrome? {d} => {IsPalindrome(d)}");
            });
        }

        private bool IsPalindrome(string str)
        {
            if(str.Length<2)
            {
                return true;
            }

            str = str.ToLower();
            int i = 0;
            int j = str.Length - 1;
            while(i<j)
            {
                if(!isAlphaNumeric(str[i]))
                {
                    i++;
                }
                else if(!isAlphaNumeric(str[j]))
                {
                    j--;
                }
                else if(str[i] != str[j])
                {
                    return false;
                }
                else
                {
                    i++;
                    j--;
                }
            }

            return true;
        }

        private bool isAlphaNumeric(char c)
        {
            return (c > 47 && c < 58) || (c > 96 && c < 123);
        }
    }
}
