using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using CSharpFunctionalExtensions;
using WL_DDD.Logic.Common;

namespace WL_DDD.Logic
{
    public class Email : ValueObject<Email>
    {
        private readonly string _value;

        private Email(string value)
        {
            _value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Fail<Email>("Email should not be empty");

            email = email.Trim();
            if (email.Length > 256)
                return Result.Fail<Email>("Email is too long");

            if (!Regex.IsMatch(email, @"^(+)@(.+)$"))
                return Result.Fail<Email>("Email is invalid");

            return Result.Ok(new Email(email));
        }

        protected override bool EqualsCore(Email other)
        {
            return _value == other._value;
        }

        protected override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }
    }
}
