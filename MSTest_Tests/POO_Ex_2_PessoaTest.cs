using AutoFixture;
using Commom.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POO_Ex_2;
using System;

namespace MSTest_Tests
{
    [TestClass]
    public class POO_Ex_2_PessoaTest
    {
        private Fixture _fixture;

        public POO_Ex_2_PessoaTest()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        public void IdadePessoa_Success()
        {
            var pessoa = _fixture.Create<Pessoa>();
            Assert.IsTrue(pessoa.Idade() == pessoa.DataNascimento.CalculateAgeCurrentDate());
        }

        [DataTestMethod]
        [DataRow("1992-10-15")]
        [DataRow("1992-03-04")]
        public void IdadePessoa_GreaterThanEighteen(string birthDate)
        {
            var pessoa = new Pessoa() { Nome = "Kaio", DataNascimento = Convert.ToDateTime(birthDate) };

            Assert.IsTrue(pessoa.Idade() >= 18);
        }
    }
}
