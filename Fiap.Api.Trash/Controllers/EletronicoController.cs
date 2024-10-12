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
    public class EletronicoController : ControllerBase
    {
        private readonly IEletronicoService _eletronicoService;
        private readonly IMapper _mapper;

        public EletronicoController(IEletronicoService eletronicoService, IMapper mapper)
        {
            _eletronicoService = eletronicoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<EletronicoViewModel>> Get()
        {
            var lista = _eletronicoService.ListarEletronico();
            var viewModelList = _mapper.Map<IEnumerable<EletronicoViewModel>>(lista);

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
        public ActionResult<EletronicoViewModel> Get([FromRoute] int id)
        {
            var model = _eletronicoService.ObterEletronicoPorId(id);


            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<EletronicoViewModel>(model);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = "analista,gerente")]
        public ActionResult Post([FromBody] EletronicoViewModel viewModel)
        {
            var model = _mapper.Map<EletronicoModel>(viewModel);
            _eletronicoService.CriarEletronico(model);

            return CreatedAtAction(nameof(Get), new { id = model.EletronicoId }, model);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put([FromRoute] int id, [FromBody] EletronicoViewModel viewModel)
        {
            if (viewModel.EletronicoId == id)
            {
                var model = _mapper.Map<EletronicoModel>(viewModel);
                _eletronicoService.AtualizarEletronicos(model);
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
            _eletronicoService.DeletarEletronicos(id);
            return NoContent();
        }
    }
}
