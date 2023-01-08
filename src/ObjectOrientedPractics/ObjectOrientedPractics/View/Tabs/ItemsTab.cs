using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;
using Color = ObjectOrientedPractics.Services.AppColor;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет реализацию по представлению товаров.
    /// </summary>
    public partial class ItemsTab : UserControl
    {
        /// <summary>
        /// Показывает всплывающую подсказку.
        /// </summary>
        private ToolTip _toolTip = new ToolTip();

        /// <summary>
        /// Коллекция товаров.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Выбранный товар.
        /// </summary>
        private Item _currentItem;

        /// <summary>
        /// Создает экземпляр класса <see cref="ItemsTab"/>
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
            _items = Items;
            CategoryComboBox.DataSource = Enum.GetValues(typeof(Category));

            if (ItemsListBox.Items.Count != 0)
            {
                ItemsListBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Возвращает и задает коллекцию товаров.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value;

                if (_items != null)
                {
                    UpdateListBox(-1);
                }
            }
        }

        /// <summary>
        /// Очищает поля вывода информации.
        /// </summary>
        private void ClearItemsInfo()
        {
            IDTextBox.Clear();
            CostTextBox.Clear();
            NameTextBox.Clear();
            DescriptionTextBox.Clear();
        }

        /// <summary>
        /// Обновляет данные в ListBox.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateListBox(int selectedIndex)
        {
            ItemsListBox.Items.Clear();
            var orderedListItems = 
                from item in _items orderby item.Name select item;
            _items = orderedListItems.ToList();

            foreach (Item item in _items)
            {
                ItemsListBox.Items.Add(FormattedText(item));
            }

            ItemsListBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Ищет индекс элемента по уникальному идентификатору.
        /// </summary>
        /// <returns>Возвращает индекс найденного элемента.</returns>
        private int FindIndexItemById()
        {
            var orderedListItems = from item in _items
                orderby item.Name
                select item;
            _items = orderedListItems.ToList();
            int currentItemId = _currentItem.Id;
            int index = -1;

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Id != currentItemId)
                {
                    continue;
                }

                index = i;
                break;
            }

            return index;
        }

        /// <summary>
        /// Генерирует форматированный текст для отображения.
        /// </summary>
        /// <param name="item">Товар.</param>
        /// <returns>Возвращает форматированный текст.</returns>
        private string FormattedText(Item item)
        {
            return $"{item.Name}";
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            _items.Add(new Item());
            _currentItem = _items.Last();
            UpdateListBox(0);
        }

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _items.RemoveAt(index);
            UpdateListBox(-1);

            ClearItemsInfo();
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _currentItem = _items[index];
            IDTextBox.Text = _currentItem.Id.ToString();
            CostTextBox.Text = _currentItem.Cost.ToString();
            NameTextBox.Text = _currentItem.Name;
            DescriptionTextBox.Text = _currentItem.Info;
            CategoryComboBox.SelectedIndex = (int) _currentItem.Category;
        }

        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _currentItem.Cost = Convert.ToDouble(CostTextBox.Text);
                CostTextBox.BackColor = Color.CorrectColor;
            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(CostTextBox, exception.Message);
                CostTextBox.BackColor = Color.WrongColor;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            try
            {
                NameTextBox.SelectionStart = NameTextBox.Text.Length;
                NameTextBox.BackColor = Color.CorrectColor;
                _currentItem.Name = NameTextBox.Text;
                int indexItem = FindIndexItemById();
                UpdateListBox(indexItem);
            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(NameTextBox, exception.Message);
                NameTextBox.BackColor = Color.WrongColor;
            }
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _currentItem.Info = DescriptionTextBox.Text;
                DescriptionTextBox.BackColor = Color.CorrectColor;
            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(DescriptionTextBox, exception.Message);
                DescriptionTextBox.BackColor = Color.WrongColor;
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_currentItem == null)
                {
                    return;
                }
                _currentItem.Category = (Category)CategoryComboBox.SelectedIndex;
            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(CategoryComboBox, exception.Message);
            }
        }
    }
}
