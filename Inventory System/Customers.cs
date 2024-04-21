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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data source=PLOTNIKOVPC\MSSQLSERVER1;Initial Catalog=InventoryDb;Integrated Security=True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"INSERT INTO [InventoryDb].dbo.[custab] ([CustomerID], [CustomerName], [Age], [Address])
            VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text +  "','" + textBox4.Text + "')";

            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Запись добавлена", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }

        public void ShowData()
        {
            SqlConnection con = new SqlConnection(@"Data source=PLOTNIKOVPC\MSSQLSERVER1;Initial Catalog=InventoryDb;Integrated Security=True");

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [InventoryDb].dbo.[custab]", con);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in table.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["cid"].Value = item["CustomerId"].ToString();
                dataGridView1.Rows[n].Cells["cname"].Value = item["CustomerName"].ToString();
                dataGridView1.Rows[n].Cells["cage"].Value = item["Age"].ToString();
                dataGridView1.Rows[n].Cells["caddress"].Value = item["Address"].ToString();
            }

        }

        private void Customers_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data source=PLOTNIKOVPC\MSSQLSERVER1;Initial Catalog=InventoryDb;Integrated Security=True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"UPDATE [custab] SET CustomerName = '" + textBox2.Text + "',[Age] =  '" + textBox3.Text + "',[Address] = '" + textBox4.Text + "' WHERE [CustomerID] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Запись обнавлена", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data source=PLOTNIKOVPC\MSSQLSERVER1;Initial Catalog=InventoryDb;Integrated Security=True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"DELETE FROM [custab] WHERE [CustomerId] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Запись удалена", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
        }
    }
}
