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

        }

        private void btFind_Click(object sender, EventArgs e)
        {
            if(dataGridViewAuthor==null)
            dataGridViewAuthor.Rows.Clear();

            using (Library3Entities db = new Library3Entities())
            {

                var books = db.Book.Join(db.Author,
                        b=>b.IdAuthor,
                        a=>a.Id,

                        (b, a)=> new
                        {
                            b.Title,
                            a.LastName
                        }
                    );

                var books2 = (from x in books where x.LastName.Contains(tbFind.Text) select new { x.Title, x.LastName });

                 if (books2 != null)
                    dataGridViewAuthor.DataSource = books2.ToList();
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
