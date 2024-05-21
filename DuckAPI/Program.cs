
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Xml.Linq;

namespace DuckAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();



            app.MapPost("/sendDuckie", (string useremail) =>
            {
                string email = useremail;
                Duckie micheal = new Duckie("Original");
                Customer newuser = new Customer(email);

                micheal.addSubscriber(newuser);
                micheal.notifySubscriber();
                return "Message sent";
            })
            .WithName("ValidateWord")
            .WithOpenApi();

            app.Run();
        }

    }
}
