using Programming.Model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Geometry
{

    /// <summary>
    /// Хранит данные о координатах X и Y. 
    /// </summary>
    public class Point2D
    {

        /// <summary>
        /// Координата Y. 
        /// </summary>
        private double _y;

        /// <summary>
        /// Координата Х. 
        /// </summary>
        private double _x;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Point2D"/>.
        /// </summary>
        public Point2D()
        {
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Point2D"/>.
        /// </summary>
        /// <param name="x">Координата X. Должна быть положительным значением.</param>
        /// <param name="y">Координата Y. Должна быть положительным значением.</param>
        public Point2D(double x, double y)
        {
            _y = y;
            _x = x;
        }

        /// <summary>
        /// Возвращает и задаёт координату Y. Должна быть положительным значением.
        /// </summary>
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(Y));
                _y = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт координату Y. Должна быть положительным значением.
        /// </summary>
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(X));
                _x = value;
            }
        }
    }
}
