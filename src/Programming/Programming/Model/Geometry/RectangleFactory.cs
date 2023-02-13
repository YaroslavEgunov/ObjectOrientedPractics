using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Geometry
{
    /// <summary>
    /// Предоставляет методы для создания коллекции класса Rectangle со случайными значениями.
    /// </summary>
    public static class RectangleFactory
    {
        /// <summary>
        /// Позволяет генерировать случайные значения.
        /// </summary>
        private static Random Random = new Random();

        /// <summary>
        /// Создаёт один объект класса Rectangle и добавляет его в список.
        /// </summary>
        /// <param name="rectangles">Список, куда нужно добавить новый элемент. </param>
        public static void RandomizeList(List<Rectangle> rectangles)
        {
            rectangles.Add(new Rectangle(
                Random.Next(10, 100),
                Random.Next(10, 100),
                "White",
                Random.Next(10, 400),
                Random.Next(10, 400)));
        }

        /// <summary>
        /// Создаёт пять объектов класса Rectangle и добавляет их в массив.
        /// </summary>
        /// <param name="rectangles">Массив, куда нужно добавить новые элементы. </param>
        public static void RandomizeArray(Rectangle[] rectangles)
        {
            string[] RectangleColors = { "White", "Black", "Yellow", "Brown",
                "Green", "Red", "Blue", "Purple" };
            for (var i = 0; i < 5; i++)
            {
                var Colors = Random.Next(RectangleColors.Length);
                rectangles[i] = new Rectangle(Random.Next(1, 100),
                    Random.Next(1, 100),
                    RectangleColors[Colors],
                    Random.Next(1, 100),
                    Random.Next(1, 100));
            }
        }
    }
}
