using AutoFixture;
using Commom.Extensions;
using NUnit.Framework;
using POO_Ex_2;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnit_Tests
{
    public class POO_Ex_2_PessoaTest
    {
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void IdadePessoa_Success()
        {
            var pessoa = _fixture.Create<Pessoa>();
            Assert.IsTrue(pessoa.Idade() == pessoa.DataNascimento.CalculateAgeCurrentDate());
        }

        [Test]
        [TestCase("1992-10-15")]
        [TestCase("1992-03-04")]
        public void IdadePessoa_GreaterThanEighteen(DateTime birthDate)
        {
            var pessoa = new Pessoa() { Nome = "Kaio", DataNascimento = birthDate };

            Assert.IsTrue(pessoa.Idade() >= 18);
        }
    }
}
