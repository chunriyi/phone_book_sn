using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phone_Book
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void phone_book_tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phone_book_tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pb_dataset);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pb_dataset.phone_book_table' table. You can move, or remove it, as needed.
            //this.phone_book_tableTableAdapter.Fill_all(this.pb_dataset.phone_book_table);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // the 1st search button, find similar last name in sql server database by entering the 1st letter-----------
            this.phone_book_tableTableAdapter.FillBy_last_name(this.pb_dataset.phone_book_table,
                this.search_tb1.Text + "%");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // load all data
            this.phone_book_tableTableAdapter.Fill_all(this.pb_dataset.phone_book_table);    
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // the 1st search button, find customers by date of birth
            this.phone_book_tableTableAdapter.FillBy_birth_date(this.pb_dataset.phone_book_table,
                this.search_tb2.Text);
        }
    }
}
