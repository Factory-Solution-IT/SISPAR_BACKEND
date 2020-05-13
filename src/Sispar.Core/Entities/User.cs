using Sispar.Common.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sispar.Common.Helpers;

namespace Sispar.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Boolean Active { get; set; } = true;

        public void SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotEmpty(password, "Senha não pode ser vazio");
            AssertionConcern.AssertArgumentNotEmpty(confirmPassword, "Confirma senha não pode ser vazio");
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, "Senha e confirma senha são diferentes");

            this.Password = password.Encrypt();
        }
    }
}
