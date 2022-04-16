using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top50FacebookQuestions
{
    /// <summary>
    /// https://leetcode.com/problems/valid-palindrome
    /// </summary>
    class ValidPalindrome
    {
        List<string> data = new List<string>();
        public ValidPalindrome()
        {
            data.Add("A man, a plan, a canal: Panama");
            data.Add("nothing");
            data.Add("race tote car");
            data.Add("#@$%^");
            data.Add("");
            data.Add("#$%bbb#");
        }


        public void Execute()
        {
            data.ForEach(k =>
            {
                Console.WriteLine($"Is this Palindrome {string.Join(",", k)} =  {IsPalindrome(k)}");
            });
        }

        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                while (left<right && !IsAlphaNumeric(s[left]))
                {
                    left++;
                }
                while (left<right && !IsAlphaNumeric(s[right]))
                {
                    right--;
                }

                if (Char.ToLower(s[left++]) != Char.ToLower(s[right--]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsAlphaNumeric(char c)
        {
            return (c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c >= 97 && c <= 122);
        }
    }
}
