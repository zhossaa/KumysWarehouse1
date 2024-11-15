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
    public partial class AddTransactionWindow : Window
    {
        private string connectionString = "data source=DESKTOP-N9AD6FJ; initial catalog=KumysWarehouse; Integrated Security=True";

        public AddTransactionWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Transactions (TransactionDate, Type, ItemID, Quantity, Unit, Notes) VALUES (GETDATE(), @Type, @ItemID, @Quantity, @Unit, @Notes)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Type", TypeTextBox.Text);
                    cmd.Parameters.AddWithValue("@ItemID", int.Parse(ItemIDTextBox.Text));
                    cmd.Parameters.AddWithValue("@Quantity", decimal.Parse(QuantityTextBox.Text));
                    cmd.Parameters.AddWithValue("@Unit", UnitTextBox.Text);
                    cmd.Parameters.AddWithValue("@Notes", NotesTextBox.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Операция успешно добавлена!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
