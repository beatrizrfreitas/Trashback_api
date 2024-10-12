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
    public class DescarteControllerTest
    {
        private readonly Mock<DatabaseContext> _mockContext;
        private readonly DescarteController _descarteController;
        private readonly DbSet<DescarteModel> _mockSet;
        public DescarteControllerTest()
        {
            _mockContext = new Mock<DatabaseContext>();
            _mockSet = MockDbSet();
            _mockContext.Setup(m => m.Descartes).Returns(_mockSet);

        }

        private DbSet<DescarteModel> MockDbSet()
        {

            var data = new List<DescarteModel>
            {
                new DescarteModel { DescarteId = 1, Endereco = "Rua Brasil" },
                new DescarteModel { DescarteId = 2, Endereco = "Rua Mexico" }
            }.AsQueryable();
            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<DescarteModel>>();
            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<DescarteModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DescarteModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DescarteModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DescarteModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewWithDescarte()
        {
            // Act
            var result = _descarteController;

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);


            var model = Assert.IsAssignableFrom<IEnumerable<DescarteModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());


        }

        [Fact]
        public void Index_ReturnsViewWithoutDescarte()
        {

            //Arrange
            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup(m => m.Descartes).Returns(_mockSet);

            // Act
            var result = _descarteController;

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<DescarteModel>>(viewResult.Model);

            Assert.Empty(model);


        }
    }
}
