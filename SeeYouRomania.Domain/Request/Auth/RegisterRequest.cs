﻿namespace Domain.Request
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}