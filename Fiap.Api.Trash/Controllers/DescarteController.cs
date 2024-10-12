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
    public class DescarteController : ControllerBase
    {
        private readonly IDescarteService _descarteService;
        private readonly IMapper _mapper;

        public DescarteController(IDescarteService descarteService, IMapper mapper)
        {
            _descarteService = descarteService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<DescarteViewModel>> Get()
        {
            var lista = _descarteService.ListarDescarte();
            var viewModelList = _mapper.Map<IEnumerable<DescarteViewModel>>(lista);

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
        public ActionResult<DescarteViewModel> Get([FromRoute] int id)
        {
            var model = _descarteService.ObterDescartePorId(id);


            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<DescarteViewModel>(model);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = "analista,gerente")]
        public ActionResult Post([FromBody] DescarteViewModel viewModel)
        {
            var model = _mapper.Map<DescarteModel>(viewModel);
            _descarteService.CriarDescarte(model);

            return CreatedAtAction(nameof(Get), new { id = model.DescarteId }, model);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put([FromRoute] int id, [FromBody] DescarteViewModel viewModel)
        {
            if (viewModel.DescarteId == id)
            {
                var model = _mapper.Map<DescarteModel>(viewModel);
                _descarteService.AtualizarDescarte(model);
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
            _descarteService.DeletarDescarte(id);
            return NoContent();
        }
    }
}
