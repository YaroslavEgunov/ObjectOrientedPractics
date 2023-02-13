using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Classes
{
    /// <summary>
    /// Предоставляет методы для проверки введённых значений.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверяет, положительное ли значение у целого числа. 
        /// </summary>
        /// <param name="value">Проверяемое значение. </param>
        /// <param name="fieldName">Имя свойства или объекта, 
        /// которое подлежит проверке. </param>
        public static void AssertOnPositiveValue(int value,string fieldName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Enter a positive value in {fieldName}");
            }
        }

        /// <summary>
        /// Проверяет, положительное ли значение у вещественного числа. 
        /// </summary>
        /// <param name="value">Проверяемое значение. </param>
        /// <param name="fieldName">Имя свойства или объекта, 
        /// которое подлежит проверке. </param>
        public static void AssertOnPositiveValue(double value, string fieldName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Enter a positive value in {fieldName}");
            }
        }

        /// <summary>
        /// Проверяет, входит ли значение целого числа в заданный диапазон.
        /// </summary>
        /// <param name="value">Проверяемое значение. </param>
        /// <param name="min">Минимально допустимое значение. /param>
        /// <param name="max">Максимально допустимое значение. </param>
        /// <param name="fieldName">Имя свойства или объекта, 
        /// которое подлежит проверке. </param>
        public static void AssertValueInRange(int value, int min, int max, string fieldName)
        {
            if (!(value >= min) || !(value <= max))
            {
                throw new ArgumentException(
                    $"Enter a value  in {fieldName} within the valid range");
            }
        }

        /// <summary>
        /// Проверяет, входит ли значение вещественного числа в заданный диапазон.
        /// </summary>
        /// <param name="value">Проверяемое значение. </param>
        /// <param name="min">Минимально допустимое значение. /param>
        /// <param name="max">Максимально допустимое значение. </param>
        /// <param name="fieldName">Имя свойства или объекта, 
        /// которое подлежит проверке. </param>
        public static void AssertValueInRange(double value, double min, double max, string fieldName)
        {
            if (!(value >= min) || !(value <= max))
            {
                throw new ArgumentException(
                    $"Enter a value  in {fieldName} within the valid range");
            }
        }

        /// <summary>
        /// ПРоверяет, сожержит ли значение только буквы. 
        /// </summary>
        /// <param name="value">Проверяемое значение. </param>
        /// <param name="fieldName">Имя свойства или объекта, 
        /// которое подлежит проверке. </param>
        public static void AssertStringContainsOnlyLetters(string value, string fieldName)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]) != true)
                {
                    throw new ArgumentException($"Only English letters are required in " +
                                                $"{fieldName}");
                }
            }
        }

        /// <summary>
        /// ПРоверяет, сожержит ли значение только цифры. 
        /// </summary>
        /// <param name="value">Проверяемое значение. </param>
        /// <param name="fieldName">Имя свойства или объекта, 
        /// которое подлежит проверке. </param>
        public static void AssertStringContainsOnlyNumbers(string value, string fieldName)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsNumber (value[i]) != true)
                {
                    throw new ArgumentException($"Only numbers are required in " +
                                                $"{fieldName}");
                }
            }
        }
    }
}

