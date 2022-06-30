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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void phone_book_tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phone_book_tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pb_dataset);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'pb_dataset.phone_book_table' table. You can move, or remove it, as needed.
                this.phone_book_tableTableAdapter.Fill_all(this.pb_dataset.phone_book_table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //--------------disable save cancel buttons-----------------
            this.save_butt.Enabled = false;
            this.cancel_butt.Enabled = false;
            //-------------------------------------------------------
            this.groupBox1.Enabled = false;
            this.phone_book_tableDataGridView.Enabled = true;
        }

        //private void birth_dateDateTimePicker_ValueChanged(object sender, EventArgs e)
        //{

        //}

        private void new_butt_Click(object sender, EventArgs e)
        {
            new_edit_del_butt_enable();
            //-----------------------add new record------------------
            this.phone_book_tableBindingSource.AddNew();
            //-------------------------------------------------------
        }

        void new_edit_del_butt_enable()
        {
            this.new_butt.Enabled = false;
            this.edit_butt.Enabled = false;
            this.del_butt.Enabled = false;
            //-------------------disable save & undo---------------
            this.save_butt.Enabled = true;
            this.cancel_butt.Enabled = true;
            //-----------------------------------------------------
            this.groupBox1.Enabled = true;
            this.phone_book_tableDataGridView.Enabled = false;
        }

        private void cancel_butt_Click(object sender, EventArgs e)
        {
            save_cancel_butt_enable();
            this.pb_dataset.phone_book_table.RejectChanges();
            this.phone_book_tableBindingSource.CancelEdit();
        }

        void save_cancel_butt_enable()
        {
            this.save_butt.Enabled = false;
            this.cancel_butt.Enabled = false;
            //-------------enable 3 buttons----------------
            this.new_butt.Enabled = true;
            this.edit_butt.Enabled = true;
            this.del_butt.Enabled = true;
            //--------------------------------------------
            this.groupBox1.Enabled = false;
            this.phone_book_tableDataGridView.Enabled = true;
        }

        private void edit_butt_Click(object sender, EventArgs e)
        {
            //-----------------------------------------
            Int32 rc;
            rc = this.pb_dataset.phone_book_table.Rows.Count;
            if (rc == 0)
            {
                MessageBox.Show("Please select your record to edit!");
                return;
            }
            //-----------------------------------------
            new_edit_del_butt_enable();
        }

        private void del_butt_Click(object sender, EventArgs e)
        {
            //-----------------------------------------
            Int32 rc;
            rc = this.pb_dataset.phone_book_table.Rows.Count;
            if (rc == 0)
            {
                MessageBox.Show("Please select your record to delete!");
                return;
            }
            //-----------------------------------------
            new_edit_del_butt_enable();
            this.groupBox1.Enabled = false;
            //----------------------delete record-------------------
            this.phone_book_tableBindingSource.RemoveCurrent();
            //------------------------------------------------------
        }

        private void save_butt_Click(object sender, EventArgs e)
        {
            save_cancel_butt_enable();
            this.phone_book_tableBindingSource.EndEdit();
            Int32 r;
            try
            {
                r = this.phone_book_tableTableAdapter.Update(this.pb_dataset.phone_book_table);
                if (r > 0)
                {
                    MessageBox.Show("Saved!");
                }
                else
                {
                    MessageBox.Show("Not Saved!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }

        private void search_butt_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
