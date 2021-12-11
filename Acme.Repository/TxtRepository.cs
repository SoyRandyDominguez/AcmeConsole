using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Repository
{
    public class TxtRepository : ITxtRepository
    {
        private static readonly string _url_txt = @"C:\Users\Oriontek\source\repos\CONSOLE_ACME\Acme.Repository\Data\database.txt";
        //correction in path to point it in Root directory
        public Dictionary<string, string> GetDataFromTXT()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                List<string> listFromTXT = System.IO.File.ReadAllLines(_url_txt).ToList();
                List<string[]> listSplitted = new List<string[]>();

                int totalRecords = listFromTXT.Count();
                for (int i = 0; i < totalRecords; i++)
                {
                    if (listFromTXT[i].Contains("="))

                        listSplitted.Add(listFromTXT[i].Split('='));
                    else
                    {
                        listFromTXT.RemoveAt(i);
                        i--; totalRecords--;
                    }
                }

                listSplitted.ForEach(x => {
                    result.Add(x[0], x[1]);
                });
            }
            catch (Exception e)
            {
                return null;
            }

            return result;
        }

        public Dictionary<string, string> GetFakeData(int cant, int initValue = 0)
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
            for (int i = initValue; i < cant + initValue; i++)
            {
                dataFiltered.Add(data.ToArray()[i].Key, data.ToArray()[i].Value);
            }
            return dataFiltered;
        }
    }
}
