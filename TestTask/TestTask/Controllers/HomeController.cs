using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        TransactionService _transactionService;

        public HomeController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [Route("")]
        public IActionResult Index()
        {
            _transactionService.ReadFile();
            _transactionService.MatchTransactions();
            return View();
        }
    }
}
