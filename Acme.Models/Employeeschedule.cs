using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Models
{
    public class EmployeeSchedule
    {
        public string Name { get; set; }
        public List<string> Schedule { get; set; }
        public EmployeeSchedule()
        {
            Schedule = new List<string>();
        }
    }
}
