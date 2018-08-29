using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryWinFormEntity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //var columnAuthorName = new DataGridViewColumn();
            //columnAuthorName.CellTemplate = new DataGridViewTextBoxCell();

            //var columnAuthorLastName = new DataGridViewColumn();
            //columnAuthorLastName.CellTemplate = new DataGridViewTextBoxCell();

            //var columnBookTitle = new DataGridViewColumn();
            //columnBookTitle.CellTemplate = new DataGridViewTextBoxCell();

            //dataGridViewAuthor.Columns.Add(columnAuthorName);
            //dataGridViewAuthor.Columns.Add(columnAuthorLastName);
            //dataGridViewAuthor.Columns.Add(columnBookTitle);

        }

        private void btFind_Click(object sender, EventArgs e)
        {
            if(dataGridViewAuthor==null)
            dataGridViewAuthor.Rows.Clear();

            using (Library3Entities db = new Library3Entities())
            {

                var authors = (from a in db.Author where a.LastName.Contains(tbFind.Text) select new { a.FirstName, a.LastName });

                if(authors!=null)
                dataGridViewAuthor.DataSource = authors.ToList();
            }
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
