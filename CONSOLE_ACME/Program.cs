using Acme.Application.EmployeeScheduleService;
using Acme.Models;
using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeConsole
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            IEmployeeScheduleAppService _service = new EmployeeScheduleAppService(new TxtRepository());
            Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_**_*_*_*_*_*_*");
            Console.WriteLine("");
            _service.GetEmployeeTogetherFrequencyTable();
            Console.WriteLine(""); 
            Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_**_*_*_*_*_*_*");
            Console.WriteLine("");
            Console.ReadLine();

        }
         
      
    }
}
