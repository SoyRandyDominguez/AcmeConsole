using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AcmeConsole;
using System.Linq;
using System.Configuration;
using Acme.Application.EmployeeScheduleService;
using Acme.Repository;
using Acme.Models;

namespace UnitTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void FakeData()
        {
            ITxtRepository _repository = new TxtRepository();
            int cant = 10;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data = _repository.GetFakeData(1);
            Assert.IsNotNull(data, "Something wrong");
            data = _repository.GetFakeData(cant);
            Assert.AreNotEqual(cant, data.Count());
        }

        [TestMethod]
        public void DiccionaryToList_With_Fake_Data()
        {
            IEmployeeScheduleAppService _service = new EmployeeScheduleAppService(new TxtRepository());
            ITxtRepository _repository = new TxtRepository();
            List<EmployeeSchedule> result = _service.DiccionaryToList(_repository.GetFakeData(3));
            Assert.IsNotNull(result, "Something wrong");
        }

        [TestMethod]
        public void EmployeeTogetherFrequencyTable_With_Fake_Data()
        {
            IEmployeeScheduleAppService _service = new EmployeeScheduleAppService(new TxtRepository());
            bool result = _service.GetEmployeeTogetherFrequencyTable();
            Assert.IsFalse(result, "Something wrong");
        }


        [TestMethod]
        public void GetDataFromTXT()
        {
            ITxtRepository _repository = new TxtRepository();
            Dictionary<string, string> result = new Dictionary<string, string>();
            result = _repository.GetDataFromTXT();
            Assert.IsNotNull(result, "Something wrong");
        }
         

    }
}

