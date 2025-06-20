using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Accounting.Api.Features.Accounts.ChangePassword
{
    public class Request
    {
        public required string UserId { get; set; }
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
    }

    public class Response
    {
        public bool Saved { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User must be logged in.");
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Current Password is required.");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New Password is required.");
        }
    }
}