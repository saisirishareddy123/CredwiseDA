using CredWise.Services.Interface;
using CredWise.Services.Service.Implementations;
using CredWise.Rules.Interface;
using CredWise.Rules.Rules.Implementations;
using CredWise.Models;
using CredWise.API.Rules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

// Register core services
builder.Services.AddScoped<ILoanDecisionService, LoanDecisionService>();

// Register all rules
builder.Services.AddSingleton<ILoanRule, LoanAmountRule>();
builder.Services.AddSingleton<ILoanRule, ExistingLoanRule>();
builder.Services.AddSingleton<ILoanRule, MinimumSalaryRule>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
