using System;
using System.Windows.Forms;

namespace GmailDeleteUI
{
    public partial class Form1 : Form
    {
        private GmailHelper gmailHelper;
        public Form1()
        {
            InitializeComponent();
            gmailHelper = new GmailHelper();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string senderEmail = textBox1.Text;
            if (string.IsNullOrEmpty(senderEmail))
            {
                richTextBox1.AppendText("Please enter a valid email address.\n");
                return;
            }
            
            richTextBox1.AppendText($"Processing emails from: {senderEmail}...\n");

            try
            {
                string result = gmailHelper.TrashAllFromSender(senderEmail);
                richTextBox1.AppendText(result + "\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Error: {ex.Message}\n");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
