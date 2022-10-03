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
	public partial class Form4 : Form
	{
		static SqlCommand COM;
		static SqlDataReader READ;
		int c = 0;
		public Form4()
		{
			InitializeComponent();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
			SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

			COM = new SqlCommand("SELECT * FROM " + textBox1.Text + "", Connect);

			READ = COM.ExecuteReader();
			
			if (c == 1)
			{
				int Id = Convert.ToInt32(textBox2.Text);
				string Room = textBox3.Text;
				string Device = textBox4.Text;
				int Place = Convert.ToInt32(textBox5.Text);
				string Price = textBox6.Text;
				COM.CommandText = "Insert into " + textBox1.Text + " values(" + Id + " , " + "'" + Room + "'" + " , " + "'" + Device + "'" + " , " + "'" + Place + "'" + " , " + "'" + Price + "'" + ",null);";
				READ.Close();
				COM.ExecuteNonQuery();
			}

			if (c == 2)
			{
				int id = Convert.ToInt32(textBox2.Text);
				string name = textBox3.Text;
				string poz = textBox4.Text;
				int zp = Convert.ToInt32(textBox5.Text);
				string stavka = textBox6.Text;

				COM.CommandText = "Insert into " + textBox1.Text + " values(" + id + " , " + "'" + name + "'" + " , " + "'" + poz + "'" + " , " + "'" + zp + "'" + " , " + "'" + stavka + "'" + ",null);";
				READ.Close();
				COM.ExecuteNonQuery();
			}

			if (c == 3)
			{
				int id = Convert.ToInt32(textBox2.Text);
				string name = textBox3.Text;
				string room = textBox4.Text;
				int place = Convert.ToInt32(textBox5.Text);
				int number = Convert.ToInt32(textBox6.Text);

				COM.CommandText = "Insert into " + textBox1.Text + " values(" + id + " , " + "'" + name + "'" + " , " + "'" + room + "'" + " , " + "'" + place + "'" + " , " + "'" + number + "'" + ",null);";
				READ.Close();
				COM.ExecuteNonQuery();
			}



		}

		private void Form4_Load(object sender, EventArgs e)
		{
			textBox1.Text = "Apartament";
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			textBox1.Text = "Apartament";
			c = 1;

			label2.Visible = true;
			label3.Visible = true;
			label4.Visible = true;
			label5.Visible = true;


			label8.Visible = false;
			label9.Visible = false;
			label10.Visible = false;

			label19.Visible = false;
			label12.Visible = false;
			label13.Visible = false;
			label17.Visible = false;

		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			textBox1.Text = "Pracivnyk";
			c = 2;

			label8.Visible = true;
			label9.Visible = true;
			label10.Visible = true;
			label19.Visible = true;

			label2.Visible = false;
			label3.Visible = false;
			label4.Visible = false;
			label5.Visible = false;


			label12.Visible = false;
			label13.Visible = false;
			label17.Visible = false;



		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			textBox1.Text = "Rezerv";
			c = 3;

			label19.Visible = true;
			label12.Visible = true;
			label13.Visible = true;
			label17.Visible = true;


			label2.Visible = false;
			label3.Visible = false;
			label4.Visible = false;
			label5.Visible = false;


			label8.Visible = false;
			label9.Visible = false;
			label10.Visible = false;

		}
    }
}
