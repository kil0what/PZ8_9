using System;
using System.Linq;

namespace PasswordLibrary
{
    public class PasswordChecker
    {
        /// <summary>
        /// Метод для проверки пароля на соответствие требованиям безопасности.
        /// </summary>
        public static bool ValidatePassword(string password)
        {
            // 1. Проверка на null (защита от ошибок)
            if (string.IsNullOrEmpty(password)) return false;

            // 2. Проверка длины: от 8 до 20 символов
            if (password.Length < 8 || password.Length > 20)
                return false;

            // 3. Наличие хотя бы одной цифры
            if (!password.Any(char.IsDigit))
                return false;

            // 4. Наличие хотя бы одной строчной буквы
            if (!password.Any(char.IsLower))
                return false;

            // 5. Наличие хотя бы одной прописной (заглавной) буквы
            if (!password.Any(char.IsUpper))
                return false;

            // 6. Наличие спецсимволов из разрешенного списка
            char[] specialChars = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+' };
            if (!password.Intersect(specialChars).Any())
                return false;

            // Если все проверки пройдены
            return true;
        }
    }
}