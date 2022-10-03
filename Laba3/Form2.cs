using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form2 : Form
    {
        static SqlCommand COM;
        static SqlDataReader READ;
        public SqlCommand command;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM Apartament", Connect);

            READ = COM.ExecuteReader();

           while(READ.Read())
                listBox1.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(28) + "\t" + READ.GetValue(4).ToString().PadRight(35));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();
            string column3 = textBox15.Text;
            string value3 = textBox14.Text;
            COM = new SqlCommand("SELECT * FROM Apartament WHERE " + column3 + " = " + "'" + value3 + "'", Connect);
            listBox1.Items.Clear();
            READ = COM.ExecuteReader();

            while (READ.Read())
                listBox1.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(28) + "\t" + READ.GetValue(4).ToString().PadRight(35));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
        }
    }
}