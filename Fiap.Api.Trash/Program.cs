using AutoMapper;
using Fiap.Api.Trash.Data;
using Fiap.Api.Trash.Data.Repository;
using Fiap.Api.Trash.Models;
using Fiap.Api.Trash.Services;
using Fiap.Api.Trash.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
    );
#endregion

#region Registro IServiceCollection
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEletronicoRepository, EletronicoRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
builder.Services.AddScoped<IDescarteRepository, DescarteRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEletronicoService, EletronicoService>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
builder.Services.AddScoped<IDescarteService, DescarteService>();
#endregion

#region AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    //c.CreateMap<>();

    //c.CreateMap<CreatePedidoViewModel, PedidoModel>()
    //        .ForMember(dest => dest.PedidoProdutos, opt => opt.MapFrom(src =>
    //            src.ProdutoIds.Select(id => new PedidoProdutoModel { ProdutoId = id }).ToList()));

    //Usuário
    c.CreateMap<UsuarioModel, CreateUsuarioViewModel>();
    c.CreateMap<CreateUsuarioViewModel, UsuarioModel>();

    c.CreateMap<UsuarioModel, UsuarioViewModel>();
    c.CreateMap<UsuarioViewModel, UsuarioModel>();

    c.CreateMap<UsuarioModel, UsuarioUpdateViewModel>();
    c.CreateMap<UsuarioUpdateViewModel, UsuarioModel>();

    c.CreateMap<UsuarioModel, UsuarioPaginacaoViewModel>();
    c.CreateMap<UsuarioPaginacaoViewModel, UsuarioModel>();

    c.CreateMap<UsuarioModel, UsuarioPaginacaoReferenciaViewModel>();
    c.CreateMap<UsuarioPaginacaoReferenciaViewModel, UsuarioModel>();

    //Eletronico
    c.CreateMap<EletronicoModel, CreateEletronicoViewModel>();
    c.CreateMap<CreateEletronicoViewModel, EletronicoModel>();

    c.CreateMap<EletronicoModel, EletronicoViewModel>();
    c.CreateMap<EletronicoViewModel, EletronicoModel>();

    c.CreateMap<EletronicoModel, EletronicoUpdateViewModel>();
    c.CreateMap<EletronicoUpdateViewModel, EletronicoModel>();

    //Descarte
    c.CreateMap<DescarteModel, DescarteViewModel>();
    c.CreateMap<DescarteViewModel, DescarteModel>();

    //Notificação
    c.CreateMap<NotificacaoModel, NotificacaoViewModel>();
    c.CreateMap<NotificacaoViewModel, NotificacaoModel>();
}
);

// Cria o mapper com base na configuração definida
IMapper mapper = mapperConfig.CreateMapper();

// Registra o IMapper como um serviço singleton no container de DI do ASP.NET Core
builder.Services.AddSingleton(mapper);
#endregion


#region Auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
