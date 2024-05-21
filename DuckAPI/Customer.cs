namespace DuckAPI
{
    using System;
    using System.Threading.Tasks;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;

    public class Customer : IObserver
    {
        protected string name;
        public Customer(string name)
        {
            this.name = name;
        }

        public async Task notificationAsync()
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("moolmans20013@gmail.com", "Duckie ducks");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(this.name, "Duckie User");
            var plainTextContent = "You have recieved a Duckie Notification!!!!!";
            var htmlContent = "<strong>You have recieved a Duckie Notification!!!!!</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        void IObserver.notificationAsync()
        {
            notificationAsync().Wait();
        }
    }
}
