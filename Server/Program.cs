﻿
using ExerciseDiary.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Exercisediary.Server.Controllers;
using Exercisediary.Server.DataInterfaces.LocationDataInterfaces;
using Exercisediary.Server.DataInterfaces.ExerciseTypeDataInterfaces;
using Exercisediary.Server.DataInterfaces.ExerciseDataInterfaces;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

                builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        options => options.UseNetTopologySuite());
});

builder.Services.AddScoped<IExerciseData, ExerciseData>();
builder.Services.AddScoped<IExerciseTypeData, ExerciseTypeData>();
builder.Services.AddScoped<ILocationData, LocationData>();
//var jsonoptions = new JsonSerializerOptions
//{
//    WriteIndented = true,
//    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
//    NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
    
//};
//builder.Services.AddSingleton(jsonoptions);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");



app.Run();
