using Dal;
using Bll;
using Entity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(option => option.AddPolicy("policy", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(DocumentIDAL), typeof(DocumentDAL));
builder.Services.AddScoped(typeof(DocumentIBLL), typeof(DocumentBLL));
builder.Services.AddScoped(typeof(DocReferanceIDAL), typeof(DocReferanceDAL));
builder.Services.AddScoped(typeof(DocReferanceIBLL), typeof(DocReferanceBLL));
builder.Services.AddScoped(typeof(TblAssistIDAL), typeof(TblAssistDAL));
builder.Services.AddScoped(typeof(TblAssistIBLL), typeof(TblAssistBLL));
builder.Services.AddScoped(typeof(TblAssistValueIDAL), typeof(TblAssistValueDAL));
builder.Services.AddScoped(typeof(ITblAssistValueIBLL), typeof(TblAssistValueBLL));
builder.Services.AddScoped(typeof(UserIDAL), typeof(UserDAL));
builder.Services.AddScoped(typeof(UserIBLL), typeof(UserBLL));
builder.Services.AddScoped(typeof(ViewLogIDAL), typeof(ViewLogDAL));
builder.Services.AddScoped(typeof(ViewLogIBLL), typeof(ViewLogBLL));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("policy");

app.MapControllers();

app.Run();
