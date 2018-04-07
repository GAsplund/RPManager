using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using GAspsRPmngr;

namespace GAsplund_s_WynnPack_Manager
{
    public partial class ManagerForm : Form
    {
        public dynamic currentPackList;
        public dynamic currentEditionsList;
        public dynamic currentSettings;
        int currentSelectedItemNumber;
        int currentSelectedEditionNumber;
        int settingsCount;
        bool packIsInstalled;
        bool packIsOutdated;
        bool packHasOneEdition;
        bool packHasNoEditions;
        bool packHasNoSettings;
        bool ErrorOccurredWhileTryingToApplySettingDisabled;
        string packCreator;
        string packDescription;
        string packImage;
        string packVersion;
        string packName;
        string packFileName;
        string packMD5;
        string packResolutions;
        string packDownload;
        string pastSelectedItem;
        string pastSelectedEdition;
        string packSource;
        string packCompatibility;
        dynamic SettingsInfo;
        Exception ErrorOutsideOfCatch;
        JObject SetjObj;
        private delegate void EnableDelegate(string enable);


        public ManagerForm()
        {
            InitializeComponent();
            updateWebList();
            updateThemes();
        }
        private Updating formm;
        public ManagerForm(Updating f)
        {
            this.formm = f;
        }
        private void fetchPacksButton_Click(object sender, EventArgs e)
        {
            updateWebList();
            updateThemes();
        }

        public void addItemsToResourcePackList(string item)
        { packSelectionListBox.Items.Add(item); }

        private void updatingBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void packSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //  
                if (currentPackList != null) {
                    if (packSelectionListBox.SelectedItem != null)
                    {
                        if (pastSelectedItem != packSelectionListBox.SelectedItem.ToString()) // If the same pack was selected again, why go through all this crap once more?
                        {
                            PackSettingsCheckedListBox.Items.Clear(); // Clear the settings SelectedListBox
                            packPreviewPictureBox.Image = GAspsRPmngr.Properties.Resources.blank; // Clear the pack preview Picture box.
                            packStatusLabel.Text = "Pack Status: Loading...";

                            // some stuff

                            currentSelectedItemNumber = packSelectionListBox.Items.IndexOf(packSelectionListBox.SelectedItem.ToString());
                            currentSelectedItemNumber++;
                            updateEditionsList(JsonConvert.SerializeObject((object)currentPackList[currentSelectedItemNumber.ToString()]["editions"]));

                            // Setting all the variables to their new value
                            if ((bool)currentPackList[currentSelectedItemNumber.ToString()]["external_source"])
                            {        // Retreive data from external JSON instead of from current JSON
                                packDescription =   (string)currentPackList[currentSelectedItemNumber.ToString()]["description"];
                                packImage =         (string)currentPackList[currentSelectedItemNumber.ToString()]["image_preview"];
                                packResolutions =   (string)currentPackList[currentSelectedItemNumber.ToString()]["resolutions"];
                                packCompatibility = (string)currentPackList[currentSelectedItemNumber.ToString()]["compatibility"];
                                packVersion =       (string)currentPackList[currentSelectedItemNumber.ToString()]["latest_version"];
                            } else { // Retreive data from current JSON instead of from external JSON
                                packDescription =   (string)currentPackList[currentSelectedItemNumber.ToString()]["description"];
                                packImage =         (string)currentPackList[currentSelectedItemNumber.ToString()]["image_preview"];
                                packResolutions =   (string)currentPackList[currentSelectedItemNumber.ToString()]["resolutions"];
                                packCompatibility = (string)currentPackList[currentSelectedItemNumber.ToString()]["compatibility"];
                                packVersion =       (string)currentPackList[currentSelectedItemNumber.ToString()]["latest_version"];
                            }

                            // Retreive data from current JSON that doesn't need to be changed and therefore not from external JSON

                            packName =          (string)currentPackList[currentSelectedItemNumber.ToString()]["name"];
                            packCreator =       (string)currentPackList[currentSelectedItemNumber.ToString()]["creator"];
                            packResolutions =   (string)currentPackList[currentSelectedItemNumber.ToString()]["resolutions"];

                            // Setting all the not label stuff to their new value

                            packDescriptionTextBox.Text = packDescription;
                            packPreviewPictureBox.ImageLocation = packImage;
                            PackEditionComboBox.Text = "";

                            // Setting all the labels to their new value

                            packVersionLabel.Text =       "Latest Version: " +  packVersion;
                            packCompatibilityLabel.Text = "MC Versions: " +     packCompatibility;
                            currentPackLabel.Text =                             packName;
                            ResolutionsLabel.Text =       "Resolution(s): " +   packResolutions;
                            creatorLabel.Text =           "Created by " +       packCreator;

                            setApplyButton(); // Essentially checking which buttons need to be enabled or disabled.
                        }
                    }

                }
                else //
                {
                    throw new System.ArgumentNullException("Pack List is null.");
                }

            } catch (Exception er)
            {
                ErrorForm form3 = new ErrorForm(er.Message,er.StackTrace, e.GetType().ToString());
                form3.ShowDialog();

            }
            if (packHasOneEdition && pastSelectedItem != packSelectionListBox.SelectedItem.ToString() || packHasNoEditions && pastSelectedItem != packSelectionListBox.SelectedItem.ToString())
                {
                    currentSelectedEditionNumber = 1;
                    PackSettingsCheckedListBox.Enabled = true;
                    updateSettingsList(JsonConvert.SerializeObject((object)currentPackList[currentSelectedItemNumber.ToString()]["settings"]));
                }
            // If the selected pack has no selectable editions, check here for settings
            pastSelectedItem = packSelectionListBox.SelectedItem.ToString(); // We just checked a new pack, no need to check it directly again
        }
    

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // Me trying to play around with scaling (might happen sometime when I care more)

            //this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); 
            //this.MaximizeBox = false;
            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowOnly;
            FileManagement.CheckForProgramData();
        }

        private void ManagerForm_Resize(object sender, EventArgs e)
        {

        }

            private void currentPackLabel_Click(object sender, EventArgs e)
        {
            // Why is this here?
        }

        public string GetExternalSource(string source)
        {
            WebClient httpClient = new WebClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string clientResponse = httpClient.DownloadString(source);
            return clientResponse;
        }


        public void updateWebList()
        {
            if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 2) // Setting 2 = custom source
            {
                packSource = GAspsRPmngr.Properties.Settings.Default.CustomSource;
            } else if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 0) // Setting 0 = Wynn
            {
                packSource = "https://gasplund.github.io/downloads/packlist_wynn.json";  // Wynn packs JSON direct ("official" source)
            }
            else if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 1) // Setting 1 = Vanilla
            {
                packSource = "https://gasplund.github.io/downloads/packlist_vanilla.json";  // Vanilla packs JSON ("official" source)
            }

            TimeSpan timeoutTimespan = new TimeSpan(0, 0, 10);
            WebClient httpClient = new WebClient();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string clientResponse = httpClient.DownloadString(packSource);
                string updateListList = clientResponse;
                updateList(updateListList);
            } catch (System.ArgumentException e)
            {
                ErrorForm form3 = new ErrorForm("Your custom link is invalid or broken!", e.StackTrace, e.GetType().ToString());
                // Get your shit together yo
                form3.ShowDialog();
            } catch (Exception e)
            {
                ErrorForm form3 = new ErrorForm(e.Message, e.StackTrace, e.GetType().ToString());
                form3.ShowDialog();
            }
        }

        public void updateList(string list)
        // Updating the pack list from the downloaded JSON
        {
            packSelectionListBox.Items.Clear();
            JObject jObj = (JObject)JsonConvert.DeserializeObject(list);
            dynamic info = JObject.Parse(list);
            currentPackList = info;
            int objCount = jObj.Count;
            for (int i = 1; i <= objCount; i++)
            {
                JObject packRoot = (JObject)info[i.ToString()];
                Console.WriteLine("External source is " + (bool)info[i.ToString()]["external_source"]);
                if ((bool)info[i.ToString()]["external_source"]) {
                    string externalPackRoot = GetExternalSource((string)info[i.ToString()]["external_link"]); 
                    packRoot.Merge(JObject.Parse(externalPackRoot));
                    info[i.ToString()]["external_source"] = false;
                }
            }

            for (int i = 1; i <= objCount; i++)
            {
                string packTitle = (string)info[i.ToString()]["name"];
                packSelectionListBox.Items.Add(packTitle.ToString());
                Console.WriteLine("Added Pack \"" + packTitle + "\" for i = " + i);
            }

        }

        public void updateThemes()
        {
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 0) { this.BackgroundImage = null; setAllLabelsColor(Color.Black); }
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 1) { this.BackgroundImage = GAspsRPmngr.Properties.Resources.wynn_dirt; setAllLabelsColor(Color.White); }
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 2) { this.BackgroundImage = GAspsRPmngr.Properties.Resources.dirt; setAllLabelsColor(Color.White); }
        }


        public void updateEditionsList(string list)
        // Could be more compact, just cba. Otherwise this shit is pretty self explanatory.
        {
            PackEditionComboBox.Items.Clear();
            JObject jObj = (JObject)JsonConvert.DeserializeObject(list);
            dynamic info = JObject.Parse(list);
            currentEditionsList = info;
            int objCount = jObj.Count;
            if (objCount == 0) { packHasNoEditions = true; } else if (objCount == 1) { packHasOneEdition = true; } else { packHasNoEditions = false; packHasOneEdition = false; }
            for (int i = 1; i <= objCount; i++)
            {
                string EditionName = (string)info[i.ToString()]["name"];
                PackEditionComboBox.Items.Add(EditionName.ToString());
                Console.WriteLine("Added Edition \"" + EditionName + "\" for i = " + i);
            }

        }

        public void updateSettingsList(string settings)
        {
            PackSettingsCheckedListBox.Items.Clear();
                if (settings != "null")
                {
                    SetjObj = (JObject)JsonConvert.DeserializeObject(settings);
                    SettingsInfo = JObject.Parse(settings);
                    currentSettings = SettingsInfo;
                    settingsCount = SetjObj.Count;
                } else
                {
                    settingsCount = 0;
                    packHasNoSettings = true;
                }
            for (int i = 1; i <= settingsCount; i++)
                {
                    JArray settingEditions = (JArray)currentSettings[i.ToString()]["edition"];
                    
                    if ( DoesThisJArrayContain(settingEditions, currentSelectedEditionNumber) )
                    {
                        string EditionName = (string)SettingsInfo[i.ToString()]["name"];
                        PackSettingsCheckedListBox.Items.Add(EditionName.ToString());
                        packHasNoSettings = false;
                        Console.WriteLine("Added Setting \"" + EditionName + "\" for i = " + i);
                    }
                }
            PackSettingsCheckedListBox.Enabled = !packHasNoSettings && packIsInstalled;
            ApplySettingsButton.Enabled = !packHasNoSettings && packIsInstalled;
                
        }

        private bool DoesThisJArrayContain(JArray Array, dynamic valueToMatch)
        {
            for (int i = 0; i <= Array.Count; i++)
            {
                Console.WriteLine("JArray[i] is " + (int)Array[i] + " and i is " + i + " with value to match " + valueToMatch);
                if ((int)Array[i] == valueToMatch) { Console.WriteLine("I returned true"); return true; } else 
                    if (i+1 == Array.Count) { Console.WriteLine("I returned false"); return false; }
            }
            return false;
        }


        private int LookForSetting(string SettingName)
        {
            int Success = 1;
            for (int i = 1; i <= (settingsCount); i++)
            {
                if((string)SettingsInfo[i.ToString()]["name"] == SettingName) { Success = i; return i; }
            }
            return Success;
        }


        private void setApplyButton()
        {
            if (PackEditionComboBox.SelectedIndex == -1 && packHasNoEditions == false) 
            // Disable all buttons if a new pack with editions is selected
            {
                installOrUninstallPackButton.Enabled = false;
                forceUpdatePackButton.Enabled = false;
                uninstallPackButton.Enabled = false;
            }

            if (packHasOneEdition)
            // If the selected pack has only one edition, the pack edition selection isn't needed and will be disabled and
            // the pack hash, file name and download for the first edition will be used. Simple enough.
            {
                packFileName = (string)currentEditionsList["1"]["file_name"];
                packDownload = (string)currentEditionsList["1"]["download"];
                packMD5 = (string)currentEditionsList["1"]["md5"];
                //PackEditionLabel.Visible = false;
                PackEditionComboBox.Enabled = false;
            }
            else if (packHasNoEditions)
            // Self explanatory
            {
                //PackEditionLabel.Visible = false;
                PackEditionComboBox.Enabled = false;
            }
            else
            // Just in case
            {
                //PackEditionLabel.Visible = true;
                PackEditionComboBox.Enabled = true;
            }

            if (PackEditionComboBox.SelectedItem == null && packHasOneEdition == false) { packStatusLabel.Text = "Pack Status: Select an edition!"; installOrUninstallPackButton.Enabled = false; } else if (PackEditionComboBox.SelectedItem != null || packHasOneEdition == true)
            // Checking if pack has no edition edition selected or if nothing is selected, and will make pack status n/a if returned true.
            {
                if (FileManagement.CurrentPackIsInstalled(currentSelectedItemNumber, packFileName))
                // Checking if the selected pack is installed
                {
                    packIsInstalled = true;
                    if (FileManagement.CurrentPackIsOutdated(currentSelectedItemNumber, packFileName, packMD5))
                    // Checking if the selected pack is outdated or damaged/corrupt
                    {
                        packIsOutdated = true;
                        installOrUninstallPackButton.Enabled = true;
                        uninstallPackButton.Enabled = true;
                        forceUpdatePackButton.Enabled = true;
                        installOrUninstallPackButton.Text = "Update Pack";
                        packStatusLabel.Text = "Pack Status: Outdated or damaged";
                    }
                    else
                    // If it isn't outdated, it's installed and working fine
                    {
                        packIsInstalled = true;
                        packIsOutdated = false;
                        installOrUninstallPackButton.Enabled = false;
                        uninstallPackButton.Enabled = true;
                        forceUpdatePackButton.Enabled = true;
                        installOrUninstallPackButton.Text = "Install Pack";
                        packStatusLabel.Text = "Pack Status: Installed";
                    }
                }
                else
                // CurrentPackIsInstalled returned false, therefore it's is not installed
                {
                    packIsInstalled = false;
                    packIsOutdated = false;
                    installOrUninstallPackButton.Enabled = true;
                    uninstallPackButton.Enabled = false;
                    forceUpdatePackButton.Enabled = false;
                    installOrUninstallPackButton.Text = "Install Pack";
                    packStatusLabel.Text = "Pack Status: Not Installed";
                }
            }
            PackSettingsCheckedListBox.Enabled = !packHasNoSettings && packIsInstalled;
            ApplySettingsButton.Enabled = !packHasNoSettings && packIsInstalled;
        }

        private async void installOrUninstallPackButton_Click(object sender, EventArgs e)
        {
            installOrUninstallPackButton.Enabled = false;
            if (packIsInstalled)
            {
                if (packIsOutdated)
                {
                    packStatusLabel.Text = "Pack Status: Downloading...";
                    await FileManagement.downloadPack(packDownload, packFileName);
                }
            }
            else
            {
                packStatusLabel.Text = "Pack Status: Downloading...";
                await FileManagement.downloadPack(packDownload, packFileName);
            }

            setApplyButton();
        }

        private void uninstallPackButton_Click(object sender, EventArgs e)
        {
            uninstallPackButton.Enabled = false;
            FileManagement.removePack(packFileName);
            setApplyButton();
        }

        private void setAllLabelsColor(Color color)
        {
            currentPackLabel.ForeColor = color;
            creatorLabel.ForeColor = color;
            packVersionLabel.ForeColor = color;
            packCompatibilityLabel.ForeColor = color;
            ResolutionsLabel.ForeColor = color;
            packStatusLabel.ForeColor = color;
            selectPackLabel.ForeColor = color;
            PackEditionLabel.ForeColor = color;
            SettingsLabel.ForeColor = color;
        }


        private async void forceUpdatePackButton_Click(object sender, EventArgs e)
        {
            packStatusLabel.Text = "Pack Status: Downloading...";
            await FileManagement.downloadPack(packDownload, packFileName);
            setApplyButton();
        }

        private void PackEditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            packStatusLabel.Text = "Pack Status: Checking...";
            if (pastSelectedEdition != PackEditionComboBox.SelectedItem.ToString()) {
                currentSelectedEditionNumber = PackEditionComboBox.Items.IndexOf(PackEditionComboBox.SelectedItem.ToString());
                currentSelectedEditionNumber++;
                packFileName = (string)currentEditionsList[currentSelectedEditionNumber.ToString()]["file_name"];
                packMD5 = (string)currentEditionsList[currentSelectedEditionNumber.ToString()]["md5"];
                packDownload = (string)currentEditionsList[currentSelectedEditionNumber.ToString()]["download"];

                setApplyButton();
                
            }
            pastSelectedEdition = PackEditionComboBox.SelectedItem.ToString();

            if (!packHasOneEdition) { updateSettingsList(JsonConvert.SerializeObject((object)currentPackList[currentSelectedItemNumber.ToString()]["settings"]));

            /* It threw an error. So what? It just means that settings are absent. No biggie.
                PackSettingsCheckedListBox.Enabled = false;
                ApplySettingsButton.Enabled = false;*/
            }
            // If pack has editions, check here for settings

            try
            {
                if ((string)currentEditionsList[currentSelectedEditionNumber.ToString()]["edition_preview"] != null)
                { packImage = (string)currentEditionsList[currentSelectedEditionNumber.ToString()]["edition_preview"]; packPreviewPictureBox.ImageLocation = packImage; }
            }
            catch { }
        }

        private void packPreviewPictureBox_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start(packImage); } catch { MessageBox.Show("Please select a pack first.", "Warning"); }
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm form2 = new OptionsForm();
            form2.ShowDialog();
        }

        private void PackSettingsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ApplySettingsButton_Click(object sender, EventArgs e)
        {
            string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepacks\\" + packFileName + "\\";
            string SettingCachePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepack_manager\\localsettings\\";
            string s = "Successfully applied settings: ";
            for (int i = 0; i <= (PackSettingsCheckedListBox.Items.Count - 1); i++)
            {
                if (PackSettingsCheckedListBox.GetItemChecked(i))
                {
                    s = s + "\n" + PackSettingsCheckedListBox.Items[i].ToString() + " as true";
                    int realsetting = LookForSetting(PackSettingsCheckedListBox.Items[i].ToString());
                    Console.WriteLine(currentSettings[realsetting.ToString()]["settingpaths"]);
                    JArray SettingsAmount1 = currentSettings[realsetting.ToString()]["settingpaths"];
                    int SettingsAmount = SettingsAmount1.Count();
                    for (int f = 0; f <= (SettingsAmount - 1); f++)
                    {
                        string settingPath = currentSettings[realsetting.ToString()]["settingpaths"][f];
                        Console.WriteLine(settingPath);
                        try
                        {
                            if (File.Exists(appDataLocation + settingPath + ".disabled"))
                            {   // If the file doesnt exist already, do copy it from settings cache.
                                string newPathForFile = Path.GetFileName(appDataLocation + settingPath);
                                File.Move(appDataLocation + settingPath + ".disabled", appDataLocation + settingPath);
                                // Copy the files for settings from .minecraft\resourcepack_manager\localsettings\(SELECTED PACK NAME)\(SELECTED EDITION NAME)\(SELECTED SETTING NAME)\(SETTING FILE NAME)
                                // ... to .minecraft\resourcepacks\(SELECTED PACK NAME)\(SETTING PATH NAME)\(SETTING FILE NAME)
                            }
                        }
                        catch (Exception er)
                        {
                            s = s.Replace("\n" + PackSettingsCheckedListBox.Items[i].ToString() + " as true", "\n" + PackSettingsCheckedListBox.Items[i].ToString() + " not applied (error occurred)");
                            ErrorForm form3 = new ErrorForm(er.Message, er.StackTrace, e.GetType().ToString());
                            form3.ShowDialog();
                        }
                    }
                } else if (!PackSettingsCheckedListBox.GetItemChecked(i))
                {
                    s = s + "\n" + PackSettingsCheckedListBox.Items[i].ToString() + " as false";
                    int realsetting = LookForSetting(PackSettingsCheckedListBox.Items[i].ToString());
                    Console.WriteLine(currentSettings[realsetting.ToString()]["settingpaths"]);
                    JArray SettingsAmount1 = currentSettings[realsetting.ToString()]["settingpaths"];
                    int SettingsAmount = SettingsAmount1.Count();
                    for(int f = 0; f <= (SettingsAmount-1); f++)
                    {
                        
                        string settingPath = currentSettings[realsetting.ToString()]["settingpaths"][f];

                        Console.WriteLine(settingPath);
                        try
                        {
                            if (!File.Exists(appDataLocation + settingPath + ".disabled"))
                            {
                                string newPathForFile = Path.GetFileName(appDataLocation + settingPath);
                                File.Move(appDataLocation + settingPath, appDataLocation + settingPath + ".disabled");
                                //File.Delete(appDataLocation + settingPath);
                                // Copy it to settings as backup and delete where it was before
                            }
                        }
                        catch (FileNotFoundException err)
                        {
                            ErrorOccurredWhileTryingToApplySettingDisabled = true;
                            ErrorOutsideOfCatch = err;
                        }
                        catch (Exception er)
                        {
                            ErrorForm form3 = new ErrorForm(er.Message, er.StackTrace, er.GetType().ToString());
                            form3.ShowDialog();
                            s = s.Replace("\n" + PackSettingsCheckedListBox.Items[i].ToString() + " as false","\n" + PackSettingsCheckedListBox.Items[i].ToString() + " was not applied (error occurred)");
                        }
                    }
                    if (ErrorOccurredWhileTryingToApplySettingDisabled)
                    {
                        ErrorForm form3 = new ErrorForm(ErrorOutsideOfCatch.Message + " PLEASE NOTE: There may have been more errors that have followed.", ErrorOutsideOfCatch.StackTrace, ErrorOutsideOfCatch.GetType().ToString());
                        form3.ShowDialog();
                    }

                }
            }
            if (GAspsRPmngr.Properties.Settings.Default.EnableDebug) { MessageBox.Show(s); }
            Console.WriteLine(s);
        }
    }


}

