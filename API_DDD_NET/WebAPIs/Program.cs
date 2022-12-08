using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.InterfacesExternal;
using Domain.Services;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Infrastructure.Repository.RepositoryExternal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPIs.Models;
using WebAPIs.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ConfigServices. --
builder.Services.AddDbContext<ContextBase>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();


// Configurações opcionais. --
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configuração de interface e repositório(injeção de dependência). --
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IMessage, RepositoryMessage>();
builder.Services.AddSingleton<IProduto, RepositoryProduto>();

// Serviço Dominio. --
builder.Services.AddSingleton<IServiceMessage, ServiceMessage>();

// JWT. --
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            // Posso modificar o teste pelo nome da empresa por ex.
            ValidIssuer = "Teste.Securiry.Bearer",
            ValidAudience = "Teste.Securiry.Bearer",
            // Criar um código da minha preferência.
            IssuerSigningKey = JWTSecurityKey.Create("Secret_key-12345678")
        };

        option.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });

// Configurações MAPPER. Models que serão automapedas .--
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<MessageViewModel, Message>();
    cfg.CreateMap<Message, MessageViewModel>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Forma 1, para utilizar o Cors. --
//var urlDev = "https://dominiodocliente.com.br";
//var urlDHML = "https://dominiodocliente2.com.br";
//var urlPROD = "https://dominiodocliente3.com.br";

//app.UseCors(b => b.WithOrigins(urlDEV, urlHML, urlPROD));


// Forma 2, para utilizar o Cors. --
var devClient = "http://localhost:4200";
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader().WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication(); // --
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI(); // --

app.Run();
