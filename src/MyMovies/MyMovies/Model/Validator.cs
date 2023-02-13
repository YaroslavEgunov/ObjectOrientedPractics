using System;

namespace Movies.Model
{
    /// <summary>
    /// Предоставляет методы для проверки значений.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверяет, меньше ли строка 100 символов.
        /// </summary>
        /// <param name="name">Строка, которую нужно проверить.</param>
        /// <param name="fieldName">Имя объекта у которого проверяется значение.</param>
        /// <exception cref="ArgumentException">Возникает, 
        /// если количество символов больше 100.</exception>
        public static void AssertLessThan100Characters(string name, string fieldName)
        {
            if (name.Length > 100 || name.Length == 0)
            {
                throw new ArgumentException(
                    $"{fieldName} must be no more than 100 characters");
            }
        }

        /// <summary>
        /// Проверяет, введено ли положительное значение у целочисленного типа данных.
        /// </summary>
        /// <param name="value">Значение, которое нужно проверить.</param>
        /// <param name="fieldName">Имя объекта у которого проверяется значение.</param>
        /// <exception cref="ArgumentException">Возникает, если значение отрицательное.</exception>
        public static void AssertOnPositiveValue(int value, string fieldName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    $"{fieldName} must be greater than 0");
            }
        }

        /// <summary>
        /// Проверяет, входит ли значение число с плавающей запятой в промежуток.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="min">Нижняя граница.</param>
        /// <param name="max">Верхняя граница.</param>
        /// <param name="propertyName">Имя объекта у которого проверяется значение.</param>
        /// <exception cref="ArgumentException">Возникает, 
        /// если значение не входит в промежуток.</exception>
        public static void AssertValueInRangeDouble
            (double value, int min, int max, string fieldName)
        {
            if (!(value >= min) || !(value <= max))
            {
                throw new ArgumentException(
                    $"{fieldName} must be more {min} and less than {max}");
            }
        }

        /// <summary>
        /// Проверяет, входит ли значение целочисленное значение в промежуток.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="min">Нижняя граница.</param>
        /// <param name="max">Верхняя граница.</param>
        /// <param name="propertyName">Имя объекта у которого проверяется значение.</param>
        /// <exception cref="ArgumentException">Возникает, 
        /// если значение не входит в промежуток.</exception>
        public static void AssertValueInRangeInt
            (int value, int min, int max, string fieldName)
        {
            if (!(value >= min) || !(value <= max))
            {
                throw new ArgumentException(
                    $"{fieldName} must be more {min} and less than {max}");
            }
        }
    }
}
