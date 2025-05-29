using CredWise.Services.Interface;
using CredWise.Rules.Interface;
using CredWise.Rules.Rules.Implementations;
using CredWise.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

// Register service
builder.Services.AddScoped<ILoanDecisionService, LoanDecisionService>();

// Register rule implementations as a list
builder.Services.AddSingleton<ILoanRule, LoanAmountRule>();
builder.Services.AddSingleton<ILoanRule, ExistingLoanRule>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBankStatementService, BankStatementService>();

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
