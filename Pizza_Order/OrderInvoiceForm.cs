using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pizza_Order
{
    public partial class OrderInvoiceForm : Form
    {
        private MySqlConnection connection;

        private RadioButton PersonalRadioButton;
        private RadioButton SmallRadioButton;
        private RadioButton MediumRadioButton;
        private RadioButton LargeRadioButton;

        public OrderInvoiceForm()
        {
            InitializeComponent();
            // Устанавливаем подключение к базе данных
            string connectionString = "Server=localhost;Database=pizza;Uid=root;Pwd="; // Укажите свои параметры подключения
            connection = new MySqlConnection(connectionString);
        }

        // Этот метод выполняется при нажатии кнопки Exit
        private void ExitButton_Click(object sender, EventArgs e)
        {
            PizzaOrderForm NewForm = new PizzaOrderForm();
            NewForm.Show();  // Show the new form
            this.Dispose(false); // Get rid of the old form
        }

        // Этот метод выполняется при подтверждении заказа
        private void ConfirmOrder_Click(object sender, EventArgs e)
        {
            double tax = 0.08; // Налог 8%
            double taxAmount = 0.00; // Сумма налога
            double subTotal = 0.00; // Сумма после налога
            double total = 0.00; // Общая сумма до налога

            // Этот цикл добавляет все цены из списка в общую сумму
            foreach (ListViewItem item in SubTotalListView.Items)
            {
                string priceText = item.SubItems[1].Text; // Вторая колонка

                // Очищаем строку и проверяем на корректность перед парсингом
                string cleanText = priceText.Replace("$", "").Trim();
                if (double.TryParse(cleanText, NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
                {
                    total += price; // Добавляем цену в общую сумму
                }
                else
                {
                    // Обрабатываем некорректные значения
                    MessageBox.Show($"Некорректная цена: '{priceText}'. Пожалуйста, проверьте ввод.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Выход из метода, если ошибка
                }
            }

            // Рассчитываем сумму налога и общую сумму
            taxAmount = tax * total;
            subTotal = total + taxAmount;

            // Обновляем элементы UI с отформатированными значениями
            PizzaPrice.Text = "$" + total.ToString("0.00"); // Печать суммы до налога
            taxPriceLabel.Text = "$" + taxAmount.ToString("0.00"); // Печать налога
            TotalPrice.Text = "$" + subTotal.ToString("0.00"); // Печать общей суммы

            // Сохраняем заказ в базе данных
            SaveOrderToDatabase(total, taxAmount, subTotal);

            // Показать сообщение о подтверждении заказа
            MessageBox.Show("Ваш заказ был принят. Спасибо и приятного аппетита!",
                "VV's Pizza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // Метод для сохранения заказа в базу данных
        private void SaveOrderToDatabase(double total, double taxAmount, double subTotal)
        {
            try
            {
                connection.Open(); // Открываем соединение с базой данных

                // Формируем строку с выбранными начинками
                string toppings = "";
                foreach (ListViewItem item in SubTotalListView.Items)
                {
                    toppings += item.Text + ", ";
                }
                toppings = toppings.TrimEnd(',', ' '); // Убираем лишнюю запятую в конце

                // Формируем запрос на вставку данных в таблицу
                string query = "INSERT INTO Orders (PizzaSize, Toppings, TotalPrice, Tax, Subtotal, OrderDate) " +
                               "VALUES (@PizzaSize, @Toppings, @TotalPrice, @Tax, @Subtotal, @OrderDate)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PizzaSize", GetPizzaSize()); // Метод для получения размера пиццы
                cmd.Parameters.AddWithValue("@Toppings", toppings);
                cmd.Parameters.AddWithValue("@TotalPrice", total);
                cmd.Parameters.AddWithValue("@Tax", taxAmount);
                cmd.Parameters.AddWithValue("@Subtotal", subTotal);
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now); // Текущая дата и время

                cmd.ExecuteNonQuery(); // Выполнение запроса

                MessageBox.Show("Заказ успешно сохранен в базе данных!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в базу данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); // Закрываем соединение с базой данных
            }
        }

        // Метод для получения размера пиццы (можно улучшить в зависимости от вашего кода)
        private string GetPizzaSize()
        {
            if (PersonalRadioButton != null && PersonalRadioButton.Checked)
            {
                return "Personal";
            }

            if (SmallRadioButton!=null && SmallRadioButton.Checked)
                return "Small";
            if (MediumRadioButton != null && MediumRadioButton.Checked)
                return "Medium";
            if (LargeRadioButton != null && LargeRadioButton.Checked)
                return "Large";
            return "Personal";
        }

        private void OrderInvoiceForm_Load(object sender, EventArgs e)
        {

        }

        private void bd_Click(object sender, EventArgs e)
        {
            DataBase NewForm = new DataBase();
            NewForm.Show();  // Show the new form
            this.Dispose(false); // Get rid of the old form
        }
    }
}
