using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Windows.Forms;
using GAsplund_s_WynnPack_Manager;
using GAspsRPmngr;
using System.Net;

namespace GAsplund_s_WynnPack_Manager
{
    public class Updating {

        public void updateWebList(ManagerForm _MainForm, PackMetadata Metadata)
        {
            if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 2) // Setting 2 = custom source
            {
                Metadata.Source = GAspsRPmngr.Properties.Settings.Default.CustomSource;
            }
            else if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 0) // Setting 0 = Wynn
            {
                Metadata.Source = "https://gasplund.github.io/downloads/packlist_wynn.json";  // Wynn packs JSON direct ("official" source)
            }
            else if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 1) // Setting 1 = Vanilla
            {
                Metadata.Source = "https://gasplund.github.io/downloads/packlist_vanilla.json";  // Vanilla packs JSON ("official" source)
            }

            TimeSpan timeoutTimespan = new TimeSpan(0, 0, 10);
            WebClient httpClient = new WebClient();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string clientResponse = httpClient.DownloadString(Metadata.Source);
                string updateListList = clientResponse;
                _MainForm.updateList(updateListList);
            }
            catch (System.ArgumentException e)
            {
                ErrorForm form3 = new ErrorForm("Your custom link is invalid or broken!", e.StackTrace, e.GetType().ToString());
                // Get your shit together yo
                form3.ShowDialog();
            }
            catch (Exception e)
            {
                ErrorForm form3 = new ErrorForm(e.Message, e.StackTrace, e.GetType().ToString());
                form3.ShowDialog();
            }
        }








        public void UpdateVisualAndPackData(ManagerForm Main, PackMetadata Pack)
        {
            try
            {
                //  
                if (Main.CurrentPackList != null)
                {
                    if (Main.packSelectionListBox.SelectedItem != null)
                    {
                        if (Main.pastSelectedItem != Main.packSelectionListBox.SelectedItem.ToString()) // If the same pack was selected again, why go through all this crap once more?
                        {
                            Main.PackSettingsCheckedListBox.Items.Clear(); // Clear the settings SelectedListBox
                            Main.packPreviewPictureBox.Image = GAspsRPmngr.Properties.Resources.blank; // Clear the pack preview Picture box.
                            Main.packStatusLabel.Text = "Pack Status: Loading...";

                            // some stuff

                            Main.CurrentSelectedItemNumber = Main.packSelectionListBox.Items.IndexOf(Main.packSelectionListBox.SelectedItem.ToString());
                            Main.CurrentSelectedItemNumber++;
                            Main.updateEditionsList(JsonConvert.SerializeObject((object)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["editions"]));

                            // Setting all the variables to their new value
                            if ((bool)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["external_source"])
                            {        // Retreive data from external JSON instead of from current JSON
                                Pack.Description =      (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["description"];
                                Pack.Image =            (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["image_preview"];
                                Pack.Resolutions =      (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["resolutions"];
                                Pack.Compatibility =    (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["compatibility"];
                                Pack.Compatibility =    (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["latest_version"];
                            }
                            else
                            { // Retreive data from current JSON instead of from external JSON
                                Pack.Description =      (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["description"];
                                Pack.Image =            (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["image_preview"];
                                Pack.Resolutions =      (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["resolutions"];
                                Pack.Compatibility =    (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["compatibility"];
                                Pack.Compatibility =    (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["latest_version"];
                            }

                            // Retreive data from current JSON that doesn't need to be changed and therefore not from external JSON

                            Pack.Name = (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["name"];
                            Pack.Creator = (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["creator"];
                            Pack.Resolutions = (string)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["resolutions"];

                            // Setting all the not label stuff to their new value

                            Main.packDescriptionTextBox.Text = Pack.Description;
                            Main.packPreviewPictureBox.ImageLocation = Pack.Image;
                            Main.PackEditionComboBox.Text = "";

                            // Setting all the labels to their new value

                            Main.packVersionLabel.Text = "Latest Version: " + Pack.Compatibility;
                            Main.packCompatibilityLabel.Text = "MC Versions: " + Pack.Compatibility;
                            Main.currentPackLabel.Text = Pack.Name;
                            Main.ResolutionsLabel.Text = "Resolution(s): " + Pack.Resolutions;
                            Main.creatorLabel.Text = "Created by " + Pack.Creator;

                            UpdateApplyButton(Main, Pack); // Essentially checking which buttons need to be enabled or disabled.
                        }
                    }

                }
                else //
                {
                    throw new System.ArgumentNullException("Pack List is null.");
                }

            }
            catch (Exception er)
            {
                ErrorForm form3 = new ErrorForm(er.Message, er.StackTrace, er.GetType().ToString());
                form3.ShowDialog();

            }
            if (Pack.HasOneEdition && Main.pastSelectedItem != Main.packSelectionListBox.SelectedItem.ToString() || Pack.HasNoEditions && Main.pastSelectedItem != Main.packSelectionListBox.SelectedItem.ToString())
            {
                Main.CurrentSelectedEditionNumber = 1;
                Main.PackSettingsCheckedListBox.Enabled = true;
                Main.updateSettingsList(JsonConvert.SerializeObject((object)Main.CurrentPackList[Main.CurrentSelectedItemNumber.ToString()]["settings"]));
            }
            // If the selected pack has no selectable editions, check here for settings
            Main.pastSelectedItem = Main.packSelectionListBox.SelectedItem.ToString(); // We just checked a new pack, no need to check it directly again
        }








        public void UpdateApplyButton(ManagerForm Main, PackMetadata Pack)
        {
            if (Main.PackEditionComboBox.SelectedIndex == -1 && Pack.HasNoEditions == false)
            // Disable all buttons if a new pack with editions is selected
            {
                Main.installOrUninstallPackButton.Enabled = false;
                Main.forceUpdatePackButton.Enabled = false;
                Main.uninstallPackButton.Enabled = false;
            }

            if (Pack.HasOneEdition)
            // If the selected pack has only one edition, the pack edition selection isn't needed and will be disabled and
            // the pack hash, file name and download for the first edition will be used. Simple enough.
            {
                Pack.FileName = (string)Main.CurrentEditionsList["1"]["file_name"];
                Pack.Download = (string)Main.CurrentEditionsList["1"]["download"];
                Pack.MD5 = (string)Main.CurrentEditionsList["1"]["md5"];
                //PackEditionLabel.Visible = false;
                Main.PackEditionComboBox.Enabled = false;
            }
            else if (Pack.HasNoEditions)
            // Self explanatory
            {
                //PackEditionLabel.Visible = false;
                Main.PackEditionComboBox.Enabled = false;
            }
            else
            // Just in case
            {
                //PackEditionLabel.Visible = true;
                Main.PackEditionComboBox.Enabled = true;
            }

            if (Main.PackEditionComboBox.SelectedItem == null && Pack.HasOneEdition == false) { Main.packStatusLabel.Text = "Pack Status: Select an edition!"; Main.installOrUninstallPackButton.Enabled = false; }
            else if (Main.PackEditionComboBox.SelectedItem != null || Pack.HasOneEdition == true)
            // Checking if pack has no edition edition selected or if nothing is selected, and will make pack status n/a if returned true.
            {
                if (FileManagement.CurrentPackIsInstalled(Pack.FileName))
                // Checking if the selected pack is installed
                {
                    Pack.IsInstalled = true;
                    if (FileManagement.CurrentPackIsOutdated(Pack.FileName, Pack.MD5))
                    // Checking if the selected pack is outdated or damaged/corrupt
                    {
                        Pack.IsOutdated = true;
                        Main.installOrUninstallPackButton.Enabled = true;
                        Main.uninstallPackButton.Enabled = true;
                        Main.forceUpdatePackButton.Enabled = true;
                        Main.installOrUninstallPackButton.Text = "Update Pack";
                        Main.packStatusLabel.Text = "Pack Status: Outdated or damaged";
                    }
                    else
                    // If it isn't outdated, it's installed and working fine
                    {
                        Pack.IsInstalled = true;
                        Pack.IsOutdated = false;
                        Main.installOrUninstallPackButton.Enabled = false;
                        Main.uninstallPackButton.Enabled = true;
                        Main.forceUpdatePackButton.Enabled = true;
                        Main.installOrUninstallPackButton.Text = "Install Pack";
                        Main.packStatusLabel.Text = "Pack Status: Installed";
                    }
                }
                else
                // CurrentPackIsInstalled returned false, therefore it's is not installed
                {
                    Pack.IsInstalled = false;
                    Pack.IsOutdated = false;
                    Main.installOrUninstallPackButton.Enabled = true;
                    Main.uninstallPackButton.Enabled = false;
                    Main.forceUpdatePackButton.Enabled = false;
                    Main.installOrUninstallPackButton.Text = "Install Pack";
                    Main.packStatusLabel.Text = "Pack Status: Not Installed";
                }
            }
            Main.PackSettingsCheckedListBox.Enabled = !Pack.HasNoSettings && Pack.IsInstalled;
            Main.ApplySettingsButton.Enabled = !Pack.HasNoSettings && Pack.IsInstalled;
        }

    }
}
