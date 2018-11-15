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

        private void wordCountToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            // add word count code here...
        }
    }
}
