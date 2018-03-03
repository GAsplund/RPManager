using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAsplund_s_WynnPack_Manager
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

            CustomSourceRadioButton.Checked = GAspsRPmngr.Properties.Settings.Default.SourceSelection == 2;
            customSourceTextBox.Enabled = GAspsRPmngr.Properties.Settings.Default.SourceSelection == 2;
            OfficialVanillaRadioButton.Checked = GAspsRPmngr.Properties.Settings.Default.SourceSelection == 1;
            OfficialWynnRadioButton.Checked = GAspsRPmngr.Properties.Settings.Default.SourceSelection == 0;
            customSourceTextBox.Text = GAspsRPmngr.Properties.Settings.Default.CustomSource;
        }

        private void useCustomSourceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSourceRadioButton.Checked)
            {customSourceTextBox.Enabled = true; }
            else
            { customSourceTextBox.Enabled = false; customSourceTextBox.Clear(); }
        }

        private void ApplySettings(){
            if (customSourceTextBox.Enabled && GAspsRPmngr.Properties.Settings.Default.SourceSelection == 2)
            {
                GAspsRPmngr.Properties.Settings.Default.CustomSource = customSourceTextBox.Text;
            }
            if (CustomSourceRadioButton.Checked) { GAspsRPmngr.Properties.Settings.Default.SourceSelection = 2; }
            else if (OfficialVanillaRadioButton.Checked) { GAspsRPmngr.Properties.Settings.Default.SourceSelection = 1; }
            else if (OfficialWynnRadioButton.Checked) { GAspsRPmngr.Properties.Settings.Default.SourceSelection = 0; }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OfficialWynnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSourceRadioButton.Checked)
            { customSourceTextBox.Enabled = true; }
            else
            { customSourceTextBox.Enabled = false; customSourceTextBox.Clear(); }
        }

        private void OfficialVanillaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSourceRadioButton.Checked)
            { customSourceTextBox.Enabled = true; }
            else
            { customSourceTextBox.Enabled = false; customSourceTextBox.Clear(); }
        }

        private void CustomSourceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSourceRadioButton.Checked)
            { customSourceTextBox.Enabled = true; }
            else
            { customSourceTextBox.Enabled = false; customSourceTextBox.Clear(); }
        }

        private void ThemeChooserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
