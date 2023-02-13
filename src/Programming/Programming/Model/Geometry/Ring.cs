using Programming.Model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Geometry
{
    /// <summary>
    /// Хранит данные о кольце и его площади.
    /// </summary>
    public class Ring
    {
        /// <summary>
        /// Внутренний радиус кольца.
        /// </summary>
        private double _innerRadius;

        /// <summary>
        /// Внешний радиус кольца.
        /// </summary>
        private double _outerRadius;

        /// <summary>
        /// Возвращает и задаёт центр кольца, объект класса Point2D.
        /// </summary>
        public Point2D Center { get; set; }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Ring"/>.
        /// </summary>
        /// <param name="innerRadius">Внутренний радиус кольца, должен быть 
        /// положительным значением и меньше внешнего радиуса кольца.</param>
        /// <param name="outerRadius">Внешний радиус кольца, должен быть 
        /// положительным значением и больше внутреннего радиуса кольца.</param>
        /// <param name="x">Координата центра кольца по X, должна быть 
        /// положительным значением. На её основе создаётся объект класса Point2D.</param>
        /// <param name="y">Координата центра по Y, должна быть 
        /// положительным значением. На её основе создаётся объект класса Point2D.</param>
        public Ring(double innerRadius, double outerRadius, double x, double y)
        {
            OuterRadius = outerRadius;
            InnerRadius = innerRadius;
            Center = new Point2D(x, y);
        }

        /// <summary>
        /// Возвращает площадь кольца.
        /// </summary>
        public double Area
        {
            get
            {
                return (Math.PI*(OuterRadius * OuterRadius) - (InnerRadius * InnerRadius));
            }
        }

        /// <summary>
        /// Возвращает и задаёт внешний радиус кольца. Должно быть 
        /// положительным значением и больше внутреннего радиуса кольца.
        /// </summary>
        public double OuterRadius
        {
            get
            {
                return _outerRadius;
            }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(OuterRadius));
                Validator.AssertValueInRange(value, InnerRadius, double.MaxValue, nameof(OuterRadius));
                _outerRadius = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт внутренний радиус кольца. Должно быть 
        /// положительным значением и меньше внешнего радиуса кольца.
        /// </summary>
        public double InnerRadius
        {
            get
            {
                return _innerRadius;
            }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(InnerRadius));
                Validator.AssertValueInRange(value, 0d ,OuterRadius , nameof(InnerRadius));
                _innerRadius = value;
            }
        }
    }
}
