using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ClassLibrary1
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MonsterNameAttribute : ValidationAttribute
    {
        private readonly MonsterType[] _allowedTypes;

        public MonsterNameAttribute(params MonsterType[] allowedTypes)
        {
            _allowedTypes = allowedTypes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var name = value as string;
            if (string.IsNullOrEmpty(name))
                return new ValidationResult("Имя не может быть пустым");

            var parts = name.Split('_');
            if (parts.Length < 2)
                return new ValidationResult("Неверный формат имени");

            if (!Enum.TryParse(parts[1], true, out MonsterType type))
                return new ValidationResult("Неизвестный тип монстра");

            if (!Array.Exists(_allowedTypes, t => t == type))
                return new ValidationResult($"Тип {type} не разрешен");

            return ValidationResult.Success;
        }
    }
}