﻿using backend.DTO;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryDate { get; set; }

        public User() { }

        public User(int id, string nickname, string email, string password)
        {
            Id = id;
            Nickname = nickname;
            Email = email;
            Password = password;
        }

        public static User Map(UserRegisterDTO dto, string password)
        {
            User user = new User
            {
                Nickname = dto.Nickname,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = password,
                RefreshToken = string.Empty,
                RefreshTokenExpiryDate = DateTime.MinValue
            };
            return user;
        }

        public override string ToString() => $"Id: {Id} Nickname: {Nickname} Email: {Email}";
    }
}
