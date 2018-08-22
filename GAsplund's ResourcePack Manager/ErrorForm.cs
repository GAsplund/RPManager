using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAspsRPmngr
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string error, string stacktrace, string exceptiontype)
        {
            InitializeComponent();
            ExceptionLabel.Text = exceptiontype;
            string FullInfo = "---------- An exception was thrown: ----------@" + exceptiontype + "@@---------- Error: ----------@" + error +"@@---------- Stacktrace: ----------@"+ stacktrace;
            FullInfo = FullInfo.Replace("@", System.Environment.NewLine);
            ExceptionInfoTextBox.Text = FullInfo;
            this.ActiveControl = QuitButton;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
