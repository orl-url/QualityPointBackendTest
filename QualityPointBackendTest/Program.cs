using qualityPointBackendTest.Profiles;
using qualityPointBackendTest.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().WithMethods("GET");
            policy.AllowCredentials();
            policy.AllowAnyHeader();
        });
    ;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DaDataService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var token = builder.Configuration.GetValue<string>("DaData:Token");
var secretKey = builder.Configuration.GetValue<string>("DaData:SecretKey");


builder.Services.AddHttpClient(
    "daData",
    client =>
    {
        client.BaseAddress = new Uri("https://cleaner.dadata.ru/api/v1/");
        client.DefaultRequestHeaders.Add("Authorization", token);
        client.DefaultRequestHeaders.Add("X-Secret", secretKey);
    });
builder.Services.AddAutoMapper(typeof(AddressProfile));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();


app.Run();