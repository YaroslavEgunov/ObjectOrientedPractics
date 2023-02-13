using Programming.Model.Classes;
using System;


namespace Programming.Model.Geometry
{
    /// <summary>
    /// Хранит данные о прямоугольнике. 
    /// </summary>
    public class Rectangle
    {

        /// <summary>
        /// Количество созданных прямоугольников.
        /// </summary>
        public static int _allRectanglesCount { get; set; }

        /// <summary>
        /// Ширина созданного прямоугольника.
        /// </summary>
        private double _width;

        /// <summary>
        /// Длина созданного прямоугольника.
        /// </summary>
        private double _length;

        /// <summary>
        /// Уникальный идентификатор для всех объектов класса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Цвет созданного прямоугольника.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Центр созданного прямоугольника. Объект класса Point2D.
        /// </summary>
        public Point2D Center { get; set; }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Rectangle"/>.
        /// </summary>
        public Rectangle()
        {
            Id = _allRectanglesCount;
            _allRectanglesCount++;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="length">Длина прямоугольника, должна быть положительным значением. </param>
        /// <param name="width">Ширина прямоугольника, должна быть положительным значением. </param>
        /// <param name="color">Цвет прямоугольника. </param>
        /// <param name="x">Координата центра прямоугольника по Х, должна быть 
        /// положительным значением. На её основе создаётся объект класса Point2D. </param>
        /// <param name="y">Координата центра прямоугольника по Y, должна быть 
        /// положительным значением. На её основе создаётся объект класса Point2D. </param>
        public Rectangle(double length, double width, string color, double x, double y)
        {
            _length = length;
            _width = width;
            Color = color;
            Center = new Point2D(x, y);
            Id = _allRectanglesCount;
            _allRectanglesCount++;
        }

        /// <summary>
        /// Возвращает и задаёт ширину прямоугольника. Должна быть положительным значением.
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(Width));
                _width = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт длину прямоугольника. Должна быть положительным значением.
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(Length));
                _length = value;
            }
        }
    }
}
