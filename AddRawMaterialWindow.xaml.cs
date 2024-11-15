using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace KumysWarehouse
{
    public partial class AddRawMaterialWindow : Window
    {
        private string connectionString = "data source=DESKTOP-N9AD6FJ; initial catalog=KumysWarehouse; Integrated Security=True";

        public AddRawMaterialWindow()
        {
            InitializeComponent();
        }

        // Обработчик TextChanged (если он указан в XAML)
        private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Например, валидация введенного текста.
            // MessageBox.Show("Текст изменен в NameTextBox!");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO RawMaterials (Name, Quantity, Unit, LastUpdated) VALUES (@Name, @Quantity, @Unit, GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Quantity", decimal.Parse(QuantityTextBox.Text));
                    cmd.Parameters.AddWithValue("@Unit", UnitTextBox.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Сырье успешно добавлено!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
