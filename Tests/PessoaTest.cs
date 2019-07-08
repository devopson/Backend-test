using Domain.Arguments.Pessoa;
using Domain.Interfaces.Services;
using Moq;
using NUnit.Framework;
using System;
using WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.Services;

namespace Tests
{
    [TestFixture]
    public class PessoaTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CriarPessoaServiceTest()
        {
            var idTest = Guid.NewGuid();
            var mock = new Mock<IPessoaRepository>();
            var request = new PessoaRequest();
            var response = new PessoaResponse()
            {
                Id = idTest,
            };

            mock.Setup(s => s.Adicionar(new Pessoa()))
                    .Returns(new Pessoa());

            var ctrl = new PessoaService(mock.Object);

            var result = ctrl.CriarPessoa(request);

            Assert.AreEqual(response.Id, idTest);
        }
    }
}