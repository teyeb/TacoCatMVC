using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TacoCatMVC.Models;

namespace TacoCatMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reverse()
        {
            Palindrome model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reverse(Palindrome palidrome)
        {
            string inputValue = palidrome.InputWord;
            string reversedWord = "";

            for (int i = inputValue.Length - 1; i >= 0; i--)
            {
                reversedWord += inputValue[i];
            }

            palidrome.ReversedWord = reversedWord;

            reversedWord = Regex.Replace(reversedWord.ToLower(), "[^a-zA-Z0-9]+", "");
            inputValue = Regex.Replace(inputValue.ToLower(), "[^a-zA-Z0-9]+", "");


            if (reversedWord == inputValue)
            {
                palidrome.isPalindrome = true;
                palidrome.Message = $"Success {palidrome.InputWord} is a palindrome";
            }
            else
            {
                palidrome.isPalindrome = false;
                palidrome.Message = $"Oops, sorry {palidrome.InputWord} is NOT a palindrome";
            }

            return View(palidrome);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
