using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KumysWarehouse
{
    public partial class MainWindow : Window
    {
        // Строка подключения к базе данных
        private string connectionString = "data source=DESKTOP-N9AD6FJ; initial catalog=KumysWarehouse; Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
            LoadData(); // Загружаем данные при запуске
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Сырье
                    SqlDataAdapter rawMaterialsAdapter = new SqlDataAdapter("SELECT * FROM RawMaterials", conn);
                    DataTable rawMaterialsTable = new DataTable();
                    rawMaterialsAdapter.Fill(rawMaterialsTable);
                    RawMaterialsGrid.ItemsSource = rawMaterialsTable.DefaultView;

                    // Продукция
                    SqlDataAdapter productsAdapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                    DataTable productsTable = new DataTable();
                    productsAdapter.Fill(productsTable);
                    ProductsGrid.ItemsSource = productsTable.DefaultView;

                    // Операции
                    SqlDataAdapter transactionsAdapter = new SqlDataAdapter("SELECT * FROM Transactions", conn);
                    DataTable transactionsTable = new DataTable();
                    transactionsAdapter.Fill(transactionsTable);
                    TransactionsGrid.ItemsSource = transactionsTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void AddRawMaterial_Click(object sender, RoutedEventArgs e)
        {
            AddRawMaterialWindow window = new AddRawMaterialWindow();
            window.ShowDialog();
            LoadData(); // Обновить данные после добавления
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow();
            window.ShowDialog();
            LoadData(); // Обновить данные после добавления
        }

        private void AddTransaction_Click(object sender, RoutedEventArgs e)
        {
            AddTransactionWindow window = new AddTransactionWindow();
            window.ShowDialog();
            LoadData(); // Обновить данные после добавления
        }
    }
}