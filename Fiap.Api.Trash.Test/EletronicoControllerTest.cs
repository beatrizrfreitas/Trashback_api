using Fiap.Api.Trash.Controllers;
using Fiap.Api.Trash.Data;
using Fiap.Api.Trash.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Api.Trash.Test
{
    public class EletronicoControllerTest
    {
        private readonly Mock<DatabaseContext> _mockContext;
        private readonly EletronicoController _eletronicoController;
        private readonly DbSet<EletronicoModel> _mockSet;
        public EletronicoControllerTest()
        {
            _mockContext = new Mock<DatabaseContext>();
            _mockSet = MockDbSet();
            _mockContext.Setup(m => m.Eletronicos).Returns(_mockSet);

        }

        private DbSet<EletronicoModel> MockDbSet()
        {

            var data = new List<EletronicoModel>
            {
                new EletronicoModel { EletronicoId = 1, Nome = "Celular" },
                new EletronicoModel { EletronicoId = 2, Nome = "Notebook" }
            }.AsQueryable();
            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<EletronicoModel>>();
            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<EletronicoModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<EletronicoModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<EletronicoModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<EletronicoModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewWithEletronico()
        {
            // Act
            var result = _eletronicoController;

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);


            var model = Assert.IsAssignableFrom<IEnumerable<EletronicoModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());


        }

        [Fact]
        public void Index_ReturnsViewWithoutEletronico()
        {

            //Arrange
            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup(m => m.Eletronicos).Returns(_mockSet);

            // Act
            var result = _eletronicoController;

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<EletronicoModel>>(viewResult.Model);

            Assert.Empty(model);


        }
    }
}
