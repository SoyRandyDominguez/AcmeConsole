using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AcmeConsole;
using System.Linq;
using System.Configuration;

namespace UnitTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void FakeData()
        {
            int cant = 10;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data = Program.GetFakeData(1);
            Assert.IsNotNull(data, "Something wrong");
            data = Program.GetFakeData(cant);
            Assert.AreNotEqual(cant, data.Count());
        }

        [TestMethod]
        public void DiccionaryToList_With_Fake_Data()
        {
            List<Program.Employeeschedule> result = Program.DiccionaryToList(Program.GetFakeData(3));
            Assert.IsNotNull(result, "Something wrong");
        }

        [TestMethod]
        public void EmployeeTogetherFrequencyTable_With_Fake_Data()
        {
            bool result = Program.EmployeeTogetherFrequencyTable(Program.GetFakeData(1));
            Assert.IsFalse(result, "Something wrong");
        }


        [TestMethod]
        public void GetDataFromTXT()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result = Program.GetDataFromTXT();
            Assert.IsNotNull(result, "Something wrong");
        }
         

    }
}

