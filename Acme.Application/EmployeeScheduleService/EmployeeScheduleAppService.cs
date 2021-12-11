using Acme.Models;
using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Application.EmployeeScheduleService
{
    public class EmployeeScheduleAppService : IEmployeeScheduleAppService
    {
        private readonly ITxtRepository _repository;
        public EmployeeScheduleAppService(ITxtRepository repository)
        {
            _repository = repository;
        }
        public List<EmployeeSchedule> DiccionaryToList(Dictionary<string, string> data)
        {
            List<EmployeeSchedule> EmployeeSchedules = new List<EmployeeSchedule>();

            foreach (KeyValuePair<string, string> item in data)
            {
                EmployeeSchedule employeechedule = new EmployeeSchedule();
                employeechedule.Name = item.Key;
                //divide the schedules separed by "," getting a array of char and later converting it a list
                item.Value.Split(',').ToList().ForEach(x =>
                {
                    employeechedule.Schedule.Add(x);
                });

                EmployeeSchedules.Add(employeechedule);
            }
            return EmployeeSchedules;
        }

        public bool GetEmployeeTogetherFrequencyTable()
        {
            bool result = false;
            try
            {
                Dictionary<string, string> data = _repository.GetDataFromTXT();
                //Convert dicctionary to list of object ( List<EmployeeSchedule> )
                if (data == null)
                    return false;

                List<EmployeeSchedule> EmployeeSchedules = DiccionaryToList(data);
                List<EmployeeSchedule> results = new List<EmployeeSchedule>();
                for (int r = 0; r < EmployeeSchedules.Count; r++)
                {
                    List<EmployeeSchedule> EmployeeSchedulesAux = new List<EmployeeSchedule>();
                    EmployeeSchedulesAux = EmployeeSchedules;

                    for (int i = 0; i < EmployeeSchedulesAux.Count; i++)
                    {
                        //validate employee name to not get duplicate 
                        if (EmployeeSchedules[r].Name != EmployeeSchedulesAux[i].Name)
                        {
                            EmployeeSchedule resultTable = new EmployeeSchedule();
                            EmployeeSchedules[r].Schedule.ForEach(days =>
                            {
                                //ValidateSchedule, parametres: base day(First employye to compare) , List schedule of other employee
                                //return a string from the similar schedule
                                string SimilarSchedule = ValidateSchedule(days, EmployeeSchedulesAux[i].Schedule);
                                if (SimilarSchedule != null && SimilarSchedule != "")
                                {
                                    resultTable.Name = EmployeeSchedules[r].Name + " " + EmployeeSchedulesAux[i].Name;
                                    resultTable.Schedule.Add(SimilarSchedule);
                                }
                                else
                                {
                                    result = false;
                                }


                            });
                            results.Add(resultTable);
                        }
                    }
                    //removing employee schedule from the list when finish the second loop
                    //to not get the same result but inverted ejem: RENE ANDRES =>  ANDRES RENE
                    //caused by the loop 
                    EmployeeSchedules.Remove(EmployeeSchedules[r]);
                }

                //Method to exec the console write
                if (results == null || results.Count() <= 0)
                    return false;

                Console.WriteLine("OUTPUT");
                System.Diagnostics.Debug.WriteLine("OUTPUT");
                results.ForEach(x =>
                {
                    Console.Write(x.Name.Replace(" ", "-") + ":");
                    System.Diagnostics.Debug.Write(x.Name.Replace(" ", "-") + ":");
                    int total = 0;
                    total = x.Schedule.Count();

                    Console.Write(total);
                    System.Diagnostics.Debug.Write(total);
                    Console.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("");
                });
            }
            catch (Exception e)
            {
                return false;
            }

            return result;
        }

        public string ValidateSchedule(string schedule1, List<string> schedule2)
        {
            if (schedule1 == "" || schedule1 == null)
                return "";
            if (!schedule2.Any() || schedule2.Count() <= 0)
                return "";
            //get the first two char used as day
            string mainDay = schedule1.Substring(0, 2);
            //get the time
            string mainTime = schedule1.Substring(2);
            Schedule schedule = new Schedule();

            schedule2.ForEach(x =>
            {
                //get the first two char used as day
                string secoundDay = x.Substring(0, 2);
                //get the time
                string secondTime = x.Substring(2);
                //divide the time in hours and minutes 
                string[] mainTimes = mainTime.Split('-');
                string[] secondTimes = secondTime.Split('-');
                //compare day MO == MO
                if (mainDay == secoundDay)
                {
                    //SET DAY IN THE OBJECT 
                    schedule.Day = mainDay;
                    //Going through the times  10:15[0]    12:00[1]
                    for (int i = 0; i < mainTimes.Length; i++)
                    {
                        if (mainTimes[i] == secondTimes[i])
                        {
                            //Setting Initial and End hours
                            if (i == 0)
                                schedule.InitialHour = mainTimes[0];
                            else
                                schedule.EndHour = mainTimes[1];
                        }
                    }
                    //if Initial and End hours are null, restart Schedule object
                    if (schedule.InitialHour == null && schedule.EndHour == null)
                        schedule = new Schedule();
                }
            });
            //Forming the string of schedule
            return schedule.Day + schedule.InitialHour + schedule.EndHour;
        }
    }
}
