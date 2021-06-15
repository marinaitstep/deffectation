using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    public partial class InfoForm : Form
    {
        AddForm f; // обьект формы для добавления
        MainForm m; // обьект основной формы

        public InfoForm()
        {
            InitializeComponent();
        }
        public InfoForm(MainForm mf)  //конструктор класса в котором получаем информацию с основной формы
        {
            InitializeComponent();
            m = mf;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void changeSelectedItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool convert = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id); // парсим индекс строки которую хотим изменить
            if (convert == false)
                return;
            m.db.Information.Load();
            Information information = m.db.Information.FirstOrDefault(q => q.id == id); // получаем обьект из бд
            f = new AddForm();
            var permhouse = (from i in m.db.Houses
                             select i).OrderBy(t => t.house_name);
            foreach (var item in permhouse)
            {
                f.comboBox1.Items.Add(item.house_name);
            }
            var permparts = (from i in m.db.Parts
                             select i).OrderBy(t => t.part_name);
            foreach (var item in permparts)
            {
                f.comboBox2.Items.Add(item.part_name);
            }
            var permsectors = (from i in m.db.Sectors
                               select i).OrderBy(t => t.sector_name);
            foreach (var item in permsectors)
            {
                f.comboBox3.Items.Add(item.sector_name);
            }
            var permunder = (from i in m.db.Undersectors
                             select i).OrderBy(t => t.undersector_name);
            foreach (var item in permunder)
            {
                f.comboBox6.Items.Add(item.undersector_name);
            }
            f.comboBox1.Text = information.house_id.ToString();
            f.comboBox2.Text = information.part_id.ToString();
            f.comboBox3.Text = information.sector_id.ToString();
            f.comboBox6.Text = information.undersector_id.ToString();
            f.textBox1.Text = information.breaking; 
            f.textBox2.Text = information.repairs;
            f.dateTimePicker1.Value = information.date_begine.Date;
            f.textBox7.Text = information.cost.ToString();
            m.ConverterId(f);
            if (f.ShowDialog() == DialogResult.OK)
            {
                information.house_id = Convert.ToInt32(f.comboBox1.Text);
                information.part_id = Convert.ToInt32(f.comboBox2.Text);
                information.sector_id = Convert.ToInt32(f.comboBox3.Text);
                information.undersector_id = Convert.ToInt32(f.comboBox6.Text);
                information.breaking = f.textBox1.Text;
                information.repairs = f.textBox2.Text;
                information.date_begine = Convert.ToDateTime(f.dateTimePicker1.Value);
                if (f.checkBox1.Checked == true)
                    information.date_end = null;
                else
                information.date_end = Convert.ToDateTime(f.dateTimePicker2.Value);
                information.cost = Convert.ToDouble(f.textBox7.Text);
                m.db.SaveChanges(); //сохраняем изменение обьекта
                m.db.Information.Load();
                m.db.Houses.Load();
                m.db.Parts.Load();
                m.db.Sectors.Load(); //обновляем информацию для отображения
                m.db.Undersectors.Load();
                var permanent = from i in m.db.Information
                                join h in m.db.Houses on i.house_id equals h.id
                                join s in m.db.Sectors on i.sector_id equals s.id
                                join us in m.db.Undersectors on i.undersector_id equals us.id
                                join p in m.db.Parts on i.part_id equals p.id
                                where i.date_end == null
                                select new
                                {
                                    House_Name = h.house_name,
                                    Part_Name = p.part_name,
                                    Sector_Name = s.sector_name,
                                    Undersector_Name = us.undersector_name,
                                    Breaking = i.breaking,
                                    Repairs = i.repairs,
                                    Start_Date = i.date_begine,
                                    End_Date = i.date_end,
                                    Cost = i.cost
                                };
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = permanent.ToList();
            }
            else
                return;
        }
    }
}
