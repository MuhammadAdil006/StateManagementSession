add package 
MIcrosoft.aspnetcore.session

add in program.cs
before build
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);//ye wala session sirf 10 second ke liye valid rahe ga

});
builder.Services.AddControllersWithViews();


add after usestatic()

app.usesession();
in middleware


session is saving data on server side

knsa session kis user se belong krta ha to client side pr cookie me session ki id store krta ha


auto mappers 