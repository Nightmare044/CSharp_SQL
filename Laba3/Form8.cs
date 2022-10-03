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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            SqlCommand dbCmd = Connect.CreateCommand();
            dbCmd.CommandText = "Select * from Apartament";
            SqlDataAdapter da = new SqlDataAdapter(dbCmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Apartament");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Apartament";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            SqlCommand dbCmd = Connect.CreateCommand();
            dbCmd.CommandText = "SELECT a.Room, b.Name FROM Apartament a inner join Rezerv b ON a.Room=b.Room";
            SqlDataAdapter da = new SqlDataAdapter(dbCmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Apartament");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Apartament";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            SqlCommand dbCmd = Connect.CreateCommand();
            dbCmd.CommandText = "SELECT a.*, b.* FROM Apartament a inner join Rezerv b ON a.Room=b.Room";
            SqlDataAdapter da = new SqlDataAdapter(dbCmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Apartament");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Apartament";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            SqlCommand dbCmd = Connect.CreateCommand();
            dbCmd.CommandText = "SELECT a.Room, b.* FROM Apartament a inner join Rezerv b ON a.Room=b.Room";
            SqlDataAdapter da = new SqlDataAdapter(dbCmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Apartament");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Apartament";
        }
    }
}