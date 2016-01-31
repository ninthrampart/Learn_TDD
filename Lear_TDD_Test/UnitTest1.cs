using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Learn_TDD.Models.Interfaces;
using Learn_TDD.Models.Repositories;
using Moq;
using Learn_TDD.Models.Entities;
using System.Collections.Generic;

namespace Lear_TDD_Test
{
    [TestClass]
    public class ContractTest
    {
        IContractRepository _rep;

        public ContractTest()
        {
            _rep = new ContractRepository(@"Data Source=CHUDO-HP\SQLDEV;Initial Catalog=web_doverie;Integrated Security=True");
        }

        [TestMethod]
        public void Contract_GetAll_GotData()
        {
            int total = _rep.GetAll().Count;

            Assert.IsTrue(total > 0);
        }

        [TestMethod]
        public void Contract_GetById_Found()
        {
            var res = _rep.GetById(1);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void MockContract_GetAll_GotData()
        {
            Contract c1 = new Contract()
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Петров",
                MiddleName = "Вениаминович",
                Snils = "111-222-333 01"
            };

            Contract c2 = new Contract()
            {
                Id = 2,
                FirstName = "Иван",
                LastName = "Сидоров",
                MiddleName = "Вениаминович",
                Snils = "111-222-333 01"
            };
            List<Contract> contracts = new List<Contract> { c1, c2 };
            //int total = _rep.GetAll().Count;
            var mockCustomer = new Mock<Contract>();
            var mockRep = new Mock<IContractRepository>();
            mockRep.Setup(x => x.GetAll()).Returns(contracts);
              
            var tmp = mockRep.Object.GetAll();

            Assert.IsTrue(tmp.Count > 0);
            //.IsTrue(1 > 0);
        }
    }
}
