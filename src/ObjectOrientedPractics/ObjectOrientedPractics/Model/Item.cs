using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о товаре. 
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Уникальный индетификатор.
        /// </summary>
        private readonly int _itemsId;

        /// <summary>
        /// Название товара. 
        /// </summary>
        private string _name;

        /// <summary>
        /// Описание товара.    
        /// </summary>
        private string _info;

        /// <summary>
        /// Стоимость товара. 
        /// </summary>
        private double _cost;

        /// <summary>
        /// Возвращает и задаёт категорию товара.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Возвращает уникальный идентификатор.
        /// </summary>
        public int Id
        {
            get
            {
                return _itemsId;
            }
        }

        /// <summary>
        /// Возвращает и задаёт название товара. Должно быть меньше 200 символов.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Validator.AssertStringOnLength(value, 200, nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт описание товара. Должно быть меньше 1000 символов.
        /// </summary>
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                Validator.AssertStringOnLength(value, 1000, nameof(Info));
                _info = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт цену товара. Должна быть в пределах от 0 до 100 000.
        /// </summary>
        public double Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                Validator.AssertValueInRange(value, 0, 10000, nameof(Cost));
                _cost = value;
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Item"/>.
        /// </summary>
        /// <param name="Id">Уникальный индетификатор.</param>
        /// <param name="Name">Название товара. Должно быть меньше 200 символов.</param>
        /// <param name="Info">Описание товара. Должно быть меньше 1000 символов.</param>
        /// <param name="Cost">Цена товара. Должна быть в пределах от 0 до 100 000.</param>
        /// <param name="Category">Категория товара.</param>
        public Item(int Id, string Name, string Info, double Cost, Category category)
        {
            _itemsId = IdGenerator.GetNextItemsId();
            Name = _name;
            Info = _info;
            Cost = _cost;
            Category = category;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Item"/>.
        /// </summary>
        public Item()
        {
            _itemsId = IdGenerator.GetNextItemsId();
            Name = "Empty";
            Info = "Empty";
            Cost = 0;
            Category = 0;
        }
    }
}
