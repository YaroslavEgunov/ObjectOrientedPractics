using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Classes
{
    /// <summary>
    /// Хранит данные о цветах.
    /// </summary>
    public class AppColors
    {
        /// <summary>
        /// Красный цвет для TextBox. 
        /// </summary>
        public static readonly Color WrongColor = Color.LightPink;

        /// <summary>
        /// Белый цвет для TextBox. 
        /// </summary>
        public static readonly Color CorrectColor = Color.White;

        /// <summary>
        /// Зеленый цвет для прямоугольников на холсте.
        /// </summary>
        public static readonly Color CorrectColorPanel = Color.FromArgb
            (127, 127, 255, 127);

        /// <summary>
        /// Красный цвет для прямоугольников на холсте. 
        /// </summary>
        public static readonly Color WrongColorPanel = Color.FromArgb
            (127, 255, 127, 127);

        /// <summary>
        /// Зеленый цвет для SeasonHandle. 
        /// </summary>
        public static readonly Color SpringColor = Color.LightGreen;

        /// <summary>
        /// Ораньжевый цвет для SeasonHandle. 
        /// </summary>
        public static readonly Color AutumnColor = Color.Orange;

        /// <summary>
        ///Белый цвет для SeasonHandle. 
        /// </summary>
        public static readonly Color NoneColor = Color.White;
    }
}
