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
    public partial class CrudTableForm : Form
    {
        public CrudTableForm()
        {
            InitializeComponent();
        }

        private void CrudTableForm_Load(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Datasource=C:\\Users\\sanch\\Documents\\mydatabase.sqlite;Version=3");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
