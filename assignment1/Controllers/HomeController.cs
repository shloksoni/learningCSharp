using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using assignment1.Models;

namespace assignment1.Controllers
{

    public class HomeController : Controller
    {
        private readonly INumberRepository _numberRepository;

        public HomeController(INumberRepository numberRepository)
        {
            _numberRepository = numberRepository;
            

            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string GuessNumber)
        {

            ViewBag.guess = GuessNumber;
            string CorrectAns =  _numberRepository.GenerateCorrectAns().CorrectAns;

            if(GuessNumber ==  CorrectAns) return View("Success");
            var guess = GuessNumber.ToCharArray();
            var correct = CorrectAns.ToCharArray();
            int bulls = 0, cows = 0;
            for(int i = 0; i < 4; i++)
            {
                if (guess[i] == correct[i]) bulls++;
                else
                {
                    for(int j = 0; j < 4; j++)
                    {
                        if(guess[i] == correct[j] && correct[j] != guess[j]){
                            cows++;
                            correct[j] = 'x';
                            break;
                        }
                    }
                }
            }

            ViewBag.bulls = bulls;
          
            ViewBag.cows = cows;
            return View();
        }
    }

}
