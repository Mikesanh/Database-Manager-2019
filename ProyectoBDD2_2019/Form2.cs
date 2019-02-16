using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ProyectoBDD2_2019
{
    public partial class Form2 : Form
    {
        public Form2()
        {


            InitializeComponent();
           
        }

        //Create connection with sqlite db
        private SQLiteConnection con = new SQLiteConnection("Datasource=C:\\Users\\sanch\\Documents\\mydatabase.sqlite;Version=3");
        //Create command
        private  SQLiteCommand cmd;
        private SQLiteDataAdapter sda;
        SQLiteCommandBuilder scmb;
        private DataSet ds= new DataSet();
        

      
        //EXECUTE QUery
        private void ExecuteQuery(string txtquery)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = txtquery;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //FILL COMBO
        void fill_combo()
        {
            //Make a command string (cmdstr)
            string cmdstr = "SELECT  name FROM sqlite_master where type = 'table'"; 

            //Make a Datatable
            DataTable dt = new DataTable();

            // Data Adapter (Command string,connection)
            sda = new SQLiteDataAdapter(cmdstr, con);

            try
            {
                //Fill Data Adapter
                sda.Fill(dt);
                //Fill Combo
                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row["name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //LOAD GRID
        private void load_data()
        {
         
            con.Open();
            cmd = con.CreateCommand();
            string s = "SELECT*from";

            string comboSelectedValue = " "+comboBox1.SelectedItem.ToString();
            string CommandText = string.Concat(s,comboSelectedValue);
           
            sda = new SQLiteDataAdapter(CommandText,con);
            ds.Reset();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }
        private void Form2_Load(object sender, EventArgs e)
        {

            fill_combo();

    

        }

        //ADD GRIDVIEW PARAMTERS TO DATABASE BUTTON
        private void Add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                scmb = new SQLiteCommandBuilder();
                scmb.DataAdapter = sda;
                sda.Update(dataGridView1.DataSource as DataTable);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
     
            


            //string s = "Insert into " + comboBox1.SelectedItem.ToString()+ textBox1.Text.ToString()+
        }

        //EDIT BUTTON
        private void Edit_btn_Click(object sender, EventArgs e)
        {

        }

        //CREATE TABLE BUTTON
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            new CrudTableForm().Show();
        }
        //CREATE VIEW BUTTON
        private void button1_Click(object sender, EventArgs e)
        {

        }
        //RETURN HOME BUTTON
        private void return_login_btn_Click(object sender, EventArgs e)
        {
            new Login().Show();

        }
        //CREATE INDEX BUTTON
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
     
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


//SQLiteConnection con= new SQLiteConnection("Datasource=C:\\Users\\sanch\\Documents\\mydatabase.sqlite;Version=3");
//con.Open();
//SQLiteCommand cmd = new SQLiteCommand();
//cmd.Connection = con;

//cmd.CommandText = "select*from sqlite_master";
//using (SQLiteDataReader sdr = cmd.ExecuteReader())
//{
//    DataTable dt = new DataTable();
//    dt.Load(sdr);
//    sdr.Close();
//    con.Close();
//    dataGridView1.DataSource = dt;
//}