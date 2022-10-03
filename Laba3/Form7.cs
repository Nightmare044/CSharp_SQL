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


namespace Laba3
{
    public partial class Form7 : Form
    {
        static SqlCommand COM;
        static SqlDataReader READ;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM Rezerv", Connect);

            READ = COM.ExecuteReader();

            while (READ.Read())
                listBox1.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(28) + "\t" + READ.GetValue(4).ToString().PadRight(35));


        }
        private void button2_Click(object sender, EventArgs e)
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM Rezerv", Connect);

            READ = COM.ExecuteReader();

      
                int Id = Convert.ToInt32(textBox1.Text);
                string Name = textBox2.Text;
                string Room = textBox3.Text;
                int Place = Convert.ToInt32(textBox4.Text);
                int Number = Convert.ToInt32(textBox5.Text);
                COM.CommandText = "Insert into Rezerv values(" + Id + " , " + "'" + Name + "'" + " , " + "'" + Room + "'" + " , " + "'" + Place + "'" + " , " + "'" + Number + "'" + ",null);";
                READ.Close();
                COM.ExecuteNonQuery();
           
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            READ.Close();
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM Rezerv", Connect);

            READ = COM.ExecuteReader();

            while (READ.Read())
                listBox1.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(25) + "\t" + READ.GetValue(4).ToString().PadRight(30));

            Connect.Close();
        }
    }
}
