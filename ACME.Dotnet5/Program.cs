using Acme.Application.EmployeeScheduleService;
using Acme.Repository;
using System;

namespace ACME.Dotnet5
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeScheduleAppService _service = new EmployeeScheduleAppService(new TxtRepository());
            Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_**_*_*_*_*_*_*");
            Console.WriteLine("");
            if (!_service.GetEmployeeTogetherFrequencyTable()) { 
                Console.WriteLine("Error --- something wrong");
            }
            Console.WriteLine("");
            Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_**_*_*_*_*_*_*");
            Console.WriteLine("");
            Console.ReadLine();

        }
    }
}
