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
	public partial class Form5 : Form
	{
		
		static SqlCommand COM;
		static SqlDataReader READ;
		

		public Form5()
		{
			InitializeComponent();
			textBox3.Text = "Apartament";
			
		}

		

		private void button1_Click_1(object sender, EventArgs e)
		{
			string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
			SqlConnection Connect = new SqlConnection(CON);
			Connect.Open();

			COM = new SqlCommand("SELECT * FROM " + textBox3.Text + "", Connect);

			READ = COM.ExecuteReader();

			string column = textBox1.Text;
			string value = textBox2.Text;
			COM.CommandText = "DELETE from " + textBox3.Text + " where " + column + " = " + "'" + value + "'" + " ;";
			READ.Close();
			COM.ExecuteNonQuery();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			textBox3.Text = "Apartament";		
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			textBox3.Text = "Pracivnyk";		
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			textBox3.Text = "Rezerv";	
		}
    }
}
