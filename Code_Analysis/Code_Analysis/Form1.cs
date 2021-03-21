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
using System.Text.RegularExpressions;

namespace Code_Analysis
{
    public struct TextState
    {
        public string text;
        public int cursor_pos;
        public TextState(string text, int cursor_pos) 
        {
            this.text = text;
            this.cursor_pos = cursor_pos;
        }
    }

    public partial class Form1 : Form
    {
        string currentFileName;
        string windowsTitle;
        bool textSaved;
         

        RingStack<TextState> undo_stack = new RingStack<TextState>(100);
        RingStack<TextState> redo_stack = new RingStack<TextState>(100);
        string buff_text;

        public Form1()
        {
            InitializeComponent();
            windowsTitle = "Анализатор кода";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textSaved = true;
            newFile();
            buff_text = editRichTextBox.Text;
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
            editRichTextBox.SelectedText = "";
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
            undo_stack.push(new TextState(editRichTextBox.Text, editRichTextBox.SelectionStart));
            redo_stack.clear();
            editRichTextBox.Paste();
        }

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            editRichTextBox.Undo();
            //Undo();
        }

        private void redoToolStripButton_Click(object sender, EventArgs e)
        {
            editRichTextBox.Redo(); 
            //Redo();
        }

        private void newFile() 
        {
            if (!textSaved)
            {
                var result = MessageBox.Show("Сохранить файл " + currentFileName + "?", "Сохранение",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveFile();
                }
            }
            editRichTextBox.Clear();
            currentFileName = "";
            Text = windowsTitle;
            textSaved = false;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void openFile() 
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!textSaved)
                {
                    var result = MessageBox.Show("Сохранить файл " + currentFileName + "?", "Сохранение",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        saveFile();
                    }
                }

                string openFileName = openFileDialog1.FileName;
                try
                {
                    editRichTextBox.LoadFile(openFileName, RichTextBoxStreamType.PlainText);
                    textSaved = true;
                    currentFileName = openFileName;
                    this.Text = openFileName + " - " + windowsTitle;
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
                    textSaved = true;
                    currentFileName = newFileName;
                    this.Text = newFileName + " - " + windowsTitle;
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Не получилось сохранить файл");
                }
            }
        }

        private void saveFile() 
        {    

            if (textSaved) return;

            if (currentFileName != "")
            {
                try
                {
                    editRichTextBox.SaveFile(currentFileName, RichTextBoxStreamType.PlainText);
                    textSaved = true;
                    this.Text = currentFileName + " - " + windowsTitle;
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

        private void Undo() 
        {
            if (!undo_stack.isempty())
            {
                redo_stack.push(new TextState(editRichTextBox.Text, editRichTextBox.SelectionStart));
                TextState s = undo_stack.pop();
                //s = undo_stack.pop();
                //MessageBox.Show(s.text);
                editRichTextBox.Text = s.text;
                editRichTextBox.SelectionStart = s.cursor_pos;
                buff_text = editRichTextBox.Text;
            }
        }

        private void Redo() 
        {
            if (!redo_stack.isempty())
            {
                 undo_stack.push(new TextState(editRichTextBox.Text, editRichTextBox.SelectionStart));
                 TextState s = redo_stack.pop();
                 editRichTextBox.Text = s.text;
                 editRichTextBox.SelectionStart = s.cursor_pos;
                 buff_text = editRichTextBox.Text;
            }
        }

        // Изменение текста
        private void editRichTextBox_TextChanged(object sender, EventArgs e)
        {
            this.textSaved = false;
            this.Text = currentFileName + "* - " + windowsTitle;

            // сохранение состояния
            undo_stack.push(new TextState(buff_text, editRichTextBox.SelectionStart));
            redo_stack.clear();
            buff_text = editRichTextBox.Text;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void createToolStripButton_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!textSaved) 
            {
                var result = MessageBox.Show("Сохранить файл " + currentFileName + "?", "Сохранение",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveFile();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void runHelp() 
        {
            string curDir = Directory.GetCurrentDirectory();
            HelpForm helpForm = new HelpForm("file:///" + curDir + "/Help/html/help.html");
            helpForm.Show();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            runHelp();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение: блокнот\nГруппа: АВТ-813\nАвторы: Николай Самсонов\n\tЛысак Кирилл");
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            runHelp();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveFileAs();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            editRichTextBox.SelectedText = "";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            editRichTextBox.Text = "";
        }

        private void runToolStripButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Clear();
            resultRichTextBox.Text = "Лабораторная 2 (Регулярные выражения)\n";
            string log = RegularExp.printCards(editRichTextBox.Text);
            resultRichTextBox.Text += log;

            resultRichTextBox.Text += "\nЛабораторная 3 (Конечный автомат)\n";

            string chain = editRichTextBox.Text;
            List<string> valid_chains = StateMachine.validChains(chain, StateMachine.transFunction, "A1", "K");

            foreach (string ch in valid_chains)
            {
                resultRichTextBox.Text += ch + " (" + RegularExp.typeCard(ch) + ")\n";
            }
        }

        private void editRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void editRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*ndo_stack.push(new TextState(editRichTextBox.Text, editRichTextBox.SelectionStart));
            redo_stack.clear();*/
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void resultRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
 
}

