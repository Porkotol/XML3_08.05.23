using System.Data;

namespace XML3_08._05._23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Заповнiть усi поля. Помилка");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;
            }
            else
            {
                MessageBox.Show("Виберiть рядок.", "Помлика.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Виберiть рядок для видалення.", "Помилка.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("Height");
                dt.Columns.Add("University");
                dt.Columns.Add("Bad habits");
                ds.Tables.Add(dt);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Employee"].NewRow();
                    row["Name"] = r.Cells[0].Value;
                    row["Height"] = r.Cells[1].Value;
                    row["University"] = r.Cells[2].Value;
                    row["Bad habits"] = r.Cells[3].Value;
                    ds.Tables["Employee"].Rows.Add(row);
                    ds.WriteXml("C:\\Important\\XML.xml");
                    MessageBox.Show("XML файл успiшно збережен.", "good.");
                }
            }
            catch
            {
                MessageBox.Show("Неможлиов зберегти файл.", "Помилка.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблиця пуста.", "Помилка.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 0)
            {
                MessageBox.Show("Очистiть поле.", "Помилка.");
            }
            else
            {
                if (File.Exists("C:\\Important\\XML.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("C:\\Important\\XML.xml");

                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["Name"];
                        dataGridView1.Rows[n].Cells[1].Value = item["Height"];
                        dataGridView1.Rows[n].Cells[2].Value = item["University"];
                        dataGridView1.Rows[n].Cells[3].Value = item["Bad habits"];
                    }
                }
                else
                {
                    MessageBox.Show("XML файл не знайден.", "Помилка.");
                }
            }
        }
    }
}