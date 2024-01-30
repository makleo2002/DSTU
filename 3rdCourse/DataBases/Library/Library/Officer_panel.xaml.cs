using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace Library
{
    public partial class Officer_panel : Window
    {
        private string connectionString;
        private DataTable dataTable;
        public Officer_panel()
        {
            InitializeComponent();
            connectionString = @"Data Source=LAPTOP-P14D9V4Q;Initial Catalog=Library; Integrated Security=True";
        }

        private void LibraryView(object sender, SelectionChangedEventArgs e)
        {
            string selectedTable = ((ComboBoxItem)Tables.SelectedItem).Content.ToString(); // Получаем имя выбранной таблицы
            string query = "SELECT * FROM " + selectedTable;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    LibraryGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }
        private void AddObject(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM " + ((ComboBoxItem)Tables.SelectedItem).Content, connection);

                    dataAdapter.UpdateCommand = new SqlCommandBuilder(dataAdapter).GetUpdateCommand();
                    try
                    {
                        dataAdapter.Update(dataTable);
                    }
                    catch (Exception)
                    {
                       MessageBox.Show("Неправильно введено Id", "Ошибка ввода" + Tables.SelectedItem.ToString(),
                           MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    }
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }
        private void UpdateObject(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = LibraryGrid.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM " + ((ComboBoxItem)Tables.SelectedItem).Content, connection);

                        dataAdapter.UpdateCommand = new SqlCommandBuilder(dataAdapter).GetUpdateCommand();
                        dataAdapter.Update(dataTable);

                        RefreshData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
            }
        }
        private void DeleteObject(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = LibraryGrid.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        selectedRow.Row.Delete();

                        SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM " + ((ComboBoxItem)Tables.SelectedItem).Content, connection);

                        dataAdapter.UpdateCommand = new SqlCommandBuilder(dataAdapter).GetUpdateCommand();
                        dataAdapter.Update(dataTable);

                        RefreshData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
            }
        }
        private void RefreshData()
        {
            string selectedTable = ((ComboBoxItem)Tables.SelectedItem).Content.ToString();
            string query = "SELECT * FROM " + selectedTable;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataTable.Clear();
                    dataAdapter.Fill(dataTable);

                    LibraryGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }
    }
}
