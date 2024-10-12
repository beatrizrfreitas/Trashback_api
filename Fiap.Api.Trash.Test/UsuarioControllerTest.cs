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
    public class UsuarioControllerTest
    {
        private readonly Mock<DatabaseContext> _mockContext;
        private readonly UsuarioController _usuarioController;
        private readonly DbSet<UsuarioModel> _mockSet;
        public UsuarioControllerTest()
        {
            _mockContext = new Mock<DatabaseContext>();
            _mockSet = MockDbSet();
            _mockContext.Setup(m => m.Usuarios).Returns(_mockSet);

        }

        private DbSet<UsuarioModel> MockDbSet()
        {
            // Lista de clientes para simular dados no banco de dados
            var data = new List<UsuarioModel>
            {
                new UsuarioModel { UserId = 1, Nome = "Cliente 1" },
                new UsuarioModel { UserId = 2, Nome = "Cliente 2" }
            }.AsQueryable();
            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<UsuarioModel>>();
            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<UsuarioModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UsuarioModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UsuarioModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UsuarioModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewWithClients()
        {
            // Act
            var result = _usuarioController;

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            //var model = Assert.IsAssignableFrom<ClienteModel>(viewResult.Model);
            var model = Assert.IsAssignableFrom<IEnumerable<UsuarioModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());


        }

        [Fact]
        public void Index_ReturnsViewWithoutClients()
        {

            //Arrange
            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup(m => m.Usuarios).Returns(_mockSet);

            // Act
            var result = _usuarioController;

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            //var model = Assert.IsAssignableFrom<ClienteModel>(viewResult.Model);
            var model = Assert.IsAssignableFrom<IEnumerable<UsuarioModel>>(viewResult.Model);

            Assert.Empty(model);


        }
    }
}
