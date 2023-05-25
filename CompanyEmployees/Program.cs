using CompanyEmployees;
using CompanyEmployees.Extensions;
using CompanyEmployees.Presentation.ActionFilters;
using CompanyEmployees.Utility;
using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Service.DataShaping;
using Shared.DataTransferObjects;

var builder = WebApplication.CreateBuilder(args);

//2.4 Configuring Logger Service for Logging Messages
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

//9.2.1 Validation from the ApiController Attribute: 
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    //Disable automatic 400 response
    options.SuppressModelStateInvalidFilter = true;
});

//15. ActionFilters
builder.Services.AddScoped<ValidationFilterAttribute>();
//21. Supporting HATEOAS
builder.Services.AddScoped<ValidateMediaTypeAttribute>();

//20. Data Shaping
builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();

//21. Supporting HATEOAS
builder.Services.AddScoped<IEmployeeLinks, EmployeeLinks>();

//Add controllers from CompanyEmployees.Presentation project
//7.2 Changing the Default Configuration of Our Project JSON to XML
builder.Services.AddControllers(config => {
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.InputFormatters.Insert(0, JsonPatchInputFormatter.GetJsonPatchInputFormatter());
}).AddXmlDataContractSerializerFormatters()
    .AddCustomCSVFormatter() //Custom Response only for CompanyDto
    .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

//21. Supporting HATEOAS
builder.Services.AddCustomMediaTypes();

var app = builder.Build();

// Configure the HTTP request pipeline.

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
