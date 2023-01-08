using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Предоставляет методы для проверки введённых значений.
    /// </summary>
    class Validator
    {
        /// <summary>
        /// Проверят, меньше ли строка введённого значения. 
        /// </summary>
        /// <param name="string">Строка, которую проверяют.</param>
        /// <param name="value">Значение, не больше которого должна быть строка.</param>
        /// <param name="fieldName">Имя свойства или объекта, 
        /// которое подлежит проверке.</param>
        /// <exception cref="ArgumentException">Возникает, 
        /// если количество символов больше введёного значения.</exception>
        public static void AssertStringOnLength
            (string @string, int value, string fieldName)
        {
            if (@string.Length > value)
            {
                throw new ArgumentException
                    ($"{fieldName} can't be more than {value} characters");
            }
        }

        /// <summary>
        /// Проверяет, входит ли значение в заданный диапазон.
        /// </summary>
        /// <param name="value">Значение, которое нужно проверить.</param>
        /// <param name="min">Нижняя граница.</param>
        /// <param name="max">Верхняя граница.</param>
        /// <param name="fieldName">Имя свойства или объекта, 
        /// которое подлежит проверке.</param>
        /// <exception cref="ArgumentException">
        /// Возникает, если введённое значение вне диапазона.</exception>
        public static void AssertValueInRange
            (double value, double min, double max, string fieldName)
        {
            if (!(value >= min) || !(value <= max))
            {
                throw new ArgumentException(
                    $"Value  in {fieldName} must be greater than {min} and less than {max}");
            }
        }

        /// <summary>
        /// Проверяет, входит ли целочисленное значение в заданный диапазон.
        /// </summary>
        /// <param name="value">Значение, которое нужно проверить.</param>
        /// <param name="min">Нижняя граница.</param>
        /// <param name="max">Верхняя граница.</param>
        /// <param name="fieldName">Имя свойства или объекта,
        /// которое подлежит проверке.</param>
        /// <exception cref="ArgumentException">
        /// Возникает, если введённое значение вне диапазона.</exception>
        public static void AssertIntValueInRange
            (int value, double min, double max, string fieldName)
        {
            if (!(value >= min) || !(value <= max))
            {
                throw new ArgumentException(
                    $"Value  in {fieldName} must be greater than {min} and less than {max}");
            }
        }

    }
}
