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
    public partial class Form3 : Form
    {
        private SqlConnection connection; 
        private DataSet dataSt;

        public Form3()
        {
            InitializeComponent();
        }

        private void selectData()
        {
            string sql = "SELECT  * FROM  Product "; 
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Prod"); 

            comboBox1.Items.Clear(); 
            comboBox1.Text = "Here";
            for (int i = 0; i < dataSt.Tables["Prod"].Rows.Count; i++)
            {
                comboBox1.Items.Add(dataSt.Tables["Prod"].Rows[i]["PName"].ToString());
            } 
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProductDB.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql2 = "SELECT * FROM Product WHERE PName = @oldPN"; 

            SqlCommand command = new SqlCommand(sql2, connection); 

            command.Parameters.Clear(); 
            command.Parameters.AddWithValue("oldPN", comboBox1.SelectedItem.ToString());
            command.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(command); 
            dataSt = new DataSet(); 
            adapter.Fill(dataSt, "Prod");

            label2.Text = dataSt.Tables["Prod"].Rows[0][1].ToString(); 
            label3.Text = dataSt.Tables["Prod"].Rows[0][2].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(label3.Text);
            int amt = Convert.ToInt32(numericUpDown1.Value);
            int ans,receiptno = 100001;

            label8.Text = "ร้าน Bake A Wish สาขา รังสิต";
            label9.Text = "เลขที่ใบเสร็จ " + receiptno.ToString();
            label10.Text = DateTime.Now.ToString();
            label4.Text = label2.Text;
            label7.Text = "จำนวน "+ amt.ToString() +  " ชิ้น";
            ans = price * amt;
            label5.Text = ans.ToString() + ".00 Baht";
            label11.Text = "Thank you for visitting. \nYou're always welcomed.";
            label12.Text = "***********************************************";
            label13.Text = "***********************************************";
            label14.Text = "\n***********************************************";

            receiptno++;
        }
    }
}
