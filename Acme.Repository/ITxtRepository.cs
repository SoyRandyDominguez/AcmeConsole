using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Repository
{
    public interface ITxtRepository
    {
        Dictionary<string, string> GetDataFromTXT();
        Dictionary<string, string> GetFakeData(int cant, int initValue = 0);

    }
}
