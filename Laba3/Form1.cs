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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SqlCommand command;
       

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {

                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection CON = new SqlConnection(constring);
                CON.Open();
            
                command = CON.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select id from Users;";

                SqlDataReader reader = command.ExecuteReader();

                int id = 1;
                while (reader.Read())
                {

                    id = reader.GetInt32(0);
                    id += 1;
                }

                reader.Close();

                command = CON.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Users VALUES ('" + id + "' , '" + textBox1.Text + "', '" + textBox2.Text + "' , '" + 1 + "');";
                command.ExecuteNonQuery();


                MessageBox.Show("Вітаємо, " + textBox1.Text + ". Реєстрація пройшла успішно!");

                CON.Close();
            }
            else
            { MessageBox.Show("Заповніть всі поля!"); }

        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
               
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection CON = new SqlConnection(constring);
                CON.Open();
                try
                {
                    command = CON.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Users where login ='" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                    SqlDataReader reader = command.ExecuteReader();
                    string check_password = "";
                    string check_login = "";
                    int level = 0;
                    int i = 0;
                 

                    while (reader.Read())
                    {
                        i++;
                        check_login = reader.GetString(1);
                        check_password = reader.GetString(2);
                        level = reader.GetInt32(3);
                    }

                    if (i == 1)
                    {
                        if (level == 2)
                        {
                            Form3 form = new Form3();
                            form.Show();
                            this.Hide();
                            

                        }

                        else if (level == 1)
                        {
                            Form2 form = new Form2();
                            form.Show();
                            this.Hide();
                        }
                    }

                    if (level == 2)
                    { MessageBox.Show("Ви успішно увійшли як адміністратор"); }
                    else if (level == 1)
                    { MessageBox.Show("Ви успішно увійшли як користувач"); }

                    else
                    {
                        MessageBox.Show("Такого користувача не знайдено");
                    }
                }
             
                finally
                {
                    CON.Close();
                }
            }
            else
            { MessageBox.Show("Заповніть всі поля!"); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            if (textBox1.Text != "")
            {
                string inputString = textBox1.Text;

                textBox1.Text = inputString.Trim().Replace(" ", string.Empty);

                listBox1.Items.Clear();
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection CON = new SqlConnection(constring);
                CON.Open();

                command = CON.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT login FROM Users where login LIKE "+ "'" +  textBox1.Text + "%'; ";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    listBox1.Items.Add(reader.GetValue(0) + "\t");
                CON.Close();
            }

            else
            {
                listBox1.Items.Clear();
            }
        }

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
            if(listBox1.Text != "")
			{
                textBox1.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;

            }

            else
			{
                MessageBox.Show("Нічого не вибрано");
			}
        }

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
            listBox1.Visible = true;
           
        }
    }
}


         
    
