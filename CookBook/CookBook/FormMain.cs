using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace CookBook
{
    public partial class FormMain : Form
    {
        SqlConnection connection;
        string connectionString;

        public FormMain()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["CookBook.Properties.Settings.CookBookConnectionString"].ConnectionString;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            PopulateRecipies();
            PopulateAllIngredients();
        }

        private void PopulateRecipies()
        {

            using (connection = new SqlConnection(connectionString)) //closes the connection for us
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Recipe", connection)) //handles opening the connection for us
            {

                DataTable recipeTable = new DataTable();
                adapter.Fill(recipeTable);

                ListRecipes.DisplayMember = "Name";
                ListRecipes.ValueMember = "Id";
                ListRecipes.DataSource = recipeTable;
            }
            
        }

        private void PopulateIngredients()
        {
            string query = "SELECT a.Name FROM Ingredient a " +
                "INNER JOIN RecipeIngredient b ON a.Id = b.IngredientID " +
                "WHERE b.RecipeId = @RecipeId";

            using (connection = new SqlConnection(connectionString)) //closes the connection for us
            using (SqlCommand command = new SqlCommand(query, connection)) //connection is specified here and so no need for it in the adapter
            using (SqlDataAdapter adapter = new SqlDataAdapter(command)) //handles opening the connection for us
            {
                command.Parameters.AddWithValue("@RecipeId", ListRecipes.SelectedValue);

                DataTable IngredientTable = new DataTable();
                adapter.Fill(IngredientTable);

                ListIngredients.DisplayMember = "Name";
                ListIngredients.ValueMember = "Id";
                ListIngredients.DataSource = IngredientTable;
            }

        }

        private void PopulateAllIngredients()
        {

            using (connection = new SqlConnection(connectionString)) //closes the connection for us
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ingredient", connection)) //handles opening the connection for us
            {

                DataTable IngredientTable = new DataTable();
                adapter.Fill(IngredientTable);

                ListAllIngredients.DisplayMember = "Name";
                ListAllIngredients.ValueMember = "Id";
                ListAllIngredients.DataSource = IngredientTable;
            }

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ListIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateIngredients();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Recipe VALUES (@RecipeName, 80, 'added instruction')";

            using (connection = new SqlConnection(connectionString)) //closes the connection for us
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open(); //as adapater doesnt open it for us 
                command.Parameters.AddWithValue("@RecipeName", TextRexipeName.Text);
                command.ExecuteNonQuery();
            }

            PopulateRecipies();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Recipe SET Name = @RecipeName WHERE Id = @RecipeId";

            using (connection = new SqlConnection(connectionString)) //closes the connection for us
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open(); //as adapater doesnt open it for us 
                command.Parameters.AddWithValue("@RecipeName", TextRexipeName.Text);
                command.Parameters.AddWithValue("@RecipeId", ListRecipes.SelectedValue);
                command.ExecuteNonQuery();
            }

            PopulateRecipies();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO RecipeIngredient VALUES (@RecipeId, @IngredientId)";

            using (connection = new SqlConnection(connectionString)) //closes the connection for us
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open(); //as adapater doesnt open it for us 
                command.Parameters.AddWithValue("@RecipeId", ListRecipes.SelectedValue);
                command.Parameters.AddWithValue("@IngredientId", ListAllIngredients.SelectedValue);

                command.ExecuteNonQuery();
            }

            PopulateIngredients();
        }
    }
}
