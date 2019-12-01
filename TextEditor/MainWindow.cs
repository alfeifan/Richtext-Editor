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

namespace TextEditor
{
    public partial class MainWindow : Form
    {
        string filename = null;

        public MainWindow()
        {
            InitializeComponent();
            richTextBox1.KeyUp += richTextBox1_KeyUp;
        }
        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                richTextBox1.SelectionIndent = 30;
            }
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox1.SelectionIndent = 0;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About window = new About();
            window.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                filename = openFile1.FileName;
                richTextBox1.LoadFile(openFile1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                filename = openFile1.FileName;
                richTextBox1.LoadFile(openFile1.FileName);
                
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file name from the saveFileDialog.
            if (filename != null)
            {
                richTextBox1.SaveFile(filename);
            }

            else if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into new file.
                richTextBox1.SaveFile(saveFile1.FileName);
                filename = saveFile1.FileName;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName);
                filename = saveFile1.FileName;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName);
                filename = saveFile1.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file name from the saveFileDialog.
            if (filename != null)
            {
                richTextBox1.SaveFile(filename);
            }

            else if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into new file.
                richTextBox1.SaveFile(saveFile1.FileName);
                filename = saveFile1.FileName;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            filename = null;
            richTextBox1.Clear();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filename = null;
            richTextBox1.Clear();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Font new1, old1;
            old1 = richTextBox1.SelectionFont;
            if (old1.Bold)
                new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Bold);

            richTextBox1.SelectionFont = new1;
            richTextBox1.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Font new1, old1;
            old1 = richTextBox1.SelectionFont;
            if (old1.Italic)
                new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Italic);

            richTextBox1.SelectionFont = new1;

            richTextBox1.Focus();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Font new1, old1;
            old1 = richTextBox1.SelectionFont;
            if (old1.Underline)
                new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Underline);

            richTextBox1.SelectionFont = new1;
            richTextBox1.Focus();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            catch (System.ArgumentNullException noText)
            {
                noText = null;
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            try
            {
                string xx = Clipboard.GetText();
                richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, xx);
            }
            catch (System.ArgumentNullException noText)
            {
                string xx = null;
            }

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = string.Empty;
            }
            catch (System.ArgumentNullException noText)
            {
                noText = null;
            }

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = string.Empty;
            }
            catch (System.ArgumentNullException noText)
            {
                noText = null;
            }

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            catch (System.ArgumentNullException noText)
            {
                noText = null;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string xx = Clipboard.GetText();
                richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, xx);
            }
            catch (System.ArgumentNullException noText)
            {
                string xx = null;
            }

        }

        private void fontBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize = Convert.ToSingle(((ToolStripComboBox)sender).Text);
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, fontSize);
        }

        private void fontStyle_Click(object sender, EventArgs e)
        {
            foreach(FontFamily font in FontFamily.Families)
            {
                fontStyle.Items.Add(font.Name.ToString());
            }
        }
        private void fontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string desiredFont = Convert.ToString(((ToolStripComboBox)sender).Text);
            Single fontSize = richTextBox1.SelectionFont.Size;
            FontStyle fontStyle = richTextBox1.SelectionFont.Style;

            richTextBox1.SelectionFont = new Font(desiredFont, fontSize , fontStyle);
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = true;
            richTextBox1.AcceptsTab = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != null)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save before exiting?", "Warning", MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    SaveFileDialog saveFile1 = new SaveFileDialog();

                    // Initialize the SaveFileDialog to specify the RTF extention for the file.
                    saveFile1.DefaultExt = "*.rtf";
                    saveFile1.Filter = "RTF Files|*.rtf";

                    // Determine whether the user selected a file name from the saveFileDialog.
                    if (filename != null)
                    {
                        richTextBox1.SaveFile(filename);
                        MessageBox.Show("Saved", "File Saved!", MessageBoxButtons.OK);
                        Application.Exit();
                    }

                    else if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                       saveFile1.FileName.Length > 0)
                    {
                        // Save the contents of the RichTextBox into new file.
                        richTextBox1.SaveFile(saveFile1.FileName);
                        filename = saveFile1.FileName;
                        MessageBox.Show("Saved", "File Saved!", MessageBoxButtons.OK);
                        Application.Exit();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }

            else
            {
                Application.Exit();
            }
        }
    }
}
