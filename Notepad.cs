using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int i = 0;
        string fnm = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
        }

        public void savefile()
        {
            if (i == 0)
            {
                SaveFileDialog SD = new SaveFileDialog();
                SD.DefaultExt = ".txt";
                SD.Title = "Notepad Save File";
                SD.InitialDirectory = @"D:\";
                SD.ShowDialog();
                if (SD.FileName != "")
                {
                    richTextBox1.SaveFile(SD.FileName);
                    fnm = SD.FileName;
                    i = 1;
                }
            }
            else
            {
                richTextBox1.SaveFile(fnm);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.Filter = "Text Files | *.txt";
            OD.ShowDialog();
            if (OD.FileName != "")
            {
                richTextBox1.LoadFile(OD.FileName);
                fnm = OD.FileName;
                i = 1;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult DR = MessageBox.Show("Save?", "Notepad", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DR == DialogResult.Yes)
                {
                    savefile();
                    richTextBox1.Text = "";
                    i = 0;
                    fnm = string.Empty;
                }
                else
                {
                    richTextBox1.Text = "";
                    i = 0;
                    fnm = string.Empty;
                }
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            CD.ShowDialog();
            richTextBox1.ForeColor = CD.Color;
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            CD.ShowDialog();
            richTextBox1.BackColor = CD.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog FD = new FontDialog();
            FD.ShowDialog();
            richTextBox1.Font = FD.Font;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SD = new SaveFileDialog();
            SD.DefaultExt = ".txt";
            SD.ShowDialog();
            if (SD.FileName != "")
            {
                richTextBox1.SaveFile(SD.FileName);
                i = 1;
                fnm = SD.FileName;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text != "" && i == 0)
            {
                DialogResult DR = MessageBox.Show("Save?", "Notepad", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DR == DialogResult.Yes)
                {
                    savefile();
                }
            }
        }
    }
}
