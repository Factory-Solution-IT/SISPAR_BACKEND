using System;

namespace Sispar.Api.Commands.Responses
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public bool IsValid { get; set; } = false;
    }
}