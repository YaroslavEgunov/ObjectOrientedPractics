using System;

namespace Programming.Model.Classes
{
    /// <summary>
    /// Хранит данные о школьном предмете.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Оценка по предмету.
        /// </summary>
        private int _mark;

        /// <summary>
        /// Название предмета.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия преподавателя.
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Subject"/>.
        /// </summary>
        public Subject()
        {
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Subject"/>.
        /// </summary>
        /// <param name="name">Название предмета. </param>
        /// <param name="teachername">Фамилия преподавателя. </param>
        /// <param name="mark">Оценка по предмету, должна быть 
        /// положительным значением. </param>
        public Subject(string name, string teachername, int mark)
        {
            Name = name;
            TeacherName = teachername;
            _mark = mark;
        }

        /// <summary>
        /// Возвращает и задаёт оценку по предмету. Должна быть значением от 1 до 5.
        /// </summary>
        public int Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                Validator.AssertValueInRange(value, 0, 5, nameof(Mark));
                _mark = value;
            }
        }
    }
}
