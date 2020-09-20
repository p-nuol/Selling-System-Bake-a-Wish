using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace program_baw
{
    public partial class ManageForm : Form
    {
        public ManageForm()
        {
            InitializeComponent();
        }

        private SqlConnection connection;
        private DataSet dataSt;

        private void selectData()
        {
            string sql = "SELECT  * FROM  Product ";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Prod");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pid = textBox1.Text;
            string pname = textBox2.Text;
            string price = textBox3.Text;

            string sql = "INSERT INTO Product (ProductID,PName,Price)VALUES(@prodid, @pname, @price)";

            SqlCommand command = new SqlCommand(sql, connection); 
            command.Parameters.AddWithValue("prodid", pid); 
            command.Parameters.AddWithValue("pname", pname); 
            command.Parameters.AddWithValue("price", price); 
        }
    }
}
