using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Interfaces;

namespace TestTask.Models
{
    public class NewTransaction : ITransaction
    {
        public int ID { get; set; }
        public string Source { get; set; }
        public string Destiny { get; set; }
        public string Amount { get; set; }
    }
}
