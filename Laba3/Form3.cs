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
using System.IO;

namespace Laba3
{
    public partial class Form3 : Form
    {
        static SqlCommand COM;
        static SqlDataReader READ;
        int g = 1;
        public Form3()
        {     
            InitializeComponent();
            textBox4.Text = "Apartament";
            timer2.Enabled = true;

            button11.Visible = false;
            button25.Visible = true;
            pictureBox2.Visible = false;

        }

        public static byte[] GetPhoto(string filePath)
        {

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] Image = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return Image;

        }

        private void button9_Click(object sender, EventArgs e)
		{
            Form4 form = new Form4();
            form.Show();
        }

		private void button10_Click(object sender, EventArgs e)
		{
            Form5 form = new Form5();
            form.Show();
        }

		private void button13_Click(object sender, EventArgs e)
		{
            Form6 form = new Form6();
            form.Show();
        }

		private void button15_Click(object sender, EventArgs e)
		{
            listBox2.Items.Clear();
            READ.Close();
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM " + textBox4.Text + "", Connect);

            READ = COM.ExecuteReader();

            while (READ.Read())
                listBox2.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(25) + "\t" + READ.GetValue(4).ToString().PadRight(30));

            Connect.Close();
        }

		private void Form3_Load_1(object sender, EventArgs e)
		{
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM Apartament", Connect);

            READ = COM.ExecuteReader();

            while (READ.Read())
                listBox2.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(25) + "\t" + READ.GetValue(4).ToString().PadRight(30));

            Connect.Close();
        }
	
		private void button14_Click(object sender, EventArgs e)
		{
            if (checkBox1.Checked)
                MessageBox.Show("Для того, щоб користуватись фільтрами - вимкніть автооновлення");
            else
                         
            try
			{
                listBox2.Items.Clear();
                READ.Close();
                string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection Connect = new SqlConnection(CON);
                Connect.Open();

                COM = new SqlCommand("SELECT * FROM " + textBox4.Text + " where " + textBox2.Text + " LIKE " + "'" + textBox1.Text + "%'; ", Connect);

                READ = COM.ExecuteReader();

                    while (READ.Read())
                        listBox2.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(25) + "\t" + READ.GetValue(4).ToString().PadRight(30));

                    Connect.Close();
                }

			catch
			{
                MessageBox.Show("Фільтри пусті або збігів не знайдено");
			}         
        }
		
		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
            try
			{
                textBox3.Text = listBox2.SelectedIndex.ToString();
                if (g == 1)
                {
                    ShowImage();
                }
                if (g == 2)
                {
                    ShowImage2();
                }

                textBox5.Clear();

                string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection Connect = new SqlConnection(CON);
                Connect.Open();

                COM = new SqlCommand("SELECT Room FROM " + textBox4.Text + " where id = " + textBox3.Text + " + 1", Connect);

                READ = COM.ExecuteReader();

                while (READ.Read())
                    textBox5.AppendText((string)READ.GetValue(0));

                Connect.Close();
            }

			catch
			{
                textBox3.Text = listBox2.SelectedIndex.ToString();
                if (g == 1)
                {
                    ShowImage();
                }
                if (g == 2)
                {
                    ShowImage2();
                }

                textBox5.Clear();

                string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection Connect = new SqlConnection(CON);
                Connect.Open();

                COM = new SqlCommand("SELECT Name FROM " + textBox4.Text + " where id = " + textBox3.Text + " + 1", Connect);

                READ = COM.ExecuteReader();

                while (READ.Read())
                    textBox5.AppendText((string)READ.GetValue(0));

                Connect.Close();
            }
        }

        private void ShowImage()
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("select Image from " + textBox4.Text + " where Id = " + textBox3.Text + "+1", Connect);

            SqlDataAdapter da = new SqlDataAdapter(COM);

            DataSet ds = new DataSet();

            da.Fill(ds);

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);
                    pictureBox1.Image = new Bitmap(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            catch
            {
                MessageBox.Show("Картинка відсутня");
            }
            Connect.Close();
            pictureBox2.Image = pictureBox1.Image;
        }
        private void ShowImage2()
        {
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("select Image from " + textBox4.Text + " where Id = " + textBox3.Text + "+1", Connect);

            SqlDataAdapter da = new SqlDataAdapter(COM);

            DataSet ds = new DataSet();

            da.Fill(ds);

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);
                    pictureBox2.Image = new Bitmap(ms);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            catch
            {
                MessageBox.Show("Картинка відсутня");
            }
            Connect.Close();
            pictureBox1.Image = pictureBox2.Image;
        }
        private void button25_Click(object sender, EventArgs e)
		{
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.JPEG; *.GIF | All files(*.*) | *.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                        byte[] img = GetPhoto(open_dialog.FileName);

                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = Image.FromFile(open_dialog.FileName);

                }

                catch (Exception n)
                {
                    DialogResult rezult = MessageBox.Show(n.Message, n.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection Connect = new SqlConnection(CON);
                Connect.Open();

                try
                {
                    COM = new SqlCommand("SELECT * FROM " + textBox4.Text + "", Connect);
                    COM.CommandText = "UPDATE " + textBox4.Text + " SET Image = @Image where id = " + textBox3.Text + " + 1; ";
                    byte[] img = GetPhoto(open_dialog.FileName);
                    COM.Parameters.Add("@Image", SqlDbType.Image, img.Length);
                    COM.Parameters["@Image"].Value = img;

                    COM.ExecuteNonQuery();
                }

                catch (Exception n)
                {
                    MessageBox.Show(n.Message, n.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {    
                    Connect.Close();
                }
            }
        }

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
            int g = 1;
            ShowImage();
            textBox4.Text = "Apartament";

            button11.Visible = false;
            button25.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label12.Visible = true;

            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;

            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;

            listBox2.Items.Clear();
            READ.Close();
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM " + textBox4.Text + "", Connect);

            READ = COM.ExecuteReader();

            while (READ.Read())
                listBox2.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(25) + "\t" + READ.GetValue(4).ToString().PadRight(30));

            Connect.Close();
        }

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
            textBox4.Text = "Pracivnyk";
            int g = 2;
            ShowImage2();

            button11.Visible = true;
            button25.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;

            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label12.Visible = false;

            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;

            listBox2.Items.Clear();
            READ.Close();
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM " + textBox4.Text + "", Connect);

            READ = COM.ExecuteReader();

            while (READ.Read())
                listBox2.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(25) + "\t" + READ.GetValue(4).ToString().PadRight(30));

            Connect.Close();
        }

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
            int g = 1;
            ShowImage();
            textBox4.Text = "Rezerv";

            button11.Visible = false;
            button25.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;

            label17.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            label24.Visible = true;

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label12.Visible = false;

            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;

            listBox2.Items.Clear();
            READ.Close();
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM " + textBox4.Text + "", Connect);

            READ = COM.ExecuteReader();
            while (READ.Read())
                listBox2.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(25) + "\t" + READ.GetValue(4).ToString().PadRight(30));

            Connect.Close();
        }

		private void timer2_Tick(object sender, EventArgs e)
		{
            listBox2.Items.Clear();
            READ.Close();
            string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection Connect = new SqlConnection(CON);
            Connect.Open();

            COM = new SqlCommand("SELECT * FROM " + textBox4.Text + "", Connect);

            READ = COM.ExecuteReader();

            while (READ.Read())
                listBox2.Items.Add(READ.GetValue(0).ToString().PadRight(7) + "\t" + READ.GetValue(1).ToString().PadRight(20) + "\t" + READ.GetValue(2).ToString().PadRight(21) + "\t" + READ.GetValue(3).ToString().PadRight(25) + "\t" + READ.GetValue(4).ToString().PadRight(30));


            Connect.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                timer2.Enabled = true;
            else
                timer2.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.JPEG; *.GIF | All files(*.*) | *.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    byte[] img = GetPhoto(open_dialog.FileName);

                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = Image.FromFile(open_dialog.FileName);

                }

                catch (Exception n)
                {
                    DialogResult rezult = MessageBox.Show(n.Message, n.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olegv\Documents\NightClub.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection Connect = new SqlConnection(CON);
                Connect.Open();

                try
                {
                    COM = new SqlCommand("SELECT * FROM " + textBox4.Text + "", Connect);
                    COM.CommandText = "UPDATE " + textBox4.Text + " SET Image = @Image where id = " + textBox3.Text + " + 1; ";
                    byte[] img = GetPhoto(open_dialog.FileName);
                    COM.Parameters.Add("@Image", SqlDbType.Image, img.Length);
                    COM.Parameters["@Image"].Value = img;

                    COM.ExecuteNonQuery();
                }

                catch (Exception n)
                {
                    MessageBox.Show(n.Message, n.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    Connect.Close();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            form.Show();
        }
    }
}