using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MCCC_Name_Chooser
{
    public partial class Main : Form
    {
        int count=0;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var reader = new StreamReader(File.OpenRead("NameList.txt"));
            while (!reader.EndOfStream)
            {
                count++;
                var line = reader.ReadLine();
                listBox1.Items.Add(line);
            }
            reader.Close();
            listBox1.Sorted = true;
            label1.Text = "";
            label2.Text = "";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int WriteCount = 0;
            if(textBox1.Text!="")
            {
                count++;
                listBox1.Items.Add(textBox1.Text);
            }
            var writer = new StreamWriter(File.OpenWrite("NameList.txt"));
            while(WriteCount<count)
            {
                listBox1.SetSelected(WriteCount, true);
                writer.WriteLine(listBox1.SelectedItem.ToString());
                WriteCount++;
            }
            writer.Close();
            listBox1.Sorted = true;
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            count--;
            int WriteCount = 0;
            int index;
            index = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(index);
            if(index!=-1)
            {
                File.WriteAllText("NameList.txt", String.Empty);
                var writer = new StreamWriter(File.OpenWrite("NameList.txt"));

                while (WriteCount < count)
                {
                    listBox1.SetSelected(WriteCount, true);
                    writer.WriteLine(listBox1.SelectedItem.ToString());
                    WriteCount++;
                }
                writer.Close();
            }
            listBox1.Sorted = true;
        }

        private void ButtonStartRoll_Click(object sender, EventArgs e)
        {
            label1.Text = "WINNER";
            int loop = 0;
            int randNum;
            Random rand = new Random();
            loop = 0;
            while (loop != 30)
            {
                randNum = rand.Next(0, count);
                listBox1.SelectedIndex = randNum;
                loop++;
                Thread.Sleep(300);
            }
            loop = 0;
            while (loop != 40)
            {
                randNum = rand.Next(0, count);
                listBox1.SelectedIndex = randNum;
                loop++;
                Thread.Sleep(200);
            }
            loop = 0;
            while (loop != 50)
            {
                randNum = rand.Next(0, count);
                listBox1.SelectedIndex = randNum;
                loop++;
                Thread.Sleep(100);
            }
            loop = 0;
            while (loop != 60)
            {
                randNum = rand.Next(0, count);
                listBox1.SelectedIndex = randNum;
                loop++;
                Thread.Sleep(50);
            }
            label2.Text = listBox1.SelectedItem.ToString();

        }
    }
}
