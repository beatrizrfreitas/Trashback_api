using AutoMapper;
using Fiap.Api.Trash.Models;
using Fiap.Api.Trash.Services;
using Fiap.Api.Trash.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Fiap.Api.Trash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<UsuarioPaginacaoReferenciaViewModel>> Get([FromQuery] int referencia = 0, [FromQuery] int tamanho = 10)
        {
            var clientes = _usuarioService.ListarUsuariosUltimaReferencia(referencia, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<UsuarioModel>>(clientes);

            var viewModel = new UsuarioPaginacaoReferenciaViewModel
            {
                Usuario = viewModelList,
                PageSize = tamanho,
                Ref = referencia,
                NextRef = viewModelList.Last().UserId
            };


            return Ok(viewModel);
        }






        //[HttpGet]
        //[Authorize(Roles = "operador,analista,gerente")]
        //public ActionResult<IEnumerable<UsuarioPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 5)
        //{
        //    var usuario = _usuarioService.ListarUsuarios(pagina, tamanho);
        //    var viewModelList = _mapper.Map<IEnumerable<UsuarioModel>>(usuario);

        //    var viewModel = new UsuarioPaginacaoViewModel
        //    {
        //        Usuario = viewModelList,
        //        CurrentPage = pagina,
        //        PageSize = tamanho

        //    };

        //    return Ok(viewModel);
        //}


        [HttpGet("{id}")]
        [Authorize(Roles = "analista,gerente")]
        public ActionResult<UsuarioViewModel> Get([FromRoute] int id)
        {
            var model = _usuarioService.ObterUsuarioPorId(id);
            

            if (model == null)
            {
                return NotFound();
            } else
            {
                var viewModel = _mapper.Map<UsuarioViewModel>(model);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult Post([FromBody]UsuarioViewModel viewModel)
        {
            var model = _mapper.Map<UsuarioModel>(viewModel);
            _usuarioService.CriarUsuario(model);

            return CreatedAtAction(nameof(Get), new { id = model.UserId}, model);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "analista,gerente")]
        public ActionResult Put([FromRoute]int id, [FromBody] UsuarioViewModel viewModel)
        {
            if (viewModel.UserId == id)
            {
                var model = _mapper.Map<UsuarioModel>(viewModel);
                _usuarioService.AtualizarUsuario(model);
                return NoContent();
            } else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete([FromRoute] int id)
        {
            _usuarioService.DeletarUsuario(id);
            return NoContent();
        }
    }
}
