using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lettertype_Chaos
{
    public partial class FontRandomizer : Form
    {        
        public FontRandomizer()
        {
            InitializeComponent();
        }
        private void randomizeFontToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openFile1.DefaultExt = "rtf";
            openFile1.Filter = "RTF Files (*.rtf)|*.rtf|Text files (*.txt)|*.txt";

            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                openFile1.FileName.Length > 0)
            {
                // Load file into the RichTextBox.
                if (openFile1.FilterIndex == 1)
                    richTextBox1.LoadFile(openFile1.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            saveFile1.DefaultExt = "rtf";
            saveFile1.Filter = "RTF Files (*.rtf)|*.rtf|Text files (*.txt)|*.txt";

            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                saveFile1.FileName.Length > 0)
            {
                saveFile1.AddExtension = true;
                if (System.IO.Path.GetExtension(saveFile1.FileName) == "")
                    saveFile1.FileName = saveFile1.FileName + ".xxx";
                // Save contents of RichTextBox to file.				

                if (saveFile1.FilterIndex == 1)
                    richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }


        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        // add word count code here...
        char[] DELIMS = new char[10] { ' ', '.', ',', '?', '!', '-', '_', '+', '*', '/' };
        int charcount = 0;
        
        private bool IsDelimiter(char c)
        {
           bool delimfound = false;
           foreach (char mychar in DELIMS)
           {
               if (mychar == c)
               delimfound = true;
           }
           return delimfound;
        }

        private void FindDelims()
        {
            string s = richTextBox1.Text;
            int delimcount = 0;
            for (int i = 0; i < s.Length; i++)
            {
               if (IsDelimiter(s[i]))
               delimcount++;
            }
            MessageBox.Show("delimcount=" + delimcount,
                "Statistics",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        
        private void ScrollThroughDelims(string s)
        {
            while ((charcount < s.Length) && IsDelimiter(s[charcount]))
            {
                charcount++;
            }
        }
            
        private bool ScrollThroughWord(string s)
        {
            bool wordfound = false;
            while ((charcount < s.Length) && !(IsDelimiter(s[charcount])))
            {
                charcount++;
                wordfound = true;
            }
            return wordfound;
        }
            
        private void CountWordsAndCharacters()
        {
            string s = richTextBox1.Text;
            charcount = 0;
            int wordcount = 0;
            while (charcount < s.Length)
            {
                ScrollThroughDelims(s);
                if (ScrollThroughWord(s))
                {
                    wordcount++;
                }
            }
            MessageBox.Show("Number of words: " + wordcount + " Characters: " + charcount);
        }

        private void wordCountToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            CountWordsAndCharacters();
        }

        private void randomizeFontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Add font randomizer here
        }
    }
}
