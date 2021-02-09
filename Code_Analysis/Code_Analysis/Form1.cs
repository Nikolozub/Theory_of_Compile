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

namespace Code_Analysis
{
    public partial class Form1 : Form
    {
        string currentFileName;
        string windowsTitle;

        public Form1()
        {
            InitializeComponent();
            currentFileName = "";
            windowsTitle = "Анализатор кода";
            this.Text = windowsTitle;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editRichTextBox.Redo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editRichTextBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editRichTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editRichTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editRichTextBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editRichTextBox.SelectAll();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            editRichTextBox.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            editRichTextBox.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            editRichTextBox.Paste();
        }

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            editRichTextBox.Undo();
        }

        private void redoToolStripButton_Click(object sender, EventArgs e)
        {
            editRichTextBox.Redo();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openFile() 
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                try
                {
                    editRichTextBox.LoadFile(fileName, RichTextBoxStreamType.PlainText);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Не получилось открыть файл");
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveFileAs() 
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string newFileName = saveFileDialog1.FileName;
                try
                {
                    editRichTextBox.SaveFile(newFileName, RichTextBoxStreamType.PlainText);
                    currentFileName = newFileName;
                    this.Text = newFileName + windowsTitle;
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Не получилось сохранить файл");
                }
            }
        }

        private void saveFile() 
        {
            if (currentFileName != "")
            {
                try
                {
                    editRichTextBox.SaveFile(currentFileName, RichTextBoxStreamType.PlainText);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Не получилось сохранить файл");
                }
            }
            else 
            {
                saveFileAs();             
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileAs();
        }
    }
}
