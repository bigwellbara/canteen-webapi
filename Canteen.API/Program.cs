//removed the usings to make them global 
var builder = WebApplication.CreateBuilder(args);

//using extension methods to register services
builder.RegisterServices(typeof(Program));

var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));
app.Run();