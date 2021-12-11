using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Models;
namespace Acme.Application.EmployeeScheduleService
{
    public interface IEmployeeScheduleAppService
    {
        List<EmployeeSchedule> DiccionaryToList(Dictionary<string, string> data);
        bool GetEmployeeTogetherFrequencyTable();
        string ValidateSchedule(string schedule1, List<string> schedule2);
    }
}
