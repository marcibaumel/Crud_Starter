﻿namespace BackendPart.API.Entities
{
    public class UserEntity
    {
       
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}
