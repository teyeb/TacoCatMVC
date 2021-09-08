using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacoCatMVC.Models
{
    public class Palindrome
    {
        public string InputWord { get; set; }
        public string ReversedWord { get; set; }
        public bool isPalindrome { get; set; }
        public string Message { get; set; }
    }
}
