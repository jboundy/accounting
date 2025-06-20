using FastEndpoints;

namespace Accounting.Api.Features.Accounts.ResetPassword
{
    public class Request
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }

    public class Response
    {
        public bool Saved { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
}