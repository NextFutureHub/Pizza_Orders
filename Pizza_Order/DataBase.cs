using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pizza_Order
{
    public partial class DataBase : Form
    {
        private string connectionString = "Server=localhost;Database=pizza;Uid=root;Pwd=";

        public DataBase()
        {
            InitializeComponent();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            LoadOrdersFromDatabase(); // Загрузка всех заказов при открытии формы
            PopulatePizzaSizeFilter(); // Заполняем фильтр для выбора размера пиццы
        }

        // Метод для загрузки заказов с учётом фильтров
        private void LoadOrdersFromDatabase(string sizeFilter = "", string toppingFilter = "")
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Базовый SQL-запрос
                    string query = "SELECT OrderID, PizzaSize, Toppings, TotalPrice, Tax, Subtotal, OrderDate FROM Orders WHERE 1=1";

                    // Условия фильтрации
                    if (!string.IsNullOrEmpty(sizeFilter))
                    {
                        query += " AND PizzaSize = @PizzaSize";
                    }

                    if (!string.IsNullOrEmpty(toppingFilter))
                    {
                        query += " AND Toppings LIKE @Toppings";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // Передаём параметры фильтров в запрос
                    if (!string.IsNullOrEmpty(sizeFilter))
                    {
                        cmd.Parameters.AddWithValue("@PizzaSize", sizeFilter);
                    }

                    if (!string.IsNullOrEmpty(toppingFilter))
                    {
                        cmd.Parameters.AddWithValue("@Toppings", $"%{toppingFilter}%");
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable ordersTable = new DataTable();
                    adapter.Fill(ordersTable);

                    OrdersDataGridView.DataSource = ordersTable;

                    // Настройка заголовков
                    OrdersDataGridView.Columns["OrderID"].Visible = false;
                    OrdersDataGridView.Columns["PizzaSize"].HeaderText = "Размер пиццы";
                    OrdersDataGridView.Columns["Toppings"].HeaderText = "Начинки";
                    OrdersDataGridView.Columns["TotalPrice"].HeaderText = "Общая стоимость";
                    OrdersDataGridView.Columns["Tax"].HeaderText = "Налог";
                    OrdersDataGridView.Columns["Subtotal"].HeaderText = "Сумма с налогом";
                    OrdersDataGridView.Columns["OrderDate"].HeaderText = "Дата заказа";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для заполнения выпадающего списка с размерами пиццы
        private void PopulatePizzaSizeFilter()
        {
            PizzaSizeComboBox.Items.Clear();
            PizzaSizeComboBox.Items.Add("Все");
            PizzaSizeComboBox.Items.Add("Personal");
            PizzaSizeComboBox.Items.Add("Small");
            PizzaSizeComboBox.Items.Add("Medium");
            PizzaSizeComboBox.Items.Add("Large");
            PizzaSizeComboBox.SelectedIndex = 0; // По умолчанию "Все"
        }

        // Обработчик кнопки "Применить фильтры"
        private void ApplyFiltersButton_Click(object sender, EventArgs e)
        {
            string sizeFilter = PizzaSizeComboBox.SelectedItem.ToString() != "Все"
                ? PizzaSizeComboBox.SelectedItem.ToString()
                : "";

            string toppingFilter = ToppingTextBox.Text.Trim();

            LoadOrdersFromDatabase(sizeFilter, toppingFilter);
        }
    }
}
