using Newtonsoft.Json;

namespace Accounting.Api.Models.Mail
{
    public class MailObjMessage
    {
        public MailObjMessage(string fromEmail, string fromName, string toEmail, string toName, string subject, string html)
        {
            From = new MessageEmailName
            {
                Email = fromEmail,
                Name = fromName
            };
            To =
                [
                    new MessageEmailName
                    {
                        Email = toEmail,
                        Name = toName
                    }
                ];

            Subject = subject;
            HTMLPart = html;
        }
        [JsonProperty("From")]
        public MessageEmailName From { get; set; }

        [JsonProperty("To")]
        public List<MessageEmailName> To { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("HTMLPart")]
        public string HTMLPart { get; set; }
    }

    public class MessageEmailName
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
