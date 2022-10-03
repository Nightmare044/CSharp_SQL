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
	public partial class Form6 : Form
	{
		static SqlCommand COM;
		static SqlDataReader READ;
		public Form6()
		{
			InitializeComponent();

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
				listBox1.Items.Add(READ.GetValue(0) + "\t" + READ.GetValue(1) + "\t" + READ.GetValue(2) + "\t" + READ.GetValue(3) + "\t" + READ.GetValue(4) + "\t" + READ.GetValue(5));
		}
	}
}
