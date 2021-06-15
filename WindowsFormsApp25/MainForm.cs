using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp10;

namespace WindowsFormsApp25
{
    public partial class MainForm : Form
    {
        public DefectationEntities db;
        AddForm add; // обьект формы для добавления
        string buf;// обьект для конверта
        InfoForm f3;// обьект для формы отображения информации
        Graphic f4;// обьект для формы с графиком
        Form1 f1;// обьект для формы с лампочками
        public MainForm()
        {

            InitializeComponent();
            db = new DefectationEntities(); // получаем данные из базы данных
            db.Information.Load(); 
            db.Houses.Load();
            db.Sectors.Load();              // Актуализируем информацию в таблицах
            db.Undersectors.Load();
            GetAllHouses();        
            GetAllSectors();
            

            var permanent = from i in db.Information                    
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where h.house_name == "дом 1" && i.date_end == null
                            orderby i.date_begine
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
                            }; // запрос для получения информации из бд

            foreach (var item in permanent) // цикл визуального отображения поломок
            {
                if (item.End_Date == null)
                {
                    Text = item.House_Name;
                    if (item.Part_Name.ToLower() == button1.Text.ToLower())
                        button1.BackColor = Color.Red;
                    if (item.Part_Name.ToLower() == button3.Text.ToLower())
                        button3.BackColor = Color.Red;
                    if (item.Part_Name.ToLower() == button4.Text.ToLower())
                        button4.BackColor = Color.Red;
                    if (item.Part_Name.ToLower() == button5.Text.ToLower())
                        button5.BackColor = Color.Red;
                    if (item.Part_Name.ToLower() == button6.Text.ToLower())
                        button6.BackColor = Color.Red;
                }
            }


        }
        private void ButtonInvoke(Color c,Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<Color,Control>(ButtonInvoke), c,control);
            }
            control.BackColor = c;
        }
        private void ComboBoxInvoke(string house)
        {
            if (toolStrip1.InvokeRequired)
            {
                toolStrip1.Invoke(new Action<string>(ComboBoxInvoke), house);
            }
            toolStripComboBox1.Items.Add(house);
            toolStripComboBox1.SelectedIndex = 0;
        }
        private void GetAllHouses() // Функция для получения всех названий домов в комбобокс 
        {
            var permanent = from i in db.Houses
                            select i;
            foreach (var item in permanent)
            {
                //toolStripComboBox1.Items.Add(item.house_name);
                ComboBoxInvoke(item.house_name);
            }
        }
        private void GetAllSectors() // Функция для получения всех названий секторов в комбобокс 
        {
            var permanent = from i in db.Sectors
                            select i;
            foreach (var item in permanent)
            {
                toolStripComboBox2.Items.Add(item.sector_name);
                //ComboBoxInvoke(item.part_name);
            }
        }

        public void Converter(AddForm f2) // Функция для перевода данных в значения необходимые базе данных 
        {
            db.Parts.Load();
            db.Houses.Load();
            db.Sectors.Load();
            db.Undersectors.Load();
            var permanent = from i in db.Houses
                            select i;
            foreach (var item in permanent)
                if (f2.comboBox1.Text.ToLower() == item.house_name.ToLower())
                    f2.comboBox1.Text = item.id.ToString();
            var permanent1 = from i in db.Parts
                             select i;
            foreach (var item in permanent1)
                if (f2.comboBox2.Text.ToLower() == item.part_name.ToLower())
                    f2.comboBox2.Text = item.id.ToString();
            var permanent2 = from i in db.Sectors
                             select i;
            foreach (var item in permanent2)
                if (f2.comboBox3.Text.ToLower() == item.sector_name.ToLower())
                    f2.comboBox3.Text = item.id.ToString();
            var permanent3 = from i in db.Undersectors
                             select i;
            foreach (var item in permanent3)
                if (f2.comboBox6.Text.ToLower() == item.undersector_name.ToLower())
                    f2.comboBox6.Text = item.id.ToString();
        }
        public void ConverterId(AddForm f2) // Функция для перевода данных в значения необходимые базе данных 
        {
            db.Parts.Load();
            db.Houses.Load();
            db.Sectors.Load();
            db.Undersectors.Load();
            var permanent = from i in db.Houses
                            select i;
            foreach (var item in permanent)
                if (Convert.ToInt32(f2.comboBox1.Text) == item.id)
                {
                    f2.comboBox1.Text = item.house_name.ToString();
                    break;
                }
            var permanent1 = from i in db.Parts
                             select i;
            foreach (var item in permanent1)
                if (Convert.ToInt32(f2.comboBox2.Text) == item.id)
                {
                    f2.comboBox2.Text = item.part_name;
                    break;
                }
            var permanent2 = from i in db.Sectors
                             select i;
            foreach (var item in permanent2)
                if (Convert.ToInt32(f2.comboBox3.Text) == item.id)
                {
                    f2.comboBox3.Text = item.sector_name;
                    break;
                }
            var permanent3 = from i in db.Undersectors
                             select i;
            foreach (var item in permanent3)
                if (Convert.ToInt32(f2.comboBox6.Text) == item.id)
                {
                    f2.comboBox6.Text = item.undersector_name;
                    break;
                }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            add = new AddForm();
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where h.house_name == "дом 1"
                            orderby i.date_begine
                            orderby i.date_begine
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
            var permhouse = (from i in db.Houses
                            select i).OrderBy(t => t.house_name);
            foreach (var item in permhouse)
            {
                add.comboBox1.Items.Add(item.house_name);
            }
            var permparts = (from i in db.Parts
                            select i).OrderBy(t => t.part_name);
            foreach (var item in permparts)
            {
                add.comboBox2.Items.Add(item.part_name);
            }
            var permsectors= (from i in db.Sectors
                            select i).OrderBy(t => t.sector_name);
            foreach (var item in permsectors)
            {
                add.comboBox3.Items.Add(item.sector_name);
            }
            var permunder = (from i in db.Undersectors
                            select i).OrderBy(t=> t.undersector_name);
            foreach (var item in permunder)
            {
                add.comboBox6.Items.Add(item.undersector_name);
            }
            if (add.ShowDialog() == DialogResult.OK) 
            {

                Converter(add);
                Information information = new Information(); // обьект для добавления в бд
                information.house_id = Convert.ToInt32(add.comboBox1.Text);
                information.part_id = Convert.ToInt32(add.comboBox2.Text);
                information.sector_id = Convert.ToInt32(add.comboBox3.Text);
                information.undersector_id = Convert.ToInt32(add.comboBox6.Text);
                information.breaking = add.textBox1.Text;
                information.repairs = add.textBox2.Text;
                information.date_begine = Convert.ToDateTime(add.dateTimePicker1.Value);
                if(add.checkBox1.Checked == true)
                    information.date_end = null;
                else
                information.date_end = Convert.ToDateTime(add.dateTimePicker2.Value);
                information.cost = Convert.ToDouble(add.textBox7.Text);
                db.Information.Add(information); //  добавление в бд
                db.SaveChanges();
            }
        }

        private void toolStripLabel1_MouseEnter(object sender, EventArgs e)
        {
            ToolStripItem i = (ToolStripItem)sender;
            i.ForeColor = Color.Aqua;
        }

        private void toolStripLabel1_MouseLeave(object sender, EventArgs e)
        {
            ToolStripItem i = (ToolStripItem)sender;
            i.ForeColor = Control.DefaultForeColor;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            f3 = new InfoForm(this);
            db.Information.Load();
            db.Houses.Load();
            db.Sectors.Load();
            db.Undersectors.Load();

            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where i.date_end == null
                            orderby i.date_begine
                            select new
                            {
                                Case_id = i.id,
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
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value; // сохраняем данные в переменные чтобы использовать как параметры в запрос к бд
            DateTime dt2 = dateTimePicker2.Value;
            f3 = new InfoForm(this);
            db.Information.Load();
            db.Houses.Load();
            db.Sectors.Load();
            db.Undersectors.Load();
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where i.date_begine > dt1 && i.date_begine < dt2
                            orderby i.date_begine
                            select new
                            {
                                Case_id = i.id,
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
            double all = 0; // переменная общей стоимости всех ремонтов
            foreach (var item in permanent)
            {
                all += Convert.ToDouble(item.Cost);
            }
            MessageBox.Show("Стоимость всех ремонтов: " + all.ToString() + " грн");
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
           
            f3 = new InfoForm(this);
            db.Information.Load();
            db.Houses.Load();
            db.Sectors.Load();
            db.Undersectors.Load();
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where i.date_end != null
                            orderby i.date_begine
                            select new
                            {
                                Case_id = i.id,
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
            double all = 0; // переменная общей стоимости всех ремонтов
            foreach (var item in permanent)
            {
                all += Convert.ToDouble(item.Cost);
            }
            MessageBox.Show("Стоимость всех ремонтов: " + all.ToString() + " грн");
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            f3 = new InfoForm(this);
            db.Information.Load();
            db.Houses.Load();
            db.Sectors.Load();
            db.Undersectors.Load();
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            orderby i.date_begine
                            select new
                            {
                                Case_id = i.id,
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
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.BackColor = Button.DefaultBackColor;
            button3.BackColor = Button.DefaultBackColor;
            button4.BackColor = Button.DefaultBackColor;
            button5.BackColor = Button.DefaultBackColor; // Обнавляем цвета всех кнопок
            button6.BackColor = Button.DefaultBackColor;
            buf = toolStrip1.Items["toolStripComboBox1"].Text;  // сохраняем данные в переменные чтобы использовать как параметры в запрос к бд
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where h.house_name == buf && i.date_end == null
                            select new
                            {
                                Case_id = i.id,
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
            foreach (var item in permanent) // цикл визуального отображения поломок
            {
                if (item.End_Date == null)
                {
                    if (item.Part_Name.ToLower() == button1.Text.ToLower())
                        button1.BackColor = Color.Red;
                    if (item.Part_Name.ToLower() == button3.Text.ToLower())
                        button3.BackColor = Color.Red;
                    if (item.Part_Name.ToLower() == button4.Text.ToLower())
                        button4.BackColor = Color.Red;
                    if (item.Part_Name.ToLower() == button5.Text.ToLower())
                        button5.BackColor = Color.Red;
                    if (item.Part_Name.ToLower() == button6.Text.ToLower())
                        button6.BackColor = Color.Red;
                }
            }
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {

            f4 = new Graphic();
            buf = toolStrip1.Items["toolStripComboBox2"].Text; // сохраняем данные в переменные чтобы использовать как параметры в запрос к бд
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where s.sector_name == buf
                            orderby i.date_begine
                            select new
                            {
                                Case_id = i.id,
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

            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series   //создаем обьект графика
            {

            };
            foreach (var item in permanent) // наполняем обьект графика точками
            {
                f4.chart1.Text = "Частота поломок объекта: " + item.House_Name + " в части " + item.Part_Name + " - " + item.Sector_Name;
                series1.Points.AddXY(item.Start_Date, 1);
            }
            f4.chart1.Series.Add(series1); // добавляем обьект в график
            f4.dataGridView1.DataSource = permanent.ToList();
            f4.ShowDialog();
        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {
            f1 = new Form1();
            f1.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            buf = toolStrip1.Items["toolStripComboBox1"].Text;
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where h.house_name == buf && i.date_end == null && p.part_name == button1.Text
                            select new
                            {
                                Case_id = i.id,
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
            f3 = new InfoForm(this);
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buf = toolStrip1.Items["toolStripComboBox1"].Text; // сохраняем данные в переменные чтобы использовать как параметры в запрос к бд
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where h.house_name == buf && i.date_end == null && p.part_name == button6.Text
                            select new
                            {
                                Case_id = i.id,
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
            f3 = new InfoForm();
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buf = toolStrip1.Items["toolStripComboBox1"].Text; // сохраняем данные в переменные чтобы использовать как параметры в запрос к бд
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where h.house_name == buf && i.date_end == null && p.part_name == button3.Text
                            select new
                            {
                                Case_id = i.id,
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
            f3 = new InfoForm();
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buf = toolStrip1.Items["toolStripComboBox1"].Text; // сохраняем данные в переменные чтобы использовать как параметры в запрос к бд
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where h.house_name == buf && i.date_end == null && p.part_name == button4.Text
                            select new
                            {
                                Case_id = i.id,
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
            f3 = new InfoForm();
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buf = toolStrip1.Items["toolStripComboBox1"].Text; // сохраняем данные в переменные чтобы использовать как параметры в запрос к бд
            var permanent = from i in db.Information
                            join h in db.Houses on i.house_id equals h.id
                            join s in db.Sectors on i.sector_id equals s.id
                            join us in db.Undersectors on i.undersector_id equals us.id
                            join p in db.Parts on i.part_id equals p.id
                            where h.house_name == buf && i.date_end == null && p.part_name == button5.Text
                            select new
                            {
                                Case_id = i.id,
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
            f3 = new InfoForm();
            f3.dataGridView1.DataSource = permanent.ToList();
            f3.ShowDialog();
        }
    }
}
