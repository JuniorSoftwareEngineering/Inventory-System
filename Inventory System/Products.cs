using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Inventory_System
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data source=PLOTNIKOVPC\MSSQLSERVER1;Initial Catalog=InventoryDb;Integrated Security=True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"INSERT INTO [InventoryDb].dbo.[protab] ([ProductID], [ProductName], [Price])
            VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";

            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Запись добавлена", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        public void ShowData()
        {
            SqlConnection con = new SqlConnection(@"Data source=PLOTNIKOVPC\MSSQLSERVER1;Initial Catalog=InventoryDb;Integrated Security=True");

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [InventoryDb].dbo.[protab]",con);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.Rows.Clear();
            foreach(DataRow item in table.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["tid"].Value = item["ProductId"].ToString();
                dataGridView1.Rows[n].Cells["tname"].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells["tprice"].Value = item["Price"].ToString();
            }
            
        }

        private void Products_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data source=PLOTNIKOVPC\MSSQLSERVER1;Initial Catalog=InventoryDb;Integrated Security=True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"UPDATE [protab] SET ProductName = '" + textBox2.Text + "', [Price] =  '" + textBox3.Text + "' WHERE [ProductID] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Запись обнавлена", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data source=PLOTNIKOVPC\MSSQLSERVER1;Initial Catalog=InventoryDb;Integrated Security=True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"DELETE FROM [protab] WHERE [ProductId] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Запись удалена", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }
    }
}

