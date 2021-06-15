using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Console;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        string filePathStock = "stock.txt";
        string filePathWork = "work_lamp.txt";
        string filePathGuarantee = "guarantee.txt";
        string filePathDate = "date.txt";
        string filePathLog = "log.txt";
        int[] work_lamp = new int[67];
        int[] before = new int[67];

        public Form1()
        {
            InitializeComponent();

            //считывание инфо по запасам лампочек
            if (File.Exists(filePathStock))
            {
                using (FileStream fs = new FileStream(filePathStock, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                    {
                        string temp = sr.ReadToEnd();
                        string[] tmp = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < tmp.Length; i++)
                        {
                            textBox5.Text = tmp[0].Trim(' ');
                            textBox6.Text = tmp[1].Trim(' ');
                            textBox7.Text = tmp[2].Trim(' ');
                            textBox8.Text = tmp[3].Trim(' ');
                            textBox9.Text = tmp[4].Trim(' ');
                            textBox10.Text = tmp[5].Trim(' ');
                            textBox11.Text = tmp[6].Trim(' ');
                            textBox12.Text = tmp[7].Trim(' ');
                        }
                    }
                }
            }


            //считывание инфо по рабочим лампочкам
            if (File.Exists(filePathWork))
            {
                using (FileStream fs = new FileStream(filePathWork, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                    {
                        string temp = sr.ReadToEnd();
                        for (int i = 0; i < temp.Length; i++)
                            work_lamp[i] = int.Parse(temp[i].ToString());
                    }
                }
            }
            //инициализация имён чекбоксов, чтобы не прописывать их вручную - не работает
            // string[] checkBox = new string[work_lamp.Length];
            //for (int i = 0; i < work_lamp.Length; i++)
            //    checkBox[i] = "checkBox" + (i + 1);

            #region заполнение чекбоксов из файла
            if (work_lamp[0] == 1)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            if (work_lamp[1] == 1)
                checkBox2.Checked = true;
            else
                checkBox2.Checked = false;
            if (work_lamp[2] == 1)
                checkBox3.Checked = true;
            else
                checkBox3.Checked = false;
            if (work_lamp[3] == 1)
                checkBox4.Checked = true;
            else
                checkBox4.Checked = false;
            if (work_lamp[4] == 1)
                checkBox5.Checked = true;
            else
                checkBox5.Checked = false;
            if (work_lamp[5] == 1)
                checkBox6.Checked = true;
            else
                checkBox6.Checked = false;
            if (work_lamp[6] == 1)
                checkBox7.Checked = true;
            else
                checkBox7.Checked = false;
            if (work_lamp[7] == 1)
                checkBox8.Checked = true;
            else
                checkBox8.Checked = false;
            if (work_lamp[8] == 1)
                checkBox9.Checked = true;
            else
                checkBox9.Checked = false;
            if (work_lamp[9] == 1)
                checkBox10.Checked = true;
            else
                checkBox10.Checked = false;
            if (work_lamp[10] == 1)
                checkBox11.Checked = true;
            else
                checkBox11.Checked = false;
            if (work_lamp[11] == 1)
                checkBox12.Checked = true;
            else
                checkBox12.Checked = false;
            if (work_lamp[12] == 1)
                checkBox13.Checked = true;
            else
                checkBox13.Checked = false;
            if (work_lamp[13] == 1)
                checkBox14.Checked = true;
            else
                checkBox14.Checked = false;
            if (work_lamp[14] == 1)
                checkBox15.Checked = true;
            else
                checkBox15.Checked = false;
            if (work_lamp[15] == 1)
                checkBox16.Checked = true;
            else
                checkBox16.Checked = false;
            if (work_lamp[16] == 1)
                checkBox17.Checked = true;
            else
                checkBox17.Checked = false;
            if (work_lamp[17] == 1)
                checkBox18.Checked = true;
            else
                checkBox18.Checked = false;
            if (work_lamp[18] == 1)
                checkBox19.Checked = true;
            else
                checkBox19.Checked = false;
            if (work_lamp[19] == 1)
                checkBox20.Checked = true;
            else
                checkBox20.Checked = false;
            if (work_lamp[20] == 1)
                checkBox21.Checked = true;
            else
                checkBox21.Checked = false;
            if (work_lamp[21] == 1)
                checkBox22.Checked = true;
            else
                checkBox22.Checked = false;
            if (work_lamp[22] == 1)
                checkBox23.Checked = true;
            else
                checkBox23.Checked = false;
            if (work_lamp[23] == 1)
                checkBox24.Checked = true;
            else
                checkBox24.Checked = false;
            if (work_lamp[24] == 1)
                checkBox25.Checked = true;
            else
                checkBox25.Checked = false;
            if (work_lamp[25] == 1)
                checkBox26.Checked = true;
            else
                checkBox26.Checked = false;
            if (work_lamp[26] == 1)
                checkBox27.Checked = true;
            else
                checkBox27.Checked = false;
            if (work_lamp[27] == 1)
                checkBox28.Checked = true;
            else
                checkBox28.Checked = false;
            if (work_lamp[28] == 1)
                checkBox29.Checked = true;
            else
                checkBox29.Checked = false;
            if (work_lamp[29] == 1)
                checkBox30.Checked = true;
            else
                checkBox30.Checked = false;
            if (work_lamp[30] == 1)
                checkBox31.Checked = true;
            else
                checkBox31.Checked = false;
            if (work_lamp[31] == 1)
                checkBox32.Checked = true;
            else
                checkBox32.Checked = false;
            if (work_lamp[32] == 1)
                checkBox33.Checked = true;
            else
                checkBox33.Checked = false;
            if (work_lamp[33] == 1)
                checkBox34.Checked = true;
            else
                checkBox34.Checked = false;
            if (work_lamp[34] == 1)
                checkBox35.Checked = true;
            else
                checkBox35.Checked = false;
            if (work_lamp[35] == 1)
                checkBox36.Checked = true;
            else
                checkBox36.Checked = false;
            if (work_lamp[36] == 1)
                checkBox37.Checked = true;
            else
                checkBox37.Checked = false;
            if (work_lamp[37] == 1)
                checkBox38.Checked = true;
            else
                checkBox38.Checked = false;
            if (work_lamp[38] == 1)
                checkBox39.Checked = true;
            else
                checkBox39.Checked = false;
            if (work_lamp[39] == 1)
                checkBox40.Checked = true;
            else
                checkBox40.Checked = false;
            if (work_lamp[40] == 1)
                checkBox41.Checked = true;
            else
                checkBox41.Checked = false;
            if (work_lamp[41] == 1)
                checkBox42.Checked = true;
            else
                checkBox42.Checked = false;
            if (work_lamp[42] == 1)
                checkBox43.Checked = true;
            else
                checkBox43.Checked = false;
            if (work_lamp[43] == 1)
                checkBox44.Checked = true;
            else
                checkBox44.Checked = false;
            if (work_lamp[44] == 1)
                checkBox45.Checked = true;
            else
                checkBox45.Checked = false;
            if (work_lamp[45] == 1)
                checkBox46.Checked = true;
            else
                checkBox46.Checked = false;
            if (work_lamp[46] == 1)
                checkBox47.Checked = true;
            else
                checkBox47.Checked = false;
            if (work_lamp[47] == 1)
                checkBox48.Checked = true;
            else
                checkBox48.Checked = false;
            if (work_lamp[48] == 1)
                checkBox49.Checked = true;
            else
                checkBox49.Checked = false;
            if (work_lamp[49] == 1)
                checkBox50.Checked = true;
            else
                checkBox50.Checked = false;
            if (work_lamp[50] == 1)
                checkBox51.Checked = true;
            else
                checkBox51.Checked = false;
            if (work_lamp[51] == 1)
                checkBox52.Checked = true;
            else
                checkBox52.Checked = false;
            if (work_lamp[52] == 1)
                checkBox53.Checked = true;
            else
                checkBox53.Checked = false;
            if (work_lamp[53] == 1)
                checkBox54.Checked = true;
            else
                checkBox54.Checked = false;
            if (work_lamp[54] == 1)
                checkBox55.Checked = true;
            else
                checkBox55.Checked = false;
            if (work_lamp[55] == 1)
                checkBox56.Checked = true;
            else
                checkBox56.Checked = false;
            if (work_lamp[56] == 1)
                checkBox57.Checked = true;
            else
                checkBox57.Checked = false;
            if (work_lamp[57] == 1)
                checkBox58.Checked = true;
            else
                checkBox58.Checked = false;
            if (work_lamp[58] == 1)
                checkBox59.Checked = true;
            else
                checkBox59.Checked = false;
            if (work_lamp[59] == 1)
                checkBox60.Checked = true;
            else
                checkBox60.Checked = false;
            if (work_lamp[60] == 1)
                checkBox61.Checked = true;
            else
                checkBox61.Checked = false;
            if (work_lamp[61] == 1)
                checkBox62.Checked = true;
            else
                checkBox62.Checked = false;
            if (work_lamp[62] == 1)
                checkBox63.Checked = true;
            else
                checkBox63.Checked = false;
            if (work_lamp[63] == 1)
                checkBox64.Checked = true;
            else
                checkBox64.Checked = false;
            if (work_lamp[64] == 1)
                checkBox65.Checked = true;
            else
                checkBox65.Checked = false;
            if (work_lamp[65] == 1)
                checkBox66.Checked = true;
            else
                checkBox66.Checked = false;
            if (work_lamp[66] == 1)
                checkBox67.Checked = true;
            else
                checkBox67.Checked = false;
            Array.Copy(work_lamp, before, work_lamp.Length);
            #endregion

            //считывание инфо по гарантиям
            if (File.Exists(filePathGuarantee))
                using (FileStream fs = new FileStream(filePathGuarantee, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                    {
                        string temp = sr.ReadToEnd();
                        string[] tmp = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < tmp.Length; i++)
                        {
                            if (tmp[i][0] == '1')
                                textBox1.Text = tmp[i].Remove(0, 1);
                            if (tmp[i][0] == '2')
                                textBox2.Text = tmp[i].Remove(0, 1);
                            if (tmp[i][0] == '3')
                                textBox3.Text = tmp[i].Remove(0, 1);
                            if (tmp[i][0] == '4')
                                textBox4.Text = tmp[i].Remove(0, 1);
                        }
                    }
                }

            //считывание даты последних изменений
            if (File.Exists(filePathDate))
                using (FileStream fs = new FileStream(filePathDate, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                    {
                        label25.Text = sr.ReadToEnd();
                    }
                }
        }

        #region изменение состояния чекбоксов
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                work_lamp[0] = 1;
            else
                work_lamp[0] = 0;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                work_lamp[1] = 1;
            else
                work_lamp[1] = 0;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                work_lamp[2] = 1;
            else
                work_lamp[2] = 0;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                work_lamp[3] = 1;
            else
                work_lamp[3] = 0;
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                work_lamp[4] = 1;
            else
                work_lamp[4] = 0;
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
                work_lamp[5] = 1;
            else
                work_lamp[5] = 0;
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
                work_lamp[6] = 1;
            else
                work_lamp[6] = 0;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
                work_lamp[7] = 1;
            else
                work_lamp[7] = 0;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
                work_lamp[8] = 1;
            else
                work_lamp[8] = 0;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
                work_lamp[9] = 1;
            else
                work_lamp[9] = 0;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
                work_lamp[10] = 1;
            else
                work_lamp[10] = 0;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
                work_lamp[11] = 1;
            else
                work_lamp[11] = 0;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
                work_lamp[12] = 1;
            else
                work_lamp[12] = 0;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
                work_lamp[13] = 1;
            else
                work_lamp[13] = 0;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
                work_lamp[14] = 1;
            else
                work_lamp[14] = 0;
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
                work_lamp[15] = 1;
            else
                work_lamp[15] = 0;
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
                work_lamp[16] = 1;
            else
                work_lamp[16] = 0;
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
                work_lamp[17] = 1;
            else
                work_lamp[17] = 0;
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
                work_lamp[18] = 1;
            else
                work_lamp[18] = 0;
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked)
                work_lamp[19] = 1;
            else
                work_lamp[19] = 0;
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
                work_lamp[20] = 1;
            else
                work_lamp[20] = 0;
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
                work_lamp[21] = 1;
            else
                work_lamp[21] = 0;
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked)
                work_lamp[22] = 1;
            else
                work_lamp[22] = 0;
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked)
                work_lamp[23] = 1;
            else
                work_lamp[23] = 0;
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked)
                work_lamp[24] = 1;
            else
                work_lamp[24] = 0;
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked)
                work_lamp[25] = 1;
            else
                work_lamp[25] = 0;
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked)
                work_lamp[26] = 1;
            else
                work_lamp[26] = 0;
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked)
                work_lamp[27] = 1;
            else
                work_lamp[27] = 0;
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked)
                work_lamp[28] = 1;
            else
                work_lamp[28] = 0;
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked)
                work_lamp[29] = 1;
            else
                work_lamp[29] = 0;
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked)
                work_lamp[30] = 1;
            else
                work_lamp[30] = 0;
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked)
                work_lamp[31] = 1;
            else
                work_lamp[31] = 0;
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox33.Checked)
                work_lamp[32] = 1;
            else
                work_lamp[32] = 0;
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox34.Checked)
                work_lamp[33] = 1;
            else
                work_lamp[33] = 0;
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox35.Checked)
                work_lamp[34] = 1;
            else
                work_lamp[34] = 0;
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox36.Checked)
                work_lamp[35] = 1;
            else
                work_lamp[35] = 0;
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox37.Checked)
                work_lamp[36] = 1;
            else
                work_lamp[36] = 0;
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox38.Checked)
                work_lamp[37] = 1;
            else
                work_lamp[37] = 0;
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox39.Checked)
                work_lamp[38] = 1;
            else
                work_lamp[38] = 0;
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox40.Checked)
                work_lamp[39] = 1;
            else
                work_lamp[39] = 0;
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox41.Checked)
                work_lamp[40] = 1;
            else
                work_lamp[40] = 0;
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox42.Checked)
                work_lamp[41] = 1;
            else
                work_lamp[41] = 0;
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox43.Checked)
                work_lamp[42] = 1;
            else
                work_lamp[42] = 0;
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox44.Checked)
                work_lamp[43] = 1;
            else
                work_lamp[43] = 0;
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox45.Checked)
                work_lamp[44] = 1;
            else
                work_lamp[44] = 0;
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox46.Checked)
                work_lamp[45] = 1;
            else
                work_lamp[45] = 0;
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox47.Checked)
                work_lamp[46] = 1;
            else
                work_lamp[46] = 0;
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox48.Checked)
                work_lamp[47] = 1;
            else
                work_lamp[47] = 0;
        }

        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox49.Checked)
                work_lamp[48] = 1;
            else
                work_lamp[48] = 0;
        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox50.Checked)
                work_lamp[49] = 1;
            else
                work_lamp[49] = 0;
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox51.Checked)
                work_lamp[50] = 1;
            else
                work_lamp[50] = 0;
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox52.Checked)
                work_lamp[51] = 1;
            else
                work_lamp[51] = 0;
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox53.Checked)
                work_lamp[52] = 1;
            else
                work_lamp[52] = 0;
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox54.Checked)
                work_lamp[53] = 1;
            else
                work_lamp[53] = 0;
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox55.Checked)
                work_lamp[54] = 1;
            else
                work_lamp[54] = 0;
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox56.Checked)
                work_lamp[55] = 1;
            else
                work_lamp[55] = 0;
        }

        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox57.Checked)
                work_lamp[56] = 1;
            else
                work_lamp[56] = 0;
        }

        private void checkBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox58.Checked)
                work_lamp[57] = 1;
            else
                work_lamp[57] = 0;
        }

        private void checkBox59_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox59.Checked)
                work_lamp[58] = 1;
            else
                work_lamp[58] = 0;
        }

        private void checkBox60_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox60.Checked)
                work_lamp[59] = 1;
            else
                work_lamp[59] = 0;
        }

        private void checkBox61_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox61.Checked)
                work_lamp[60] = 1;
            else
                work_lamp[60] = 0;
        }

        private void checkBox62_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox62.Checked)
                work_lamp[61] = 1;
            else
                work_lamp[61] = 0;
        }

        private void checkBox63_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox63.Checked)
                work_lamp[62] = 1;
            else
                work_lamp[62] = 0;
        }

        private void checkBox64_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox64.Checked)
                work_lamp[63] = 1;
            else
                work_lamp[63] = 0;
        }

        private void checkBox65_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox65.Checked)
                work_lamp[64] = 1;
            else
                work_lamp[64] = 0;
        }

        private void checkBox66_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox66.Checked)
                work_lamp[65] = 1;
            else
                work_lamp[65] = 0;
        }

        private void checkBox67_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox67.Checked)
                work_lamp[66] = 1;
            else
                work_lamp[66] = 0;
        }
        #endregion

       

        //логирование
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(filePathStock, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write(textBox5.Text + " \n");
                    sw.Write(textBox6.Text + " \n");
                    sw.Write(textBox7.Text + " \n");
                    sw.Write(textBox8.Text + " \n");
                    sw.Write(textBox9.Text + " \n");
                    sw.Write(textBox10.Text + " \n");
                    sw.Write(textBox11.Text + " \n");
                    sw.Write(textBox12.Text + " \n");
                }
            }

            using (FileStream fs = new FileStream(filePathWork, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    for (int i = 0; i < work_lamp.Length; i++)
                    {
                        sw.Write(work_lamp[i]);
                    }
                }
            }

            using (FileStream fs = new FileStream(filePathGuarantee, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write("1" + textBox1.Text + "\n");
                    sw.Write("2" + textBox2.Text + "\n");
                    sw.Write("3" + textBox3.Text + "\n");
                    sw.Write("4" + textBox4.Text + "\n");
                }
            }

            label25.Text = DateTime.Now.ToLongDateString();
            using (FileStream fs = new FileStream(filePathDate, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write(DateTime.Now.ToLongDateString());
                }
            }

            for (int i = 0; i < before.Length; i++)
            {
                if (before[i] != work_lamp[i])
                {
                    if (before[i] == 0)
                    {
                        if (i <= 5)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (спальня, дом 1)");
                        if (i >= 6 && i <= 8)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (кухня, дом 1)");
                        if (i >= 9 && i <= 14)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (терраса, дом 1)");
                        if (i >= 15 && i <= 20)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (спальня, дом 2)");
                        if (i >= 21 && i <= 23)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (кухня, дом 2)");
                        if (i > 24 && i <= 33)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (терраса, дом 2)");
                        if (i >= 34 && i <= 39)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (спальня, дом 3)");
                        if (i >= 40 && i <= 42)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (кухня, дом 3)");
                        if (i >= 43 && i <= 52)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (терраса, дом 3)");
                        if (i >= 53 && i <= 57)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (спальня, дом 4)");
                        if (i >= 58 && i <= 60)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (кухня, дом 4)");
                        if (i >= 61)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " заменена лампа №" + (i + 1) + " (терраса, дом 4)");
                    }
                    else
                    {
                        if (i <= 5)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (спальня, дом 1)");
                        if (i >= 6 && i <= 8)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (кухня, дом 1)");
                        if (i >= 9 && i <= 14)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (терраса, дом 1)");
                        if (i >= 15 && i <= 20)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (спальня, дом 2)");
                        if (i >= 21 && i <= 23)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (кухня, дом 2)");
                        if (i > 24 && i <= 33)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (терраса, дом 2)");
                        if (i >= 34 && i <= 39)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (спальня, дом 3)");
                        if (i >= 40 && i <= 42)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (кухня, дом 3)");
                        if (i >= 43 && i <= 52)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (терраса, дом 3)");
                        if (i >= 53 && i <= 57)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (спальня, дом 4)");
                        if (i >= 58 && i <= 60)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (кухня, дом 4)");
                        if (i >= 61)
                            Logs.WriteTXT(filePathLog, DateTime.Now.ToLongDateString() + " перегорела лампа №" + (i + 1) + " (терраса, дом 4)");
                    }
                }
            }

            Array.Copy(work_lamp, before, work_lamp.Length);
        }

        //открытие лога
        private void button2_Click_1(object sender, EventArgs e)
        {
            Process.Start(filePathLog);
        }

     
    }
    class Logs
    {

        public static void WriteTXT(string filePathLog, string message)
        {
            using (FileStream fs = new FileStream(filePathLog, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}
