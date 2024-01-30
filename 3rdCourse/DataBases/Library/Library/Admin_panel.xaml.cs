using Library.Models;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace Library
{
    
    public partial class Admin_panel : Window
    {
        private string connectionString;
        private DataTable dataTable;
        string query = "SELECT * FROM USERS";
        public Admin_panel()
        {
            InitializeComponent();
            connectionString = @"Data Source=LAPTOP-P14D9V4Q;Initial Catalog=Library; Integrated Security=True";
            LibraryView();
        }
        private void LibraryView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    UsersGrid.ItemsSource = dataTable.DefaultView;
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

                    // Set the SelectCommand property for dataAdapter
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    dataAdapter.UpdateCommand = new SqlCommandBuilder(dataAdapter).GetUpdateCommand();
                    try
                    {
                        dataAdapter.Update(dataTable);
                    }
                    catch (Exception)
                    {
                        string messageBoxText = "Неправильно введено Id";
                        string caption = "Ошибка ввода";
                        MessageBoxButton button = MessageBoxButton.OKCancel;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
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
            DataRowView selectedRow = UsersGrid.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Set the SelectCommand property for dataAdapter
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

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
            DataRowView selectedRow = UsersGrid.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        selectedRow.Row.Delete();

                        // Set the SelectCommand property for dataAdapter
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

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
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataTable.Clear();
                    dataAdapter.Fill(dataTable);

                    UsersGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }
        private void ExportObject(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            if (saveFileDialog.ShowDialog() == true)
            {
                string backupFilePath = saveFileDialog.FileName;
                ExportDatabase(backupFilePath);
            }
        }
        private void ExportDatabase(string path)
        {
            try
            {
                using var connection = new SqlConnection(@"Data Source=LAPTOP-P14D9V4Q; Initial Catalog=Library; Integrated Security=True");
                var query = $"BACKUP DATABASE {"Library"} TO DISK = N'{path}'   WITH FORMAT,\r\n   " +
                    $"   MEDIANAME = 'SQLServerBackups',\r\n      NAME = 'Full Backup of SQLTestDB';";
                using var command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при экспорте базы данных: " + ex.Message);
            }
        }
        private void ImportObject(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            if (openFileDialog.ShowDialog() == true)
            {
                string backupFilePath = openFileDialog.FileName;
                ImportDatabase(backupFilePath);
            }
        }
        private void ImportDatabase(string backupFilePath)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string databaseName = "Library"; // Имя вашей базы данных
                    string query = $"USE master RESTORE DATABASE {databaseName} FROM DISK = N'{backupFilePath}' WITH REPLACE;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("База данных успешно импортирована.");
                    RefreshData(); // Обновите данные в приложении после импорта.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при импорте базы данных: " + ex.Message);
            }
        }
    }
}
