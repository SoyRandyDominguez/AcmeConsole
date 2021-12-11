using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeConsole
{
    public class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_**_*_*_*_*_*_*");
            EmployeeTogetherFrequencyTable(getFakeData(3)); Console.WriteLine("");
            Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_**_*_*_*_*_*_*");
            EmployeeTogetherFrequencyTable(getFakeData(2,3));
            Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_**_*_*_*_*_*_*");
            Console.WriteLine("");
            Console.WriteLine("_*_*_*_*_*_*_ALL TOGETHER_*_*_*_*_*_*");
            EmployeeTogetherFrequencyTable(getFakeData(5));
            Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_**_*_*_*_*_*_*");
            Console.ReadLine();

        }
        public class Schedule
        {
            public string Day { get; set; }
            public string InitialHour { get; set; }
            public string EndHour { get; set; }
        }
        public class Employeeschedule
        {
            public string Name { get; set; }
            public List<string> Schedule { get; set; }
            public Employeeschedule()
            {
                Schedule = new List<string>();
            }
        }
        public static Dictionary<string, string> getFakeData(int cant, int initValue =0)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("RENE", "MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00- 21:00");
            data.Add("ASTRID", "MO10:00-12:00,TH12:00-14:00,SU20:00-21:00");
            data.Add("ANDRES", "MO10:00-12:00,TH12:00-14:00,SU20:00-21:00");
            data.Add("RANDY", "MO10:15-12:00,TU10:00-12:00,TH13:00-13:15,SA14:00-18:00,SU20:00-21:00");
            data.Add("ASHLEY", "MO10:00-12:00,TH12:00-14:00,SU20:00-21:00");

            if (cant <= 0)
                cant = 1;
            if (cant > data.Count())
                cant = data.Count();
            if (initValue > data.Count())
                initValue = 0;

            Dictionary<string, string> dataFiltered = new Dictionary<string, string>();
            for (int i = initValue; i < cant+initValue; i++)
            {
                dataFiltered.Add(data.ToArray()[i].Key, data.ToArray()[i].Value);
            }
            return dataFiltered;
        }

        public static List<Employeeschedule> DiccionaryToList(Dictionary<string, string> data)
        {
            List<Employeeschedule> employeeschedules = new List<Employeeschedule>();

            foreach (KeyValuePair<string, string> item in data)
            {
                Employeeschedule employeechedule = new Employeeschedule();
                employeechedule.Name = item.Key;
                //divide the schedules separed by "," getting a array of char and later converting it a list
                item.Value.Split(',').ToList().ForEach(x =>
                {
                    employeechedule.Schedule.Add(x);
                });

                employeeschedules.Add(employeechedule);
            }
            return employeeschedules;
        }

        public static bool EmployeeTogetherFrequencyTable(Dictionary<string, string> data)
        {
            bool result = false;
            //Convert dicctionary to list of object ( List<Employeeschedule> )
            try
            {
                List<Employeeschedule> employeeschedules = DiccionaryToList(data);


                List<Employeeschedule> results = new List<Employeeschedule>();
                for (int r = 0; r < employeeschedules.Count; r++)
                {
                    List<Employeeschedule> employeeschedulesAux = new List<Employeeschedule>();
                    employeeschedulesAux = employeeschedules;

                    for (int i = 0; i < employeeschedulesAux.Count; i++)
                    {
                        //validate employee name to not get duplicate 
                        if (employeeschedules[r].Name != employeeschedulesAux[i].Name)
                        {
                            Employeeschedule resultTable = new Employeeschedule();
                            employeeschedules[r].Schedule.ForEach(days =>
                            {
                                //ValidateSchedule, parametres: base day(First employye to compare) , List schedule of other employee
                                //return a string from the similar schedule
                                string SimilarSchedule = ValidateSchedule(days, employeeschedulesAux[i].Schedule);
                                if (SimilarSchedule != null && SimilarSchedule != "")
                                {
                                    resultTable.Name = employeeschedules[r].Name + " " + employeeschedulesAux[i].Name;
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
                    employeeschedules.Remove(employeeschedules[r]);
                }

                //Method to exec the console write
                if (results == null || results.Count() <= 0)
                    return false;

                Console.WriteLine("OUTPUT");
                results.ForEach(x =>
                {
                    Console.Write(x.Name.Replace(" ", "-") + ":");
                    int total = 0;
                    total = x.Schedule.Count();

                    Console.Write(total);
                    Console.WriteLine("");
                });
            }
            catch (Exception e )
            {
                return false;
            }

            return result;

        }
        public static string ValidateSchedule(string schedule1, List<string> schedule2)
        {
            if (schedule1 == "" || schedule1 == null)
                return "";
            if (!schedule2.Any()|| schedule2.Count() <=0)
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
