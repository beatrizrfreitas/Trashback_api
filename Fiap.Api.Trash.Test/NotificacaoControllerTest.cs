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
    public class NotificacaoControllerTest
    {

        private readonly Mock<DatabaseContext> _mockContext;
        private readonly NotificacaoController _notificacaoController;
        private readonly DbSet<NotificacaoModel> _mockSet;
        public NotificacaoControllerTest()
        {
            _mockContext = new Mock<DatabaseContext>();
            _mockSet = MockDbSet();
            _mockContext.Setup(m => m.Notificacoes).Returns(_mockSet);

        }

        private DbSet<NotificacaoModel> MockDbSet()
        {
            
            var data = new List<NotificacaoModel>
            {
                new NotificacaoModel { NotificacaoId = 1, Titulo = "Lixo eletronico" },
                new NotificacaoModel { NotificacaoId = 2, Titulo = "Descartes" }
            }.AsQueryable();
            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<NotificacaoModel>>();
            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<NotificacaoModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<NotificacaoModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<NotificacaoModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<NotificacaoModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewWithNotification()
        {
            // Act
            var result = _notificacaoController;

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            
            var model = Assert.IsAssignableFrom<IEnumerable<NotificacaoModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());


        }

        [Fact]
        public void Index_ReturnsViewWithoutNotification()
        {

            //Arrange
            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup(m => m.Notificacoes).Returns(_mockSet);

            // Act
            var result = _notificacaoController;

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<NotificacaoModel>>(viewResult.Model);

            Assert.Empty(model);


        }
    }
}
