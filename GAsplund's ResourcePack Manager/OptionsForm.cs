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
            ThemeChooserComboBox.SelectedIndex = GAspsRPmngr.Properties.Settings.Default.BackgroundTheme;
            EnableDebugCheckBox.Checked = GAspsRPmngr.Properties.Settings.Default.EnableDebug;

            this.ActiveControl = OKButton;
        }

        private void useCustomSourceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSourceRadioButton.Checked)
            { customSourceTextBox.Enabled = true; }
            else
            { customSourceTextBox.Enabled = false; }
        }

        private void ApplySettings() {
            if (customSourceTextBox.Enabled && GAspsRPmngr.Properties.Settings.Default.SourceSelection == 2)
            {
                GAspsRPmngr.Properties.Settings.Default.CustomSource = customSourceTextBox.Text;

            }
            if (CustomSourceRadioButton.Checked) { GAspsRPmngr.Properties.Settings.Default.SourceSelection = 2; }
            else if (OfficialVanillaRadioButton.Checked) { GAspsRPmngr.Properties.Settings.Default.SourceSelection = 1; }
            else if (OfficialWynnRadioButton.Checked) { GAspsRPmngr.Properties.Settings.Default.SourceSelection = 0; }
            var main = Application.OpenForms.OfType<ManagerForm>().First();
            GAspsRPmngr.Properties.Settings.Default.EnableDebug = EnableDebugCheckBox.Enabled;
            GAspsRPmngr.Properties.Settings.Default.BackgroundTheme = ThemeChooserComboBox.Items.IndexOf(ThemeChooserComboBox.SelectedItem.ToString());
            GAspsRPmngr.Properties.Settings.Default.Save();
            GAspsRPmngr.Properties.Settings.Default.Upgrade();
            main.updateWebList();
            updateThemes();

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Close();
        }

        private void updateThemes()
        {
            var main = Application.OpenForms.OfType<ManagerForm>().First();
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 0) { main.BackgroundImage = null; setAllLabelsColor(Color.Black); }
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 1) { main.BackgroundImage = GAspsRPmngr.Properties.Resources.wynn_dirt; setAllLabelsColor(Color.White); }
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 2) { main.BackgroundImage = GAspsRPmngr.Properties.Resources.dirt; setAllLabelsColor(Color.White); }
        }

        private void setAllLabelsColor(Color color)
        {
            var main = Application.OpenForms.OfType<ManagerForm>().First();
            main.currentPackLabel.ForeColor = color;
            main.creatorLabel.ForeColor = color;
            main.packVersionLabel.ForeColor = color;
            main.packCompatibilityLabel.ForeColor = color;
            main.ResolutionsLabel.ForeColor = color;
            main.packStatusLabel.ForeColor = color;
            main.selectPackLabel.ForeColor = color;
            main.PackEditionLabel.ForeColor = color;
            main.SettingsLabel.ForeColor = color;
        }

        public static long GetFileSizeSumFromDirectory(string searchDirectory)
        {
            var files = Directory.EnumerateFiles(searchDirectory);

            // get the sizeof all files in the current directory
            var currentSize = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();

            var directories = Directory.EnumerateDirectories(searchDirectory);

            // get the size of all files in all subdirectories
            var subDirSize = (from directory in directories select GetFileSizeSumFromDirectory(directory)).Sum();

            return currentSize + subDirSize;
        }

        private void UpdateCacheSize()
        {
            CacheSizeLabel.Text = "Size: " + GetFileSizeSumFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepack_manager\\localcache") / 1024 + " kilobytes";
        }

        private void ApplyButton_Click(object sender, EventArgs e) => ApplySettings();

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void OfficialWynnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSourceRadioButton.Checked)
            { customSourceTextBox.Enabled = true; }
            else
            { customSourceTextBox.Enabled = false;}
        }

        private void OfficialVanillaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSourceRadioButton.Checked)
            { customSourceTextBox.Enabled = true; }
            else
            { customSourceTextBox.Enabled = false;}
        }

        private void CustomSourceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomSourceRadioButton.Checked)
            { customSourceTextBox.Enabled = true; }
            else
            { customSourceTextBox.Enabled = false;}
        }

        private void ThemeChooserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            UpdateCacheSize();
        }

        private void CleanCacheButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This program uses the pack cache to check for updates. Every already downloaded pack will need to be re-downloaded.\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepack_manager\\localcache");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                UpdateCacheSize();
            }
        }
    }
}
