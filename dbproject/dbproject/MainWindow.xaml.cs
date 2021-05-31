using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Data.SqlClient;
using System.Data;

namespace dbproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["dbproject.Properties.Settings.MyWorkingDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            ShowTeams();
            ShowPlayers();
        }

        private void ShowTeams()
        {
            try
            {
                string query = "select * from Team";
                // The SqlDataAdapter can be imagined like an Interface to make Tables usable by C# - objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable teamTable = new DataTable();
                    sqlDataAdapter.Fill(teamTable);

                    // Which information of the table in DataTable should be shown in our ListBox
                    listTeams.DisplayMemberPath = "Name";

                    // Which value should be delivered, when an Item from our ListBox is selected?
                    listTeams.SelectedValuePath = "Id";

                    // The Reference to the Data the ListBox should populate
                    listTeams.ItemsSource = teamTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void ShowAssociatedPlayers()
        {
            try
            {
                string query = "select * from Player p inner join TeamPlayer tp on p.Id = tp.PlayerId where tp.TeamId = @TeamId";

                // Use sql command to pass extra data - TeamId
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // The SqlDataAdapter can be imagined like an Interface to make Tables usable by C# - objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@TeamId", listTeams.SelectedValue);

                    DataTable playerTable = new DataTable();
                    sqlDataAdapter.Fill(playerTable);

                    // Which information of the table in DataTable should be shown in our ListBox
                    listAssociatedPlayers.DisplayMemberPath = "Name";

                    // Which value should be delivered, when an Item from our ListBox is selected?
                    listAssociatedPlayers.SelectedValuePath = "Id";

                    // The Reference to the Data the ListBox should populate
                    listAssociatedPlayers.ItemsSource = playerTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.ToString());
            }
        }

        private void ShowPlayers()
        {
            try
            {
                string query = "select * from Player";
                // The SqlDataAdapter can be imagined like an Interface to make Tables usable by C# - objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable playerTable = new DataTable();
                    sqlDataAdapter.Fill(playerTable);

                    // Which information of the table in DataTable should be shown in our ListBox
                    listPlayers.DisplayMemberPath = "Name";

                    // Which value should be delivered, when an Item from our ListBox is selected?
                    listPlayers.SelectedValuePath = "Id";

                    // The Reference to the Data the ListBox should populate
                    listPlayers.ItemsSource = playerTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void DeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Team where id = @TeamId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@TeamId", listTeams.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowTeams();
            }
        }

        private void AddTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Team values (@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowTeams();
            }
        }

        private void ShowSelectedTeamInTextBox()
        {
            try
            {
                string query = "select name from Team where id = @TeamId";

                // Use sql command to pass extra data - TeamId
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // The SqlDataAdapter can be imagined like an Interface to make Tables usable by C# - objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@TeamId", listTeams.SelectedValue);

                    DataTable teamDataTable = new DataTable();
                    sqlDataAdapter.Fill(teamDataTable);

                    myTextBox.Text = teamDataTable.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.ToString());
            }
        }

        private void ShowSelectedPlayerInTextBox()
        {
            try
            {
                string query = "select name from Player where id = @PlayerId";

                // Use sql command to pass extra data - TeamId
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // The SqlDataAdapter can be imagined like an Interface to make Tables usable by C# - objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@PlayerId", listPlayers.SelectedValue);

                    DataTable playerDataTable = new DataTable();
                    sqlDataAdapter.Fill(playerDataTable);

                    myTextBox.Text = playerDataTable.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.ToString());
            }
        }

        private void AddPlayerToTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into TeamPlayer values (@TeamId, @PlayerId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@TeamId", listTeams.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@PlayerId", listPlayers.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAssociatedPlayers();
            }
        }

        private void DeleteTeamPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from TeamPlayer where playerId = @PlayerId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@PlayerId", listAssociatedPlayers.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAssociatedPlayers();
            }
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Player values (@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowPlayers();
            }
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Player where id = @PlayerId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@PlayerId", listPlayers.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowPlayers();
            }
        }
        private void listTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAssociatedPlayers();
            ShowSelectedTeamInTextBox();
        }

        private void listPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedPlayerInTextBox();
        }
    }
}
