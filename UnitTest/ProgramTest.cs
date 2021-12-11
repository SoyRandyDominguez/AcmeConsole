using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AcmeConsole;
using System.Linq;

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
            data = Program.getFakeData(1);
            Assert.IsNotNull(data, "Something wrong");
            data = Program.getFakeData(cant);
            Assert.AreNotEqual(cant, data.Count());
        }

        [TestMethod]
        public void DiccionaryToList_With_Fake_Data()
        {
            List<Program.Employeeschedule> result = Program.DiccionaryToList(Program.getFakeData(3));
            Assert.IsNotNull(result, "Something wrong");
        }

        [TestMethod]
        public void EmployeeTogetherFrequencyTable_With_Fake_Data()
        {
            bool result = Program.EmployeeTogetherFrequencyTable(Program.getFakeData(1));
            Assert.IsFalse(result, "Something wrong");
        }
    }
}
