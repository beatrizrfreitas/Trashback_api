using AutoMapper;
using Fiap.Api.Trash.Models;
using Fiap.Api.Trash.Services;
using Fiap.Api.Trash.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Trash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoService _notificacaoService;
        private readonly IMapper _mapper;

        public NotificacaoController(INotificacaoService notificacaoService, IMapper mapper)
        {
            _mapper = mapper;
            _notificacaoService = notificacaoService;
        }

        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<NotificacaoViewModel>> Get()
        {
            var lista = _notificacaoService.ListarNotificacoes();
            var viewModelList = _mapper.Map<IEnumerable<NotificacaoViewModel>>(lista);

            if (viewModelList == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(viewModelList);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "analista,gerente")]
        public ActionResult<NotificacaoViewModel> Get([FromRoute] int id)
        {
            var model = _notificacaoService.ObterNotificacoesPorId(id);


            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<NotificacaoViewModel>(model);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = "gerente")]
        public ActionResult Post([FromBody] NotificacaoViewModel viewModel)
        {
            var model = _mapper.Map<NotificacaoModel>(viewModel);
            _notificacaoService.CriarNotificacao(model);

            return CreatedAtAction(nameof(Get), new { id = model.NotificacaoId }, model);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put([FromRoute] int id, [FromBody] NotificacaoViewModel viewModel)
        {
            if (viewModel.NotificacaoId == id)
            {
                var model = _mapper.Map<NotificacaoModel>(viewModel);
                _notificacaoService.AtualizarNotificacao(model);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete([FromRoute] int id)
        {
            _notificacaoService.DeletarNotificacao(id);
            return NoContent();
        }
    }
}
