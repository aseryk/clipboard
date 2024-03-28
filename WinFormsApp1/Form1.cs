using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Add(textBoxInfo.Text);
            textBoxInfo.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxInfo.SelectedIndex != -1)
            {
                string originalText = listBoxInfo.SelectedItem.ToString();
                using (Form editForm = new Form())
                {
                    TextBox editTextBox = new TextBox { Text = originalText, Dock = DockStyle.Fill };
                    Button saveButton = new Button { Text = "Save", Dock = DockStyle.Bottom };
                    saveButton.Click += (s, args) =>
                    {
                        listBoxInfo.Items[listBoxInfo.SelectedIndex] = editTextBox.Text;
                        editForm.Close();
                    };
                    editForm.Controls.Add(editTextBox);
                    editForm.Controls.Add(saveButton);
                    editForm.ShowDialog();
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (listBoxInfo.SelectedIndex != -1)
            {
                Clipboard.SetText(listBoxInfo.SelectedItem.ToString());
            }
        }

        private void textBoxInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddInfo_Click(sender, e);
            }
        }
    }
}
